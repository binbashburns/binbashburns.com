using System.Text.Json;
using BadgeBox.Api.Models;

namespace BadgeBox.Api.Services;

public static class BadgeNormalizer
{
    public static IEnumerable<BadgeDto> Normalize(string credlyJson, DateTimeOffset now)
    {
        using var doc = JsonDocument.Parse(credlyJson);
        var root = doc.RootElement;

        // Figure out where the badge list lives:
        // 1) { "data": [...] }
        // 2) { "badges": [...] }
        // 3) [ ... ]  (array at top level)
        JsonElement badgesEl = root;
        if (root.ValueKind == JsonValueKind.Object)
        {
            if (root.TryGetProperty("data", out var d) && d.ValueKind == JsonValueKind.Array)
                badgesEl = d;
            else if (root.TryGetProperty("badges", out var b) && b.ValueKind == JsonValueKind.Array)
                badgesEl = b;
            else if (root.ValueKind != JsonValueKind.Array)
                throw new InvalidDataException($"Unrecognized Credly JSON: object without 'data'/'badges'. Keys: {string.Join(",", root.EnumerateObject().Select(p => p.Name))}");
        }
        else if (root.ValueKind != JsonValueKind.Array)
        {
            throw new InvalidDataException($"Unrecognized Credly JSON: root kind {root.ValueKind}");
        }

        foreach (var item in badgesEl.EnumerateArray())
            yield return MapBadge(item, now);
    }

    static BadgeDto MapBadge(JsonElement item, DateTimeOffset now)
    {
        // Defensive getters
        static string? S(JsonElement e, params string[] keys)
        {
            foreach (var k in keys)
                if (e.TryGetProperty(k, out var v) && v.ValueKind == JsonValueKind.String)
                    return v.GetString();
            return null;
        }

        static DateTimeOffset? D(JsonElement e, params string[] keys)
        {
            foreach (var k in keys)
                if (e.TryGetProperty(k, out var v) && v.ValueKind == JsonValueKind.String &&
                    DateTimeOffset.TryParse(v.GetString(), out var dt))
                    return dt;
            return null;
        }

        var id     = S(item, "id") ?? Guid.NewGuid().ToString("n");
        var tpl    = item.TryGetProperty("badge_template", out var t) && t.ValueKind == JsonValueKind.Object ? t : default;
        var name   = (tpl.ValueKind == JsonValueKind.Object ? S(tpl, "name") : null)
                     ?? S(item, "name") ?? "(unknown badge)";
        var desc   = (tpl.ValueKind == JsonValueKind.Object ? S(tpl, "description") : null)
                     ?? S(item, "description");

        // issuer: issuer.entities[*].entity.name  OR issuer.name
        string issuer = "(unknown issuer)";
        if (item.TryGetProperty("issuer", out var issuerEl) && issuerEl.ValueKind == JsonValueKind.Object)
        {
            if (issuerEl.TryGetProperty("entities", out var ents) && ents.ValueKind == JsonValueKind.Array)
                issuer = string.Join(", ", ents.EnumerateArray()
                    .Select(e => e.TryGetProperty("entity", out var ent) && ent.ValueKind == JsonValueKind.Object
                        ? S(ent, "name") : null)
                    .Where(n => !string.IsNullOrWhiteSpace(n))!);
            if (string.IsNullOrWhiteSpace(issuer))
                issuer = S(issuerEl, "name") ?? issuer;
        }

        var url     = S(item, "public_url") ?? $"https://www.credly.com/badges/{id}/public_url";
        var image   = S(item, "image_url") ?? S(tpl, "image_url") ?? S(item, "image") ?? "";
        var issued  = D(item, "issued_at", "issued_at_date", "issued_at_datetime");
        var expires = D(item, "expires_at", "expiry_at", "expiresAt", "expiration_date", "expirationDate");

        var expired = expires.HasValue && expires.Value <= now;
        int? daysLeft = expires.HasValue ? (int)Math.Ceiling((expires.Value - now).TotalDays) : null;

        // skills: badge_template.skills[*].name
        List<string>? skills = null;
        if (tpl.ValueKind == JsonValueKind.Object && tpl.TryGetProperty("skills", out var skillsEl) && skillsEl.ValueKind == JsonValueKind.Array)
            skills = skillsEl.EnumerateArray()
                .Select(s => s.ValueKind == JsonValueKind.Object ? S(s, "name") : null)
                .Where(n => !string.IsNullOrWhiteSpace(n))
                .Select(n => n!)
                .ToList();

        return new BadgeDto(
            Id: id,
            Name: name!,
            Issuer: issuer,
            IssuedAt: issued,
            ExpiresAt: expires,
            IsExpired: expired,
            DaysUntilExpiry: daysLeft,
            Url: url!,
            ImageUrl: image,
            Description: desc,
            Skills: skills ?? new List<string>()
        );
    }
}

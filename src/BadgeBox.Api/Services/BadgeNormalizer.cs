using System.Text.Json;
using BadgeBox.Api.Models;

namespace BadgeBox.Api.Services;

public static class BadgeNormalizer
{
    public static IEnumerable<BadgeDto> Normalize(string credlyJson, DateTimeOffset now)
    {
        using var doc = JsonDocument.Parse(credlyJson);
        var data = doc.RootElement.GetProperty("data");

        foreach (var item in data.EnumerateArray())
        {
            var id = item.GetProperty("id").GetString()!;
            var tpl = item.GetProperty("badge_template");
            var name = tpl.GetProperty("name").GetString()!;
            var desc = tpl.TryGetProperty("description", out var d) ? d.GetString() : null;

            var issuer = item.GetProperty("issuer").GetProperty("entities")
                .EnumerateArray()
                .Select(e => e.GetProperty("entity").GetProperty("name").GetString()!)
                .ToList();
            var issuerName = string.Join(", ", issuer);

            var url = item.GetProperty("public_url").GetString()!;
            var image = item.GetProperty("image_url").GetString()!;

            DateTimeOffset? issued = null;
            if (item.TryGetProperty("issued_at", out var issuedAt) &&
                issuedAt.ValueKind == JsonValueKind.String &&
                DateTimeOffset.TryParse(issuedAt.GetString(), out var issuedDt))
            {
                issued = issuedDt;
            }

            var (exp, expired, daysLeft) = ComputeValidity(item, now);

            var skills = tpl.TryGetProperty("skills", out var skillsEl)
                ? skillsEl.EnumerateArray().Select(s => s.GetProperty("name").GetString()!).ToList()
                : new List<string>();

            yield return new BadgeDto(id, name, issuerName, issued, exp, expired, daysLeft, url, image, desc, skills);
        }
    }

    public static (DateTimeOffset? ExpiresAt, bool IsExpired, int? DaysLeft) ComputeValidity(JsonElement item, DateTimeOffset now)
    {
        DateTimeOffset? exp = null;
        string[] candidates = ["expires_at","expiry_at","expiresAt","expiration_date","expirationDate"];
        foreach (var k in candidates)
        {
            if (item.TryGetProperty(k, out var v) &&
                v.ValueKind == JsonValueKind.String &&
                DateTimeOffset.TryParse(v.GetString(), out var dt))
            { exp = dt; break; }
        }

        var expired = exp.HasValue && exp.Value <= now;
        int? days = exp.HasValue ? (int)Math.Ceiling((exp.Value - now).TotalDays) : null;
        return (exp, expired, days);
    }
}

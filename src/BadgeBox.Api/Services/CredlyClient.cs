using System.Net.Http;

namespace BadgeBox.Api.Services;

public sealed class CredlyClient(HttpClient http) : ICredlyClient
{
    public async Task<string> GetBadgesRawAsync(string userId, CancellationToken ct = default)
    {
        // Public JSON endpoint for profile badges
        var url = $"https://www.credly.com/users/{userId}/badges.json";
        using var req = new HttpRequestMessage(HttpMethod.Get, url);
        req.Headers.TryAddWithoutValidation("Accept", "application/json");
        var res = await http.SendAsync(req, ct);
        res.EnsureSuccessStatusCode();
        return await res.Content.ReadAsStringAsync(ct);
    }
}

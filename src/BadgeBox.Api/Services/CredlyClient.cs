using System.Net.Http;
using System.Net.Http.Headers;

namespace BadgeBox.Api.Services;

public sealed class CredlyClient(HttpClient http) : ICredlyClient
{
    public async Task<string> GetBadgesRawAsync(string userId, CancellationToken ct = default)
    {
        var url = $"https://www.credly.com/users/{userId}/badges.json";
        using var req = new HttpRequestMessage(HttpMethod.Get, url);
        req.Headers.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        req.Headers.UserAgent.ParseAdd("BadgeBox/1.0 (+https://binbashburns.com)");

        var res = await http.SendAsync(req, ct);
        res.EnsureSuccessStatusCode();
        return await res.Content.ReadAsStringAsync(ct);
    }
}

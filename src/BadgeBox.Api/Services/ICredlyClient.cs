namespace BadgeBox.Api.Services;

public interface ICredlyClient
{
    Task<string> GetBadgesRawAsync(string userId, CancellationToken ct = default);
}

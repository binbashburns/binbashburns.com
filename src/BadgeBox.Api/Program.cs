using BadgeBox.Api.Models;
using BadgeBox.Api.Services;
using Microsoft.Extensions.Caching.Memory;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddMemoryCache();
builder.Services.AddHttpClient<ICredlyClient, CredlyClient>();
builder.Services.AddCors(p => p.AddDefaultPolicy(b => b.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod()));

var app = builder.Build();
app.UseSwagger().UseSwaggerUI();
app.UseCors();

app.MapGet("/health", () => Results.Ok(new { status = "ok" }));

app.MapGet("/api/badges", async (ICredlyClient credly, IMemoryCache cache, string userId) =>
{
    if (string.IsNullOrWhiteSpace(userId))
        return Results.BadRequest(new { error = "Missing userId." });

    var cacheKey = $"badges:{userId}";
    if (!cache.TryGetValue(cacheKey, out List<BadgeDto>? badges))
    {
        var raw = await credly.GetBadgesRawAsync(userId);
        badges = BadgeNormalizer.Normalize(raw, DateTimeOffset.UtcNow).ToList();
        cache.Set(cacheKey, badges, TimeSpan.FromMinutes(30));
    }
    return Results.Ok(badges);
});

app.MapGet("/api/status", async (ICredlyClient credly, string userId, int soonDays = 30) =>
{
    if (string.IsNullOrWhiteSpace(userId))
        return Results.BadRequest(new { error = "Missing userId." });

    var raw = await credly.GetBadgesRawAsync(userId);
    var badges = BadgeNormalizer.Normalize(raw, DateTimeOffset.UtcNow).ToList();
    var expired = badges.Where(b => b.IsExpired).Select(b => b.Id).ToList();
    var expSoon = badges.Where(b => !b.IsExpired && (b.DaysUntilExpiry ?? int.MaxValue) <= soonDays)
                        .Select(b => b.Id).ToList();

    return Results.Ok(new { total = badges.Count, expired = expired.Count, expiringSoon = expSoon });
});

app.Run(); // workflow passes --urls http://localhost:5080


app.MapGet("/api/credly-raw", async (ICredlyClient credly, string userId) =>
{
    if (string.IsNullOrWhiteSpace(userId)) return Results.BadRequest(new { error = "Missing userId." });
    var raw = await credly.GetBadgesRawAsync(userId);
    return Results.Text(raw, "application/json");
});

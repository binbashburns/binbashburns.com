using System.Text.Json;
using BadgeBox.Api.Models;
using BadgeBox.Api.Services;
using Microsoft.Extensions.Caching.Memory;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddMemoryCache();
builder.Services.AddHttpClient<ICredlyClient, CredlyClient>();
builder.Services.AddCors(o => o.AddDefaultPolicy(p => p.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod()));

var app = builder.Build();
app.UseSwagger().UseSwaggerUI();
app.UseCors();

app.MapGet("/health", () => Results.Ok(new { status = "ok" }));

app.MapGet("/api/badges", async (ICredlyClient credly, IMemoryCache cache, IConfiguration cfg, string? userId) =>
{
    userId ??= cfg["Credly:UserId"];
    if (string.IsNullOrWhiteSpace(userId))
        return Results.BadRequest(new { error = "Missing userId. Supply ?userId= or set Credly:UserId." });

    var cacheKey = $"badges:{userId}";
    if (!cache.TryGetValue(cacheKey, out List<BadgeDto>? badges))
    {
        var raw = await credly.GetBadgesRawAsync(userId);
        badges = BadgeNormalizer.Normalize(raw, DateTimeOffset.UtcNow).ToList();
        cache.Set(cacheKey, badges, TimeSpan.FromMinutes(30));
    }
    return Results.Ok(badges);
})
.WithName("GetBadges")
.Produces<List<BadgeDto>>(StatusCodes.Status200OK, "application/json");

app.MapGet("/api/skills", async (ICredlyClient credly, IMemoryCache cache, IConfiguration cfg, string? userId) =>
{
    userId ??= cfg["Credly:UserId"];
    if (string.IsNullOrWhiteSpace(userId))
        return Results.BadRequest(new { error = "Missing userId." });

    var cacheKey = $"skills:{userId}";
    if (!cache.TryGetValue(cacheKey, out object? payload))
    {
        var raw = await credly.GetBadgesRawAsync(userId);
        var badges = BadgeNormalizer.Normalize(raw, DateTimeOffset.UtcNow).ToList();
        var skills = badges.SelectMany(b => b.Skills ?? [])
                           .GroupBy(s => s)
                           .Select(g => new { skill = g.Key, count = g.Count() })
                           .OrderByDescending(x => x.count)
                           .ToList();
        payload = skills;
        cache.Set(cacheKey, payload, TimeSpan.FromMinutes(30));
    }
    return Results.Ok(payload);
})
.WithName("GetSkills");

app.MapGet("/api/status", async (ICredlyClient credly, IMemoryCache cache, IConfiguration cfg, string? userId, int soonDays = 30) =>
{
    userId ??= cfg["Credly:UserId"];
    if (string.IsNullOrWhiteSpace(userId))
        return Results.BadRequest(new { error = "Missing userId." });

    var raw = await credly.GetBadgesRawAsync(userId);
    var badges = BadgeNormalizer.Normalize(raw, DateTimeOffset.UtcNow).ToList();
    var expired = badges.Where(b => b.IsExpired).Select(b => b.Id).ToList();
    var expiringSoon = badges.Where(b => !b.IsExpired && (b.DaysUntilExpiry ?? int.MaxValue) <= soonDays)
                             .Select(b => b.Id).ToList();

    var status = new {
        total = badges.Count,
        expired = expired.Count,
        expiringSoon,
    };
    return Results.Ok(status);
})
.WithName("GetStatus");

app.Run("http://0.0.0.0:8080");

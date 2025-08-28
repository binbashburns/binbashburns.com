namespace BadgeBox.Api.Models;

public record BadgeDto(
  string Id,
  string Name,
  string Issuer,
  DateTimeOffset? IssuedAt,
  DateTimeOffset? ExpiresAt,
  bool IsExpired,
  int? DaysUntilExpiry,
  string Url,
  string ImageUrl,
  string? Description,
  List<string>? Skills
);

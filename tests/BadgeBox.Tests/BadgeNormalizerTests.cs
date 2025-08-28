using BadgeBox.Api.Services;
using FluentAssertions;
using Xunit;

public class BadgeNormalizerTests
{
    [Fact]
    public void NormalizesBadgeWithSkillsAndIssuer()
    {
        var sample = """
        {"data":[
          {"id":"123","public_url":"https://credly/123","image_url":"https://img/123.png",
           "issued_at":"2024-06-01T00:00:00Z","expires_at":"2026-06-01T00:00:00Z",
           "badge_template":{"name":"AWS SAA","description":"desc","skills":[{"name":"AWS"},{"name":"Cloud"}]},
           "issuer":{"entities":[{"entity":{"name":"Amazon Web Services"}}]}
          }
        ]}
        """;
        var now = DateTimeOffset.Parse("2025-01-01Z");
        var list = BadgeNormalizer.Normalize(sample, now).ToList();
        list.Should().HaveCount(1);
        var b = list[0];
        b.Name.Should().Be("AWS SAA");
        b.Issuer.Should().Be("Amazon Web Services");
        b.Skills.Should().Contain(new[] { "AWS", "Cloud" });
        b.IsExpired.Should().BeFalse();
        b.DaysUntilExpiry.Should().BeGreaterThan(300);
    }
}

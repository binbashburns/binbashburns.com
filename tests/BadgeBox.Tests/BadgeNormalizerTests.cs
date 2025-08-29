using BadgeBox.Api.Services;
using FluentAssertions;
using Xunit;

public class BadgeNormalizerTests
{
    [Fact]
    public void Parses_basic_fields()
    {
        var sample = """
        {"data":[
          {"id":"123","public_url":"u","image_url":"i","issued_at":"2024-01-01T00:00:00Z",
           "badge_template":{"name":"Name","description":"desc","skills":[{"name":"X"}]},
           "issuer":{"entities":[{"entity":{"name":"Issuer"}}]}
          }
        ]}
        """;
        var list = BadgeNormalizer.Normalize(sample, DateTimeOffset.Parse("2025-01-01Z")).ToList();
        list.Should().HaveCount(1);
        list[0].Name.Should().Be("Name");
        list[0].Issuer.Should().Be("Issuer");
    }
}

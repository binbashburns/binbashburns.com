using System.Net.Http.Json;
using System.Text.Json;

return await Run();

static async Task<int> Run()
{
    var apiBase   = Environment.GetEnvironmentVariable("BADGEBOX_API") ?? "http://localhost:5080";
    var userId    = Environment.GetEnvironmentVariable("USER_ID") ?? "";
    var outFile   = Environment.GetEnvironmentVariable("OUT_FILE") ?? "website/_data/credly-badges.json";
    var statusOut = Environment.GetEnvironmentVariable("STATUS_FILE") ?? "status.json";
    var strict    = Environment.GetEnvironmentVariable("STRICT") == "1";

    if (string.IsNullOrWhiteSpace(userId))
    {
        Console.Error.WriteLine("USER_ID is required.");
        return 2;
    }

    using var http = new HttpClient { BaseAddress = new Uri(apiBase) };

    Console.WriteLine($"Fetching badges for {userId} from {apiBase} …");
    var badges = await http.GetFromJsonAsync<JsonElement>($"/api/badges?userId={Uri.EscapeDataString(userId)}");
    Directory.CreateDirectory(Path.GetDirectoryName(outFile)!);
    await File.WriteAllTextAsync(outFile, JsonSerializer.Serialize(badges, new JsonSerializerOptions { WriteIndented = true }));
    Console.WriteLine($"Wrote {outFile}");

    var status = await http.GetFromJsonAsync<JsonElement>($"/api/status?userId={Uri.EscapeDataString(userId)}");
    await File.WriteAllTextAsync(statusOut, JsonSerializer.Serialize(status, new JsonSerializerOptions { WriteIndented = true }));
    Console.WriteLine($"Wrote {statusOut}");

    var expired = status.GetProperty("expired").GetInt32();
    if (strict && expired > 0)
    {
        Console.Error.WriteLine("Expired certifications present; STRICT=1, failing.");
        return 1;
    }

    return 0;
}

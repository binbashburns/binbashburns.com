using System.Net.Http.Json;
using System.Text.Json;

var apiBase = Environment.GetEnvironmentVariable("BADGEBOX_API") ?? "http://localhost:5080";
var userId  = Environment.GetEnvironmentVariable("USER_ID") ?? "";
var outFile = Environment.GetEnvironmentVariable("OUT_FILE") ?? "website/_data/credly-badges.json";
var statusFile = Environment.GetEnvironmentVariable("STATUS_FILE") ?? "status.json";

if (string.IsNullOrWhiteSpace(userId))
{
    Console.Error.WriteLine("USER_ID env var is required.");
    return 2;
}

using var http = new HttpClient { BaseAddress = new Uri(apiBase) };

Console.WriteLine($"Fetching badges from {apiBase} for {userId}...");
var badges = await http.GetFromJsonAsync<JsonElement>($"/api/badges?userId={Uri.EscapeDataString(userId)}");
Directory.CreateDirectory(Path.GetDirectoryName(outFile)!);
await File.WriteAllTextAsync(outFile,
    JsonSerializer.Serialize(badges, new JsonSerializerOptions { WriteIndented = true }));

Console.WriteLine($"Wrote {outFile}");

var status = await http.GetFromJsonAsync<JsonElement>($"/api/status?userId={Uri.EscapeDataString(userId)}");
await File.WriteAllTextAsync(statusFile,
    JsonSerializer.Serialize(status, new JsonSerializerOptions { WriteIndented = true }));
Console.WriteLine($"Wrote {statusFile}");

var expired = status.GetProperty("expired").GetInt32();
if (Environment.GetEnvironmentVariable("STRICT") == "1" && expired > 0)
{
    Console.Error.WriteLine("Error: expired certifications present.");
    return 1;
}

return 0;

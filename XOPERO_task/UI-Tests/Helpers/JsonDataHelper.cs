using System.Text.Json;

namespace XOPERO_task.UI_Tests;

public static class JsonDataHelper
{
    public static async Task<T> LoadFromFileAsync<T>(string path)
    {
        if (string.IsNullOrWhiteSpace(path))
            throw new ArgumentException("Path to JSON file cannot be null or empty.", nameof(path));

        if (!File.Exists(path))
            throw new FileNotFoundException($"File not found at path: {path}");

        var json = await File.ReadAllTextAsync(path);

        var options = new JsonSerializerOptions
        {
            PropertyNameCaseInsensitive = true,
            ReadCommentHandling = JsonCommentHandling.Skip,
            AllowTrailingCommas = true
        };

        var result = JsonSerializer.Deserialize<T>(json, options);

        if (result == null)
            throw new InvalidOperationException($"Failed to deserialize JSON file at '{path}' into type '{typeof(T).Name}'.");

        return result;
    }
}

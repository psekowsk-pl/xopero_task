using System.Text.Json.Serialization;

namespace XOPERO_task.API_Tests;

public class UserResponseDto
{
    [JsonPropertyName("data")]
    public UserDto Data { get; set; } = null!;
}
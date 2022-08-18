using System.Text.Json.Serialization;

namespace DatingFoss.Server.DTOs;

public class PrivatePictureDTO
{
    [JsonPropertyName("id")]
    public string? Picture { get; init; }

    [JsonPropertyName("key")]
    public int KeyIndex { get; init; }
}

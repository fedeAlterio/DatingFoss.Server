using System.Text.Json.Serialization;

namespace DatingFoss.Server.DTOs;

public class MessageDTO
{
    [JsonPropertyName("from")]
    public string? FromUsername { get; init; }
    public string? Content { get; init; }    
    public string? ToUsername { get; init; }

    [JsonPropertyName("timestamp")]
    public DateTime? SentDate { get; init; }
}

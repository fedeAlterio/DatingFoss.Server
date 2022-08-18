using System.Text.Json.Serialization;

namespace DatingFoss.Server.Controllers.Messages.ActionsResponses;

public class MessagesResponse
{
    [JsonPropertyName("from")]
    public string? FromUsername { get; init; }
    public string? Content { get; init; }

    [JsonPropertyName("timestamp")]
    public DateTime? SentDate { get; init; }
}

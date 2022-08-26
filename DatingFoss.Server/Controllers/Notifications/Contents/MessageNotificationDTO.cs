using DatingFoss.Server.Controllers.Notifications.Attributes;
using System.Text.Json.Serialization;

namespace DatingFoss.Server.Controllers.Notifications.Models;

[NotificationContentDTO]
public class MessageNotificationContentDTO
{
    public string? FromUsername { get; init; }
    public string? Content { get; init; }

    [JsonPropertyName("timestamp")]
    public DateTime? SentDate { get; init; }
}

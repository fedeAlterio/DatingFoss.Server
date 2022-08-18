using DatingFoss.Server.DTOs;

namespace DatingFoss.Server.Controllers.Messages.Responses;

public class GetMessagesResponseDTO
{
    public List<MessageDTO> Messages { get; init; } = new();
}

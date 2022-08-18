using DatingFoss.Server.Controllers.Messages.Responses;
using DatingFoss.Server.DTOs;
using MediatR;

namespace DatingFoss.Server.Controllers.Messages.Queries;

public class SendMessageQuery : IRequest<SendMessageResponseDTO>
{
    public MessageDTO? Message { get; init; }
}

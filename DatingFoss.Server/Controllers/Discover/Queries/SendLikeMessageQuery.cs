using DatingFoss.Server.Controllers.Discover.Responses;
using DatingFoss.Server.DTOs;
using MediatR;

namespace DatingFoss.Server.Controllers.Discover.Queries;

public class SendLikeMessageQuery : IRequest<SendLikeMessageResponseDTO>
{
    public LikeMessageDTO? LikeMessage { get; init; }
}

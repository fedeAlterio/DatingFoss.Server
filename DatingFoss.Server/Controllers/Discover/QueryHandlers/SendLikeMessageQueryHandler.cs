using AutoMapper;
using DatingFoss.Application.Discover.Requests;
using DatingFoss.Application.Discover.Responses;
using DatingFoss.Server.Controllers.Discover.Queries;
using DatingFoss.Server.Controllers.Discover.Responses;
using DatingFoss.Server.Controllers.QueryHandlers;
using MediatR;

namespace DatingFoss.Server.Controllers.Discover.QueryHandlers;

public class SendLikeMessageQueryHandler
    : ViewToApplicationRequestHandler<SendLikeMessageQuery, SendLikeMessageRequest, SendLikeMessageResponseDTO>
{
    public SendLikeMessageQueryHandler(IMapper mapper, IMediator mediator) : base(mapper, mediator)
    {
    }
}

using AutoMapper;
using DatingFoss.Application.Messages.Requests;
using DatingFoss.Server.Controllers.Messages.Queries;
using DatingFoss.Server.Controllers.Messages.Responses;
using DatingFoss.Server.Controllers.QueryHandlers;
using MediatR;

namespace DatingFoss.Server.Controllers.Messages.QueriesHandlers;

public class SendMessageQueryHandler
    : ViewToApplicationRequestHandler<SendMessageQuery, SendMessageRequest, SendMessageResponseDTO>
{
    public SendMessageQueryHandler(IMapper mapper, IMediator mediator) : base(mapper, mediator)
    {
    }
}

using AutoMapper;
using DatingFoss.Application.Messages.Requests;
using DatingFoss.Server.Controllers.Messages.Queries;
using DatingFoss.Server.Controllers.Messages.Responses;
using DatingFoss.Server.Controllers.QueryHandlers;
using MediatR;

namespace DatingFoss.Server.Controllers.Messages.QueriesHandlers;

public class GetMessagesQueryHandler
    : ViewToApplicationRequestHandler<GetMessagesQuery, GetMessagesRequest, GetMessagesResponseDTO>
{
    public GetMessagesQueryHandler(IMapper mapper, IMediator mediator) : base(mapper, mediator)
    {
    }
}

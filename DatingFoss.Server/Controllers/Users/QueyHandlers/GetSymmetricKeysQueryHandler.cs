using AutoMapper;
using DatingFoss.Application.Users.Requests;
using DatingFoss.Application.Users.Responses;
using DatingFoss.Server.Controllers.QueryHandlers;
using DatingFoss.Server.Controllers.Users.Queries;
using DatingFoss.Server.Controllers.Users.Responses;
using MediatR;

namespace DatingFoss.Server.Controllers.Users.QueyHandlers;

public class GetSymmetricKeysQueryHandler
    : ViewToApplicationRequestHandler<GetSymmetricKeysQuery, GetSymmetricKeysRequest, GetSymmetricKeysResponseDTO>
{
    public GetSymmetricKeysQueryHandler(IMapper mapper, IMediator mediator) : base(mapper, mediator)
    {
    }
}

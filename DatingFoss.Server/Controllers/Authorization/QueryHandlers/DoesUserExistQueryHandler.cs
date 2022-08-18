using AutoMapper;
using DatingFoss.Application.Authorization.Requests;
using DatingFoss.Server.Controllers.Authorization.Queries;
using DatingFoss.Server.Controllers.Authorization.Responses;
using DatingFoss.Server.Controllers.QueryHandlers;
using MediatR;

namespace DatingFoss.Server.Controllers.Authorization.QueryHandlers;

public class DoesUserExistQueryHandler : ViewToApplicationRequestHandler<DoesUserExistQuery, DoesUserExistReqest, DoesUserExistResponseDTO>
{
    public DoesUserExistQueryHandler(IMapper mapper, IMediator mediator) : base(mapper, mediator)
    {
    }
}

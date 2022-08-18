using AutoMapper;
using DatingFoss.Application.Users.Requests;
using DatingFoss.Server.Controllers.QueryHandlers;
using DatingFoss.Server.Controllers.Users.Queries;
using DatingFoss.Server.Controllers.Users.Responses;
using MediatR;

namespace DatingFoss.Server.Controllers.Users.QueyHandlers;

public class ClearAllUsersQueryHandler
    : ViewToApplicationRequestHandler<ClearAllUsersQuery, ClearAllUsersRequest, ClearAllUsersResponseDTO>
{
    public ClearAllUsersQueryHandler(IMapper mapper, IMediator mediator) : base(mapper, mediator)
    {
    }
}

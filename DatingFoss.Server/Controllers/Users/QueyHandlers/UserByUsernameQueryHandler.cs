using AutoMapper;
using DatingFoss.Application.Users.Requests;
using DatingFoss.Server.Controllers.Users.Queries;
using DatingFoss.Server.Controllers.Users.Responses;
using DatingFoss.Server.Controllers.QueryHandlers;
using MediatR;

namespace DatingFoss.Server.Controllers.Users.QueyHandlers;

public class UserByUsernameQueryHandler : ViewToApplicationRequestHandler<UserByUsernameQuery, UserByUsernameRequest, UserByUsernameResponseDTO>
{
    public UserByUsernameQueryHandler(IMapper mapper, IMediator mediator) : base(mapper, mediator)
    {
    }
}

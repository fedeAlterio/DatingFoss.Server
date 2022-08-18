using AutoMapper;
using DatingFoss.Application.Users.Requests;
using DatingFoss.Server.Controllers.QueryHandlers;
using DatingFoss.Server.Controllers.Users.Queries;
using DatingFoss.Server.Controllers.Users.Responses;
using MediatR;

namespace DatingFoss.Server.Controllers.Users.QueyHandlers;

public class PublicKeyByUsernameQueryHandler
    : ViewToApplicationRequestHandler<PublicKeyByUsernameQuery, PublicKeyByUsernameRequest, PublicKeyByUsernameResponseDTO>
{
    public PublicKeyByUsernameQueryHandler(IMapper mapper, IMediator mediator) : base(mapper, mediator)
    {
    }
}

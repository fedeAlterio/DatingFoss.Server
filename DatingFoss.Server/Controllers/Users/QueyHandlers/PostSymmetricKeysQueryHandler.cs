using AutoMapper;
using DatingFoss.Application.Users.Requests;
using DatingFoss.Application.Users.Responses;
using DatingFoss.Server.Controllers.QueryHandlers;
using DatingFoss.Server.Controllers.Users.Queries;
using DatingFoss.Server.Controllers.Users.Responses;
using MediatR;

namespace DatingFoss.Server.Controllers.Users.QueyHandlers;

public class PostSymmetricKeysQueryHandler :
    ViewToApplicationRequestHandler<PostSymmetricKeysQuery, PostSymmetricKeysRequest, PostSymmetricKeysResponseDTO>
{
    public PostSymmetricKeysQueryHandler(IMapper mapper, IMediator mediator) : base(mapper, mediator)
    {
    }
}

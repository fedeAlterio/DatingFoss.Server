using DatingFoss.Domain;
using DatingFoss.Server.Authentication.Extensions;
using DatingFoss.Server.Controllers.Discover.DTOs;
using DatingFoss.Server.Controllers.Discover.Queries;
using DatingFoss.Server.DTOs;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace DatingFoss.Server.Controllers.Discover;


[ApiController]
[Route("[Controller]")]
public class DiscoverController : ControllerBase
{
    private readonly IMediator _mediator;

    public DiscoverController(IMediator mediator)
    {
        _mediator = mediator;
    }


    [HttpPost]
    [Route("[Action]")]
    [Authorize]
    public async Task<IList<UserDTO>> PossiblePartners([FromBody] PossiblePartnersQueryParametersDTO parameters, CancellationToken cancellationToken)
    {
        var identity = this.GetUserIdentity();
        var query = new PossiblePartnersQuery { Parameters = parameters with { Username = identity.Username } };
        var response = await _mediator.Send(query, cancellationToken);
        return response.PossiblePartners ?? Array.Empty<UserDTO>();
    }


    [HttpPost]
    [Route("[Action]")]
    public async Task SendLikeMessage(LikeMessageDTO likeMessage, CancellationToken cancellationToken)
    {
        var query = new SendLikeMessageQuery { LikeMessage = likeMessage };
        await _mediator.Send(query, cancellationToken);
    }
}

using DatingFoss.Application.Authorization.Abstractions;
using DatingFoss.Application.Authorization.Requests;
using DatingFoss.Application.Authorization.Responses;
using DatingFoss.Application.Repositories.Abstractions;
using DatingFoss.Application.Repositories.Extensions;
using MediatR;

namespace DatingFoss.Application.Authorization.RequestHandlers;

public class ChellengeHandler : IRequestHandler<ChallengeRequest, ChallengeResponse>
{
    // Private 
    private readonly IAuthorizationService _authorizationService;
    private readonly IUsersService _usersService;



    // Initialization
    public ChellengeHandler(IAuthorizationService authorizationService, IUsersService usersService)
    {
        _authorizationService = authorizationService;
        _usersService = usersService;
    }



    // Core
    public async Task<ChallengeResponse> Handle(ChallengeRequest request, CancellationToken cancellationToken)
    {
        await _usersService.AssertExists(request.Username, cancellationToken);
        var token = _authorizationService.GetChallenge(request.Username!);
        var challengeResponse = new ChallengeResponse { Token = token };
        return challengeResponse;
    }
}

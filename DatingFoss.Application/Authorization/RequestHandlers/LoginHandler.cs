using DatingFoss.Application.Authorization.Abstractions;
using DatingFoss.Application.Authorization.Requests;
using DatingFoss.Application.Authorization.Responses;
using DatingFoss.Application.Encryption.Abstractions;
using DatingFoss.Application.Repositories.Abstractions;
using MediatR;

namespace DatingFoss.Application.Authorization.RequestHandlers;
public class LoginHandler : IRequestHandler<LoginRequest, LoginResponse>
{
    // Private fields
    private readonly IAuthorizationService _authorizationService;
    private readonly IEncryptionService _encryptionService;
    private readonly IUsersService _usersService;
    private readonly AuthorizationConfiguration _authorizationConfiguration;



    // Initialization
    public LoginHandler(IAuthorizationService authorizationService, IEncryptionService encryptionService,
        IUsersService usersService, AuthorizationConfiguration authorizationConfiguration)
    {
        _authorizationService = authorizationService;
        _encryptionService = encryptionService;
        _usersService = usersService;
        _authorizationConfiguration = authorizationConfiguration;
    }



    // Core
    public async Task<LoginResponse> Handle(LoginRequest request, CancellationToken cancellationToken)
    {
        var username = request.Token!.Challenge.Username;
        var user = await _usersService.FindByUsername(username, cancellationToken);

        if (_authorizationConfiguration.ShouldVerifyClientSignature)
        {
            var publicKey = _encryptionService.RSAParametersFromExponentAndModulus(user.PublicKey!.Exponent!, user.PublicKey!.Modulus!);
            _authorizationService.AssertIsValidChallenge(request.Token!, request.DataSignedFromClient!, publicKey);
        }

        return new() { User = user };
    }
}

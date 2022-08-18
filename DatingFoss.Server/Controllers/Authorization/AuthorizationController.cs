using DatingFoss.Server.Authentication;
using DatingFoss.Server.Authentication.Extensions;
using DatingFoss.Server.Controllers.Authorization.Queries;
using DatingFoss.Server.Controllers.Authorization.Responses;
using DatingFoss.Server.DTOs;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Cryptography;

namespace DatingFoss.Server.Controllers.Authorization;

[ApiController]
[Route("[controller]")]
public class AuthorizationController : ControllerBase
{
    // Private fields
    private readonly IMediator _mediator;



    // Initialization
    public AuthorizationController(IMediator mediator)
    {
        _mediator = mediator;
    }



    [HttpPost]
    [Route("[Action]")]
    public async Task<SignUpResponseDTO> SignUp(SignUpQuery query, CancellationToken cancellationToken)
    {
        var response = await _mediator.Send(query, cancellationToken);
        return response;
    }


    [HttpGet]
    [Route("[Action]")]
    public async Task<TokenDTO> GetChallenge(string username, CancellationToken cancellationToken)
    {
        var query = new ChallengeQuery { Username = username };
        var response = await _mediator.Send(query, cancellationToken);
        return response.Token!;
    }


    [HttpPost]
    [Route("[Action]")]
    public async Task<LoginResponseDTO> Login([FromBody] LoginQuery query, CancellationToken cancellationToken)
    {
        var response = await _mediator.Send(query, cancellationToken);
        return response!;
    }


    [HttpGet]
    [Route("[Action]")]
    public async Task<bool> DoesUserExist(string username, CancellationToken cancellationToken)
    {
        var query = new DoesUserExistQuery { Username = username };
        var response = await _mediator.Send(query, cancellationToken);
        return response.DoesUserExist;
    }


    [HttpGet]
    [Authorize]
    [Route("[Action]")]
    public UserIdentity SecretString()
    {
        var identity = this.GetUserIdentity();
        return identity;
    }


    [HttpGet]
    [Route("[Action]")]
    public RSAPublicKeyDTO GetRandomPublicKey()
    {
        using var cryptoService = new RSACryptoServiceProvider();
        var publicKey = cryptoService.ExportParameters(true);
        var ret = new RSAPublicKeyDTO()
        {
            Exponent = Convert.ToBase64String(publicKey.Exponent!),
            Modulus = Convert.ToBase64String(publicKey.Modulus!),
        };
        return ret;
    }
}

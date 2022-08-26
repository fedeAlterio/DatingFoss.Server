using DatingFoss.Server.Authentication.Extensions;
using DatingFoss.Server.Controllers.Users.DTOs;
using DatingFoss.Server.Controllers.Users.Queries;
using DatingFoss.Server.Controllers.Users.Responses;
using DatingFoss.Server.DTOs;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace DatingFoss.Server.Controllers.Users;

[ApiController]
[Route("[Controller]")]
public class UserController : ControllerBase
{
    private readonly IMediator _mediator;
    private const string _symmetricKeysActionName = "SymmetricKeys";


    public UserController(IMediator mediator)
    {
        _mediator = mediator;
    }


    [HttpGet]
    [Route("")]
    public async Task<UserDTO> GetUser(string? username, CancellationToken cancellationToken)
    {
        username ??= this.GetUserIdentity()?.Username;
        var userByUsernameQuery = new UserByUsernameQuery { Username = username };
        var response = await _mediator.Send(userByUsernameQuery, cancellationToken);
        return response.User!;
    }

    [HttpPost]
    [Route(_symmetricKeysActionName)]
    [Authorize]
    public async Task<string?> PostSymmetricKeys([FromBody] string? symmetricKeys, CancellationToken cancellationToken)
    {
        var query = new PostSymmetricKeysQuery { UserName = this.GetUserIdentity().Username , SymmetricKeys = symmetricKeys };
        var response = await _mediator.Send(query, cancellationToken);
        return response.SymmetricKeys;
    }


    [HttpPost]
    [Route("[Action]")]
    public async Task ClearAllUsers(CancellationToken cancellationToken)
    {
        var query = new ClearAllUsersQuery();
        await _mediator.Send(query, cancellationToken);
    }


    [HttpGet]
    [Route(_symmetricKeysActionName)]
    [Authorize]
    public async Task<string> GetSymmetricKeys(CancellationToken cancellationToken)
    {
        var query = new GetSymmetricKeysQuery{ UserName = this.GetUserIdentity().Username };
        var response = await _mediator.Send(query, cancellationToken);
        return response.SymmetricKeys!;
    }


    [HttpGet]
    [Route("[Action]")]
    public async Task<RSAPublicKeyDTO> PublicKey(string? username, CancellationToken cancellationToken)
    {
        var query = new PublicKeyByUsernameQuery { Username = username };
        var response = await _mediator.Send(query, cancellationToken);
        return response.PublicKey!;
    }


    [HttpPost]
    [Route("[Action]")]
    [Authorize]
    public async Task<UserDTO> UpdateData([FromBody] UpdateUserDataDTO updateUserData, CancellationToken cancellationToken)
    {
        var userIdentity = this.GetUserIdentity();
        var query = new UpdateUserDataQuery { UpdateUserData = updateUserData, UserIdentity = userIdentity };        
        var response = await _mediator.Send(query, cancellationToken);
        return response.User!;
    }


    [HttpPost]
    [Route("[Action]")]
    [Authorize]
    public async Task<UploadPublicPictureResponseDTO> UploadPublicPicture([FromForm] UploadPublicPictureQuery query, CancellationToken cancellationToken)
    {
        var userIdentity = this.GetUserIdentity();
        query = query with { UserIdentity = userIdentity };
        var response = await _mediator.Send(query, cancellationToken);
        return response;
    }


    [HttpGet]
    [Route("{username}/[Action]")]
    public async Task<IActionResult> PublicPicture(string pictureName, string username)
    {
        var query = new PublicPicturePathQuery { PictureName = pictureName, Username = username };
        var response = await _mediator.Send(query);
        return PhysicalFile(response.PicutrePath!, response.ContentType!);
    }


    [HttpPost]
    [Route("[Action]")]
    [Authorize]
    public async Task<UploadPrivatePictureResponseDTO> UploadPrivatePicture([FromForm] UploadPrivatePictureQuery query, CancellationToken cancellationToken)
    {
        var userIdentity = this.GetUserIdentity();
        query = query with { UserIdentity = userIdentity };
        var response = await _mediator.Send(query, cancellationToken);
        return response;
    }


    [HttpGet]
    [Route("{username}/[Action]")]
    public async Task<IActionResult> PrivatePicture(string pictureName, string username)
    {
        var query = new PrivatePicturePathQuery { PictureName = pictureName, Username = username };
        var response = await _mediator.Send(query);
        return PhysicalFile(response.PicutrePath!, response.ContentType!);
    }
}

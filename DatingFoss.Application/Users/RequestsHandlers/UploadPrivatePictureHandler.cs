using DatingFoss.Application.Repositories.Abstractions;
using DatingFoss.Application.Users.Requests;
using DatingFoss.Application.Users.Responses;
using DatingFoss.Domain;
using MediatR;

namespace DatingFoss.Application.Users.RequestsHandlers;
public class UploadPrivatePictureHandler : IRequestHandler<UploadPrivatePictureRequest, UploadPrivatePictureResponse>
{
    private readonly IUsersService _usersService;
    private readonly ICrud<User> _usersCrud;

    public UploadPrivatePictureHandler(IUsersService usersService, ICrud<User> usersCrud)
    {
        _usersService = usersService;
        _usersCrud = usersCrud;
    }
    public async Task<UploadPrivatePictureResponse> Handle(UploadPrivatePictureRequest request, CancellationToken cancellationToken)
    {
        var user = await _usersService.FindByUsername(request.Username!, cancellationToken);
        var privatePicture = new PrivatePicture { KeyIndex = request.KeyIndex, Picture = request.Picture };
        user.PrivateInfo!.Pictures.Add(privatePicture);
        await _usersCrud.Update(user, cancellationToken);
        return new();
    }
}

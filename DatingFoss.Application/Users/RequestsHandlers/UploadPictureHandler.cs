using DatingFoss.Application.Repositories.Abstractions;
using DatingFoss.Application.Users.Requests;
using DatingFoss.Application.Users.Responses;
using DatingFoss.Domain;
using MediatR;

namespace DatingFoss.Application.Users.RequestsHandlers;
public class UploadPictureHandler : IRequestHandler<UploadPublicPictureRequest, UploadPubilcPictureResponse>
{
    private readonly IUsersService _usersService;
    private readonly ICrud<User> _usersCrud;

    public UploadPictureHandler(IUsersService usersService, ICrud<User> usersCrud)
    {
        _usersService = usersService;
        _usersCrud = usersCrud;
    }
    public async Task<UploadPubilcPictureResponse> Handle(UploadPublicPictureRequest request, CancellationToken cancellationToken)
    {
        var user = await _usersService.FindByUsername(request.Username!, cancellationToken);
        user.PublicInfo!.Pictures!.Add(request.Picture!);
        await _usersCrud.Update(user, cancellationToken);
        return new();
    }
}

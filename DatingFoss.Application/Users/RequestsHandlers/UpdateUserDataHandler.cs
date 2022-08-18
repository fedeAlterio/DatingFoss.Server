using DatingFoss.Application.Repositories.Abstractions;
using DatingFoss.Application.Users.Requests;
using DatingFoss.Application.Users.Responses;
using DatingFoss.Domain;
using MediatR;


namespace DatingFoss.Application.Users.RequestsHandlers;
public class UpdateUserDataHandler : IRequestHandler<UpdateUserDataRequest, UpdateUserDataResponse>
{
    private readonly IUsersService _usersService;
    private readonly ICrud<User> _usersCrud;

    public UpdateUserDataHandler(IUsersService usersService, ICrud<User> usersCrud)
    {
        _usersService = usersService;
        _usersCrud = usersCrud;
    }

    public async Task<UpdateUserDataResponse> Handle(UpdateUserDataRequest request, CancellationToken cancellationToken)
    {
        var dbUser = await _usersService.FindByUsername(request.User!.Username!, cancellationToken);
        var user = MergeUsers(request.User!, dbUser);
        dbUser = await _usersCrud.Update(user, cancellationToken);
        return new() { User = dbUser };
    }


    private User MergeUsers(User newUser, User dbUser) => dbUser with
    {
        PrivateInfo = newUser.PrivateInfo! with { Pictures = dbUser.PrivateInfo!.Pictures },
        PublicInfo = newUser.PublicInfo! with { Pictures = dbUser.PublicInfo!.Pictures },
    };
}

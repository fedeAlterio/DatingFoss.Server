using DatingFoss.Application.Repositories.Abstractions;
using DatingFoss.Application.Users.Requests;
using DatingFoss.Application.Users.Responses;
using MediatR;

namespace DatingFoss.Application.Users.RequestsHandlers;
public class UserByUsernameHandler : IRequestHandler<UserByUsernameRequest, UserByUsernameResponse>
{
    private readonly IUsersService _usersService;

    public UserByUsernameHandler(IUsersService usersService)
    {
        _usersService = usersService;
    }

    public async Task<UserByUsernameResponse> Handle(UserByUsernameRequest request, CancellationToken cancellationToken)
    {
        var user = await _usersService.FindByUsername(request.Username!, cancellationToken);
        return new() { User = user };
    }
}

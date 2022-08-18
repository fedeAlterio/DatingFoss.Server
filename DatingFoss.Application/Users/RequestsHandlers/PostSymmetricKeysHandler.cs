using DatingFoss.Application.Repositories.Abstractions;
using DatingFoss.Application.Users.Requests;
using DatingFoss.Application.Users.Responses;
using DatingFoss.Domain;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatingFoss.Application.Users.RequestsHandlers;
public class PostSymmetricKeysHandler : IRequestHandler<PostSymmetricKeysRequest, PostSymmetricKeysResponse>
{
    private readonly ICrud<User> _userCrud;
    private readonly IUsersService _usersService;

    public PostSymmetricKeysHandler(ICrud<User> userCrud, IUsersService usersService)
    {
        _userCrud = userCrud;
        _usersService = usersService;
    }

    public async Task<PostSymmetricKeysResponse> Handle(PostSymmetricKeysRequest request, CancellationToken cancellationToken)
    {
        User user = await _usersService.FindByUsername(request.UserName!, cancellationToken);
        var newUser = user with { SymmetricKeys = request.SymmetricKeys };
        await _userCrud.Update(newUser, cancellationToken);
        return new() { SymmetricKeys = request.SymmetricKeys };
    }
}

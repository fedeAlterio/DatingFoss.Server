using DatingFoss.Application.Repositories.Abstractions;
using DatingFoss.Application.Users.Requests;
using DatingFoss.Application.Users.Responses;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatingFoss.Application.Users.RequestsHandlers;
public class GetSymmetricKeysHandler : IRequestHandler<GetSymmetricKeysRequest, GetSymmetricKeysResponse>
{
    private readonly IUsersService _usersService;

    public GetSymmetricKeysHandler(IUsersService usersService)
    {
        _usersService = usersService;
    }

    public async Task<GetSymmetricKeysResponse> Handle(GetSymmetricKeysRequest request, CancellationToken cancellationToken)
    {
        var user = await _usersService.FindByUsername(request.UserName!, cancellationToken);
        return new() { SymmetricKeys = user.SymmetricKeys };
    }
}

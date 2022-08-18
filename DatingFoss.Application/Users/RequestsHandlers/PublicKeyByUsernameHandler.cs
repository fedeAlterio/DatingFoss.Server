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
public class PublicKeyByUsernameHandler : IRequestHandler<PublicKeyByUsernameRequest, PublicKeyByUsernameResponse>
{
    private readonly IUsersService _usersService;

    public PublicKeyByUsernameHandler(IUsersService usersService)
    {
        _usersService = usersService;
    }

    public async Task<PublicKeyByUsernameResponse> Handle(PublicKeyByUsernameRequest request, CancellationToken cancellationToken)
    {
        var publicKey = await _usersService.GetPublicKey(request.Username!, cancellationToken);
        return new PublicKeyByUsernameResponse { PublicKey = publicKey };
    }
}

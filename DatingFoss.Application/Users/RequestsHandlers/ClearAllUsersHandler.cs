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
public class ClearAllUsersHandler : IRequestHandler<ClearAllUsersRequest, ClearAllUsersResponse>
{
    private readonly ICrud<User> _usersCrud;

    public ClearAllUsersHandler(ICrud<User> usersCrud)
    {
        _usersCrud = usersCrud;
    }

    public async Task<ClearAllUsersResponse> Handle(ClearAllUsersRequest request, CancellationToken cancellationToken)
    {
        await _usersCrud.ClearAll(cancellationToken);
        return new();
    }
}

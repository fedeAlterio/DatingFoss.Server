using DatingFoss.Application.Notifications.Abstractions;
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
    private readonly INotificationService _notificationService;

    public ClearAllUsersHandler(ICrud<User> usersCrud, INotificationService notificationService)
    {
        _usersCrud = usersCrud;
        _notificationService = notificationService;
    }

    public async Task<ClearAllUsersResponse> Handle(ClearAllUsersRequest request, CancellationToken cancellationToken)
    {
        await _usersCrud.ClearAll(cancellationToken);
        await _notificationService.ClearAll(cancellationToken);
        return new();
    }
}

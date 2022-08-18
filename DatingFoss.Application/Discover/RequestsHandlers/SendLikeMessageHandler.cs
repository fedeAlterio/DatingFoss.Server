using DatingFoss.Application.Discover.Requests;
using DatingFoss.Application.Discover.Responses;
using DatingFoss.Application.Notifications.Abstractions;
using DatingFoss.Application.Notifications.Extensions;
using DatingFoss.Application.Repositories.Abstractions;
using DatingFoss.Application.Repositories.Extensions;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatingFoss.Application.Discover.RequestsHandlers;
public class SendLikeMessageHandler : IRequestHandler<SendLikeMessageRequest, SendLikeMessageResponse>
{
    private readonly IUsersService _usersService;
    private readonly INotificationService _notificationService;

    public SendLikeMessageHandler(IUsersService usersService, INotificationService notificationService)
    {
        _usersService = usersService;
        _notificationService = notificationService;
    }

    public async Task<SendLikeMessageResponse> Handle(SendLikeMessageRequest request, CancellationToken cancellationToken)
    {
        var likeMessage = request.LikeMessage!;
        await _usersService.AssertExists(likeMessage.ToUsername, cancellationToken);
        await _notificationService.PushLikeMessage(likeMessage, cancellationToken);
        return new();
    }
}

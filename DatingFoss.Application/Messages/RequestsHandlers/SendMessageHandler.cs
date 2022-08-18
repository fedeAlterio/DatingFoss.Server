using DatingFoss.Application.Messages.Abstractions;
using DatingFoss.Application.Messages.Requests;
using DatingFoss.Application.Messages.Responses;
using DatingFoss.Application.Notifications.Abstractions;
using DatingFoss.Application.Notifications.Extensions;
using DatingFoss.Application.Repositories.Abstractions;
using DatingFoss.Application.Repositories.Extensions;
using DatingFoss.Domain;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatingFoss.Application.Messages.RequestsHandlers;
public class SendMessageHandler : IRequestHandler<SendMessageRequest, SendMessageResponse>
{
    private readonly INotificationService _notificationService;
    private readonly IUsersService _usersService;

    public SendMessageHandler(INotificationService notificationService, IUsersService usersService)
    {
        _notificationService = notificationService;
        _usersService = usersService;
    }
    public async Task<SendMessageResponse> Handle(SendMessageRequest request, CancellationToken cancellationToken)
    {
        var message = request.Message;
        await _usersService.AssertExists(message?.FromUsername, cancellationToken);
        await _usersService.AssertExists(message?.ToUsername, cancellationToken);
        request.Message!.SentDate = DateTime.UtcNow;
        await _notificationService.PushMessage(request.Message!, cancellationToken);
        return new SendMessageResponse();
    }
}

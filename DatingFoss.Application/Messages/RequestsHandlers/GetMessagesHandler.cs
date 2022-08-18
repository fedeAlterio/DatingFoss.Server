using DatingFoss.Application.Messages.Abstractions;
using DatingFoss.Application.Messages.Requests;
using DatingFoss.Application.Messages.Responses;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatingFoss.Application.Messages.RequestsHandlers;
public class GetMessagesHandler : IRequestHandler<GetMessagesRequest, GetMessagesResponse>
{
    private readonly IMessagesService _messagesService;

    public GetMessagesHandler(IMessagesService messagesService)
    {
        _messagesService = messagesService;
    }

    public async Task<GetMessagesResponse> Handle(GetMessagesRequest request, CancellationToken cancellationToken)
    {
        var messages = await _messagesService.PullMessages(request, cancellationToken);    
        return new GetMessagesResponse { Messages = messages };
    }
}

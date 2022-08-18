using DatingFoss.Application.Messages.Requests;
using DatingFoss.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatingFoss.Application.Messages.Abstractions;
public interface IMessagesService
{
    Task SendMessage(Message message, CancellationToken cancellationToken);
    Task<List<Message>> PullMessages(GetMessagesRequest request, bool blockUntilUpdates, CancellationToken cancellationToken);
    public Task<List<Message>> PullMessages(GetMessagesRequest request, CancellationToken cancellationToken)
        => PullMessages(request, blockUntilUpdates: true, cancellationToken);
}

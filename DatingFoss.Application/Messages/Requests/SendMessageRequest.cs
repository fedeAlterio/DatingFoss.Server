using DatingFoss.Application.Messages.Responses;
using DatingFoss.Domain;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatingFoss.Application.Messages.Requests;
public class SendMessageRequest : IRequest<SendMessageResponse>
{
    public Message? Message { get; init; }
}

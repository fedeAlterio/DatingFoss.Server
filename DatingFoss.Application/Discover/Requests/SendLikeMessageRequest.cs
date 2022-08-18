using DatingFoss.Application.Discover.Responses;
using DatingFoss.Domain;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatingFoss.Application.Discover.Requests;
public class SendLikeMessageRequest : IRequest<SendLikeMessageResponse>
{
    public LikeMessage? LikeMessage { get; init; }
}

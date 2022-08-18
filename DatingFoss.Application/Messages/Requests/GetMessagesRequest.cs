using DatingFoss.Application.Messages.Responses;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatingFoss.Application.Messages.Requests;
public class GetMessagesRequest : IRequest<GetMessagesResponse>
{
    public string? FromUsername { get; init; }
    public string? ToUsername { get; init; }
    public int MaximumResultsCount { get; init; }
}

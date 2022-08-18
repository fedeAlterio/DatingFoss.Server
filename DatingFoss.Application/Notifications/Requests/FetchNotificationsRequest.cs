using DatingFoss.Application.Notifications.Response;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatingFoss.Application.Notifications.Requests;
public class FetchNotificationsRequest : IRequest<FetchNotificationsResponse>
{
    public string? Username { get; init; }
}

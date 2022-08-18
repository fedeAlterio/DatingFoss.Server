using DatingFoss.Application.Users.Responses;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatingFoss.Application.Users.Requests;
public class PublicKeyByUsernameRequest : IRequest<PublicKeyByUsernameResponse>
{
    public string? Username { get; init; }
}

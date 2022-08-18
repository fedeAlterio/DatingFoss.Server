using DatingFoss.Application.Users.Responses;
using DatingFoss.Domain;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatingFoss.Application.Users.Requests;
public class UpdateUserDataRequest : IRequest<UpdateUserDataResponse>
{
    public User? User { get; init; }
}

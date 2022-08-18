using DatingFoss.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatingFoss.Application.Users.Responses;
public class PublicKeyByUsernameResponse
{
    public RSAPublicKey PublicKey { get; init; }
}

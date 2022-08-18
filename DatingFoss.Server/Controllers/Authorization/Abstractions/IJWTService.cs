using DatingFoss.Domain;

namespace DatingFoss.Server.Controllers.Authorization.Abstractions;

public interface IJWTService
{
    string BuildToken(User user);
}

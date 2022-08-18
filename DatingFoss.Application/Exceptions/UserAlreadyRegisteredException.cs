using DatingFoss.Domain.Exceptions;

namespace DatingFoss.Application.Exceptions;
public class UserAlreadyRegisteredException : DatingFossException
{
    public UserAlreadyRegisteredException(string? username) : base($"User {username} aready registered")
    {
    }
}

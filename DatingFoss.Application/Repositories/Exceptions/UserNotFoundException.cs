using DatingFoss.Domain.Exceptions;

namespace DatingFoss.Application.Repositories.Exceptions;
public class UserNotFoundException : DatingFossException
{
    public UserNotFoundException(string? username) : base($"User {username} not found")
    {
    }
}

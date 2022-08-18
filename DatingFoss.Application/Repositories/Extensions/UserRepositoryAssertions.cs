using DatingFoss.Application.Repositories.Abstractions;
using DatingFoss.Application.Repositories.Exceptions;

namespace DatingFoss.Application.Repositories.Extensions;
public static class UserRepositoryAssertions
{
    public static async Task AssertExists(this IUsersService @this, string? username, CancellationToken cancellationToken)
    {
        if (!await @this.Exists(username, cancellationToken))
            throw new UserNotFoundException(username);
    }
}

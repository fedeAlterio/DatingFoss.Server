using DatingFoss.Server.Authentication.Utils;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using System.Security.Principal;

namespace DatingFoss.Server.Authentication.Extensions;

public static class IdentityExtensions
{
    public static UserIdentity GetUserIdentity(this ControllerBase @this)
        => @this.HttpContext.User.Identity?.ToUserIdentity()
            ?? throw new InvalidOperationException($"User identity not found, are you sure you are authorized?");

    public static UserIdentity ToUserIdentity(this IIdentity @this) =>
        @this is not ClaimsIdentity claimsIdentity
            ? throw new InvalidOperationException($"Can't extract user identity: Expeceted claims identity but found {@this?.GetType()}")
            : UserIdentityClaimsMapper.UserIdentityFromClaimsIdentity(claimsIdentity);
}

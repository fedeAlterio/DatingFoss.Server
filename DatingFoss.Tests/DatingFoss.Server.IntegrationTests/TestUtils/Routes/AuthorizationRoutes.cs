using DatingFoss.Server.Controllers.Authorization;

namespace DatingFoss.Server.IntegrationTests.TestUtils.Routes
{
    public static class AuthorizationRoutes
    {
        public static string SignUpUrl => FullUrlFromAction(nameof(AuthorizationController.SignUp));
        public static string DoesUserExistsUrl => FullUrlFromAction(nameof(AuthorizationController.DoesUserExist));

        private static string FullUrlFromAction(string actionName)
        {
            return MvcDefaultRoute.Create(nameof(AuthorizationController), actionName);
        }
    }
}

using DatingFoss.Server.Controllers.Authorization;
using DatingFoss.Server.IntegrationTests.TestUtils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DatingFoss.Server.Controllers.Users;

namespace DatingFoss.Server.IntegrationTests.TestUtils.Routes
{
    public static class UserControllerRoutes
    {
        public static string GetUser => FullUrl();
        public static string UpdateData => FullUrl(nameof(UserController.UpdateData));
        public static string UploadPublicPicture => FullUrl(nameof(UserController.UploadPublicPicture));

        public static string PublicPicture(string username)
        {
            var controllerWithSlash = MvcDefaultRoute.Create(nameof(UserController), "");
            return $"{controllerWithSlash}{username}/{nameof(UserController.PublicPicture)}";
        }

        private static string FullUrl(string actionName = "")
        {
            return MvcDefaultRoute.Create(nameof(UserController), actionName);
        }
    }
}

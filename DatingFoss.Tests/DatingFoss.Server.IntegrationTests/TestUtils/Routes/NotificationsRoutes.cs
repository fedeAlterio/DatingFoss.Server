using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DatingFoss.Server.Controllers.Notifications;

namespace DatingFoss.Server.IntegrationTests.TestUtils.Routes
{
    public static class NotificationsRoutes
    {
        public static string Fetch => FullUrl(nameof(NotificationsController.Fetch));

        private static string FullUrl(string actionName)
        {
            return MvcDefaultRoute.Create(nameof(NotificationsController), actionName);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DatingFoss.Server.Controllers.Discover;

namespace DatingFoss.Server.IntegrationTests.TestUtils.Routes
{
    public static class DiscoverRoutes
    {
        public static string PossiblePartners => FullUrl(nameof(DiscoverController.PossiblePartners));
        public static string SendLikeMessage => FullUrl(nameof(DiscoverController.SendLikeMessage));

        public static string FullUrl(string actionName)
        {
            return MvcDefaultRoute.Create(nameof(DiscoverController), actionName);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using DatingFoss.Server.Controllers.Discover.DTOs;
using DatingFoss.Server.DTOs;
using DatingFoss.Server.IntegrationTests.TestUtils.Extensions;
using DatingFoss.Server.IntegrationTests.TestUtils.Routes;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace DatingFoss.Server.IntegrationTests.TestUtils.Actions
{
    public static class DiscoverControllerActions
    {
        public static async Task<IList<UserDTO>> PossibleUsers(this HttpClient @this, PossiblePartnersQueryParametersDTO query)
        {
            var possibleUsers = await @this.PostAndParse<IList<UserDTO>>(DiscoverRoutes.PossiblePartners, query);
            return possibleUsers;
        }

        public static async Task SendLikeMessage(this HttpClient @this, LikeMessageDTO likeMessage)
        {
            var url = DiscoverRoutes.SendLikeMessage;
            await @this.PostAsJsonAsync(url, likeMessage);
        }
    }
}

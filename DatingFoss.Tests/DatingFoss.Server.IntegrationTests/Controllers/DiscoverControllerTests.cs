using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using DatingFoss.Application.Notifications;
using DatingFoss.Domain;
using DatingFoss.Server.Controllers.Discover.DTOs;
using DatingFoss.Server.DTOs;
using DatingFoss.Server.IntegrationTests.TestUtils;
using DatingFoss.Server.IntegrationTests.TestUtils.Actions;
using DatingFoss.Server.IntegrationTests.TestUtils.Extensions;
using DatingFoss.Server.IntegrationTests.TestUtils.Routes;
using FluentAssertions;

namespace DatingFoss.Server.IntegrationTests.Controllers
{
    public class DiscoverControllerTests : IntegrationTestBase
    {
        [Fact]
        public async Task PossiblePartners_Should_HandleSearchQueryCorrectly()
        {
            var username = "A";
            var signUpResponse = await TestClient.SignUp(username);
            TestClient.SetBearer(signUpResponse.Jwt!);

            var username2 = "B";
            var username3 = "C";
            var username4 = "D";
            await TestClient.SignUp(username2);
            await TestClient.SignUp(username3);
            await TestClient.SignUp(username4);

            var query = new PossiblePartnersQueryParametersDTO
            {
                ResultsLimit = 10
            };

            var possibleUsers = await TestClient.PossibleUsers(query);
            possibleUsers.Where(user => user.Username == username).Should().BeEmpty();
            query = query with { ExcludedUsernames = new[] { username2 } };
            possibleUsers = await TestClient.PossibleUsers(query);
            possibleUsers.Where(user => user.Username == username2).Should().BeEmpty();
            possibleUsers.Count.Should().BeGreaterThan(1);

            query = query with {ResultsLimit = 1};
            possibleUsers = await TestClient.PossibleUsers(query);
            possibleUsers.Count.Should().Be(1);
        }

        [Fact]
        public async Task SendLikeMessage_Should_SendALikeMessageNotification()
        {
            var alice = "Alice";
            var bob = "bob";

            var aliceSignUpResponse = await TestClient.SignUp(alice);
            var bobSignUpResponse = await TestClient.SignUp(bob);

            TestClient.SetBearer(aliceSignUpResponse.Jwt!);

            var message = new LikeMessageDTO { Content = "Like message to bob from Alice", ToUsername = bob };
            await TestClient.SendLikeMessage(message);

            TestClient.SetBearer(bobSignUpResponse.Jwt!);

            var notifications = TestClient.Notifications();
            var messageNotification = await notifications.FirstAsync() as Notification<LikeMessage>;
            messageNotification.Should().NotBeNull();

            messageNotification!.Type.Should().Be(NotificationType.LikeMessage);
            var receivedLikeMessage = messageNotification.Content!;
            receivedLikeMessage.Content.Should().Be(message.Content);
        }
    }
}

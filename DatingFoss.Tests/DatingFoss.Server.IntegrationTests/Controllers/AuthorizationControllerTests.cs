using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;
using DatingFoss.Infrastructure.Encryption;
using DatingFoss.Server.Controllers.Authorization;
using DatingFoss.Server.Controllers.Authorization.Queries;
using DatingFoss.Server.Controllers.Authorization.Responses;
using DatingFoss.Server.DTOs;
using DatingFoss.Server.IntegrationTests.TestUtils;
using DatingFoss.Server.IntegrationTests.TestUtils.Extensions;
using DatingFoss.Server.IntegrationTests.TestUtils.QueryBuilders;
using DatingFoss.Server.IntegrationTests.TestUtils.Routes;
using FluentAssertions;
using Microsoft.AspNetCore.WebUtilities;

namespace DatingFoss.Server.IntegrationTests.Controllers
{
    public class AuthorizationControllerTests : IntegrationTestBase
    {

        [Fact]
        public async Task SignUp_Should_ReturnAJwtOnSuccess()
        {
            var username = "Alessio";
            var signUpQuery = AuthorizationQueryBuilder.GetSignUpQuery(username);

            var response = await TestClient.PostAndParse<SignUpResponseDTO>(AuthorizationRoutes.SignUpUrl, signUpQuery);
            response.Jwt.Should().NotBeNullOrEmpty();
        }

        [Fact]
        public async Task DoesUserExist_Should_ReturnTrueIfUserExists()
        {
            var username = "Alessio";
            var signUpQuery = AuthorizationQueryBuilder.GetSignUpQuery(username);

            async Task SignUp() => await TestClient.PostAndParse<SignUpResponseDTO>(AuthorizationRoutes.SignUpUrl, signUpQuery);

            await SignUp();
            var queryParameters = new Dictionary<string, string?>
            {
                ["username"] = username
            };

            var doesUserExist = await TestClient.GetAndParse<bool>(AuthorizationRoutes.DoesUserExistsUrl, queryParameters);
            doesUserExist.Should().BeTrue();
        }
    }
}

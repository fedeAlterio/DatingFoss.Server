using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using DatingFoss.Server.Controllers.Authorization.Responses;
using DatingFoss.Server.Controllers.Users.DTOs;
using DatingFoss.Server.Controllers.Users.Responses;
using DatingFoss.Server.DTOs;
using DatingFoss.Server.IntegrationTests.TestUtils;
using DatingFoss.Server.IntegrationTests.TestUtils.Actions;
using DatingFoss.Server.IntegrationTests.TestUtils.Extensions;
using DatingFoss.Server.IntegrationTests.TestUtils.QueryBuilders;
using DatingFoss.Server.IntegrationTests.TestUtils.Routes;
using FluentAssertions;
using Microsoft.AspNetCore.Http;

namespace DatingFoss.Server.IntegrationTests.Controllers
{
    public class UserControllerTests : IntegrationTestBase
    {
        // Properties
        private string PictureFileName => @"TestFiles\Untitled.png";


        // Tests
        [Fact]
        public async Task GetUser_Should_ReturnUserIfExists()
        {
            var username = "Alessio";
            await TestClient.SignUp(username);
            var user = await TestClient.GetUser(username);
            user.Username.Should().Be(username);
        }

        [Fact]
        public async Task UpdateData_Should_UpdateDataCorrectly()
        {
            var username = "Alessio";
            var signUpResponse = await TestClient.SignUp(username);
            TestClient.SetBearer(signUpResponse.Jwt!);

            var publicInfo = new UserPublicInfoDTO
            {
                Bio = "Bio",
                BooleanInfo = new()
                {
                    ["A"] = true,
                    ["B"] = false,
                },
                Pictures = new(),
                Interests = new() { "Interest1", "Interest2" },
                Position = new() { Latitude = 1, Longitude = 2 },
                Searching = new() { Start = 0.1, End = 0.9 },
                Sex = 0.6,
                TemporalInfo = new() { ["A"] = DateTime.Now, ["B"] = DateTime.Now.AddDays(1) },
                TextualInfo = new() { ["A"] = "Text1", ["B"] = "Text2" }
            };

            var random = new Random();

            EncryptedDataDTO NewEncryptedData() => new()
            {
                Encoded = new string("dasnfaln".OrderBy(_ => random.Next()).ToArray()),
                KeyIndex = random.Next()
            };

            var privateInfo = new UserPrivateInfoDTO
            {
                Bio = new(),
                BooleanInfo = NewEncryptedData(),
                TemporalInfo = NewEncryptedData(),
                TextualInfo = NewEncryptedData(),
                Interests = NewEncryptedData(),
                Pictures = new(),
                Position = NewEncryptedData(),
                Searching = NewEncryptedData(),
                Sex = NewEncryptedData()
            };

            var updateUserDataDto = new UpdateUserDataDTO
            {
                PublicInfo = publicInfo,
                PrivateInfo = privateInfo,
            };

            var user = await TestClient.UpdateUserData(updateUserDataDto);
            user.PublicInfo.Should().BeEquivalentTo(publicInfo);
            user = await TestClient.GetUser(username);
            user.PublicInfo.Should().BeEquivalentTo(publicInfo);
        }

        [Fact]
        public async Task UploadPublicPicture_Should_UploadAPicture()
        {
            string username = "Alessio";
            var signUpResponse = await TestClient.SignUp(username);
            TestClient.SetBearer(signUpResponse.Jwt!);
            var response = await TestClient.UploadPicture(PictureFileName);
            response.PictureName.Should().NotBeNullOrEmpty();

            var user = await TestClient.GetUser(username);
            user.PublicInfo.Should().NotBeNull();
            user.PublicInfo!.Pictures.Should().Contain(response.PictureName);
        }

        [Fact]
        public async Task PublicPicture_Should_ReturnTheCorrectPublicPictureFile()
        {
            var username = "Alessio";
            var signUpResponse = await TestClient.SignUp(username);
            TestClient.SetBearer(signUpResponse.Jwt!);
            var uploadPictureResponse = await TestClient.UploadPicture(PictureFileName);

            var getPublicPictureUrl = UserControllerRoutes.PublicPicture(username);
            var queryParameters = new Dictionary<string, string?>
            {
                ["pictureName"] = uploadPictureResponse.PictureName,
            };

            var responseBytes = await TestClient.GetAndParse<byte[]>(getPublicPictureUrl, queryParameters);
            await using var fileStream = File.OpenRead(PictureFileName);
            using var memoryStream = new MemoryStream();
            await fileStream.CopyToAsync(memoryStream);
            var realBytes = memoryStream.ToArray();

            realBytes.Should().BeEquivalentTo(responseBytes);
        }
    }
}

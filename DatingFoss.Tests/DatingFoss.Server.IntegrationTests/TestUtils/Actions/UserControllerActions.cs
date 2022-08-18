using DatingFoss.Server.Controllers.Users.Responses;
using DatingFoss.Server.IntegrationTests.TestUtils.Routes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using DatingFoss.Server.IntegrationTests.TestUtils.Extensions;
using DatingFoss.Server.Controllers.Authorization.Responses;
using DatingFoss.Server.Controllers.Users.Queries;
using DatingFoss.Server.DTOs;
using DatingFoss.Server.IntegrationTests.TestUtils.QueryBuilders;
using DatingFoss.Server.Controllers.Users.DTOs;

namespace DatingFoss.Server.IntegrationTests.TestUtils.Actions
{
    public static class UserControllerActions
    {
        public static async Task<UploadPublicPictureResponseDTO> UploadPicture(this HttpClient @this, string fileName)
        {
            var url = UserControllerRoutes.UploadPublicPicture;
            await using var fileStream = File.OpenRead(fileName);
            using var formData = new MultipartFormDataContent();
            var pictureContent = new StreamContent(fileStream)
            {
                Headers = { ContentType = new MediaTypeHeaderValue("image/png") }
            };

            formData.Add(pictureContent, "Picture", "file.png");

            var response = await @this.PostFormAndParse<UploadPublicPictureResponseDTO>(url, formData);
            return response;
        }

        public static async Task<SignUpResponseDTO> SignUp(this HttpClient @this, string username)
        {
            var signUpQuery = AuthorizationQueryBuilder.GetSignUpQuery(username);

            return await @this.PostAndParse<SignUpResponseDTO>(AuthorizationRoutes.SignUpUrl, signUpQuery);
        }

        public static async Task<UserDTO> GetUser(this HttpClient @this, string username)
        {
            var queryParameters = UserQueryBuilder.BuildGetUserQueryParameters(username);
            var user = await @this.GetAndParse<UserDTO>(UserControllerRoutes.GetUser, queryParameters);
            return user;
        }

        public static async Task<UserDTO> UpdateUserData(this HttpClient @this, UpdateUserDataDTO query)
        {
            var url = UserControllerRoutes.UpdateData;
            var user = await @this.PostAndParse<UserDTO>(url, query);
            return user;
        }
    }
}

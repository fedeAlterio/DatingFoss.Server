using Microsoft.AspNetCore.WebUtilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace DatingFoss.Server.IntegrationTests.TestUtils.Extensions
{
    public static class HttpClientExtensions
    {
        public static async Task<T> PostAndParse<T>(this HttpClient @this, string url, object body)
        {
            var response = await @this.PostAsJsonAsync(url, body);
            return await ParseResponseAs<T>(response);
        }

        public static async Task<T> GetAndParse<T>(this HttpClient @this, string url, Dictionary<string, string?>? queryParameters = null)
        {
            if (queryParameters is not null)
                url = QueryHelpers.AddQueryString(url, queryParameters);
            var response = await @this.GetAsync(url);
            return await ParseResponseAs<T>(response);
        }

        public static async Task<T> PostFormAndParse<T>(this HttpClient @this, string url, MultipartFormDataContent formData)
        {
            var response = await @this.PostAsync(url, formData);
            return await ParseResponseAs<T>(response);
        }


        public static void SetBearer(this HttpClient @this, string bearer)
        {
            @this.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("bearer", bearer);
        }

        private static async Task<T> ParseResponseAs<T>(HttpResponseMessage response)
        {
            var content = response.Content;
            if (typeof(T).IsAssignableFrom(typeof(byte[])))
            {
                await using var stream = await content.ReadAsStreamAsync();
                using var memoryStream = new MemoryStream();
                await stream.CopyToAsync(memoryStream);
                return (T) (object) memoryStream.ToArray();
            }
            var contentString = await content.ReadAsStringAsync();
            if (!response.IsSuccessStatusCode)
                throw new InvalidOperationException(response.ToString());

            var serializationOptions = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            };

            return JsonSerializer.Deserialize<T>(contentString, serializationOptions)
                   ?? throw new InvalidOperationException($"Invalid content. Expected {typeof(T)} but json is {contentString}");
        }
    }
}

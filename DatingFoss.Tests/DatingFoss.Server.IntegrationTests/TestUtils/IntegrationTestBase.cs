using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.AspNetCore.WebUtilities;

namespace DatingFoss.Server.IntegrationTests.TestUtils
{
    public class IntegrationTestBase
    {
        protected readonly HttpClient TestClient;

        public IntegrationTestBase()
        {
            var appFactory = new WebApplicationFactory<Program>();
            TestClient = appFactory.CreateClient();
        }
    }
}

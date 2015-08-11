using System.Net.Http;
using Xunit;

namespace WebApiTestsSample.Tests.Controllers
{
    [Collection("InMemoryHosting")]
    public class ValueControllerTests
    {
        private readonly HttpServerFixture httpServerFixture;

        public ValueControllerTests(HttpServerFixture fixture)
        {
            httpServerFixture = fixture;
        }

        [Fact]
        public async void TestValues()
        {
            using (HttpClient client = httpServerFixture.CreateServer())
            {
                HttpRequestMessage request = httpServerFixture.CreateRequest("api/values", "application/json", new HttpMethod("GET"));
                using (HttpResponseMessage response = await client.SendAsync(request))
                {
                    Assert.NotNull(response);
                }
            }
        }
    }
}
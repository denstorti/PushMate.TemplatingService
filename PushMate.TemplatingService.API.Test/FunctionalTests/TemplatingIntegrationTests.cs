using Microsoft.AspNetCore.Mvc.Testing;
using System.Threading.Tasks;
using Xunit;

namespace PushMate.TemplatingService.API.Test
{
    public class TemplatingIntegrationTests: IClassFixture<WebApplicationFactory<Startup>>
    {
        private readonly WebApplicationFactory<Startup> _factory;

        public TemplatingIntegrationTests(WebApplicationFactory<Startup> factory)
        {
            _factory = factory;
        }

        [Theory]
        [InlineData("/api/templating?templateText=Hi%20$name$&name=Joao", "Hi Joao")]
        [InlineData("/api/templating?templateText=Hi%20$name$%20your%20balance%20is%20$balance$&name=Joao&balance=1000", "Hi Joao your balance is 1000")]
        public async Task ShouldGetSuccessfulyWebAPIAsync(string url, string expected)
        {
            var client = _factory.CreateClient();

            // Act
            var response = await client.GetAsync(url);
            string result = response.Content.ReadAsStringAsync().Result;

            Assert.Equal("OK", response.StatusCode.ToString());
            Assert.Equal(expected, result);
        }


    }
}

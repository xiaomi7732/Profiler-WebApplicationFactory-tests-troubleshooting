using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Testing;
using TargetWebAPI2;
using Xunit;

namespace UnitTestsNet3
{
    [Collection("#1")]
    public class UnitTest3 : IClassFixture<WebApplicationFactory<TargetWebAPI2.Startup>>
    {
        private readonly WebApplicationFactory<Startup> _factory;

        public UnitTest3(WebApplicationFactory<TargetWebAPI2.Startup> factory)
        {
            _factory = factory ?? throw new ArgumentNullException(nameof(factory));
        }

        [Theory]
        [InlineData("/Weatherforecast")]
        public async Task Get_EndpointsReturnSuccessAndCorrectContentType(string url)
        {
            // Arrange
            var client = _factory.CreateClient();

            // Act
            var response = await client.GetAsync(url);

            // Assert
            response.EnsureSuccessStatusCode(); // Status Code 200-299
            Assert.Equal("application/json; charset=utf-8",
                response.Content.Headers.ContentType.ToString());
        }
    }
}

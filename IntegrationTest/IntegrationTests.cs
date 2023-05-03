using Microsoft.AspNetCore.Mvc.Testing;
using System.Net;

namespace IntegrationTest
{
    public class IntegrationTests
    {
        [Fact]
        public async void Test()
        {
            //Arrange

            var webHost = new WebApplicationFactory<Program>();
            var client = webHost.CreateClient();

            //Act

            var response = await client.GetAsync("/test");

            //Assert

            Assert.NotNull(response);
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);

        }
    }
}
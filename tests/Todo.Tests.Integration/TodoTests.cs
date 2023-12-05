using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Testing;
using System.Net;

namespace Todo.Tests.Integration
{
    public class TodoTests : IClassFixture<WebApplicationFactory<Api.Program>>
    {
        private readonly HttpClient _httpClient;
        public TodoTests(WebApplicationFactory<Api.Program> factory)
        {
            _httpClient = factory.CreateDefaultClient();
        }

        [Fact]
        public async Task CanGetListOfAllTodos()
        {
            var response = await _httpClient.GetAsync("api/todos");

            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
            Assert.Equal("application/json", response.Content.Headers.ContentType?.MediaType);
            Assert.True(response.Content.Headers.ContentLength > 0);
        }

        [Fact]
        public async Task GettingAllTodosReturnsCorrectData()
        {
            // TODO: Validate response data
        }
    }
}

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
            var expected = """
                [{"name":"Tvätta","descrption":"...","done":false,"id":1},{"name":"Städa","descrption":"...","done":false,"id":2},{"name":"Diska","descrption":"...","done":false,"id":3}]
                """;
            var response = await _httpClient.GetAsync("api/todos");
            var actual = await response.Content.ReadAsStringAsync();

            Assert.Equal(expected, actual);

            // This is a bit brittle and could be made more clever
            // One approach would be to validate that we can deserialise the json back into a list of TodoItems (or custom test-model)
            // We could then also validate values on these objects
        }
    }
}

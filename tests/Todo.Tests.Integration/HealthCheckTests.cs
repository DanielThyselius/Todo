using Microsoft.AspNetCore.Mvc.Testing;
using System.Net;
namespace Todo.Tests.Integration;

public class HealthCheckTests :IClassFixture<WebApplicationFactory<Api.Program>>
{
    private readonly HttpClient _httpClient;
    public HealthCheckTests(WebApplicationFactory<Api.Program> factory)
    {
        _httpClient = factory.CreateDefaultClient();
    }

    [Fact]
    public async Task HealthCheckReturnsHealthyAsync()
    {
        var response = await _httpClient.GetAsync("api/healthcheck");

        response.EnsureSuccessStatusCode();

        //Assert.Equal(HttpStatusCode.OK, response.StatusCode);
    }
}
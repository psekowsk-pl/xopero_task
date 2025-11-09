using Flurl.Http;

namespace XOPERO_task.API_Tests;

public class PostUser : IClassFixture<APIFixture>
{
    private readonly APIFixture _fixture;
    private string _baseUrl = string.Empty;

    public PostUser(APIFixture fixture)
    {
        _fixture = fixture;
        _baseUrl += _fixture.BaseUrl + "/api/users";
    }

    [Fact]
    public async Task PostUser_CreateUser_201()
    {
        // Act
        var response = await $"{_baseUrl}"
            .WithHeader(_fixture.HeaderKey, _fixture.HeaderValue)
            .PostAsync();

        // Assert
        Assert.Equal(201, response.StatusCode);
    }
}

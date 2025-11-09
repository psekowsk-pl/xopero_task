using Flurl.Http;

namespace XOPERO_task.API_Tests;

public class GetUser : IClassFixture<APIFixture>
{
    private readonly APIFixture _fixture;
    private string _baseUrl = string.Empty;

    public GetUser(APIFixture fixture)
    {
        _fixture = fixture;
        _baseUrl += _fixture.BaseUrl + "/api/users";
    }

    [Fact]
    public async Task GetUser_GetUserById_200()
    {
        // Arrange
        int userId = 2;
        var expectedUsersDto = await UserExtension.GetUserData(_fixture, _baseUrl);
        var expectedUser = expectedUsersDto.Data.FirstOrDefault(x => x.Id == userId)!;

        // Act
        var response = await $"{_baseUrl}/{userId}"
            .WithHeader(_fixture.HeaderKey, _fixture.HeaderValue)
            .GetAsync();
        var result = await response.GetJsonAsync<UserResponseDto>();

        // Assert
        Assert.Equal(200, response.StatusCode);
        Assert.NotNull(result);
        Assert.Equal(expectedUser.Email, result.Data.Email);
        Assert.Equal(expectedUser.FirstName, result.Data.FirstName);
        Assert.Equal(expectedUser.LastName, result.Data.LastName);
        Assert.Equal(expectedUser.Avatar, result.Data.Avatar);
    }
}

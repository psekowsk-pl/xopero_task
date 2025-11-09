using Flurl.Http;

namespace XOPERO_task.API_Tests;

public static class UserExtension
{
    public async static Task<UserResponseMultiDto> GetUserData(APIFixture apiFixture, string url)
    {
        var result = await url
            .WithHeader(apiFixture.HeaderKey, apiFixture.HeaderValue)
            .GetJsonAsync<UserResponseMultiDto>();

        return result;
    }
}

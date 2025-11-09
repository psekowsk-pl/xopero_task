using Microsoft.Extensions.Configuration;
using XOPERO_task.Common.Helpers;
using XOPERO_task.UI_Tests;

namespace XOPERO_task.API_Tests;

public class APIFixture : IAsyncLifetime
{
    public string BaseUrl = string.Empty;
    public string HeaderKey = string.Empty;
    public string HeaderValue = string.Empty;

    public async Task InitializeAsync()
    {
        // Load configuration
        var config = await JsonDataHelper.LoadFromFileAsync<APIConfiguration>(DirectoryHelper.APIConfigurationPath);
        BaseUrl = config.BaseUrl;

        // Load ApiKey
        var secrets = new APISecretsProvider();
        HeaderKey = secrets.ApiKey;
        HeaderValue = secrets.ApiValue;
    }

    public async Task DisposeAsync() => await Task.CompletedTask;
}

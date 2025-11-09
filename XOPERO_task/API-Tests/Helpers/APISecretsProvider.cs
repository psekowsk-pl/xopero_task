using Microsoft.Extensions.Configuration;

namespace XOPERO_task.UI_Tests;

public class APISecretsProvider
{
    private readonly IConfiguration _config;

    public APISecretsProvider()
    {
        _config = new ConfigurationBuilder()
            .AddUserSecrets<APISecretsProvider>()
            .Build();
    }

    public string ApiKey => _config["ApiKey"]!;
    public string ApiValue => _config["ApiValue"]!;
}

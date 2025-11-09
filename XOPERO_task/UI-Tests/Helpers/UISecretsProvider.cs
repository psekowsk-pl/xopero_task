using Microsoft.Extensions.Configuration;

namespace XOPERO_task.UI_Tests;

public class UISecretsProvider
{
    private readonly IConfiguration _config;

    public UISecretsProvider()
    {
        _config = new ConfigurationBuilder()
            .AddUserSecrets<APISecretsProvider>()
            .Build();
    }

    public string Login => _config["Login"]!;
    public string Password => _config["Password"]!;
}

using Microsoft.Extensions.Configuration;

namespace XOPERO_task.UI_Tests.UI;

public class SecretsProvider
{
    private readonly IConfiguration _config;

    public SecretsProvider()
    {
        _config = new ConfigurationBuilder()
            .AddUserSecrets<SecretsProvider>()
            .Build();
    }

    public string Login => _config["Login"]!;
    public string Password => _config["Password"]!;
}

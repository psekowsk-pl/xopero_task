using Microsoft.Playwright;

namespace XOPERO_task.UI_Tests.UI;

public class HomePage
{
    private readonly IPage _page;

    public HomePage(IPage page)
    {
        _page = page;
    }

    public ILocator TitleLabel => _page.Locator(".login_logo");
    public ILocator LoginInput => _page.Locator("#user-name");
    public ILocator PasswordInput => _page.Locator("#password");
    public ILocator LoginButton => _page.Locator("#login-button");
    public ILocator LoginErrorLabel => _page.Locator(".error-message-container");

    public async Task LoginAsync(string login, string password)
    {
        await LoginInput.FillAsync(login);
        await PasswordInput.FillAsync(password);
        await LoginButton.ClickAsync();
    }

    public async Task LoginAsync(SecretsProvider secretsProvider)
    {
        await LoginInput.FillAsync(secretsProvider.Login);
        await PasswordInput.FillAsync(secretsProvider.Password);
        await LoginButton.ClickAsync();
    }
}

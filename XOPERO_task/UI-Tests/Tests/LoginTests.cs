using Microsoft.Playwright;

namespace XOPERO_task.UI_Tests.UI;

public class LoginTests : IClassFixture<PlaywrightFixture>, IAsyncLifetime
{
    private readonly PlaywrightFixture _fixture;
    private IPage _page = null!;
    private HomePage _homePage = null!;
    private ProductsPage _productsPage = null!;

    public LoginTests(PlaywrightFixture fixture)
    {
        _fixture = fixture;
    }

    public async Task InitializeAsync()
    {
        _page = await _fixture.CreateNewPageAsync();
        _homePage = new(_page);
        _productsPage = new(_page);
    }

    public async Task DisposeAsync()
    {
        await _page.CloseAsync();
    }

    [Fact]
    public async Task LogInWithCorrectCredentials()
    {
        Assert.True(await _homePage.TitleLabel.IsVisibleAsync());

        await _homePage.LoginAsync(new SecretsProvider());

        Assert.True(await _productsPage.BasketButton.IsVisibleAsync());
    }

    [Fact]
    public async Task LogInWithIncorrectCredentials()
    {
        Assert.True(await _homePage.TitleLabel.IsVisibleAsync());

        await _homePage.LoginAsync("not_existing_user", "not_existing_user_password");

        Assert.Contains("Epic sadface: Username and password do not match any user in this service", await _homePage.LoginErrorLabel.TextContentAsync());
    }
}

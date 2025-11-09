using Microsoft.Playwright;
using XOPERO_task.Common.Helpers;

namespace XOPERO_task.UI_Tests;

public class PlaywrightFixture : IAsyncLifetime
{
    protected IPlaywright Playwright { get; private set; } = default!;
    protected IBrowser Browser { get; private set; } = default!;
    private string BaseUrl = string.Empty;

    public async Task InitializeAsync()
    {
        // Load configuration
        var config = await JsonDataHelper.LoadFromFileAsync<UIConfiguration>(DirectoryHelper.UIConfigurationPath);
        BaseUrl = config.BaseUrl;

        // Launch Playwright & Browser
        Playwright = await Microsoft.Playwright.Playwright.CreateAsync();

        IBrowserType browserType = config.Browser.ToLower() switch
        {
            "firefox" => Playwright.Firefox,
            "webkit" => Playwright.Webkit,
            _ => Playwright.Chromium
        };

        Browser = await browserType.LaunchAsync(new BrowserTypeLaunchOptions
        {
            Headless = config.Headless
        });
    }

    public async Task<IPage> CreateNewPageAsync()
    {
        var context = await Browser.NewContextAsync();
        var page =  await context.NewPageAsync();
        await page.GotoAsync(BaseUrl);

        return page;
    }

    public async Task DisposeAsync()
    {
        await Browser.CloseAsync();
        Playwright.Dispose();
    }

    private class UIConfiguration
    {
        public string BaseUrl { get; set; } = null!;
        public bool Headless { get; set; }
        public string Browser { get; set; } = null!;
    }
}

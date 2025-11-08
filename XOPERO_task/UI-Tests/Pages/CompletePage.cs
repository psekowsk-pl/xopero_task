using Microsoft.Playwright;

namespace XOPERO_task.UI_Tests.UI;

public class CompletePage
{
    private readonly IPage _page;

    public CompletePage(IPage page)
    {
        _page = page;
    }

    public ILocator ThankYouHeaderLabel => _page.Locator("h2.complete-header");
    public ILocator ThankYouTextLabel => _page.Locator("div.complete-text");
    public ILocator BackHomeButton => _page.Locator("#back-to-products");
}

using Microsoft.Playwright;

namespace XOPERO_task.UI_Tests.UI;

public class OverviewPage
{
    private readonly IPage _page;

    public OverviewPage(IPage page)
    {
        _page = page;
    }
    public ILocator CancelButton => _page.Locator("#cancel");
    public ILocator FinishButton => _page.Locator("#finish");

    public ILocator GetInventoryItem(ProductDto _productDto)
    {
        var locator = "//div[@class='cart_item']";
        if (_productDto.Title != null) locator += $"[.//*[contains(@data-test,'inventory-item-name')][normalize-space()=\"{_productDto.Title}\"]]";
        if (_productDto.Description != null) locator += $"[.//*[contains(@data-test,'inventory-item-desc')][normalize-space()=\"{_productDto.Description}\"]]";
        if (_productDto.Price != null) locator += $"[.//*[contains(@data-test,'inventory-item-price')][normalize-space()=\"{_productDto.Price}\"]]";

        return _page.Locator(locator);
    }
}

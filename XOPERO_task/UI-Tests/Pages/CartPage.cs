using Microsoft.Playwright;

namespace XOPERO_task.UI_Tests;
public class CartPage
{
    private readonly IPage _page;

    public CartPage(IPage page)
    {
        _page = page;
    }
    public ILocator ContinueShoppingButton => _page.Locator("#continue-shopping");
    public ILocator CheckoutButton => _page.Locator("#checkout");

    public ILocator GetInventoryItem(ProductDto _productDto)
    {
        var locator = "//div[@class='cart_item']";
        if (_productDto.Title != null) locator += $"[.//*[contains(@data-test,'inventory-item-name')][normalize-space()=\"{_productDto.Title}\"]]";
        if (_productDto.Description != null) locator += $"[.//*[contains(@data-test,'inventory-item-desc')][normalize-space()=\"{_productDto.Description}\"]]";
        if (_productDto.Price != null) locator += $"[.//*[contains(@data-test,'inventory-item-price')][normalize-space()=\"{_productDto.Price}\"]]";

        return _page.Locator(locator);
    }

    public ILocator GetInventoryItemRemoveButton(ProductDto _productDto)
    {
        var locator = GetInventoryItem(_productDto);

        return locator.Locator("//button[normalize-space()='Remove']");
    }
}


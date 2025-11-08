using Microsoft.Playwright;

namespace XOPERO_task.UI_Tests.UI;

public class ProductsPage
{
    private readonly IPage _page;

    public ProductsPage(IPage page)
    {
        _page = page;
    }
    public ILocator BasketButton => _page.Locator("//a[contains(@data-test,'shopping-cart-link')]");

    public ILocator GetInventoryItem(ProductDto _productDto)
    {
        var locator = "//div[@class='inventory_item']";
        if (_productDto.Title != null) locator += $"[.//*[contains(@data-test,'inventory-item-name')][normalize-space()=\"{_productDto.Title}\"]]";
        if (_productDto.Description != null) locator += $"[.//*[contains(@data-test,'inventory-item-desc')][normalize-space()=\"{_productDto.Description}\"]]";
        if (_productDto.Price != null) locator += $"[.//*[contains(@data-test,'inventory-item-price')][normalize-space()=\"{_productDto.Price}\"]]";
        
        return _page.Locator(locator);
    }

    public ILocator GetInventoryItemAddToCartButton(ProductDto _productDto)
    {
        var locator = GetInventoryItem(_productDto);

        return locator.Locator("//button[normalize-space()=\"Add to cart\"]");
    }
}

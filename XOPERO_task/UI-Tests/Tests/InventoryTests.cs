using Microsoft.Playwright;
using XOPERO_task.Common.Helpers;

namespace XOPERO_task.UI_Tests;

public class InventoryTests : IClassFixture<PlaywrightFixture>, IAsyncLifetime
{
    private readonly PlaywrightFixture _fixture;
    private IPage _page = null!;
    private HomePage _homePage = null!;
    private ProductsPage _productsPage = null!;
    private CartPage _cartPage = null!;
    private List<ProductDto> _productsDto = null!;

    public InventoryTests(PlaywrightFixture fixture)
    {
        _fixture = fixture;
        _productsDto = new List<ProductDto>();
    }

    public async Task InitializeAsync()
    {
        _page = await _fixture.CreateNewPageAsync();
        _homePage = new(_page);
        _productsPage = new ProductsPage(_page);
        _cartPage = new CartPage(_page);
    }

    public async Task DisposeAsync()
    {
        await _page.CloseAsync();
    }

    [Fact]
    public async Task AddProductToBasketAndVerifyIt()
    {
        // Login
        Assert.True(await _homePage.TitleLabel.IsVisibleAsync());

        _productsDto = await JsonDataHelper.LoadFromFileAsync<List<ProductDto>>(DirectoryHelper.UIProductsDataPath);

        await _homePage.LoginAsync(new UISecretsProvider());

        // Add item to basket
        Assert.True(await _productsPage.GetInventoryItem(_productsDto.First()).IsVisibleAsync());
        await _productsPage.GetInventoryItemAddToCartButton(_productsDto.First()).ClickAsync();
        await _productsPage.BasketButton.ClickAsync();

        // Verify basket
        Assert.True(await _cartPage.GetInventoryItem(_productsDto.First()).IsVisibleAsync());
    }

    [Fact]
    public async Task AddRandomProductsToBasketAndVerifyThem()
    {
        // Login
        var elementIndexes = ValueGeneratorHelper.GetRandomNumbersArray(minLength: 0, maxLength: 5, numberOfElements: 3);
        Assert.True(await _homePage.TitleLabel.IsVisibleAsync());

        _productsDto = await JsonDataHelper.LoadFromFileAsync<List<ProductDto>>(DirectoryHelper.UIProductsDataPath);

        await _homePage.LoginAsync(new UISecretsProvider());

        // Add item to basket
        foreach (var index in elementIndexes)
        {
            Assert.True(await _productsPage.GetInventoryItem(_productsDto[index]).IsVisibleAsync());
            await _productsPage.GetInventoryItemAddToCartButton(_productsDto[index]).ClickAsync();
        }

        await _productsPage.BasketButton.ClickAsync();

        // Verify basket
        foreach (var index in elementIndexes)
        {
            Assert.True(await _cartPage.GetInventoryItem(_productsDto[index]).IsVisibleAsync());
        }
    }
}

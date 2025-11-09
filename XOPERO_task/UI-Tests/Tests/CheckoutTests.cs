using Microsoft.Playwright;
using XOPERO_task.Common.Helpers;

namespace XOPERO_task.UI_Tests;

public class CheckoutTests : IClassFixture<PlaywrightFixture>, IAsyncLifetime
{
    private readonly PlaywrightFixture _fixture;
    private IPage _page = null!;
    private HomePage _homePage = null!;
    private ProductsPage _productsPage = null!;
    private CartPage _cartPage = null!;
    private YourInformationPage _yourInformationPage = null!;
    private OverviewPage _overviewPage = null!;
    private CompletePage _completePage = null!;
    private List<ProductDto> _productsDto;

    public CheckoutTests(PlaywrightFixture fixture)
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
        _yourInformationPage = new YourInformationPage(_page);
        _overviewPage = new OverviewPage(_page);
        _completePage = new CompletePage(_page);
    }

    public async Task DisposeAsync()
    {
        await _page.CloseAsync();
    }

    [Fact]
    public async Task AddProductAndFinishOrder()
    {
        // Login
        Assert.True(await _homePage.TitleLabel.IsVisibleAsync());

        _productsDto = await JsonDataHelper.LoadFromFileAsync<List<ProductDto>>(DirectoryHelper.UIProductsDataPath);

        await _homePage.LoginAsync(new UISecretsProvider());

        // Add item to basket
        Assert.True(await _productsPage.GetInventoryItem(_productsDto.First()).IsVisibleAsync());
        await _productsPage.GetInventoryItemAddToCartButton(_productsDto.First()).ClickAsync();
        await _productsPage.BasketButton.ClickAsync();

        // Checkout
        Assert.True(await _cartPage.GetInventoryItem(_productsDto.First()).IsVisibleAsync());
        await _cartPage.CheckoutButton.ClickAsync();

        var clientsData = await JsonDataHelper.LoadFromFileAsync<ClientsDataDto>(DirectoryHelper.UIClientsDataPath);
        await _yourInformationPage.FillAndContinueAsync(clientsData);
        
        Assert.True(await _overviewPage.GetInventoryItem(_productsDto.First()).IsVisibleAsync());
        await _overviewPage.FinishButton.ClickAsync();

        Assert.Contains("Thank you for your order!", await _completePage.ThankYouHeaderLabel.TextContentAsync());
        Assert.Contains("Your order has been dispatched, and will arrive just as fast as the pony can get there!", await _completePage.ThankYouTextLabel.TextContentAsync());
    }
}

using Microsoft.Playwright;

namespace XOPERO_task.UI_Tests;

public class YourInformationPage
{
    private readonly IPage _page;

    public YourInformationPage(IPage page)
    {
        _page = page;
    }

    public ILocator TitleLabel => _page.Locator(".login_logo");
    public ILocator FirstNameInput => _page.Locator("#first-name");
    public ILocator LastNameInput => _page.Locator("#last-name");
    public ILocator PostalCodeInput => _page.Locator("#postal-code");
    public ILocator CancelButton => _page.Locator("#cancel");
    public ILocator ContinueButton => _page.Locator("#continue");

    public async Task FillAndContinueAsync(ClientsDataDto clientsData)
    {
        await FirstNameInput.FillAsync(clientsData.FirstName);
        await LastNameInput.FillAsync(clientsData.LastName);
        await PostalCodeInput.FillAsync(clientsData.PostalCode);
        await ContinueButton.ClickAsync();
    }
}

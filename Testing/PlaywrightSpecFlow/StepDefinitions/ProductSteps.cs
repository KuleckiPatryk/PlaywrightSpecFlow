using PlaywrightSpecFlow.Pages;
using TechTalk.SpecFlow;
using static Microsoft.Playwright.Assertions;

namespace PlaywrightSpecFlow.StepDefinitions
{
    [Binding]
    public class ProductSteps(ProductPage page)
    {
        [Then(@"User should be on products page")]
        public async Task CheckOnProductsPage()
        {
            await Expect(page.GetInventoryContainer()).ToBeVisibleAsync().ConfigureAwait(false);
        }
        
        [Then(@"User should not be on products page")]
        public async Task CheckNotOnProductsPage()
        {
            await Expect(page.GetInventoryContainer()).Not.ToBeVisibleAsync().ConfigureAwait(false);
        }
    }
}

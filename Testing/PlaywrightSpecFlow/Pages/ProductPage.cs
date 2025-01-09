using Microsoft.Playwright;

namespace PlaywrightSpecFlow.Pages
{
    public class ProductPage : BasePage
    {
        private ILocator InventoryContainer => Page.Locator("#inventory_container.inventory_container");

        public ProductPage(IPage page) : base(page)
        {
        }

        public ILocator GetInventoryContainer()
        {
            return InventoryContainer;
        }
    }
}

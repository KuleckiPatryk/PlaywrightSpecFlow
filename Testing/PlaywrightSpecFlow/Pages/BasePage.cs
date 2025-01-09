using Microsoft.Playwright;

namespace PlaywrightSpecFlow.Pages
{
    public class BasePage
    {
        protected IPage Page { get; set; }

        public BasePage(IPage page)
        {
            Page = page;
        }
    }
}
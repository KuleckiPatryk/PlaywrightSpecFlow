using Microsoft.Playwright;
using PlaywrightSpecFlow.Configuration.Settings;
using PlaywrightSpecFlow.Pages;
using TechTalk.SpecFlow;

namespace PlaywrightSpecFlow.StepDefinitions
{
    [Binding]
    public class LoginSteps(ISettings settings, IPage page)
    {
        [Given(@"User opens products page as a normal user")]
        public async Task OpenProductsPageAsNormalUser()
        {
            var userName = settings.UsersSettings.Admin;
            var password = settings.UsersSettings.AdminPwd;

            await Login(userName, password).ConfigureAwait(false);
        }
        
        [Given(@"User opens products page as a locked out user")]
        public async Task OpenProductsPageAsLockedOutUser()
        {
            var userName = settings.UsersSettings.User;
            var password = settings.UsersSettings.UserPwd;

            await Login(userName, password).ConfigureAwait(false);
        }

        private async Task Login(string userName, string password)
        {
            var loginPage = new LoginPage(page);
            await loginPage.OpenPage().ConfigureAwait(false);
            
            await loginPage.SetUsername(userName).ConfigureAwait(false);
            await loginPage.SetPassword(password).ConfigureAwait(false);
            await loginPage.ClickLogin().ConfigureAwait(false);
        }
    }
}

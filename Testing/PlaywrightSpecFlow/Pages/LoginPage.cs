using Microsoft.Playwright;

namespace PlaywrightSpecFlow.Pages
{
    public class LoginPage : BasePage
    {
        private ILocator UsernameInput => Page.GetByRole(AriaRole.Textbox, new PageGetByRoleOptions { Name = "Username" });

        private ILocator PasswordInput => Page.GetByRole(AriaRole.Textbox, new PageGetByRoleOptions { Name = "Password" });

        private ILocator LoginButton => Page.GetByRole(AriaRole.Button, new PageGetByRoleOptions { Name = "Login" });

        public LoginPage(IPage page) : base(page)
        {
        }

        public async Task OpenPage() => await Page.GotoAsync(string.Empty, new PageGotoOptions { Timeout = 60000 })
            .ConfigureAwait(false);

        public Task SetUsername(string username)
        {
            return UsernameInput.FillAsync(username);
        }

        public Task SetPassword(string password)
        {
            return PasswordInput.FillAsync(password);
        }

        public Task ClickLogin()
        {
            return LoginButton.ClickAsync();
        }
    }
}

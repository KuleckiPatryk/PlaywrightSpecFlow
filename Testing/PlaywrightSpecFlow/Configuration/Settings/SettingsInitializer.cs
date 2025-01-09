using BoDi;
using Microsoft.Extensions.Configuration;
using TechTalk.SpecFlow;

namespace PlaywrightSpecFlow.Configuration.Settings
{
    [Binding]
    public class SettingsInitializer
    {
        private readonly IObjectContainer _objectContainer;

        public SettingsInitializer(IObjectContainer container)
        {
            _objectContainer = container;
        }

        [Before(Order = (int)InitializationOrder.Settings)]
        public void Initialize()
        {
            var config = new ConfigurationBuilder()
                .AddJsonFile("settings.json", true)
                .AddUserSecrets<Models.Settings>(true)
                .Build();

            var settings = new Models.Settings();
            config.GetSection(nameof(Settings)).Bind(settings);

            _objectContainer.RegisterInstanceAs<ISettings>(settings);
        }
    }
}

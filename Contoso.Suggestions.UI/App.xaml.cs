using Contoso.Suggestions.Core.Services;
using Contoso.Suggestions.UI.Services;
using Xamarin.Forms;

namespace Contoso.Suggestions.UI
{
    public partial class App : Application
    {

        public App()
        {
            InitializeComponent();

            DependencyService.Register<MockDataStore>();
            DependencyService.Register<NavigationService>();
        }

        protected override async void OnStart()
        {
            var nav = DependencyService.Get<NavigationService>();
            await nav.HomeAsync();
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
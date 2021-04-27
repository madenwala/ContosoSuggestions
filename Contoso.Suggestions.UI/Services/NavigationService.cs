using Contoso.Suggestions.Core.Models;
using Contoso.Suggestions.Core.Services;
using Contoso.Suggestions.Core.ViewModels;
using Contoso.Suggestions.UI.Views;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Contoso.Suggestions.UI.Services
{

    public sealed class NavigationService: INavigationService
    {
        #region Properties

        public bool Authenticated { get; set; }

        private INavigation Navigation
        {
            get
            {
                if (Application.Current.MainPage is TabbedPage tabPage)
                {
                    return tabPage.CurrentPage.Navigation;
                }
                else if (Application.Current.MainPage is FlyoutPage flyPage)
                {
                    if (flyPage.Detail is TabbedPage flyTabbedPage)
                        return flyTabbedPage.CurrentPage.Navigation;
                    else
                        return flyPage.Detail.Navigation;
                }
                else
                {
                    return Application.Current.MainPage?.Navigation;
                }
            }
        }

        #endregion

        #region Methods

        public async Task HomeAsync()
        {
            if (Application.Current.MainPage is null)
                Application.Current.MainPage = Authenticated ? new AppShell() : new NavigationPage(new WelcomePage());
            else if (Shell.Current is null && Authenticated)
                Application.Current.MainPage = new AppShell();
            else if (Shell.Current is not null && Authenticated is false)
                Application.Current.MainPage = new NavigationPage(new WelcomePage());
            else if (Navigation is INavigation nav)
                await nav.PopToRootAsync();
        }

        public async Task GoBackAsync()
        {
            if (Shell.Current is not null)
                await Shell.Current.GoToAsync(".."); // This will pop the current page off the navigation stack
            else if (Navigation is INavigation nav)
                await nav.PopAsync();
        }

        public async Task AddItemAsync()
        {
            await Shell.Current.GoToAsync(nameof(NewItemPage));
        }

        public async Task ItemDetails(Item item)
        {
            if (item == null)
                return;

            // This will push the ItemDetailPage onto the navigation stack
            await Shell.Current.GoToAsync($"{nameof(ItemDetailPage)}?{nameof(ItemDetailViewModel.ItemId)}={item.Id}");
        }

        public Task AboutAsync()
        {
            if (Authenticated)
                return Shell.Current.GoToAsync($"//{nameof(AboutPage)}"); // Prefixing with `//` switches to a different navigation stack instead of pushing to the active one
            else
                return Navigation.PushAsync(new AboutPage());
        }

        public Task LoginAsync()
        {
            if (Authenticated is false)
                return Navigation.PushAsync(new LoginPage());
            else
                return HomeAsync();
            //await Shell.Current.GoToAsync($"//{nameof(LoginPage)}");
        }

        public Task LogoutAsync()
        {
            Authenticated = false;
            return HomeAsync();
        }

        //public Task Report()
        //{
        //    return Navigation.PushAsync(new ItemPage());
        //}

        #endregion
    }
}
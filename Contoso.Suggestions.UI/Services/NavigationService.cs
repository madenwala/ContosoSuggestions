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
                Application.Current.MainPage = new AppShell(); //new NavigationPage(new MainView());
            else if (Navigation is INavigation nav)
                await nav.PopToRootAsync();
        }

        public async Task GoBackAsync()
        {
            await Shell.Current.GoToAsync("..");
            //await Navigation.PopAsync();
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

        public async Task AboutAsync()
        {
            // Prefixing with `//` switches to a different navigation stack instead of pushing to the active one
            await Shell.Current.GoToAsync($"//{nameof(AboutPage)}");
        }

        //public Task Report()
        //{
        //    return Navigation.PushAsync(new ItemPage());
        //}

        //public void DialPhone(string number)
        //{
        //    try
        //    {
        //        PhoneDialer.Open(number);
        //    }
        //    catch (ArgumentNullException)
        //    {
        //        // Number was null or white space
        //    }
        //    catch (FeatureNotSupportedException)
        //    {
        //        // Phone Dialer is not supported on this device.
        //    }
        //    catch (Exception)
        //    {
        //        // Other error has occurred.
        //    }
        //}

        #endregion
    }
}
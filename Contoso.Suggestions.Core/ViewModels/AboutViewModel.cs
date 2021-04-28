using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.CommunityToolkit.ObjectModel;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace Contoso.Suggestions.Core.ViewModels
{
    public sealed class AboutViewModel : BaseViewModel
    {
        public ICommand OpenWebCommand { get; }

        private AsyncCommand _LogoutCommand;
        public ICommand LogoutCommand => _LogoutCommand ??= new(LogoutAsync);

        public AboutViewModel()
        {
            Title = "About";
            OpenWebCommand = new Command(async () => await Browser.OpenAsync("https://aka.ms/xamarin-quickstart"));
        }

        private Task LogoutAsync()
        {
            try
            {
                IsBusy = true;
                return Navigation.LogoutAsync();
            }
            finally
            {
                IsBusy = false;
            }
        }
    }
}
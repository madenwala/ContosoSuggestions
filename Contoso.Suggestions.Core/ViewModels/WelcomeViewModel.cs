using Contoso.Suggestions.Core.Services;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.CommunityToolkit.ObjectModel;
using Xamarin.Forms;

namespace Contoso.Suggestions.Core.ViewModels
{
    public sealed class WelcomeViewModel : BaseViewModel
    {
        private readonly INavigationService _nav = DependencyService.Get<INavigationService>();

        private AsyncCommand _AboutCommand;
        public ICommand AboutCommand => _AboutCommand ??= new(_nav.AboutAsync);

        private AsyncCommand _LoginCommand;
        public ICommand LoginCommand => _LoginCommand ??= new(LoginAsync);

        public WelcomeViewModel()
        {
            Title = "Welcome to Contoso!";
        }

        private Task LoginAsync()
        {
            try
            {
                IsBusy = true;
                return _nav.LoginAsync();
            }
            finally
            {
                IsBusy = false;
            }
        }
    }
}
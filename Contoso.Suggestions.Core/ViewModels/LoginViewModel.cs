using Contoso.Suggestions.Core.Services;
using Xamarin.Forms;

namespace Contoso.Suggestions.Core.ViewModels
{
    public class LoginViewModel : BaseViewModel
    {
        private readonly INavigationService _nav = DependencyService.Get<INavigationService>();

        public Command LoginCommand { get; }

        public LoginViewModel()
        {
            LoginCommand = new Command(OnLoginClicked);
        }

        private async void OnLoginClicked(object obj)
        {
            await _nav.AboutAsync();
        }
    }
}
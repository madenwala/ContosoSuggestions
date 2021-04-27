using Contoso.Suggestions.Core.Services;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.CommunityToolkit.ObjectModel;
using Xamarin.Forms;

namespace Contoso.Suggestions.Core.ViewModels
{
    public class LoginViewModel : BaseViewModel
    {
        private readonly INavigationService _nav = DependencyService.Get<INavigationService>();

        private AsyncCommand _LoginCommand;
        public ICommand LoginCommand => _LoginCommand ??= new(LoginAsync);

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
using System.Windows.Input;
using Xamarin.CommunityToolkit.ObjectModel;

namespace Contoso.Suggestions.Core.ViewModels
{
    public sealed class WelcomeViewModel : BaseViewModel
    {
        #region Properties

        private AsyncCommand _AboutCommand;
        public ICommand AboutCommand => _AboutCommand ??= new(Navigation.AboutAsync);

        private AsyncCommand _LoginCommand;
        public ICommand LoginCommand => _LoginCommand ??= new(Navigation.LoginAsync);

        #endregion

        #region Constructors

        public WelcomeViewModel()
        {
            Title = "Welcome to Contoso!";
        }

        #endregion
    }
}
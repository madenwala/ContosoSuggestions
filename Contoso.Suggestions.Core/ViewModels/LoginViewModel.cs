using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.CommunityToolkit.ObjectModel;

namespace Contoso.Suggestions.Core.ViewModels
{
    public sealed class LoginViewModel : BaseViewModel
    {
        #region Properties

        private AsyncCommand _SubmitCommand;
        public ICommand SubmitCommand => _SubmitCommand ??= new(SubmitAsync);

        #endregion

        #region Constructors

        public LoginViewModel()
        {
            Title = "Login to Contoso";
        }

        #endregion

        #region Methods

        private Task SubmitAsync()
        {
            try
            {
                IsBusy = true;
                Navigation.Authenticated = true;
                return Navigation.HomeAsync();
            }
            finally
            {
                IsBusy = false;
            }
        }

        #endregion
    }
}
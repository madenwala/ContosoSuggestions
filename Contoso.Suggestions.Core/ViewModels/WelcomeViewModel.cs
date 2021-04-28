using System.Windows.Input;
using Xamarin.CommunityToolkit.ObjectModel;

namespace Contoso.Suggestions.Core.ViewModels
{
    public sealed class WelcomeViewModel : BaseViewModel
    {
        #region Constructors

        public WelcomeViewModel()
        {
            Title = "Welcome to Contoso!";
        }

        #endregion
    }
}
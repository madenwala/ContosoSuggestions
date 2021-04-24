using Contoso.Suggestions.Core.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Contoso.Suggestions.UI.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class LoginPage : ContentPage
    {
        public LoginPage()
        {
            InitializeComponent();
            this.BindingContext = new LoginViewModel();
        }
    }
}
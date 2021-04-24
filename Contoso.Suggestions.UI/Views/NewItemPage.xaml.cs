using Contoso.Suggestions.Core.Models;
using Contoso.Suggestions.Core.ViewModels;
using Xamarin.Forms;

namespace Contoso.Suggestions.UI.Views
{
    public partial class NewItemPage : ContentPage
    {
        public Item Item { get; set; }

        public NewItemPage()
        {
            InitializeComponent();
            BindingContext = new NewItemViewModel();
        }
    }
}
using Contoso.Suggestions.Core.ViewModels;
using Xamarin.Forms;

namespace Contoso.Suggestions.UI.Views
{
    public partial class ItemsPage : BaseView<ItemsViewModel>
    {
        public ItemsPage()
        {
            InitializeComponent();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            ViewModel.OnAppearing();
        }
    }
}
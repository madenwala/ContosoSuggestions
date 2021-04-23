using Contoso.Suggestions.Core.ViewModels;
using System.ComponentModel;
using Xamarin.Forms;

namespace Contoso.Suggestions.UI.Views
{
    public partial class ItemDetailPage : ContentPage
    {
        public ItemDetailPage()
        {
            InitializeComponent();
            BindingContext = new ItemDetailViewModel();
        }
    }
}
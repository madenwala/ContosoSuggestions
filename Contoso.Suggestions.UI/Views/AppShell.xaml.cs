using Contoso.Suggestions.UI.Views;
using Xamarin.Forms;

namespace Contoso.Suggestions.UI.Views
{
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();
            Routing.RegisterRoute(nameof(ItemDetailPage), typeof(ItemDetailPage));
            Routing.RegisterRoute(nameof(NewItemPage), typeof(NewItemPage));
            Routing.RegisterRoute(nameof(MapPage), typeof(MapPage));
        }
    }
}
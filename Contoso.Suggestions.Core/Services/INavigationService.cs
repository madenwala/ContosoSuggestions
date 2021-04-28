using Contoso.Suggestions.Core.Models;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Contoso.Suggestions.Core.Services
{
    public interface INavigationService
    {
        bool Authenticated { get; set; }

        Task HomeAsync();
        ICommand NavigateHomeCommand { get; }

        Task GoBackAsync();
        ICommand NavigateBackCommand { get; }

        Task LoginAsync();
        ICommand NavigateLoginCommand { get; }

        Task LogoutAsync();
        ICommand NavigateLogoutCommand { get; }

        Task AboutAsync();
        ICommand NavigateAboutCommand { get; }

        Task AddItemAsync();
        ICommand NavigateAddItemCommand { get; }

        Task ItemDetailsAsync(Item item);
        ICommand NavigateItemDetailsCommand { get; }

        Task MapAsync(Item item);
        ICommand NavigateMapCommand { get; }
    }
}
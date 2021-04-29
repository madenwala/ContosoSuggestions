using Contoso.Suggestions.Core.Models;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Contoso.Suggestions.Core.Services
{
    public interface INavigationService
    {
        bool Authenticated { get; set; }

        Task HomeAsync();
        ICommand HomeCommand { get; }

        Task GoBackAsync();
        ICommand BackCommand { get; }

        Task LoginAsync();
        ICommand LoginCommand { get; }

        Task LogoutAsync();
        ICommand LogoutCommand { get; }

        Task AboutAsync();
        ICommand AboutCommand { get; }

        Task AddItemAsync();
        ICommand AddItemCommand { get; }

        Task ItemDetailsAsync(Item item);
        ICommand ItemDetailsCommand { get; }

        Task MapAsync(Item item);
        ICommand MapCommand { get; }
    }
}
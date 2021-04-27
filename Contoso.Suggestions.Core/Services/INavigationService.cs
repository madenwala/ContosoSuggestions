using Contoso.Suggestions.Core.Models;
using System.Threading.Tasks;

namespace Contoso.Suggestions.Core.Services
{
    public interface INavigationService
    {
        Task HomeAsync();
        Task GoBackAsync();

        Task LoginAsync();
        Task LogoutAsync();

        Task AboutAsync();
        Task AddItemAsync();
        Task ItemDetails(Item item);
    }
}
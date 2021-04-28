using Contoso.Suggestions.Core.Models;
using System;
using System.Diagnostics;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.CommunityToolkit.ObjectModel;
using Xamarin.Forms;

namespace Contoso.Suggestions.Core.ViewModels
{
    [QueryProperty(nameof(ItemId), nameof(ItemId))]
    public sealed class ItemDetailViewModel : BaseViewModel
    {
        #region Properties

        private AsyncCommand _HomeCommand;
        public ICommand HomeCommand => _HomeCommand ??= new(Navigation.HomeAsync);

        private AsyncCommand _AboutCommand;
        public ICommand AboutCommand => _AboutCommand ??= new(Navigation.AboutAsync);

        private AsyncCommand _MapCommand;
        public ICommand MapCommand => _MapCommand ??= new(async () => await Navigation.MapAsync(Model));

        private string itemId;
        public string ItemId
        {
            get
            {
                return itemId;
            }
            set
            {
                itemId = value;
                LoadModel(value);
            }
        }

        private Item _Model;
        public Item Model
        {
            get => _Model;
            private set => SetProperty(ref _Model, value);
        }

        #endregion

        #region Methods

        private async void LoadModel(string id)
        {
            try
            {
                IsBusy = true;
                Model = await DataStore.GetItemAsync(id);
            }
            catch (Exception)
            {
                Debug.WriteLine("Failed to Load Item");
            }
            finally
            {
                IsBusy = false;
            }
        }

        #endregion
    }
}
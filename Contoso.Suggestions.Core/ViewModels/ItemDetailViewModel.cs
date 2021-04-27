using Contoso.Suggestions.Core.Models;
using System;
using System.Diagnostics;
using Xamarin.Forms;

namespace Contoso.Suggestions.Core.ViewModels
{
    [QueryProperty(nameof(ItemId), nameof(ItemId))]
    public class ItemDetailViewModel : BaseViewModel
    {
        #region Properties

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
                Model = await DataStore.GetItemAsync(id);
            }
            catch (Exception)
            {
                Debug.WriteLine("Failed to Load Item");
            }
        }

        #endregion
    }
}
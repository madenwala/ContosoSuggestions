using Contoso.Suggestions.Core.Models;
using System;
using System.Diagnostics;
using Xamarin.Forms;

namespace Contoso.Suggestions.Core.ViewModels
{
    [QueryProperty(nameof(ID), nameof(ID))]
    public sealed class MapViewModel : BaseViewModel
    {
        #region Properties

        private string _id;
        public string ID
        {
            get => _id;
            set
            {
                _id = value;
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

        #region Constructors

        public MapViewModel()
        {
            Title = "Maps";
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
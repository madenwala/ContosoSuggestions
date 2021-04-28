using Contoso.Suggestions.Core.Models;
using System;
using System.Windows.Input;
using Xamarin.CommunityToolkit.ObjectModel;
using Xamarin.Forms;

namespace Contoso.Suggestions.Core.ViewModels
{
    public sealed class NewItemViewModel : BaseViewModel
    {
        #region Properties

        private Item _Model;
        public Item Model
        {
            get => _Model;
            private set => SetProperty(ref _Model, value);
        }

        public Command SaveCommand { get; }

        #endregion

        #region Constructors

        public NewItemViewModel()
        {
            Model = new Item();
            SaveCommand = new Command(OnSave, ValidateSave);
            Model.PropertyChanged += (sender, e) => 
            {
                if (e.PropertyName is not nameof(Model.PropertyErrors)) 
                    SaveCommand.ChangeCanExecute(); 
            };
            Model.PropertyErrors.Clear();
        }

        #endregion

        #region Methods

        private bool ValidateSave()
        {
            return Model.IsValid();
        }

        private async void OnSave()
        {
            try
            {
                IsBusy = true;
                Model.Id = Guid.NewGuid().ToString();
                await DataStore.AddItemAsync(this.Model);
            }
            finally
            {
                await Navigation.GoBackAsync();
                IsBusy = false;
            }
        }

        #endregion
    }
}
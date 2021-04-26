using Contoso.Suggestions.Core.Models;
using Contoso.Suggestions.Core.Services;
using System;
using Xamarin.Forms;

namespace Contoso.Suggestions.Core.ViewModels
{
    public class NewItemViewModel : BaseViewModel
    {
        #region Variables
        
        private readonly INavigationService _nav = DependencyService.Get<INavigationService>();

        #endregion

        #region Properties

        private Item _Model;
        public Item Model
        {
            get => _Model;
            private set => SetProperty(ref _Model, value);
        }

        public Command SaveCommand { get; }
        public Command CancelCommand { get; }

        #endregion

        #region Constructors

        public NewItemViewModel()
        {
            Model = new Item();
            SaveCommand = new Command(OnSave, ValidateSave);
            CancelCommand = new Command(OnCancel);
            Model.PropertyChanged += (_, __) => SaveCommand.ChangeCanExecute();
        }

        #endregion

        #region Methods

        private bool ValidateSave()
        {
            return Model.IsValid();
        }

        private async void OnCancel()
        {
            await _nav.GoBackAsync();
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
                await _nav.GoBackAsync();
                IsBusy = false;
            }
        }

        #endregion
    }
}
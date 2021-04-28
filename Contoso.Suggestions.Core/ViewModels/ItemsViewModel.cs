using Contoso.Suggestions.Core.Models;
using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.CommunityToolkit.ObjectModel;

namespace Contoso.Suggestions.Core.ViewModels
{
    public sealed class ItemsViewModel : BaseViewModel
    {
        #region Properties

        private Item _selectedItem;
        public Item SelectedItem
        {
            get => _selectedItem;
            set
            {
                SetProperty(ref _selectedItem, value);
                Navigation.ItemDetailsAsync(value);
            }
        }

        public ObservableCollection<Item> Items { get; } = new ObservableCollection<Item>();

        public ICommand LoadItemsCommand { get; }

        #endregion

        #region Constructors

        public ItemsViewModel()
        {
            Title = "Browse";
            LoadItemsCommand = new AsyncCommand(ExecuteLoadItemsCommand);
        }

        #endregion

        #region Methods

        private async Task ExecuteLoadItemsCommand()
        {
            try
            {
                IsBusy = true;
                Items.Clear();
                foreach (var item in await DataStore.GetItemsAsync(true))
                    Items.Add(item);
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
            finally
            {
                IsBusy = false;
            }
        }

        public override void OnAppearing()
        {
            IsBusy = true;
            SelectedItem = null;
        }

        #endregion
    }
}
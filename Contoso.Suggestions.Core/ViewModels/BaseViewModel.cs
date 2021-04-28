using Contoso.Suggestions.Core.Models;
using Contoso.Suggestions.Core.Services;
using System;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Contoso.Suggestions.Core.ViewModels
{
    public abstract class BaseViewModel : BaseModel
    {
        #region Properties

        private readonly IDataStore<Item> _dataStore = DependencyService.Get<IDataStore<Item>>();
        public IDataStore<Item> DataStore => _dataStore;

        private readonly INavigationService _nav = DependencyService.Get<INavigationService>();
        public INavigationService Navigation => _nav;

        bool _isBusy;
        public bool IsBusy
        {
            get => _isBusy;
            set => SetProperty(ref _isBusy, value);
        }

        string title = string.Empty;
        public string Title
        {
            get { return title; }
            protected set { SetProperty(ref title, value); }
        }

        #endregion

        #region Methods

        /// <summary>
        /// Initialilzes the ViewModel.
        /// </summary>
        /// <returns>Task with result.</returns>
        public virtual Task InitAsync() => Task.CompletedTask;

        public virtual void OnAppearing()
        {
        }

        public virtual bool OnBackButtonPressed()
        {
            return false;
        }

        /// <inheritdoc />
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
        }

        #endregion
    }
}
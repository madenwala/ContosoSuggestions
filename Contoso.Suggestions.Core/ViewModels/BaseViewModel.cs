using Contoso.Suggestions.Core.Models;
using Contoso.Suggestions.Core.Services;
using System;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Contoso.Suggestions.Core.ViewModels
{
    public class BaseViewModel : BaseModel
    {
        #region Properties
        
        public IDataStore<Item> DataStore => DependencyService.Get<IDataStore<Item>>();

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
            set { SetProperty(ref title, value); }
        }

        #endregion

        #region Methods

        /// <summary>
        /// Initialilzes the ViewModel.
        /// </summary>
        /// <returns>Task with result.</returns>
        public virtual Task InitAsync() => Task.CompletedTask;

        /// <inheritdoc />
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
        }

        public virtual bool OnBackButtonPressed()
        {
            return false;
        }

        #endregion
    }
}
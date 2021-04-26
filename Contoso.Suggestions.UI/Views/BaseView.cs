using Contoso.Suggestions.Core.ViewModels;
using System;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Contoso.Suggestions.UI.Views
{
    public class BaseView<T> : ContentPage where T : BaseViewModel, new()
    {
        private T _viewModel;

        public T ViewModel
        {
            get
            {
                return _viewModel;
            }
            protected set
            {
                _viewModel = value;

                BindingContext = _viewModel;

                Task.Run(async () =>
                {
                    try
                    {
                        await Init();
                    }
                    catch (Exception ex)
                    {
                        // TODO Logger.Error(ex.Message);
                        throw ex;
                    }
                });
            }
        }

        public BaseView()
        {
            ViewModel = Activator.CreateInstance(typeof(T)) as T;
        }

        private async Task Init()
        {
            try
            {
                await ViewModel?.InitAsync();
            }
            catch (Exception ex)
            {
                // TODO Logger.Error(ex.Message);
                throw ex;
            }
        }

        protected override bool OnBackButtonPressed()
        {
            return this.ViewModel?.OnBackButtonPressed() ?? false;
        }
    }
}
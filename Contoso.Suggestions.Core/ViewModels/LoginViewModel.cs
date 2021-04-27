﻿using Contoso.Suggestions.Core.Services;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.CommunityToolkit.ObjectModel;
using Xamarin.Forms;

namespace Contoso.Suggestions.Core.ViewModels
{
    public sealed class LoginViewModel : BaseViewModel
    {
        private readonly INavigationService _nav = DependencyService.Get<INavigationService>();

        private AsyncCommand _SubmitCommand;
        public ICommand SubmitCommand => _SubmitCommand ??= new(SubmitAsync);

        public LoginViewModel()
        {
            Title = "Login to Contoso";
        }

        private Task SubmitAsync()
        {
            try
            {
                IsBusy = true;
                _nav.Authenticated = true;
                return _nav.HomeAsync();
            }
            finally
            {
                IsBusy = false;
            }
        }
    }
}
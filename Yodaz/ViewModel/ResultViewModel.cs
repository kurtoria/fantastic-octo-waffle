﻿using System;

using Xamarin.Forms;
using Yodaz.Model;
using System.Windows.Input;
using Yodaz.Navigation;
using System.Threading.Tasks;

namespace Yodaz.ViewModel
{
    public class ResultViewModel
    {
        INavigationService _navigationService;
        public string FinalScore { get; set; }

        public string ResultText { get; set; }

        public ICommand PlayCommand { get; private set; }

        public ResultViewModel()
        {
            _navigationService = App.NavigationService;
            FinalScore = $"{User.Result}/{User.Input}";

            PlayCommand = new Command(
               execute: async () => await PlayAgain(),
               canExecute: () => { return true; });
        }

        public async Task PlayAgain()
        {
            await _navigationService.NavigateAsync("StartPage");
        }
    }
}


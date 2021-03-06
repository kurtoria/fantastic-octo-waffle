﻿using System;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;
using Yodaz.Model;
using Yodaz.Navigation;

namespace Yodaz.ViewModel
{
    public class StartViewModel : BaseViewModel
    {
        INavigationService _navigationService;
        public ICommand StartCommand { get; set; }
        public string number;
        public string Number 
        { 
        get 
        {
                return number;
         }
            set 
            {
                SetProperty(ref number, value);
                int result;
                IsValid = int.TryParse(value, out result);
             
                RefreshCanExecute();
            }
        }
       public bool IsValid { get; set; }

        public StartViewModel()
        {
            _navigationService = App.NavigationService;
            StartCommand = new Command(
                execute: async () => await Navigate(),
                canExecute: () => IsValid);
        }


        public void RefreshCanExecute() 
        {
            (StartCommand as Command).ChangeCanExecute();
        }

        public async Task Navigate() 
        {
            int nr = Convert.ToInt32(Number);
            if (nr > 50)
            {
                DependencyService.Get<IToast>().ShortAlert("Only 50 questions allowed");
                //Number = "50";
            }
            else
            { 
            User.Input = Convert.ToInt32(Number);
            await _navigationService.NavigateAsync("QuizPage");
            Number = "";
            }
        }
    }
}

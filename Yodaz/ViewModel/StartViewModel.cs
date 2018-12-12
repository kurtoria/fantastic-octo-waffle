using System;
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
                RefreshCanExecute();
            }
        }
       

        public StartViewModel()
        {
            _navigationService = App.NavigationService;
            StartCommand = new Command(
                execute: async () => await Navigate(),
                canExecute: () => !string.IsNullOrEmpty(Number));
        }

        public void RefreshCanExecute() 
        {
            (StartCommand as Command).ChangeCanExecute();
        }

        public async Task Navigate() 
        {
            User.Input = Convert.ToInt32(Number);
            await _navigationService.NavigateAsync("QuizPage");
            Number = "";
        }
    }
}

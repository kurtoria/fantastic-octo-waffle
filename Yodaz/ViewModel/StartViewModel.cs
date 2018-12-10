using System;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;
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
                if (!value.Equals(number))
                {
                    SetProperty(ref number, value);
                    RefreshCanExecute();
                }
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
            Console.WriteLine("TESTAR");
            await _navigationService.NavigateAsync("QuizPage");
            //await navigate.NavigateAsync("StartPage");
            //// ERROR! navigation == Null???
        }
    }
}





//private readonly INavigationService _navigationService;
//private readonly int _depth;

//public MainPage()
//{
//    InitializeComponent();
//    _navigationService = App.NavigationService;
//}

//private async void ModalNavigationOnClicked(object sender, EventArgs e)
//{
//    await _navigationService.NavigateModalAsync(nameof(ModalNavigationPage), "root page misses you");
//}

//private async void PushNavigationOnClicked(object sender, EventArgs e)
//{
//    await _navigationService.NavigateAsync(nameof(PushNavigationPage), "root page misses you");
//}

//private void NavigateBackOnClicked(object sender, EventArgs e)
//{
//    _navigationService.GoBack();
//}

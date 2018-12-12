using Xamarin.Forms;
using Yodaz.Model;
using System.Windows.Input;
using Yodaz.Navigation;
using System.Threading.Tasks;
using Yodaz.Services;

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
            SetResultText();
            FinalScore = $"{User.Result}/{User.Input}";

            PlayCommand = new Command(
               execute: async () => await PlayAgain(),
               canExecute: () => { return true; });
        }

        public async Task PlayAgain()
        {
            User.Input = 0;
            HTTPWebRequest.Trivias.Clear();
            HTTPWebRequest.GetQuestions(1);
            await _navigationService.Restart(); 
        }

        public void SetResultText()
        {
            ResultText = "Resultatet";
        }
    }
}


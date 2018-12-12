using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Yodaz.Navigation;
using Yodaz.Services;
using Yodaz.View;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace Yodaz
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            NavigationService.Configure("StartPage", typeof(View.StartPage));
            NavigationService.Configure("QuizPage", typeof(View.QuizPage));
            NavigationService.Configure("ResultPage", typeof(View.ResultPage));
            var mainPage = ((ViewNavigationService)NavigationService).SetRootPage("StartPage");

            MainPage = mainPage;
        }

        public static INavigationService NavigationService { get; } = new ViewNavigationService();


        protected override void OnStart()
        {
            // Handle when your app starts
            //HTTPWebRequest.GetQuestions(1);
            HTTPWebRequest.GetTrivia(1);
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}

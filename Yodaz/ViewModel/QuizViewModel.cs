using System;
using System.Collections.Generic;
using Xamarin.Forms;
using Yodaz.Model;
using Yodaz.Services;
using Yodaz.View;

namespace Yodaz.ViewModel
{
    public class QuizViewModel
    {
        public int Number { get; set; }
        public string Question { get; set; }

        public QuizViewModel()
        {
            //Number = User.Input;
            Console.WriteLine(Number);

            //TriviaParser triviaParser = new TriviaParser();
            //HTTPWebRequest hTTPWeb = new HTTPWebRequest(Number.ToString());
            //hTTPWeb.GetTrivia();
            HTTPWebRequest.Trivias.Clear();
            HTTPWebRequest.GetTrivia(Number);
            Console.WriteLine("---------------------------");
            Console.WriteLine("Trivia count from QuizViewModel: " + HTTPWebRequest.Trivias.Count);
            Console.WriteLine("---------------------------");

        }
    }
}

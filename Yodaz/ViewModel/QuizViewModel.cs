using System;
using System.Windows.Input;
using System.Collections.Generic;
using Xamarin.Forms;
using Yodaz.Model;
using Yodaz.Services;
using Yodaz.View;

namespace Yodaz.ViewModel
{
    public class QuizViewModel : BaseViewModel
    {
        public int Number { get; set; }
        public ICommand AnswerCommand { get; private set; }
        string question;
        public string Question 
        { 
        get 
        {
                return question;
         }
            set 
            {
                if(!value.Equals(question)) 
                {
                    SetProperty(ref question, value); 
                }
            }
        }
        public int Score { get; set; }
        public Trivia trivia;

        public QuizViewModel()
        {
       
            Question = "Here comes question";
            Score = 0;
            Number = User.Input;
            Console.WriteLine(Number);

            AnswerCommand = new Command<string>(
                execute: CheckAnswer,
                canExecute: obj => obj != null 
                );

            HTTPWebRequest.Trivias.Clear();
            HTTPWebRequest.GetTrivia(Number);
            Console.WriteLine("---------------------------");
            Console.WriteLine("Trivia count from QuizViewModel: " + HTTPWebRequest.Trivias.Count);
            Console.WriteLine("---------------------------");
        }



        private void CheckAnswer(string obj)
        {
            //if(obj.ToLower() == trivia.CorrectAnswer.ToLower() )
            //{
            //    Question = "Correct";
            //} else 
            //{
            //    Question = "Wrong";
            //}

        }
    }
}

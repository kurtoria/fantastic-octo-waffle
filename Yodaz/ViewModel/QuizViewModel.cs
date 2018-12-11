using System;
using System.Windows.Input;
using Xamarin.Forms;
using Yodaz.Model;
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
            trivia = new Trivia("Is it soon Christmas?", "true", "false");

            Question = trivia.Question;
            Score = 0;
            Number = User.Input;
            Console.WriteLine(Number);

            AnswerCommand = new Command<string>(
                execute: CheckAnswer,
                canExecute: obj => obj != null 
                );

        }

        private void CheckAnswer(string obj)
        {
            if(obj.ToLower() == trivia.CorrectAnswer.ToLower() )
            {
                Question = "Correct";
            } else 
            {
                Question = "Wrong";
            }
        }
    }
}

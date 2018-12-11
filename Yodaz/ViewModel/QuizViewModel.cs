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
        Stack<Trivia> stack = new Stack<Trivia>();
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
        int score;
        public int Score 
        { 
        get
            { 
            return score; 
            }
            set
            {
             if(!value.Equals(score))
                {
                    SetProperty(ref score, value);
                }
            }
        }
        string result;
        public string Result 
        {
            get 
            {
                return result;
            }
            set
            {
                SetProperty(ref result, value);
              }
        }
        public Trivia trivia;

        public QuizViewModel()
        {
            Number = User.Input;
            Question = "Here comes question";
            Score = 0;
            AnswerCommand = new Command<string>(
                execute: CheckAnswer,
                canExecute: obj => stack.Count > 0 
                );

            fetchQuestions();

        }

        private void fetchQuestions()
        {

            //TriviaParser triviaParser = new TriviaParser();
            //HTTPWebRequest hTTPWeb = new HTTPWebRequest(Number.ToString());
            //hTTPWeb.GetTrivia();

            HTTPWebRequest.Trivias.Clear();
            HTTPWebRequest.GetTrivia(Number);
            Console.WriteLine("---------------------------");
            Console.WriteLine("Trivia count from QuizViewModel: " + HTTPWebRequest.Trivias.Count);
            Console.WriteLine("---------------------------");

            foreach (var t in HTTPWebRequest.Trivias)
            {
                Console.WriteLine("---------------------------");
                Console.WriteLine(t.question);
                Console.WriteLine("---------------------------");
                stack.Push(t);
            }

            DisplayQuestion();

        }




        private void DisplayQuestion()
        {
            if(stack.Count > 0) 
            {
                RefreshCanExecute();
                trivia = stack.Peek();
                var text = trivia.question;
                var trimmedString = text.Replace("&quot;", "'");
                Question = trimmedString;
            } else 
            {
                RefreshCanExecute();
                Console.WriteLine("END OF QUIZ");
            }
        }

      

        private void CheckAnswer(string obj)
        {
            if (obj.ToLower() == trivia.correct_answer.ToLower())
            {
                Score += 1;
                Result = "Correct";

            } else 
            {
                Result = "Wrong";
            }

            stack.Pop();
            DisplayQuestion();

        }

        private void RefreshCanExecute()
        {
            (AnswerCommand as Command).ChangeCanExecute();
        }
    }
}

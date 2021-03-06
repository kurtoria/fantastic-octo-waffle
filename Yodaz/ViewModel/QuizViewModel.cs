﻿using System;
using System.Windows.Input;
using System.Collections.Generic;
using Xamarin.Forms;
using Yodaz.Model;
using Yodaz.Services;
using Yodaz.View;
using Yodaz.Navigation;

namespace Yodaz.ViewModel
{
    public class QuizViewModel : BaseViewModel
    {
        INavigationService _navigationService;
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
        private int count;

        public QuizViewModel()
        {
            _navigationService = App.NavigationService;
            Number = User.Input;
            stack.Push(HTTPWebRequest.Trivias[0]);
            Score = 0;
            AnswerCommand = new Command<string>(
                execute: CheckAnswer,
                canExecute: obj => stack.Count > 0 
                );
            DisplayQuestion();
            fetchQuestions();

        }

        private void fetchQuestions()
        {
            if (Number != 1)
            {
                HTTPWebRequest.GetTrivia(Number - 1);
                foreach (var t in HTTPWebRequest.Trivias)
                {
                    stack.Push(t);
                }

                DisplayQuestion();
            }

        }

        private void DisplayQuestion()
        {
            if(stack.Count > 0) 
            {
                Result = ""+ count + "/" + Number;
                RefreshCanExecute();
                trivia = stack.Peek();
                var text = trivia.question;
                var trimmedString = text.Replace("&quot;", "\"");
                trimmedString = trimmedString.Replace("&#039;", "'");
                trimmedString = trimmedString.Replace("&amp;", "&");
                trimmedString = trimmedString.Replace("&eacute;", "é");
                trimmedString = trimmedString.Replace("&epsilon;", "ε");
                trimmedString = trimmedString.Replace("&Phi;", "Φ");
                Question = trimmedString;
            } else 
            {
                RefreshCanExecute();
                User.Result = Score;
                _navigationService.NavigateAsync("ResultPage");
            }
        }

      

        private void CheckAnswer(string obj)
        {
            if (obj.ToLower() == trivia.correct_answer.ToLower())
            {
                Score += 1;
            } 

            stack.Pop();
            count += 1;
            DisplayQuestion();

        }

        private void RefreshCanExecute()
        {
            (AnswerCommand as Command).ChangeCanExecute();
        }
    }
}

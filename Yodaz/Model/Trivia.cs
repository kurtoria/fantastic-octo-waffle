using System;

namespace Yodaz.Model
{
    public class Trivia
    {
        public string Question { get; set; }
        public string CorrectAnswer { get; set; }
        public string IncorrectAnswer { get; set; }

        public Trivia(string question, string correctAnswer, string incorrectAnswer)
        {
            this.Question = question;
            this.CorrectAnswer = correctAnswer;
            this.IncorrectAnswer = incorrectAnswer;
        }
    }
}

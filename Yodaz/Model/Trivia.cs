using System;

namespace Yodaz.Model
{
    public class Trivia
    {

        public string category { get; set; }
        public string type { get; set; }
        public string difficulty { get; set; }
        public string question { get; set; }
        public string correct_answer { get; set; }
        public string[] incorrect_answers { get; set; }

        //public string Question { get; set; }
        //public string CorrectAnswer { get; set; }
        //public string IncorrectAnswer { get; set; }

        //public Trivia(string question, string correctAnswer, string incorrectAnswer)
        //{
        //    this.Question = question;
        //    this.CorrectAnswer = correctAnswer;
        //    this.IncorrectAnswer = incorrectAnswer;
        //}
    }
}

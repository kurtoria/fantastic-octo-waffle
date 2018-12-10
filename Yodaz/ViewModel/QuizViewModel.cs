using System;
using Xamarin.Forms;
using Yodaz.Model;
using Yodaz.View;

namespace Yodaz.ViewModel
{
    public class QuizViewModel
    {
        public int Number { get; set; }

        public QuizViewModel()
        {
            Number = User.Input;
            Console.WriteLine(Number);

        }
    }
}

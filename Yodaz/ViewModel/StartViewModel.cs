using System;
using System.Windows.Input;
using Xamarin.Forms;

namespace Yodaz.ViewModel
{
    public class StartViewModel
    {
        public ICommand StartCommand { get; set; }

        public StartViewModel()
        {
            StartCommand = new Command(
            execute: () => Console.WriteLine("Fetch user input from entry.."));
        }
    }
}

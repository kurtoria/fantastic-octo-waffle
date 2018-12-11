using System;

using Xamarin.Forms;

namespace Yodaz.ViewModel
{
    public class ResultViewModel : ContentPage
    {
        public ResultViewModel()
        {
            Content = new StackLayout
            {
                Children = {
                    new Label { Text = "Hello ContentPage" }
                }
            };
        }
    }
}


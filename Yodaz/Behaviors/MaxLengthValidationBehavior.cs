using System;
using Xamarin.Forms;
using System.Linq;
namespace Yodaz.Behaviors
{
    public class MaxLengthValidationBehavior : Behavior<Entry>
    {

        public static BindableProperty MaxLengthProperty = BindableProperty.Create("MaxLength", typeof(int), typeof(MaxLengthValidationBehavior), 0);
        
        public int MaxLength
        {
            get 
            { 
                return (int)GetValue(MaxLengthProperty);
            }
            set
            {
                SetValue(MaxLengthProperty, value);
            }
        }

        protected override void OnAttachedTo(Entry bindable)
        {
            bindable.TextChanged += BindableTextChanged;
        }

        private void BindableTextChanged(object sender, TextChangedEventArgs e)
        {
            if (e.NewTextValue.Length >= MaxLength)
            {
                ((Entry)sender).Text = e.NewTextValue.Substring(0, MaxLength);
            }
        }

        protected override void OnDetachingFrom(Entry bindable)
        {
            bindable.TextChanged -= BindableTextChanged;
        }
    }
}

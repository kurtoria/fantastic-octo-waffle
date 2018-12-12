using System;
using Android.App;
using Android.Widget;
using Yodaz.Droid;

[assembly: Xamarin.Forms.Dependency(typeof(AndroidToast))]
namespace Yodaz.Droid
{
    public class AndroidToast : IToast
    {
       
        public void ShortAlert(string message)
        {
            Toast.MakeText(Application.Context, message, ToastLength.Short).Show();
        }
    }
}

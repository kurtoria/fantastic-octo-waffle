using System;
using Foundation;
using UIKit;
using Yodaz.iOS;

[assembly: Xamarin.Forms.Dependency(typeof(IOSToast))]
namespace Yodaz.iOS
{
    public class IOSToast : IToast
    {
        const double SHORT_DELAY = 2.0;

        public void ShortAlert(string message)
        {
            ShowToast(message, SHORT_DELAY);
        }

        private void ShowToast(string message, double seconds)
        {
            var alert = UIAlertController.Create(null, message, UIAlertControllerStyle.Alert);

            var toastDelay = NSTimer.CreateScheduledTimer(seconds, (obj) =>
            {
                DismissMessage(alert,obj);
            });
            UIApplication.SharedApplication.KeyWindow.RootViewController.PresentViewController(alert, true, null);
          
        }

        private void DismissMessage(UIAlertController alert, NSTimer toastDelay)
        {
            if (alert != null) 
            {
                alert.DismissViewController(true, null);
            }
            if (toastDelay != null) 
            {
                toastDelay.Dispose();
            }
        }
    }
}

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
        NSTimer toastDelay;
        UIAlertController alert;

        public void ShortAlert(string message)
        {
            ShowToast(message, SHORT_DELAY);
        }

        private void ShowToast(string message, double seconds)
        {

            toastDelay = NSTimer.CreateScheduledTimer(seconds, (obj) =>
            {
                DismissMessage();
            });
            alert = UIAlertController.Create(null, message, UIAlertControllerStyle.Alert);
            //UIApplication.SharedApplication.KeyWindow.RootViewController.PresentViewController(alert, true, null);
            UIApplication.SharedApplication.KeyWindow.RootViewController.PresentViewController(alert, true, () => {
                UIApplication.SharedApplication.KeyWindow.RootViewController.DismissViewController(true, null);
             });
        }

        private void DismissMessage()
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

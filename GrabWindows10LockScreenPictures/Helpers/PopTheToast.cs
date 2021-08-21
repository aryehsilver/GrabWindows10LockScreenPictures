using Microsoft.Toolkit.Uwp.Notifications;
using System;
using System.IO;

namespace GrabWindows10LockScreenPictures.Helpers {
  public class PopTheToast {
    public static void PopIt(string notifText) =>
      new ToastContentBuilder()
          .AddText("Grab Windows 10 Lock Screen Pictures")
          .AddText(!string.IsNullOrWhiteSpace(notifText) ? notifText : "Script has run with an unknown result.")
          .AddHeroImage(new Uri("file:///" + Path.GetFullPath("Data/buffelo.png")))
          .AddAppLogoOverride(new Uri("file:///" + Path.GetFullPath("Data/lion.png")), ToastGenericAppLogoCrop.Circle)
          .AddAttributionText("Via GWLSP")
          .Show(toast => toast.ExpirationTime = DateTime.Now.AddMinutes(10));
  }
}

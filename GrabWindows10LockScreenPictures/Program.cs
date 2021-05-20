using System.Drawing;
using System.IO;
using System.Linq;

namespace GrabWindows10LockScreenPictures {
  class Program {
    static void Main(string[] args) {
      string assetsAryeh = @"C:\Users\user\AppData\Local\Packages\Microsoft.Windows.ContentDeliveryManager_cw5n1h2txyewy\LocalState\Assets";
      string assetsOthers = @"C:\Users\others\AppData\Local\Packages\Microsoft.Windows.ContentDeliveryManager_cw5n1h2txyewy\LocalState\Assets";
      string saved = @"C:\Users\user\Pictures\Spotlight Images";

      GetPics(assetsAryeh, saved);
      GetPics(assetsOthers, saved);
    }

    static void GetPics(string assets, string saved) {
      foreach (string file in Directory.GetFiles(assets).Where(f => new FileInfo(f).Length > 200 * 1024)) {
        Image img = Image.FromFile(file);
        if (img.Width > img.Height) {
          string newFile = saved + file.Replace(assets, "") + ".jpg";
          File.Copy(file, newFile, true);
        }
      }
    }
  }
}

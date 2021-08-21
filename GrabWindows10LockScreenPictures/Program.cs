using GrabWindows10LockScreenPictures.Helpers;
using System;
using System.Drawing;
using System.IO;
using System.Linq;

namespace GrabWindows10LockScreenPictures {
  class Program {
    static void Main(string[] args) {
      string[] users = File.ReadAllLines(Path.GetFullPath("Data/locations.txt"));
      string saved = @$"C:\Users\{users.FirstOrDefault()}\Pictures\Spotlight Images";

      try {
        foreach (string name in users) {
          GetPics(@$"C:\Users\{name}\AppData\Local\Packages\Microsoft.Windows.ContentDeliveryManager_cw5n1h2txyewy\LocalState\Assets", saved);
        }

        PopTheToast.PopIt("All images were successfully saved.");
      } catch (Exception ex) {
        PopTheToast.PopIt("An error occurred: " + ex.Message);
      }
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

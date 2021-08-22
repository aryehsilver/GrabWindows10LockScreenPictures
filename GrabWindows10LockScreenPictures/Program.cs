using GrabWindows10LockScreenPictures.Helpers;
using System;
using System.Drawing;
using System.IO;
using System.Linq;

namespace GrabWindows10LockScreenPictures {
  class Program {
    static readonly string App_Folder = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + @"\Grab Windows 10 Lock Screen Pictures";

    static void Main(string[] args) {
      try {
        string userName = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile).Replace(@"C:\Users\", "");

        if (!Directory.Exists(App_Folder)) {
          Directory.CreateDirectory(App_Folder);
          File.WriteAllText(Path.Combine(App_Folder, "locations.txt"), userName);
        }

        if (File.Exists(Path.Combine(App_Folder, "locations.txt"))) {
          string[] users = File.ReadAllLines(Path.Combine(App_Folder, "locations.txt"));
          string saved = @$"C:\Users\{users.FirstOrDefault()}\Pictures\Spotlight Images";

          foreach (string name in users) {
            GetPics(@$"C:\Users\{name}\AppData\Local\Packages\Microsoft.Windows.ContentDeliveryManager_cw5n1h2txyewy\LocalState\Assets", saved);
          }

          PopTheToast.PopIt("All images were successfully saved.");
        } else {
          PopTheToast.PopIt("Error: locations.txt file was not found.");
        }
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

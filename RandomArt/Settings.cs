using System.Text.Json;
using System.Runtime.InteropServices;

namespace RandomArtScreensaver
{
    public static class Settings {
        #region Constants
        // Required constants and external functions
        private const uint WM_CREATE = 0x0001;
        private const uint WM_DESTROY = 0x0002;
        private const uint WM_MOUSEMOVE = 0x0200;
        private const uint WM_KEYDOWN = 0x0100;
        private const uint WM_ERASEBKGND = 0x0014;
        private const uint WM_PAINT = 0x000F;
        private const uint WM_INITDIALOG = 0x0110;
        private const string SettingsFileName = "RandomArt.json";
        private const string FilePath = "\\Local\\RandomArt";
        private const string logFileName = "RandomArt.log";
        #endregion
        public static int? All_artType = null;
        public static bool All_Alpha = false;
        public static Entities.SaverSettings? saverSettings;
        public static List<RandomArt>? screensaverForms;
        
        public static void SavePicture(Form form)
        {
            string PicPath = Environment.GetFolderPath(Environment.SpecialFolder.MyPictures);
            PicPath = PicPath + "\\RandomArt";
            if (!Directory.Exists(PicPath))
                Directory.CreateDirectory(PicPath);
            string PicName = DateTime.Now.ToString("YYYYMMddHHmmss") + ".jpeg";
            string FullPath = Path.Combine(PicPath, PicName);
            using (Bitmap bitmap = new Bitmap(form.ClientSize.Width, form.ClientSize.Height))
            {
                form.DrawToBitmap(bitmap, new Rectangle(0, 0, form.ClientSize.Width, form.ClientSize.Height));
                bitmap.Save(FullPath, System.Drawing.Imaging.ImageFormat.Jpeg);
            }
        }
        public static void LoadSettings()
        {
            try
            {
                DirectoryInfo? sPath = Directory.GetParent(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData));
                if (sPath == null) return;
                string fullpath = sPath + FilePath;
                string sFile = Path.Combine(fullpath, SettingsFileName);
                if (File.Exists(sFile))
                {
                    string jsonString = File.ReadAllText(sFile);
                    Entities.SaverSettings? settings = Newtonsoft.Json.JsonConvert.DeserializeObject<Entities.SaverSettings>(jsonString);
                    if (settings != null) saverSettings = settings;
                }
                else
                {
                    saverSettings = new Entities.SaverSettings();
                }
            }
            catch (Exception ex)
            {
                Log($"Error loading settings: {ex.Message}");
                saverSettings = new Entities.SaverSettings();
            }
        }
        public static void SaveSettings()
        {
            try
            {
                DirectoryInfo? sPath = Directory.GetParent(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData));
                if (sPath == null) return;
                string fullpath = sPath + FilePath;
                if (!Directory.Exists(fullpath))
                    Directory.CreateDirectory(fullpath);
                string sFile = Path.Combine(fullpath, SettingsFileName);
                string jsonString = Newtonsoft.Json.JsonConvert.SerializeObject(saverSettings);
                File.WriteAllText(sFile, jsonString);
            }
            catch (Exception ex)
            {
                Settings.Log($"Error saving settings: {ex.Message}");
            }
        }
        public static string Base64Converter(string imagePath)
        {
            try
            {
                byte[] imageBytes = File.ReadAllBytes(imagePath);
                string base64String = Convert.ToBase64String(imageBytes);
                return base64String;
            }
            catch (Exception ex)
            {
                Settings.Log($"Error reading file: {ex.Message}");
                return "";
            }
        }
        public static void Log(string message) {
            DirectoryInfo? sPath = Directory.GetParent(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData));
            if (sPath == null) return;
            string fullpath = sPath + FilePath;
            if (!Directory.Exists(fullpath))
                Directory.CreateDirectory(fullpath);
            string sFile = Path.Combine(fullpath, logFileName);
            Console.WriteLine(message);
            if (Program.Logging) {
                using (StreamWriter file = File.Exists(sFile) ? File.AppendText(sFile) : File.CreateText(sFile))
                {
                    file.Write(DateTime.Now.ToShortDateString() + " - " + message);
                    file.Write(Environment.NewLine);
                }
            }
        }
    }
}
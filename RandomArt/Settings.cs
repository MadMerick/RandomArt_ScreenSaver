using System.Text.Json;
using System.Runtime.InteropServices;

namespace RandomArtScreensaver
{
    public static class Settings {
        #region DLLImports
        [DllImport("user32.dll", SetLastError = true, CharSet = CharSet.Auto)]
        private static extern IntPtr DefWindowProc(IntPtr hWnd, uint uMsg, IntPtr wParam, IntPtr lParam);
        // Exported function for Windows to show the configuration dialog
        [UnmanagedCallersOnly(EntryPoint = "ScreenSaverConfigureDialog", CallConvs = new Type[] { typeof(System.Runtime.CompilerServices.CallConvStdcall) })]
        public static bool ScreenSaverConfigureDialog(IntPtr hWnd, uint message, IntPtr wParam, IntPtr lParam)
        {
            Settings.Log("ScreenSaverConfigureDialog");
            if (message == WM_INITDIALOG)
            {
                Program.ShowSettingsForm();
                return true;
            }
            return false;
        }
        // Exported function for Windows to run the screensaver
        [UnmanagedCallersOnly(EntryPoint = "ScreenSaverProc", CallConvs = new Type[] { typeof(System.Runtime.CompilerServices.CallConvStdcall) })]
        public static IntPtr ScreenSaverProc(IntPtr hWnd, uint message, IntPtr wParam, IntPtr lParam)
        {
            Settings.Log("ScreenSaverProc: " + message);
            try
            {
                Settings.Log($"Started ScreenSaverProc: {hWnd}, {message}, {wParam}, {lParam}");
                switch (message)
                {
                    case WM_CREATE:
                        // Initialize your screensaver here
                        Program.ShowTitleScreenAndRun();
                        return IntPtr.Zero;
                    case WM_DESTROY:
                        // Clean up resources
                        if (screensaverForms == null) return IntPtr.Zero; ;
                        foreach (RandomArt scr in screensaverForms)
                        {
                            scr.Stop();
                            scr.Close();
                            scr.Dispose();
                        }
                        return IntPtr.Zero;
                    case WM_MOUSEMOVE:
                    case WM_KEYDOWN:
                        // Exit the screensaver on mouse movement or key press
                        if (screensaverForms == null) return IntPtr.Zero; ;
                        foreach (RandomArt scr in screensaverForms)
                        {
                            if (scr.IsDemo != 1)
                            {
                                Application.Exit();
                            }
                        }
                        return IntPtr.Zero;
                    case WM_ERASEBKGND:
                        return (IntPtr)1; // Indicate that we'll handle the background
                    case WM_PAINT:
                        // Your drawing logic here (likely within the RandomArt form)
                        return IntPtr.Zero;
                    default:
                        return Settings.DefWindowProc(hWnd, message, wParam, lParam);
                }
            }
            catch (Exception ex)
            {
                Settings.Log($"Exception in ScreenSaverProc: {ex.Message}");
                Settings.Log($"Stack Trace: {ex.StackTrace}");
                return IntPtr.Zero; // Or some appropriate error handling
            }
        }
        #endregion
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
        private const string logFileName = "RandomArt_log.log";
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
            string sFile = Path.Combine(FilePath, logFileName);
            Console.WriteLine(message);
            if (Program.Logging) {
                using (StreamWriter file = File.AppendText(sFile))
                {
                    file.Write(DateTime.Now.ToShortDateString() + " - " + message);
                    file.Write(Environment.NewLine);
                }
            }
        }
    }
}
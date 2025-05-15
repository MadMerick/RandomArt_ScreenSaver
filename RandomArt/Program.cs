using System.Buffers.Text;
using System.Diagnostics;
using System.Text.Json;
using Microsoft.Win32;
using System.Runtime.InteropServices;
using RGiesecke.DllExport;
using Microsoft.VisualBasic.Logging;
using System.Media;

/*todo: 

*/

namespace RandomArtScreensaver
{
    public class Program
    {
        public static bool Logging = false;
        public static bool IsTesting = false;

        [STAThread]
        static void Main(string[] args)
        {
            try
            {
                Settings.Log("Started Main");
                foreach (string arg in args) {
                    Settings.Log("arg=" + arg);
                }
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                if (args.Length > 0)
                {
                    string firstArgument = args[0].ToLower().Trim();
                    string? secondArgument = null;

                    // Handle cases where "/c:" or "/p:" might have parameters
                    if (firstArgument.Length > 2)
                    {
                        secondArgument = firstArgument.Substring(3).Trim();
                        firstArgument = firstArgument.Substring(0, 2);
                    }
                    else if (args.Length > 1)
                    {
                        secondArgument = args[1];
                    }

                    if (firstArgument == "/c")         // Configuration Mode
                    {
                        ShowSettingsForm();
                    }
                    else if (firstArgument == "/p")    // Preview Mode
                    {
                        if (secondArgument != null)
                        {
                            IntPtr previewHandle = new IntPtr(long.Parse(secondArgument));
                            RunPreview(previewHandle);
                        }
                    }
                    else if (firstArgument == "/s")    // Full-screen Mode
                    {
                        ShowTitleScreenAndRun();
                    }
                    else // No arguments or invalid arguments
                    {
                        // Run in full-screen mode by default or show settings?
                        ShowTitleScreenAndRun();
                    }
                }
                else // No arguments
                {
                    // Run in full-screen mode by default or show settings?
                    ShowTitleScreenAndRun();
                    //ShowSettingsForm();
                }
            }
            catch (Exception ex)
            {
                // Log the exception details
                Settings.Log($"Exception in Main: {ex.Message}");
                Settings.Log($"Stack Trace: {ex.StackTrace}");
                // Potentially show an error message or handle the error as needed
            }
        }
        public static void ShowSettingsForm()
        {
            Settings.Log("Started ShowSettingsForm");
            SettingsForm settingsForm = new SettingsForm();
            Application.Run(settingsForm);
        }
        public static void RunPreview(IntPtr previewHandle) {
            Settings.Log("Started RunPreview:" + previewHandle);
            if (previewHandle == IntPtr.Zero) return;

            Settings.RECT rect;
            if (Settings.GetClientRect(previewHandle, out rect))
            {
                try {
                    Settings.screensaverForms = new List<RandomArt>();
                    Rectangle previewRect = new Rectangle(rect.Left, rect.Top, rect.Right - rect.Left, rect.Bottom - rect.Top);
                    Settings.Log($"Preview Window Size: {previewRect}");
                    RandomArt scr = new RandomArt(previewRect, 2);
                    scr.TopLevel = false;
                    IntPtr scrHandle = scr.Handle;
                    Settings.SetParent(scrHandle, previewHandle);
                    Settings.SetWindowLong(scrHandle, Settings.GWL_STYLE, Convert.ToUInt32(new IntPtr(Settings.GetWindowLong(scrHandle, -16) | Settings.WS_CHILD)));
                    scr.FormBorderStyle = FormBorderStyle.None;
                    scr.Bounds = previewRect;
                    scr.StartPosition = FormStartPosition.Manual;
                    scr.Show();
                    scr.Start();
                    Settings.screensaverForms.Add(scr);
                }
                catch (Exception ex)
                {
                    Settings.Log($"Exception in RunPreview drawing: {ex.Message}");
                    Settings.Log($"Stack Trace: {ex.StackTrace}");
                }
            }
            else
            {
                Settings.Log("Failed to get preview window client rectangle.");
            }
            Application.Run();
        }
        public static void ShowTitleScreenAndRun()
        {
            Settings.Log("Started ShowTitleScreenAndRun");
            // Get primary screen bounds
            Rectangle primaryScreenBounds = Screen.PrimaryScreen?.Bounds ?? Rectangle.Empty;

            if (Settings.saverSettings == null)
                Settings.LoadSettings(); 

            // Create and show the title screen
            TitleScreen titleScreen = new TitleScreen();
            titleScreen.StartPosition = FormStartPosition.Manual;
            titleScreen.Location = new Point(
            primaryScreenBounds.X + (primaryScreenBounds.Width - titleScreen.Width) / 2,
            primaryScreenBounds.Y + (primaryScreenBounds.Height - titleScreen.Height) / 2);
            titleScreen.Show();
            Application.DoEvents();
            titleScreen.Dispose();

            Settings.screensaverForms = new List<RandomArt>();

            // Run the screen saver on all screens
            foreach (Screen screen in Screen.AllScreens)
            {
                if (IsTesting)
                    if (screen.Bounds.Left  > 0) break; ///  testing purposes
                RandomArt scr = new RandomArt(screen.Bounds, 0);
                Settings.Log($"RandomArt created for Device Name:{screen.DeviceName}, Handle: {scr.Handle}, Bounds: {screen.Bounds}");
                scr.Show();
                scr.Start();
                Settings.screensaverForms.Add(scr);
            }
            Application.Run();
        }
        public static int TextWidth(string s, Font f)
        {
            Bitmap b = new Bitmap(2200, 2200);
            Graphics g = Graphics.FromImage(b);
            SizeF sz = g.MeasureString(s, f);
            return Convert.ToInt32(sz.Width);
        }
        public static int TextHeight(string s, Font f)
        {
            Bitmap b = new Bitmap(2200, 2200);
            Graphics g = Graphics.FromImage(b);
            SizeF sz = g.MeasureString(s, f);
            return Convert.ToInt32(sz.Height);
        }
        public static bool IsPowerOfTwo(int number) {
            if (number <= 0) {
                return false; // Non-positive numbers are not powers of 2
            }
            while (number % 2 == 0) {
                number /= 2;
            }
            return number == 1; // If it's a power of 2, after repeated division by 2, it will eventually be 1
        }
        public static int GetPowerofTwo(int number) {
            int cnt = 1;
            int r = 2;
            while (cnt < number) {
                r = r * 2;
                cnt = cnt + 1;
            }
            return r;
        }
    }

    public static class Settings {
        [DllImport("user32.dll", SetLastError = true)]
        public static extern IntPtr SetParent(IntPtr hWndChild, IntPtr hWndNewParent);
        [DllImport("user32.dll", SetLastError = true)]
        public static extern int SetWindowLong(IntPtr hWnd, int nIndex, uint dwNewLong);
        [DllImport("user32.dll", SetLastError = true)]
        public static extern int GetWindowLong(IntPtr hWnd, int nIndex);
        [DllImport("gdi32.dll")]
        public static extern bool BitBlt(IntPtr hdcDest, int nXDest, int nYDest, int nWidth, int nHeight, IntPtr hdcSrc, int nXSrc, int nYSrc, uint dwRrop);
        // Import GetDC and ReleaseDC functions from user32.dll
        [DllImport("user32.dll")]
        public static extern IntPtr GetDC(IntPtr hWnd);
        [DllImport("user32.dll")]
        public static extern int ReleaseDC(IntPtr hWnd, IntPtr hdc);
        [DllImport("user32.dll")]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool GetClientRect(IntPtr hWnd, out RECT lpRect);
        [DllImport("user32.dll", SetLastError = true, CharSet = CharSet.Auto)]
        public static extern IntPtr DefWindowProc(IntPtr hWnd, uint uMsg, IntPtr wParam, IntPtr lParam);
        // Exported function for Windows to show the configuration dialog
        [DllExport("ScreenSaverConfigureDialog", CallingConvention = CallingConvention.StdCall)]
        public static bool ScreenSaverConfigureDialog(IntPtr hWnd, uint message, IntPtr wParam, IntPtr lParam)
        {
            if (message == WM_INITDIALOG)
            {
                Program.ShowSettingsForm();
                return true;
            }
            return false;
        }
        // Exported function for Windows to run the screensaver
        [DllExport("ScreenSaverProc", CallingConvention = CallingConvention.StdCall)]
        public static IntPtr ScreenSaverProc(IntPtr hWnd, uint message, IntPtr wParam, IntPtr lParam)
        {
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
                        if (screensaverForms == null) return IntPtr.Zero;;
                        foreach(RandomArt scr in screensaverForms) {
                            scr.Stop();
                            scr.Close();
                            scr.Dispose();
                        }
                        return IntPtr.Zero;
                    case WM_MOUSEMOVE:
                    case WM_KEYDOWN:
                        // Exit the screensaver on mouse movement or key press
                        if (screensaverForms == null) return IntPtr.Zero;;
                        foreach(RandomArt scr in screensaverForms) {
                            if (scr.IsDemo != 1) {
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
        [StructLayout(LayoutKind.Sequential)]
        public struct RECT
        {
            public int Left;
            public int Top;
            public int Right;
            public int Bottom;
        }

        private static readonly string SettingsFileName = "RandomArt.json";
        private static readonly string FilePath = "\\Local\\RandomArt";
        private static readonly string logFileName = "RandomArt_log.log";
        //private static readonly string logFilePath = Path.Combine("C:\\Data", logFileName);
        
        public static int? All_artType = null;
        public static SaverSettings? saverSettings;

        public static List<RandomArt>? screensaverForms;
        // Required constants and external functions
        public const uint WM_CREATE = 0x0001;
        public const uint WM_DESTROY = 0x0002;
        public const uint WM_MOUSEMOVE = 0x0200;
        public const uint WM_KEYDOWN = 0x0100;
        public const uint WM_ERASEBKGND = 0x0014;
        public const uint WM_PAINT = 0x000F;
        public const uint WM_INITDIALOG = 0x0110;
        public const int GWL_STYLE = -16;
        public const uint WS_CHILD = 0x40000000;
        public const uint SRCCOPY = 0x00CC0020;
        
        public static void SavePicture(Form form) {
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
                    SaverSettings? settings = JsonSerializer.Deserialize<SaverSettings>(jsonString);
                    if (settings != null) saverSettings = settings;
                }
                else
                {
                    saverSettings = new SaverSettings();
                }
            }
            catch (Exception ex)
            {
                Log($"Error loading settings: {ex.Message}");
                saverSettings = new SaverSettings();
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
                string jsonString = JsonSerializer.Serialize(saverSettings, new JsonSerializerOptions { WriteIndented = true });
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

    public enum artType {
        Dots = 0,
        Grow = 1,
        Scribble = 2,
        Light = 3,
        Weeds = 4,
        Bubbles = 5,
        Warp = 6,
        Plasma = 7,
    }
}
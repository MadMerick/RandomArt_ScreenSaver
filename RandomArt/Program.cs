using System.Runtime.InteropServices;
using Newtonsoft.Json.Linq;
using System.Diagnostics;

namespace RandomArtScreensaver
{
    public static class Program
    {
        public static bool Logging = false;
        public static bool IsTesting = true;
        public static decimal Version = 2.3m;

        #region DLL Imports
        [DllImport("user32.dll", SetLastError = true)]
        private static extern IntPtr SetParent(IntPtr hWndChild, IntPtr hWndNewParent);[DllImport("user32.dll", SetLastError = true)]
        private static extern int SetWindowLong(IntPtr hWnd, int nIndex, uint dwNewLong);
        [DllImport("user32.dll", SetLastError = true)]
        private static extern int GetWindowLong(IntPtr hWnd, int nIndex);
        [DllImport("user32.dll")]
        [return: MarshalAs(UnmanagedType.Bool)]
        private static extern bool GetClientRect(IntPtr hWnd, out RECT lpRect);
        #endregion
        #region Structures
        [StructLayout(LayoutKind.Sequential)]
        public struct RECT
        {
            public int Left;
            public int Top;
            public int Right;
            public int Bottom;
        }
        #endregion
        #region Constants
        // Required constants and external functions
        private const int GWL_STYLE = -16;
        private const uint WS_CHILD = 0x40000000;
        private const string GitHubOwner = "MadMerick";
        private const string GitHubRepo = "RandomArt_ScreenSaver";

        #endregion
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
            Forms.SettingsForm settingsForm = new Forms.SettingsForm();
            Application.Run(settingsForm);
        }
        public static void RunPreview(IntPtr previewHandle) {
            Settings.Log("Started RunPreview:" + previewHandle);
            if (previewHandle == IntPtr.Zero) return;

            RECT rect;
            if (GetClientRect(previewHandle, out rect))
            {
                try {
                    Settings.screensaverForms = new List<RandomArt>();
                    Rectangle previewRect = new Rectangle(rect.Left, rect.Top, rect.Right - rect.Left, rect.Bottom - rect.Top);
                    Settings.Log($"Preview Window Size: {previewRect}");
                    RandomArt scr = new RandomArt(previewRect, 2);
                    scr.TopLevel = false;
                    IntPtr scrHandle = scr.Handle;
                    SetParent(scrHandle, previewHandle);
                    SetWindowLong(scrHandle, GWL_STYLE, Convert.ToUInt32(new IntPtr(GetWindowLong(scrHandle, -16) | WS_CHILD)));
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
            Forms.TitleForm titleScreen = new Forms.TitleForm();
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
        public static async Task<Version> GetLatestGitHubVersion()
        {
            try
            {
                using (HttpClient client = new HttpClient())
                {
                    client.DefaultRequestHeaders.Add("User-Agent", GitHubRepo);

                    string url = $"https://api.github.com/repos/{GitHubOwner}/{GitHubRepo}/releases/latest";
                    HttpResponseMessage response = await client.GetAsync(url);

                    if (response.IsSuccessStatusCode)
                    {
                        string json = await response.Content.ReadAsStringAsync();
                        JObject release = JObject.Parse(json);
                        string? tagName = release["tag_name"]?.ToString();

                        if (!string.IsNullOrEmpty(tagName))
                        {
                            // GitHub release tags often start with 'v' (e.g., v1.0.0).
                            // You might need to remove this prefix for accurate version parsing.
                            if (tagName.StartsWith("v", StringComparison.OrdinalIgnoreCase))
                            {
                                tagName = tagName.Substring(1);
                            }
                            return new Version(tagName);
                        }
                    }
                }
            }
            catch (HttpRequestException httpEx)
            {
                // Log the exception, e.g., using a logging framework or Console.WriteLine
                Console.WriteLine($"HTTP request error: {httpEx.Message}");
            }
            catch (Exception ex)
            {
                // Log other exceptions
                Console.WriteLine($"An error occurred during update check: {ex.Message}");
            }
            return null; // Return null if unable to get the latest version
        }
        public static void OpenGitHubReleasePage()
        {
            string releaseUrl = $"https://github.com/{GitHubOwner}/{GitHubRepo}/releases";
            try
            {
                Process.Start(new ProcessStartInfo(releaseUrl) { UseShellExecute = true });
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Could not open the download page: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        public static async Task CheckForUpdates()
        {
            Version currentVersion = new Version(Convert.ToString(Program.Version));
            Version latestGitHubVersion = await GetLatestGitHubVersion();

            if (latestGitHubVersion != null && latestGitHubVersion > currentVersion)
            {
                DialogResult result = MessageBox.Show(
                    $"A newer version ({latestGitHubVersion}) of the application is available!\n\n" +
                    "Do you want to go to the download page?",
                    "New Version Available",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Information
                );

                if (result == DialogResult.Yes)
                {
                    OpenGitHubReleasePage();
                }
            }
            else if (latestGitHubVersion == null)
            {
                MessageBox.Show("Could not check for updates. Please check your internet connection or try again later.", "Update Check Failed", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
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
}
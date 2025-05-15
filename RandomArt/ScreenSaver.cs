using System;
using System.Drawing;
using System.Windows.Forms;
using Microsoft.Win32;
using System.Collections.Generic;
using System.Linq;
using System.Diagnostics;
using System.ComponentModel;

namespace RandomArtScreensaver
{
    public abstract class ScreenSaver : Form
    {
        private Point _mouseLocation;
        private bool _mouseMoved = false;
        public int IsDemo = 0; //0:Normal, 1:Demo, 2:Preview
        public Bitmap? _capturedBackground;
        public ScreenSaver()
        {
            SetStyle(ControlStyles.UserPaint, true);
            SetStyle(ControlStyles.AllPaintingInWmPaint, true);
            SetStyle(ControlStyles.DoubleBuffer, true);
            StartPosition = FormStartPosition.Manual;
            Dock = DockStyle.Fill;
            FormBorderStyle = FormBorderStyle.None;
        }
        protected override void OnMouseMove(MouseEventArgs e)
        {
            if (!_mouseMoved)
            {
                if (Math.Abs(e.X - _mouseLocation.X) > 10 || Math.Abs(e.Y - _mouseLocation.Y) > 10)
                {
                    Settings.Log("Closing on mouse move");
                    if (IsDemo == 0) Application.Exit();
                    //else Dispose();
                }
            }
            _mouseMoved = true;
            base.OnMouseMove(e);
        }
        protected override void OnMouseClick(MouseEventArgs e)
        {
            Settings.Log("Closing on mouse click");
            if (IsDemo == 0) Application.Exit();
            //else Dispose();
            base.OnMouseClick(e);
        }
        protected override void OnKeyDown(KeyEventArgs e)
        {
            Settings.Log("Closing on mouse key down");
            if (IsDemo == 0) Application.Exit();
            //else Dispose();
            base.OnKeyDown(e);
        }
        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            _mouseLocation = Control.MousePosition;
            if (IsDemo == 0) Cursor.Hide();
        }
        protected override void OnClosing(CancelEventArgs e)
        {
            Settings.Log("Closing.");
            if (Settings.saverSettings != null) {
                if (Settings.saverSettings.setWallpaper) {
                    Settings.SavePicture(this);
                }
            }
            if (_capturedBackground != null)
            {
                _capturedBackground.Dispose();
                _capturedBackground = null;
            }
            if (IsDemo != 1) Application.Exit();
            base.OnClosing(e);
        }
        public void SetBackColor() {
            if (Settings.saverSettings == null) return;
            short R;
            short G;
            short B;
		
            if (Settings.saverSettings.UseBack == true)
            {
                BackColor = Color.Black;
                CaptureScreenAndSetBackground();
            }
			else
            {
                if (Settings.saverSettings.backGround.Rand == false)
                    BackColor = Color.FromArgb(Settings.saverSettings.backGround.R, Settings.saverSettings.backGround.G, Settings.saverSettings.backGround.B);
                else
                {
                    Random Rnd = new Random();
                    R = Convert.ToInt16(Rnd.Next(255));
                    G = Convert.ToInt16(Rnd.Next(255));
                    B = Convert.ToInt16(Rnd.Next(255));
                    BackColor = Color.FromArgb(R, G, B);
                }
            }
	    }
        public void CaptureScreenAndSetBackground()
        {
            Screen screen = Screen.FromControl(this);
            if (screen == null) return;
            // Get the dimensions of the primary screen
            int screenWidth = screen.Bounds.Width;
            int screenHeight = screen.Bounds.Height;

            // Create a bitmap to hold the screenshot
            Bitmap screenshot = new Bitmap(screenWidth, screenHeight);
            // Create a graphics object from the bitmap
            using (Graphics graphics = Graphics.FromImage(screenshot))
            {
                // Get the device context of the screen
                IntPtr hdcScreen = Settings.GetDC(IntPtr.Zero); // IntPtr.Zero represents the entire screen
                if (hdcScreen != IntPtr.Zero)
                {
                    Application.DoEvents();
                    System.Threading.Thread.Sleep(1000);
                    // Copy the screen image to the bitmap
                    Settings.BitBlt(graphics.GetHdc(), 0, 0, screenWidth, screenHeight, hdcScreen, 0, 0, Settings.SRCCOPY); // 0xCC0020 is the value for SRCCOPY
                    // Release the screen device context
                    Settings.ReleaseDC(IntPtr.Zero, hdcScreen);
                }
                else
                {
                    MessageBox.Show("Failed to capture the screen.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return; // Exit the method if screen capture fails
                }
            }

            // Set the captured image as the form's background
            _capturedBackground = screenshot;
            //BackgroundImageLayout = ImageLayout.Stretch; // Or any other layout you prefer
        }
    }
}
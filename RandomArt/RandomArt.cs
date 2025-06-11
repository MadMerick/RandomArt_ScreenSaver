using System.ComponentModel.Design.Serialization;
using System.Drawing.Imaging;
using RandomArtScreensaver.Entities;

namespace RandomArtScreensaver
{
    public class RandomArt : Forms.ScreenSaverForm
    {
        #region Static Methods for Screen Saver Functionality
        private Random _random = new Random();
        private bool Drawing = false;
        private bool _alpha = true;
        public System.Windows.Forms.Timer tmrPlasma = new System.Windows.Forms.Timer();
        public System.Windows.Forms.Timer tmrPlasmaBlend = new System.Windows.Forms.Timer();
        public System.Windows.Forms.Timer tmrDot = new System.Windows.Forms.Timer();
        public System.Windows.Forms.Timer tmrWarp = new System.Windows.Forms.Timer();
        public System.Windows.Forms.Timer tmrWeeds = new System.Windows.Forms.Timer();
        public System.Windows.Forms.Timer tmrScribble = new System.Windows.Forms.Timer();
        public System.Windows.Forms.Timer tmrGrow = new System.Windows.Forms.Timer();
        public System.Windows.Forms.Timer tmrBubbles = new System.Windows.Forms.Timer();
        public System.Windows.Forms.Timer tmrLight = new System.Windows.Forms.Timer();
        int Angles = 0;
        bool MirrorType;
        public int? _artType = null;
        private Color[,] _Pixels = new Color[1,1];
        private Bitmap? _screenBuffer;
        private Bitmap? _newScreenBuffer;
        private Bitmap? _originalBaseBufferForFade;
        private bool _isBlending = false;
        private int _currentFadeStep = 0;
        private int _numberOfFadeSteps = 10;
        public void InitializeComponent()
        {
            // Initialize default art type configurations
            if (Settings.saverSettings == null) Settings.LoadSettings();
            if (Settings.saverSettings == null) return;
            _screenBuffer = new Bitmap(Width, Height, System.Drawing.Imaging.PixelFormat.Format32bppArgb);
            // 
            // tmrPlasma
            // 
            Entities.ArtType? s = Settings.saverSettings.artTypes.Find(o => o.Type == Entities.ArtTypeEnum.Plasma);
            tmrPlasma.Interval = s != null ? s.Speed : 5000;
            tmrPlasma.Tick += tmrPlasma_Tick;
            // 
            // tmrPlasmaBlend
            // 
            tmrPlasmaBlend.Interval = Settings.saverSettings.plasma.TransitionSpeed;
            tmrPlasmaBlend.Tick += tmrPlasmaBlend_Tick;
            _numberOfFadeSteps = Settings.saverSettings.plasma.TransitionCount;
            // 
            // tmrBubbles
            // 
            s = Settings.saverSettings.artTypes.Find(o => o.Type == Entities.ArtTypeEnum.Bubbles);
            tmrBubbles.Interval = s != null ? s.Speed : 500;
            tmrBubbles.Tick += tmrBubbles_Tick;
            // 
            // tmrLight
            // 
            s = Settings.saverSettings.artTypes.Find(o => o.Type == Entities.ArtTypeEnum.Light);
            tmrLight.Interval = s != null ? s.Speed : 500;
            tmrLight.Tick += tmrLight_Tick;
            // 
            // tmrDot
            // 
            s = Settings.saverSettings.artTypes.Find(o => o.Type == Entities.ArtTypeEnum.Dots);
            tmrDot.Interval = s != null ? s.Speed : 1;
            tmrDot.Tick += tmrDot_Tick;
            // 
            // tmrWarp
            // 
            s = Settings.saverSettings.artTypes.Find(o => o.Type == Entities.ArtTypeEnum.Warp);
            tmrWarp.Interval = s != null ? s.Speed : 500;
            tmrWarp.Tick += tmrWarp_Tick;
            // 
            // tmrWeeds
            // 
            s = Settings.saverSettings.artTypes.Find(o => o.Type == Entities.ArtTypeEnum.Weeds);
            tmrWeeds.Interval = s != null ? s.Speed : 500;
            tmrWeeds.Tick += tmrWeeds_Tick;
            // 
            // tmrScribble
            // 
            s = Settings.saverSettings.artTypes.Find(o => o.Type == Entities.ArtTypeEnum.Scribble);
            tmrScribble.Interval = s != null ? s.Speed : 500;
            tmrScribble.Tick += tmrScribble_Tick;
            // 
            // tmrGrow
            // 
            s = Settings.saverSettings.artTypes.Find(o => o.Type == Entities.ArtTypeEnum.Grow);
            tmrGrow.Interval = s != null ? s.Speed : 10;
            tmrGrow.Tick += tmrGrow_Tick;
        }
        public RandomArt(Rectangle parentRect, int isDemo)
        {
            Bounds = parentRect;
            IsDemo = isDemo;
            if (IsDemo == 0) {
                TopMost = true;
                Cursor.Hide();
            }
            else
            {
                TopMost = false;
            }
            SetBackColor();
        }
        #endregion
        #region Tick
        private void tmrGrow_Tick(object? sender, EventArgs e)
        {
            DoGrow();
        }
        private void tmrScribble_Tick(object? sender, EventArgs e)
        {
            DoScribble();
        }
        private void tmrWeeds_Tick(object? sender, EventArgs e)
        {
            DoWeeds();
        }
        private void tmrWarp_Tick(object? sender, EventArgs e)
        {
            DoWarp();
        }
        private void tmrDot_Tick(object? sender, EventArgs e)
        {
            DoDot();
        }
        private void tmrLight_Tick(object? sender, EventArgs e)
        {
            DoLight();
        }
        private void tmrBubbles_Tick(object? sender, EventArgs e)
        {
            DoBubble();
        }
        private void tmrPlasma_Tick(object? sender, EventArgs e)
        {
            DoPlasma();
        }
        private void tmrPlasmaBlend_Tick(object? sender, EventArgs e)
        {
            DoPlasmaBlend();
        }
        #endregion
        #region ScreenSaver Implementation
        protected override void OnLoad(EventArgs e)
        {
            InitializeComponent();
            base.OnLoad(e);
        }
        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            if (_screenBuffer == null) return;
            e.Graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
            /*e.Graphics.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;
            e.Graphics.PixelOffsetMode = System.Drawing.Drawing2D.PixelOffsetMode.HighQuality;
            e.Graphics.CompositingQuality = System.Drawing.Drawing2D.CompositingQuality.HighQuality;*/
            if (_capturedBackground != null)
            {
                e.Graphics.DrawImage(_capturedBackground, ClientRectangle);
            }
            e.Graphics.DrawImage(_screenBuffer, 0, 0);
            return;
        }
        public void Start()
        {
            try
            {
                if (Settings.saverSettings == null) return;
                // Should not reach here if frequencies add up to 100
                int randomNumber = _random.Next(100);
                int cumulativeFrequency = 0;
                foreach (Entities.ArtType _a in Settings.saverSettings.artTypes)
                {
                    cumulativeFrequency += _a.Percentage;
                    if (randomNumber < cumulativeFrequency)
                    {
                        _artType = (int)_a.Type;
                        _alpha = _a.Alpha;
                        break;
                    }
                }
                if (Settings.saverSettings.AllScreens == true) {
                    if (Settings.All_artType == null)
                    {
                        Settings.All_artType = _artType;
                        Settings.All_Alpha = _alpha;
                    }
                    else
                    {
                        _artType = Settings.All_artType;
                        _alpha = Settings.All_Alpha;
                    }
                }
                Settings.Log("ArtType:" + _artType);
                _Pixels = new Color[Width + 1, Height + 1];
                switch (_artType)
                {
                    case (int)Entities.ArtTypeEnum.Grow:
                        SetUp();
                        tmrGrow.Start();
                        break;
                    case (int)Entities.ArtTypeEnum.Light:
                        SetUp();
                        tmrLight.Start();
                        break;
                    case (int)Entities.ArtTypeEnum.Plasma:
                        SetUp();
                        tmrPlasma.Start();
                        DoPlasma();
                        break;
                    case (int)Entities.ArtTypeEnum.Scribble:
                        SetUp();
                        tmrScribble.Start();
                        break;
                    case (int)Entities.ArtTypeEnum.Bubbles:
                        SetUp();
                        tmrBubbles.Start();
                        break;
                    case (int)Entities.ArtTypeEnum.Warp:
                        SetUp();
                        WarpSetup();
                        tmrWarp.Start();
                        break;
                    case (int)Entities.ArtTypeEnum.Dots:
                        SetUp();
                        tmrDot.Start();
                        break;
                    case (int)Entities.ArtTypeEnum.Weeds:
                        SetUp();
                        tmrWeeds.Start();
                        break;
                    default:
                        // Handle default case or error
                        break;
                }
            }
            catch (Exception ex)
            {
                Settings.Log($"Exception in RandomArt.Start(): {ex.Message}");
                Settings.Log($"Stack Trace: {ex.StackTrace}");
            }
        }
        public void Stop() {
            Settings.All_artType = null;
            _artType = null;
            tmrGrow.Stop();
            tmrLight.Stop();
            tmrPlasma.Stop();
            tmrScribble.Stop();
            tmrBubbles.Stop();
            tmrWarp.Stop();
            tmrDot.Stop();
            tmrWeeds.Stop();
        }
        private void WarpSetup() {
            if (Settings.saverSettings == null) return;
            //Set up warp
            Angles = Settings.saverSettings.warp.Angles;
            if (Settings.saverSettings.warp.Rand)
            {
                Angles = Convert.ToInt16(_random.Next(96) + 4);
            }
        }
        private void SetUp() {
            _screenBuffer?.Dispose(); // Dispose of the old bitmap if it exists
            _screenBuffer = new Bitmap(Width, Height, System.Drawing.Imaging.PixelFormat.Format32bppArgb);
        }
        #endregion
        #region Draw Graphics
        unsafe private void DrawLine(byte* pixelPtr, int stride, int bytesPerPixel, int x1, int y1, int x2, int y2, Color color)
        {
            // Implementation of Bresenham's line algorithm (for drawing on a bitmap)
            int dx = Math.Abs(x2 - x1);
            int dy = Math.Abs(y2 - y1);
            int sx = (x1 < x2) ? 1 : -1;
            int sy = (y1 < y2) ? 1 : -1;
            int err = dx - dy;
            int e2;
            int x = x1;
            int y = y1;

            for (int i = 0; i < 10000; i++)
            {
                if (x >= 0 && x < Width && y >= 0 && y < Height) //check boundary
                {
                    int offset = y * stride + x * bytesPerPixel;
                    pixelPtr[offset] = color.B;
                    pixelPtr[offset + 1] = color.G;
                    pixelPtr[offset + 2] = color.R;
                    pixelPtr[offset + 3] = color.A;
                }

                if (x == x2 && y == y2) break;
                e2 = 2 * err;
                if (e2 > -dy)
                {
                    err -= dy;
                    x += sx;
                }
                if (e2 < dx)
                {
                    err += dx;
                    y += sy;
                }
            }
        }
        unsafe private void DrawPixel(byte* pixelPtr, int stride, int bytesPerPixel, int x, int y, Color color)
        {
            if (_screenBuffer == null) return;
            if (x >= 0 && x < Width && y >= 0 && y < Height)
            {
                int offset = y * stride + x * bytesPerPixel;
                if (offset >= 0 && offset < stride * _screenBuffer.Height)
                {
                    pixelPtr[offset] = color.B;
                    pixelPtr[offset + 1] = color.G;
                    pixelPtr[offset + 2] = color.R;
                    pixelPtr[offset + 3] = color.A;
                }
            }
        }
        unsafe private void DrawLargePixel(byte* pixelPtr, int stride, int bytesPerPixel, int x, int y, Color color)
        {
            for (int newX = x - 1; newX < x + 3; newX++)
            {
                for (int newY = y - 1; newY < y + 3; newY++)
                {
                    if (newX == x - 1 || newY == y - 1 || newX == x + 2 || newY == y + 2)
                    {
                        Color c = GetPixelColor(pixelPtr, stride, bytesPerPixel, newX, newY);
                        if (c.A != 0)
                            DrawPixel(pixelPtr, stride, bytesPerPixel, newX, newY, AverageColor(c, color));
                    }
                    else
                    DrawPixel(pixelPtr, stride, bytesPerPixel, newX, newY, color);
                }
            }
        }
        unsafe private Color GetPixelColor(byte* pixelPtr, int stride, int bytesPerPixel, int x, int y)
        {
            Color rColor = new Color();
            if (x >= 0 && x < Width && y >= 0 && y < Height)
            {
                int offset = y * stride + x * bytesPerPixel;
                byte b = pixelPtr[offset];
                byte g = pixelPtr[offset + 1];
                byte r = pixelPtr[offset + 2];
                byte a = pixelPtr[offset + 3];
                rColor = Color.FromArgb(a, r, g, b);
            }
            return rColor;
        }
        #endregion
        #region DoMethods
        private void DoScribble()
        {
            if (Drawing) return;
            if (_screenBuffer == null) return;
            if (Settings.saverSettings == null) return;
            Drawing = true;

            int r = _random.Next(256);
            int g = _random.Next(256);
            int b = _random.Next(256);
            int a = _random.Next(256);
            if (_alpha) a = 255;
            int l = _random.Next((Width + Height) * Settings.saverSettings.scribble.Length);

            int x = _random.Next(Width + 1);
            int y = _random.Next(Height + 1);

            int tries = 0;

            // Lock the bitmap for efficient drawing of multiple pixels
            BitmapData? bmpData = null;
            try
            {
                bmpData = _screenBuffer.LockBits(new Rectangle(0, 0, _screenBuffer.Width, _screenBuffer.Height), ImageLockMode.WriteOnly, PixelFormat.Format32bppArgb);
                IntPtr ptr = bmpData.Scan0;
                int bytesPerPixel = Image.GetPixelFormatSize(bmpData.PixelFormat) / 8;
                int stride = bmpData.Stride;

                unsafe
                {
                    byte* pixelPtr = (byte*)ptr;

                    for (int i = 0; i <= l; i++)
                    {
                        int d = _random.Next(4);

                        if (d == 0)
                        {
                            if (x < Width) x += 2;
                            else tries++;
                        }
                        else if (d == 1)
                        {
                            if (y < Height) y += 2;
                            else tries++;
                        }
                        else if (d == 2)
                        {
                            if (x > 0) x -= 2;
                            else tries++;
                        }
                        else // d == 3
                        {
                            if (y > 0) y -= 2;
                            else tries++;
                        }

                        if (tries > 5) break;

                        // Directly set the pixel color in the bitmap data
                        DrawLargePixel(pixelPtr, stride, bytesPerPixel, x, y, Color.FromArgb(a, r, g, b));
                    }
                }
            }
            finally
            {
                if (bmpData != null)
                {
                    _screenBuffer.UnlockBits(bmpData);
                }
            }

            Invalidate(); // Trigger a single repaint after the scribble is drawn
            Drawing = false;
        }
        private void DoGrow()
        {
            if (Drawing) return;
            if (_screenBuffer == null) return;
            if (Settings.saverSettings == null) return;
            Drawing = true;

            int r = _random.Next(256);
            int g = _random.Next(256);
            int b = _random.Next(256);
            int a = _random.Next(256);
            if (_alpha) a = 255;
            int x = _random.Next(Width + 1);
            int h = Height - 1;

            BitmapData? bmpData = null;
            try
            {
                bmpData = _screenBuffer.LockBits(new Rectangle(0, 0, _screenBuffer.Width, _screenBuffer.Height), ImageLockMode.ReadWrite, PixelFormat.Format32bppArgb);
                IntPtr ptr = bmpData.Scan0;
                int bytesPerPixel = Image.GetPixelFormatSize(bmpData.PixelFormat) / 8;
                int stride = bmpData.Stride;

                unsafe
                {
                    byte* pixelPtr = (byte*)ptr;

                    for (int y = 0; y <= Height; y += 2)
                    {
                        int checkY = h - y;
                        if (checkY < 0) break;

                        if (x >= 0 && x < Width && checkY >= 0 && checkY < Height)
                        {
                            int offset = checkY * stride + x * bytesPerPixel;
                            if (offset >= 0 && offset < stride * _screenBuffer.Height)
                            {
                                // Get the current pixel's alpha value directly from memory
                                byte currentAlpha = pixelPtr[offset + 3];

                                if (currentAlpha == 0)
                                {
                                    // Set the new pixel color
                                    DrawLargePixel(pixelPtr, stride, bytesPerPixel, x, checkY, Color.FromArgb(a, r, g, b));
                                    break;
                                }
                            }
                        }

                        if (y == Height)
                        {
                            SetUp();
                            break;
                        }
                    }
                }
            }
            finally
            {
                if (bmpData != null)
                {
                    _screenBuffer.UnlockBits(bmpData);
                }
            }

            Invalidate();
            Drawing = false;
        }
        private void DoDot()
        {
            if (Drawing) return;
            if (_screenBuffer == null) return;
            if (Settings.saverSettings == null) return;
            Drawing = true;

            int r = _random.Next(256);
            int g = _random.Next(256);
            int b = _random.Next(256);
            int a = _random.Next(256);
            if (_alpha) a = 255;
            int x = _random.Next(Width + 1);
            int y = _random.Next(Height + 1);

            BitmapData? bmpData = null;
            try
            {
                bmpData = _screenBuffer.LockBits(new Rectangle(0, 0, _screenBuffer.Width, _screenBuffer.Height), ImageLockMode.WriteOnly, PixelFormat.Format32bppArgb);
                IntPtr ptr = bmpData.Scan0;
                int bytesPerPixel = Image.GetPixelFormatSize(bmpData.PixelFormat) / 8;
                int stride = bmpData.Stride;

                unsafe
                {
                    byte* pixelPtr = (byte*)ptr;

                    DrawLargePixel(pixelPtr, stride, bytesPerPixel, x, y, Color.FromArgb(a, r, g, b));
                }
            }
            finally
            {
                if (bmpData != null)
                {
                    _screenBuffer.UnlockBits(bmpData);
                }
            }

            Invalidate(); // Trigger a repaint
            Drawing = false;
        }
        private void DoWeeds()
        {
            if (Drawing) return;
            if (Settings.saverSettings == null) return;
            if (_screenBuffer == null) return;
            Drawing = true;

            int r = _random.Next(256);
            int g = _random.Next(256);
            int b = _random.Next(256);
            int a = _random.Next(256);
            if (_alpha) a = 255;
            int x = _random.Next(Width + 1);
            int y = _random.Next(Height + 1);

            int tries = 0;

            // Lock the bitmap for efficient drawing of multiple pixels
            BitmapData? bmpData = null;
            try
            {
                bmpData = _screenBuffer.LockBits(new Rectangle(0, 0, _screenBuffer.Width, _screenBuffer.Height), ImageLockMode.WriteOnly, PixelFormat.Format32bppArgb);
                IntPtr ptr = bmpData.Scan0;
                int bytesPerPixel = Image.GetPixelFormatSize(bmpData.PixelFormat) / 8;
                int stride = bmpData.Stride;

                unsafe
                {
                    byte* pixelPtr = (byte*)ptr;

                    while (y < Height)
                    {
                        int d = _random.Next(3);

                        if (d == 0)
                        {
                            if (x < Width) x += 2;
                            else tries++;
                        }
                        else if (d == 1)
                        {
                            if (y < Height) y += 2;
                            else tries++;
                        }
                        else // d == 2
                        {
                            if (x > 0) x -= 2;
                            else tries++;
                        }

                        if (tries > 5) break;

                        // Directly set the pixel color in the bitmap data
                        DrawLargePixel(pixelPtr, stride, bytesPerPixel, x, y, Color.FromArgb(a, r, g, b));
                    }
                }
            }
            finally
            {
                if (bmpData != null)
                {
                    _screenBuffer.UnlockBits(bmpData);
                }
            }

            Invalidate(); // Trigger a single repaint after the scribble is drawn
            Drawing = false;
        }
        private void DoWarp()
        {
            if (Drawing) return;
            if (Settings.saverSettings == null) return;
            if (_screenBuffer == null) return;
            Drawing = true;

            BitmapData? bmpData = null;
            try
            {
                bmpData = _screenBuffer.LockBits(new Rectangle(0, 0, _screenBuffer.Width, _screenBuffer.Height), ImageLockMode.ReadWrite, PixelFormat.Format32bppArgb);
                IntPtr ptr = bmpData.Scan0;
                int bytesPerPixel = Image.GetPixelFormatSize(bmpData.PixelFormat) / 8;
                int stride = bmpData.Stride;

                unsafe
                {
                    byte* pixelPtr = (byte*)ptr;
                    int c = Settings.saverSettings.warp.Speed;
                    int cX = Width / 2;
                    int cY = Height / 2;
                    const double PI = 3.14159265;
                    float theta, dtheta;
                    short seg;
                    float radius;
                    int AnglesRand;

                    if (Settings.saverSettings.warp.Smooth)
                    {
                        AnglesRand = _random.Next(-1, 2);
                        Angles = Angles + AnglesRand; // Use the class level 'Angles'
                        if (Angles < 4) Angles = 4;
                        if (Angles > 100) Angles = 100;

                        Color prevColor = Color.Black; // Start with black, or a default.

                        for (int i = 0; i <= (int)(cX * 2); i++)
                        {
                            if (i >= ((int)(cX * 2)) - c)
                            {
                                if (i > 0)
                                {
                                    int R = prevColor.R + _random.Next(-1, 2);
                                    int G = prevColor.G + _random.Next(-1, 2);
                                    int B = prevColor.B + _random.Next(-1, 2);
                                    int A = prevColor.A + _random.Next(-1, 2);
                                    if (_alpha) A = 255;
                                    if (R > 255) R = 255;
                                    if (R < 0) R = 0;
                                    if (G > 255) G = 255;
                                    if (G < 0) G = 0;
                                    if (B > 255) B = 255;
                                    if (B < 0) B = 0;
                                    if (A > 255) A = 255;
                                    if (A < 0) A = 0;
                                    prevColor = Color.FromArgb(A, R, G, B);
                                }
                            }
                            else
                            {
                                // Use the color from the next segment
                                int nextIndex = i + c;
                                if (nextIndex <= (int)(cX * 2))
                                {
                                    // исправлено
                                    radius = (cX * 2) - nextIndex;
                                    dtheta = (float)(2 * PI / Angles);
                                    int nextX = Convert.ToInt32(cX + radius);
                                    int nextY = Convert.ToInt32(cY);
                                    float thetaForNextColor = 0;

                                    for (int segCount = 1; segCount <= Angles; segCount++)
                                    {
                                        thetaForNextColor += dtheta;
                                        int possibleNextX = Convert.ToInt32(cX + (float)(radius * Math.Cos(thetaForNextColor)));
                                        int possibleNextY = Convert.ToInt32(cY + (float)(radius * Math.Sin(thetaForNextColor)));
                                        if (possibleNextX >= 0 && possibleNextX < Width && possibleNextY >= 0 && possibleNextY < Height)
                                        {
                                            int offset = possibleNextY * stride + possibleNextX * bytesPerPixel;
                                            byte b = pixelPtr[offset];
                                            byte g = pixelPtr[offset + 1];
                                            byte r = pixelPtr[offset + 2];
                                            byte a = pixelPtr[offset + 3];
                                            prevColor = Color.FromArgb(a, r, g, b);
                                            break;
                                        }
                                    }
                                }
                            }

                            Color currentColor = prevColor;
                            radius = (cX * 2) - i;
                            dtheta = (float)(2 * PI / Angles);
                            int currentX = Convert.ToInt32(cX + radius);
                            int currentY = Convert.ToInt32(cY);
                            theta = 0;

                            for (seg = 1; seg <= Angles; seg++)
                            {
                                theta = theta + dtheta;
                                int nextX = Convert.ToInt32(cX + (float)(radius * Math.Cos(theta)));
                                int nextY = Convert.ToInt32(cY + (float)(radius * Math.Sin(theta)));

                                // Draw the line directly onto the bitmap
                                DrawLine(pixelPtr, stride, bytesPerPixel, currentX, currentY, nextX, nextY, currentColor);

                                currentX = nextX;
                                currentY = nextY;
                            }
                        }
                    }
                    else // DoCircle2
                    {
                        Angles = Settings.saverSettings.warp.Angles;
                        if (Settings.saverSettings.warp.Rand)
                        {
                            Angles = _random.Next(96) + 4;
                        }
                        for (int i = 0; i <= (int)(cX * 2); i++)
                        {
                            int R = _random.Next(0, 256);
                            int G = _random.Next(0, 256);
                            int B = _random.Next(0, 256);
                            int A = 255; //_random.Next(0, 256);
                            Color currentColor = Color.FromArgb(A, R, G, B);

                            radius = (cX * 2) - i;
                            dtheta = (float)(2 * PI / Angles);
                            int currentX = Convert.ToInt32(cX + radius);
                            int currentY = Convert.ToInt32(cY);
                            theta = 0;

                            for (seg = 1; seg <= Angles; seg++)
                            {
                                theta = theta + dtheta;
                                int nextX = Convert.ToInt32(cX + (float)(radius * Math.Cos(theta)));
                                int nextY = Convert.ToInt32(cY + (float)(radius * Math.Sin(theta)));

                                // Draw the line directly onto the bitmap
                                DrawLine(pixelPtr, stride, bytesPerPixel, currentX, currentY, nextX, nextY, currentColor);

                                currentX = nextX;
                                currentY = nextY;
                            }
                        }
                    }
                }
            }
            finally
            {
                if (bmpData != null)
                {
                    _screenBuffer.UnlockBits(bmpData);
                }
            }
            Invalidate();
            Drawing = false;
        }
        private void DoLight()
        {
            if (Drawing) return;
            if (_screenBuffer == null) return;
            if (Settings.saverSettings == null) return;
            Drawing = true;

            int centerX = _random.Next(0, Width);
            int centerY = _random.Next(0, Height);
            int maxRadius = _random.Next(Width / 50, Width / 4);
            //maxRadius = 20; // For testing
            int r = _random.Next(256);
            int g = _random.Next(256);
            int b = _random.Next(256);

            BitmapData? bmpData = null;
            try
            {
                bmpData = _screenBuffer.LockBits(new Rectangle(0, 0, _screenBuffer.Width, _screenBuffer.Height), ImageLockMode.ReadWrite, PixelFormat.Format32bppArgb);
                IntPtr ptr = bmpData.Scan0;
                int bytesPerPixel = Image.GetPixelFormatSize(bmpData.PixelFormat) / 8;
                int stride = bmpData.Stride;

                unsafe
                {
                    byte* pixelPtr = (byte*)ptr;
                    decimal alphaStep = Decimal.Divide(100, maxRadius - (Settings.saverSettings.light.Center * maxRadius));
                    int maxAlpha = (int)((1 - Settings.saverSettings.light.Transparent) * 255); // the most opaque it will get = center
                    if (_alpha) maxAlpha = 255;
                    decimal start = Settings.saverSettings.light.Center * maxRadius;
                    bool[,] done = new bool[2 * maxRadius + 1, 2 * maxRadius + 1];
                    for (int currentRadius = 1; currentRadius <= maxRadius; currentRadius++)
                    {
                        // Calculate alpha, modified by centerTransparencyPercent and fadeStartPercent
                        int alpha;
                        if (currentRadius < start)
                        {
                            alpha = maxAlpha; // Fully opaque before fadeStart
                        }
                        else
                        {
                            // Calculate alpha, modified by centerTransparencyPercent and fadeStartPercent
                            decimal CurrentStep = alphaStep * (currentRadius - start);
                            CurrentStep = Math.Min(100, Math.Max(0, CurrentStep)); // cap it
                            alpha = (byte)(maxAlpha - (maxAlpha * (CurrentStep * (decimal).01)));
                        }
                        byte a = (byte)alpha;
                        float normalizedBallA = a / 255.0f;

                        for (int xOffset = -currentRadius; xOffset <= currentRadius; xOffset++)
                        {
                            for (int yOffset = -currentRadius; yOffset <= currentRadius; yOffset++)
                            {
                                if ((xOffset * xOffset) + (yOffset * yOffset) >= (currentRadius - 1) * (currentRadius - 1) &&
                                    (xOffset * xOffset) + (yOffset * yOffset) <= currentRadius * currentRadius)
                                {
                                    int x = centerX + xOffset;
                                    int y = centerY + yOffset;
                                    int doneX = xOffset + maxRadius;
                                    int doneY = yOffset + maxRadius;

                                    if (x >= 0 && x < Width && y >= 0 && y < Height &&
                                        doneX >= 0 && doneX < 2 * maxRadius + 1 && doneY >= 0 && doneY < 2 * maxRadius + 1 &&
                                        !done[doneX, doneY])
                                    {
                                        int offset = y * stride + x * bytesPerPixel;
                                        if (offset >= 0 && offset < stride * _screenBuffer.Height)
                                        {
                                            byte currentB = pixelPtr[offset];
                                            byte currentG = pixelPtr[offset + 1];
                                            byte currentR = pixelPtr[offset + 2];
                                            byte currentBufferA = pixelPtr[offset + 3];

                                            byte newB = (byte)((b * normalizedBallA) + (currentB * (1 - normalizedBallA)));
                                            byte newG = (byte)((g * normalizedBallA) + (currentG * (1 - normalizedBallA)));
                                            byte newR = (byte)((r * normalizedBallA) + (currentR * (1 - normalizedBallA)));
                                            byte newA = (byte)Math.Min(255, a + currentBufferA * (1 - normalizedBallA));

                                            pixelPtr[offset] = newB;
                                            pixelPtr[offset + 1] = newG;
                                            pixelPtr[offset + 2] = newR;
                                            pixelPtr[offset + 3] = newA;

                                            done[doneX, doneY] = true;
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }
            finally
            {
                if (bmpData != null)
                {
                    _screenBuffer.UnlockBits(bmpData);
                }
            }

            Invalidate();
            Drawing = false;
        }
        private void DoBubble()
        {
            if (Drawing) return;
            if (_screenBuffer == null) return;
            if (Settings.saverSettings == null) return;
            Drawing = true;

            int centerX = _random.Next(0, Width);
            int centerY = _random.Next(0, Height);
            int maxRadius = _random.Next(Width / 50, Width / 4);
            //maxRadius = 10; // For testing
            int r = _random.Next(256);
            int g = _random.Next(256);
            int b = _random.Next(256);

            BitmapData? bmpData = null;
            try
            {
                bmpData = _screenBuffer.LockBits(new Rectangle(0, 0, _screenBuffer.Width, _screenBuffer.Height), ImageLockMode.ReadWrite, PixelFormat.Format32bppArgb);
                IntPtr ptr = bmpData.Scan0;
                int bytesPerPixel = Image.GetPixelFormatSize(bmpData.PixelFormat) / 8;
                int stride = bmpData.Stride;

                unsafe
                {
                    byte* pixelPtr = (byte*)ptr;
                    decimal alphaStep = Decimal.Divide(100, maxRadius - (Settings.saverSettings.bubble.Center * maxRadius));

                    bool[,] done = new bool[2 * maxRadius + 1, 2 * maxRadius + 1];
                    decimal start = Settings.saverSettings.bubble.Center * maxRadius;
                    int maxAlpha = (int)((1 - Settings.saverSettings.bubble.Transparent) * 255); // the most opaque it will get = edge
                    if (_alpha) maxAlpha = 255;
                    for (int currentRadius = (int)start; currentRadius <= maxRadius; currentRadius++)
                    {
                        // Calculate alpha, modified by centerTransparencyPercent and fadeStartPercent
                        decimal CurrentStep = alphaStep * (currentRadius - start);
                        CurrentStep = Math.Min(100, Math.Max(0, CurrentStep)); // cap it
                        byte a = (byte)(maxAlpha * (CurrentStep * (decimal).01));
                        float normalizedBallA = a / 255.0f;

                        for (int xOffset = -currentRadius; xOffset <= currentRadius; xOffset++)
                        {
                            for (int yOffset = -currentRadius; yOffset <= currentRadius; yOffset++)
                            {
                                if ((xOffset * xOffset) + (yOffset * yOffset) >= (currentRadius - 1) * (currentRadius - 1) &&
                                    (xOffset * xOffset) + (yOffset * yOffset) <= currentRadius * currentRadius)
                                {
                                    int x = centerX + xOffset;
                                    int y = centerY + yOffset;
                                    int doneX = xOffset + maxRadius;
                                    int doneY = yOffset + maxRadius;

                                    if (x >= 0 && x < Width && y >= 0 && y < Height &&
                                        doneX >= 0 && doneX < 2 * maxRadius + 1 && doneY >= 0 && doneY < 2 * maxRadius + 1 &&
                                        !done[doneX, doneY])
                                    {
                                        int offset = y * stride + x * bytesPerPixel;
                                        if (offset >= 0 && offset < stride * _screenBuffer.Height)
                                        {
                                            byte currentB = pixelPtr[offset];
                                            byte currentG = pixelPtr[offset + 1];
                                            byte currentR = pixelPtr[offset + 2];
                                            byte currentBufferA = pixelPtr[offset + 3];

                                            byte newB = (byte)((b * normalizedBallA) + (currentB * (1 - normalizedBallA)));
                                            byte newG = (byte)((g * normalizedBallA) + (currentG * (1 - normalizedBallA)));
                                            byte newR = (byte)((r * normalizedBallA) + (currentR * (1 - normalizedBallA)));
                                            byte newA = (byte)Math.Min(255, a + currentBufferA * (1 - normalizedBallA));

                                            pixelPtr[offset] = newB;
                                            pixelPtr[offset + 1] = newG;
                                            pixelPtr[offset + 2] = newR;
                                            pixelPtr[offset + 3] = newA;

                                            done[doneX, doneY] = true;
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }
            finally
            {
                if (bmpData != null)
                {
                    _screenBuffer.UnlockBits(bmpData);
                }
            }

            Invalidate();
            Drawing = false;
        }
        private void DoPlasma()
        {
            if (Drawing) return;
            if( _isBlending) return;
            if (Settings.saverSettings == null) return;
            if (_screenBuffer == null) return;
            Drawing = true;
            short ColorAmount;
            bool mirrorType;

            // Create newScreenBuffer if it doesn't exist
            _newScreenBuffer = new Bitmap(_screenBuffer.Width, _screenBuffer.Height, _screenBuffer.PixelFormat);

            // Lock buffer
            BitmapData? newBmpData = null;
            try
            {
                newBmpData = _newScreenBuffer.LockBits(new Rectangle(0, 0, _newScreenBuffer.Width, _newScreenBuffer.Height), ImageLockMode.ReadWrite, PixelFormat.Format32bppArgb);
                IntPtr newPtr = newBmpData.Scan0;
                int bytesPerPixel = Image.GetPixelFormatSize(_newScreenBuffer.PixelFormat) / 8;
                int newStride = newBmpData.Stride;

                unsafe
                {
                    byte* newPixelPtr = (byte*)newPtr;

                    short ColorV;

                    // Entry into the recursive Plasma sub.
                    if (Settings.saverSettings.plasma.Type == 0)
                        mirrorType = _random.Next(0, 2) == 0;
                    else if (Settings.saverSettings.plasma.Type == 1)
                        mirrorType = true;
                    else
                        mirrorType = false; // 2

                    if (Settings.saverSettings.plasma.ColorRand)
                        ColorAmount = (short)(_random.Next(3) + 1);
                    else
                        ColorAmount = (short)Settings.saverSettings.plasma.Color;
                    ColorAmount = (short)Program.GetPowerofTwo(ColorAmount); //ensure it is even

                    if (Settings.saverSettings.plasma.ColorVRand)
                        ColorV = (short)_random.Next(0, 256);
                    else
                        ColorV = (short)Settings.saverSettings.plasma.ColorV;

                    int plasmaWidth = mirrorType ? _newScreenBuffer.Width / 2 : _newScreenBuffer.Width - 1;
                    int plasmaHeight = mirrorType ? _newScreenBuffer.Height / 2 : _newScreenBuffer.Height - 1;

                    // Instead of DoPlasmaStart, do the initialization here
                    Color[,] templatePixels = new Color[Width + 1, Height + 1]; //temp array
                    int iX, iY, cWidth, cHeight;
                    short i = 0;

                    //randomize color in all corners
                    Color cColor = Color.FromArgb(_random.Next(255), _random.Next(255), _random.Next(255), _random.Next(255));
                    if (_alpha) cColor = Color.FromArgb(255, cColor.R, cColor.G, cColor.B);

                    while (i < ColorAmount * ColorAmount) //ColorAmount = 1-7 - keep going until we have have found empty pixel
                    {
                        int[] iC = { cColor.A, cColor.R, cColor.G, cColor.B };
                        int cnt = 4;
                        if (_alpha) cnt = 3;
                        for (int c = 0; c < cnt; c++)
                        {
                            int r = _random.Next(0, 2);
                            if (r == 0) r = -1;
                            iC[c] = iC[c] + _random.Next(0, ColorV + 1) * r;
                            if (iC[c] > 255) iC[c] = 255;
                            if (iC[c] < 0) iC[c] = 0;
                        }
                        cColor = Color.FromArgb(iC[0], iC[1], iC[2], iC[3]);

                        cWidth = _random.Next(ColorAmount + 1); //randomly choose a color amount
                        cHeight = _random.Next(ColorAmount + 1); //randomly choose a color amount

                        iX = (int)Math.Floor(Decimal.Divide(plasmaWidth, ColorAmount) * cWidth); //break the width into segments and randomly go x number of segments
                        iY = (int)Math.Floor(Decimal.Divide(plasmaHeight, ColorAmount) * cHeight); //break the height into segments and randomly go y many segments
                        if (iX >= plasmaWidth) iX = plasmaWidth;
                        if (iY >= plasmaHeight) iY = plasmaHeight;

                        short inner_i = 0; // Using a separate counter for the inner loop
                        while (inner_i < ColorAmount * ColorAmount) //keep trying new pixels until we have have found empty pixel
                        {
                            if (templatePixels[iX, iY].Name != "0")
                            {
                                short iD = (short)_random.Next(4); //Randomly choosea direction

                                if (iD == 0) // go up a segment
                                    if (cHeight != 0) cHeight--;
                                    else if (iD == 1) // go right a segment
                                        if (cWidth != ColorAmount) cWidth++;
                                        else if (iD == 2) // go down a segment
                                            if (cHeight != ColorAmount) cHeight++;
                                            else // (iD == 3) // go left a segment
                                            if (cWidth != 0) cWidth--;

                                iX = (int)Math.Floor(Decimal.Divide(plasmaWidth, ColorAmount) * cWidth); //go x many segments and try again
                                iY = (int)Math.Floor(Decimal.Divide(plasmaHeight, ColorAmount) * cHeight); //go y many segments and try again
                                if (iX >= plasmaWidth) iX = plasmaWidth;
                                if (iY > -plasmaHeight) iY = plasmaHeight;
                            }
                            else
                            {
                                templatePixels[iX, iY] = cColor;
                                if (iX + 1 < Width + 1)
                                    templatePixels[iX + 1, iY] = cColor;
                                if (iY + 1 < Height + 1)
                                    templatePixels[iX, iY + 1] = cColor;
                                if (iX + 1 < Width + 1 && iY + 1 < Height + 1)
                                    templatePixels[iX + 1, iY + 1] = cColor;
                                i++;
                                break; // Exit inner loop after setting a pixel
                            }
                            inner_i++;
                        }
                    }
                    //DoPlasmaDetails(0, 0, plasmaWidth, plasmaHeight, partSize);  //original call
                    PlasmaDetails(newPixelPtr, newStride, bytesPerPixel, 0, 0, plasmaWidth, plasmaHeight, templatePixels); //draw to new buffer

                    if (mirrorType)
                        MirrorPlasma(newPixelPtr, newStride, bytesPerPixel, plasmaWidth, plasmaHeight);
                }
            }
            finally
            {
                if (newBmpData != null)
                    _newScreenBuffer.UnlockBits(newBmpData);
            }
            Drawing = false;
            Application.DoEvents();
            tmrPlasma.Stop();
            _originalBaseBufferForFade = (Bitmap)_screenBuffer.Clone();
            _currentFadeStep = 0;
            tmrPlasmaBlend.Start();
        }
        private void DoPlasmaBlend()
        {
            if (_screenBuffer == null || _originalBaseBufferForFade == null || _newScreenBuffer == null) return;
            if (_currentFadeStep > _numberOfFadeSteps)
            {
                // Fade complete
                tmrPlasmaBlend.Stop();

                // Dispose of the temporary original base buffer
                _originalBaseBufferForFade?.Dispose();
                _originalBaseBufferForFade = null;

                this.Invalidate();

                tmrPlasma.Start();
                return;
            }

            float alpha = (float)_currentFadeStep / _numberOfFadeSteps;

            // Create a temporary bitmap for this step's rendering
            // It's crucial to create a new bitmap for each step or clear and redraw onto one,
            // otherwise, you'll accumulate the alpha blending.
            Bitmap tempBuffer = new Bitmap(_screenBuffer.Width, _screenBuffer.Height, PixelFormat.Format32bppArgb);

            using (Graphics g = Graphics.FromImage(tempBuffer))
            {
                g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;
                g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
                g.PixelOffsetMode = System.Drawing.Drawing2D.PixelOffsetMode.HighQuality;
                g.CompositingQuality = System.Drawing.Drawing2D.CompositingQuality.HighQuality;

                // 1. Draw the original base _screenBuffer state (before fading started)
                // This ensures _newScreenBuffer is blended onto a clean, stable base.
                g.DrawImage(_originalBaseBufferForFade, 0, 0, _originalBaseBufferForFade.Width, _originalBaseBufferForFade.Height);

                // 2. Prepare ImageAttributes for alpha blending _newScreenBuffer
                ColorMatrix cm = new ColorMatrix();
                cm.Matrix33 = alpha; // Set the overall alpha for the top bitmap

                ImageAttributes ia = new ImageAttributes();
                ia.SetColorMatrix(cm, ColorMatrixFlag.Default, ColorAdjustType.Bitmap);

                // 3. Draw _newScreenBuffer with the calculated alpha onto the temporary buffer
                g.DrawImage(_newScreenBuffer,
                            new Rectangle(0, 0, _newScreenBuffer.Width, _newScreenBuffer.Height),
                            0, 0, _newScreenBuffer.Width, _newScreenBuffer.Height,
                            GraphicsUnit.Pixel,
                            ia);
            }

            // Now, update _screenBuffer with the newly rendered frame
            // Dispose the old _screenBuffer if it's not the same instance as _originalBaseBufferForFade
            _screenBuffer?.Dispose();
            _screenBuffer = tempBuffer; // _screenBuffer now holds the current fade state

            // Request a repaint of the control, which will use the updated _screenBuffer
            Invalidate();

            _currentFadeStep++;
        }
        unsafe private void PlasmaDetails(byte* pixelPtr, int stride, int bytesPerPixel, int left, int top, int width, int height, Color[,] templatePixels)
        {
            if (_newScreenBuffer == null) return;
            if ((width - left < 2) && (height - top < 2)) return; //if the box is small, exit
            int midX = (left + width) / 2;
            int midY = (top + height) / 2;
            if (width >= _newScreenBuffer.Width) width = _newScreenBuffer.Width;
            if (height >= _newScreenBuffer.Height) height = _newScreenBuffer.Height;

            // Get the colors from the templatePixels or the image
            Color cTopLeft = templatePixels[left, top];
            if (cTopLeft.Name == "0") cTopLeft = GetPixelColor(pixelPtr, stride, bytesPerPixel, left, top);
            Color cTopRight = templatePixels[width, top];
            if (cTopRight.Name == "0") cTopRight = GetPixelColor(pixelPtr, stride, bytesPerPixel, width, top);
            Color cBottomRight = templatePixels[width, height];
            if (cBottomRight.Name == "0") cBottomRight = GetPixelColor(pixelPtr, stride, bytesPerPixel, width, height);
            Color cBottomLeft = templatePixels[left, height];
            if (cBottomLeft.Name == "0") cBottomLeft = GetPixelColor(pixelPtr, stride, bytesPerPixel, left, height);

            // Calculate the mid-point colors using the correct neighbors
            Color cMidTop = templatePixels[midX, top];
            //if (cMidTop.Name == "0") cMidTop = GetPixelColor(pixelPtr, stride, bytesPerPixel, midX, top);
            if (cMidTop.Name == "0") cMidTop = AverageColor(cTopLeft, cTopRight);
            Color cMidBottom = templatePixels[midX, height];
            //if (cMidBottom.Name == "0") cMidBottom = GetPixelColor(pixelPtr, stride, bytesPerPixel, midX, height);
            if (cMidBottom.Name == "0") cMidBottom = AverageColor(cBottomLeft, cBottomRight);
            Color cMidLeft = templatePixels[left, midY];
            //if (cMidLeft.Name == "0") cMidLeft = GetPixelColor(pixelPtr, stride, bytesPerPixel, left, midY);
            if (cMidLeft.Name == "0") cMidLeft = AverageColor(cTopLeft, cBottomLeft);
            Color cMidRight = templatePixels[width, midY];
            //if (cMidRight.Name == "0") cMidRight = GetPixelColor(pixelPtr, stride, bytesPerPixel, width, midY);
            if (cMidRight.Name == "0") cMidRight = AverageColor(cTopRight, cBottomRight);
            Color cMiddle = templatePixels[midX, midY];
            //if (cMiddle.Name == "0") cMiddle = GetPixelColor(pixelPtr, stride, bytesPerPixel, midX, midY);
            if (cMiddle.Name == "0") cMiddle = AverageColor4(cTopLeft, cTopRight, cBottomLeft, cBottomRight);

            // Draw the corners
            DrawPixel(pixelPtr, stride, bytesPerPixel, left, top, cTopLeft);
            DrawPixel(pixelPtr, stride, bytesPerPixel, width, top, cTopRight);
            DrawPixel(pixelPtr, stride, bytesPerPixel, width, height, cBottomRight);
            DrawPixel(pixelPtr, stride, bytesPerPixel, left, height, cBottomLeft);

            // Draw the mid-points
            DrawPixel(pixelPtr, stride, bytesPerPixel, midX, top, cMidTop);
            DrawPixel(pixelPtr, stride, bytesPerPixel, midX, height, cMidBottom);
            DrawPixel(pixelPtr, stride, bytesPerPixel, left, midY, cMidLeft);
            DrawPixel(pixelPtr, stride, bytesPerPixel, width, midY, cMidRight);
            DrawPixel(pixelPtr, stride, bytesPerPixel, midX, midY, cMiddle);

            //_screenBuffer = (Bitmap)_newScreenBuffer.Clone();
            //Invalidate();
            //Application.DoEvents();

            //Call the recursive function Plasma for with the bounds of the
            //sub-rectangles as the left, top, width, and height parameters.
            PlasmaDetails(pixelPtr, stride, bytesPerPixel, left, top, midX, midY, templatePixels); //left, top - half
            PlasmaDetails(pixelPtr, stride, bytesPerPixel, midX, top, width, midY, templatePixels); //right, top - half
            PlasmaDetails(pixelPtr, stride, bytesPerPixel, left, midY, midX, height, templatePixels); //left, bottom - half
            PlasmaDetails(pixelPtr, stride, bytesPerPixel, midX, midY, width, height, templatePixels); //right, bottom - half
        }
        private Color AverageColor(Color c1, Color c2)
        {
            return Color.FromArgb(
                (c1.A + c2.A) / 2,
                (c1.R + c2.R) / 2,
                (c1.G + c2.G) / 2,
                (c1.B + c2.B) / 2
            );
        }
        private Color AverageColor4(Color c1, Color c2, Color c3, Color c4)
        {
            return Color.FromArgb(
                (c1.A + c2.A + c3.A + c4.A) / 4,
                (c1.R + c2.R + c3.R + c4.R) / 4,
                (c1.G + c2.G + c3.G + c4.G) / 4,
                (c1.B + c2.B + c3.B + c4.B) / 4
            );
        }
        unsafe private void MirrorPlasma(byte* pixelPtr, int stride, int bytesPerPixel, int plasmaWidth, int plasmaHeight)
        {
            for (int x = 0; x < plasmaWidth; x++)
            {
                for (int y = 0; y < plasmaHeight; y++)
                {
                    Color sourceColor = GetPixelColor(pixelPtr, stride, bytesPerPixel, x, y);

                    // Mirror horizontally
                    int mirroredX = Width - 1 - x;
                    DrawPixel(pixelPtr, stride, bytesPerPixel, mirroredX, y, sourceColor);

                    // Mirror vertically
                    int mirroredY = Height - 1 - y;
                    DrawPixel(pixelPtr, stride, bytesPerPixel, x, mirroredY, sourceColor);

                    // Mirror both horizontally and vertically
                    DrawPixel(pixelPtr, stride, bytesPerPixel, mirroredX, mirroredY, sourceColor);
                }
            }
        }
        #endregion
    }
}
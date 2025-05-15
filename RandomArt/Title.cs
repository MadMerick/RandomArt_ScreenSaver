using System.Reflection;
using System.Drawing;
using System.IO;
using System.ComponentModel;
using System.Security.Cryptography.X509Certificates;

namespace RandomArtScreensaver
{
    public partial class TitleScreen : Form
    {
        public TitleScreen()
        {
            InitializeComponent();
            // Add your logo, maker, version information to labels or drawing
            Text = "RandomArt"; // Example title bar text
            ClientSize = new Size(300, 200); // Example size
        }
        private IContainer components = new Container();
        public ToolTip ToolTip1 = new ToolTip();
        public Label lblXeno = new Label();
        public Label lblVersion = new Label();
        public Label LblMe = new Label();
        public Label lblTitle = new Label();
        public PictureBox imgIcon = new PictureBox();
        private void InitializeComponent()
        {
            SuspendLayout();
            components = new Container();
            ToolTip1 = new ToolTip(components);
			lblXeno = new Label();
			lblVersion = new Label();
			LblMe = new Label();
			lblTitle = new Label();
			imgIcon = new PictureBox();
			((ISupportInitialize)imgIcon).BeginInit();
			SuspendLayout();
			// 
			// lblXeno
			// 
			lblXeno.BackColor = Color.Transparent;
			lblXeno.ForeColor = SystemColors.ControlText;
			lblXeno.Location = new Point(40, 56);
			lblXeno.Name = "lblXeno";
			lblXeno.RightToLeft = RightToLeft.No;
			lblXeno.Size = new Size(257, 17);
			lblXeno.TabIndex = 3;
			lblXeno.Text = "GNU General Public License v3.0";
			lblXeno.TextAlign = ContentAlignment.TopCenter;
			// 
			// lblVersion
			// 
			lblVersion.BackColor = Color.Transparent;
			lblVersion.ForeColor = SystemColors.ControlText;
			lblVersion.Location = new Point(56, 32);
			lblVersion.Name = "lblVersion";
			lblVersion.RightToLeft = RightToLeft.No;
			lblVersion.Size = new Size(209, 15);
			lblVersion.TabIndex = 2;
			lblVersion.Tag = "Version";
			lblVersion.Text = "Version";
			lblVersion.TextAlign = ContentAlignment.TopCenter;
			// 
			// LblMe
			// 
			LblMe.BackColor = Color.Transparent;
			LblMe.ForeColor = SystemColors.ControlText;
			LblMe.Location = new Point(8, 72);
			LblMe.Name = "LblMe";
			LblMe.RightToLeft = RightToLeft.No;
			LblMe.Size = new Size(305, 17);
			LblMe.TabIndex = 1;
			LblMe.Text = "Open Source: github.com/MadMerick";
			LblMe.TextAlign = ContentAlignment.TopCenter;
			// 
			// lblTitle
			// 
			lblTitle.BackColor = Color.Transparent;
			lblTitle.ForeColor = SystemColors.ControlText;
			lblTitle.Location = new Point(56, 8);
			lblTitle.Name = "lblTitle";
			lblTitle.RightToLeft = RightToLeft.No;
			lblTitle.Size = new Size(265, 25);
			lblTitle.TabIndex = 0;
			lblTitle.Text = "Random Art Screen Saver";
			lblTitle.TextAlign = ContentAlignment.TopCenter;
			// 
			// imgIcon
			// 
			imgIcon.Location = new Point(8, 8);
			imgIcon.Name = "imgIcon";
			imgIcon.Size = new Size(41, 41);
			imgIcon.SizeMode = PictureBoxSizeMode.StretchImage;
			imgIcon.TabIndex = 4;
			imgIcon.TabStop = false;
			imgIcon.BorderStyle = BorderStyle.FixedSingle;
			Assembly currentAssembly = Assembly.GetExecutingAssembly();
			string resourceName = "RandomArtScreensaver.Resources.imgIcon.jpg"; // Double-check this!
			using (Stream? stream = currentAssembly.GetManifestResourceStream(resourceName))
			{
				if (stream != null)
				{
					try
					{
						imgIcon.Image = Image.FromStream(stream);
					}
					catch (Exception ex)
					{
						Settings.Log($"Error loading embedded image: {ex.Message}");
					}
				}
				else
				{
					Settings.Log($"Error: Embedded resource '{resourceName}' not found.");
					// Optionally set a default image or handle the missing resource
				}
			}
			// 
			// frmSplash
			// 
			AutoScaleBaseSize = new Size(5, 13);
			BackColor = SystemColors.Control;
			ClientSize = new Size(323, 104);
			ControlBox = false;
			Controls.Add(lblXeno);
			Controls.Add(lblVersion);
			Controls.Add(LblMe);
			Controls.Add(lblTitle);
			Controls.Add(imgIcon);
			Font = new Font("Arial", 8F, FontStyle.Regular, GraphicsUnit.Point, 0);
			FormBorderStyle = FormBorderStyle.FixedDialog;
			Location = new Point(3, 3);
			MaximizeBox = false;
			MinimizeBox = false;
			Name = "frmSplash";
			RightToLeft = RightToLeft.No;
			ShowInTaskbar = false;
			StartPosition = FormStartPosition.CenterParent;
			Load += TitleScreen_Load;
			Shown += TitleScreen_Shown; 
			((ISupportInitialize)imgIcon).EndInit();
            ResumeLayout(false);
        }
        private void TitleScreen_Shown(object? sender, EventArgs e)
        {
			int i = 0;
			while (i < 5) {
				Application.DoEvents();
				Thread.Sleep(1000);
				i = i + 1;
			}
			Close();
        }
        private void TitleScreen_Load(object? sender, EventArgs e)
		{
			int ScaleDiff;
            ScaleDiff = ClientRectangle.Width - Width;
			imgIcon.Top = 4;
			imgIcon.Left = 4;
			lblTitle.Top = 4;
			lblTitle.Left = imgIcon.Left + imgIcon.Width + 4;
			lblTitle.Width = ClientRectangle.Width - (lblTitle.Left + 4);
			Width = lblTitle.Left + lblTitle.Width + 4 - ScaleDiff;
			lblVersion.Top = lblTitle.Top + lblTitle.Height + 4;
			lblVersion.Left = lblTitle.Left;
			lblVersion.Width = lblTitle.Width;
			lblVersion.Text = "Version 2.0"; // Or some other default value
			lblXeno.Left = lblTitle.Left;
			lblXeno.Width = lblTitle.Width;
            lblXeno.Top = lblVersion.Top + lblVersion.Height + 4;
			LblMe.Left = lblTitle.Left;
			LblMe.Width = lblTitle.Width;
			LblMe.Top = lblXeno.Top + lblXeno.Height;
			ScaleDiff = ClientRectangle.Height - Height;
			Height = LblMe.Top + LblMe.Height + 4 - ScaleDiff;
			Application.DoEvents();
		}
        protected override void OnKeyDown(KeyEventArgs e)
        {
            // Allow dismissal on key press during title screen
            Close();
        }
        protected override void OnMouseDown(MouseEventArgs e)
        {
            // Allow dismissal on mouse click during title screen
            Close();
        }
    }
}
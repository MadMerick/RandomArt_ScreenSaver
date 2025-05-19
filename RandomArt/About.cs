using System.Reflection;
using System.Drawing;
using System.IO;
using System.ComponentModel;
using System.Security.Cryptography.X509Certificates;
using System.Reflection.Metadata.Ecma335;
using System.Net.Mail;

namespace RandomArtScreensaver
{
    public partial class AboutScreen : Form
    {
        public AboutScreen()
        {
            InitializeComponent();
            // Add your logo, maker, version information to labels or drawing
            Text = "RandomArt"; // Example title bar text
            ClientSize = new Size(300, 200); // Example size
        }
        private IContainer components = new Container();
        private ToolTip ToolTip1 = new ToolTip();
        private Label lblTech = new Label();
        private Label lblVersion = new Label();
        private Label LblMe = new Label();
        private Label lblTitle = new Label();
		private Label LblCopyright = new Label();
		private Panel _Line1_1 = new Panel();
		private Panel _Line1_0 = new Panel();
		private Label lblDisclaimer = new Label();
		private Button cmdOK = new Button();
		private Button cmdSysInfo = new Button();
        private PictureBox imgIcon = new PictureBox();
        private void InitializeComponent()
        {
            SuspendLayout();
            components = new Container();
            ToolTip1 = new ToolTip(components);
			lblTech = new Label();
			imgIcon = new PictureBox();
			cmdOK = new Button();
			cmdSysInfo = new Button();
			lblVersion = new Label();
			LblMe = new Label();
			LblCopyright = new Label();
			lblTitle = new Label();
			_Line1_0 = new Panel();
			_Line1_1 = new Panel();
			lblDisclaimer = new Label();
			((ISupportInitialize)imgIcon).BeginInit();
			SuspendLayout();
			// 
			// lblTech
			// 
			lblTech.BackColor = Color.Transparent;
			lblTech.ForeColor = SystemColors.ControlText;
			lblTech.Location = new Point(40, 56);
			lblTech.Name = "lblTech";
			lblTech.RightToLeft = RightToLeft.No;
			lblTech.Size = new Size(257, 17);
			lblTech.TabIndex = 3;
			lblTech.Text = "GNU General Public License v3.0";
			lblTech.TextAlign = ContentAlignment.TopCenter;
			// 
            // cmdOK
            // 
            cmdOK.BackColor = SystemColors.Control;
            cmdOK.ForeColor = SystemColors.ControlText;
            cmdOK.Location = new Point(369, 360);
            cmdOK.Name = "cmdOK";
            cmdOK.RightToLeft = RightToLeft.No;
            cmdOK.Size = new Size(65, 25);
            cmdOK.TabIndex = 25;
            cmdOK.Text = "Ok";
            cmdOK.UseVisualStyleBackColor = false;
            cmdOK.Click += cmdOK_Click;
            cmdOK.Cursor = System.Windows.Forms.Cursors.Hand;
            ToolTip1.SetToolTip(cmdOK, "Close and return.");
			// 
            // cmdSysInfo
            // 
            cmdSysInfo.BackColor = SystemColors.Control;
            cmdSysInfo.ForeColor = SystemColors.ControlText;
            cmdSysInfo.Location = new Point(369, 360);
            cmdSysInfo.Name = "cmdSysInfo";
            cmdSysInfo.RightToLeft = RightToLeft.No;
            cmdSysInfo.Size = new Size(65, 25);
            cmdSysInfo.TabIndex = 25;
            cmdSysInfo.Text = "&System Info...";
            cmdSysInfo.UseVisualStyleBackColor = false;
            cmdSysInfo.Click += cmdSysInfo_Click;
            cmdSysInfo.Cursor = System.Windows.Forms.Cursors.Hand;
            ToolTip1.SetToolTip(cmdSysInfo, "System Info...");
			// 
			// LblMe
			// 
			LblMe.BackColor = Color.Transparent;
			LblMe.ForeColor = SystemColors.ControlText;
			LblMe.Location = new Point(56, 32);
			LblMe.Name = "LblMe";
			LblMe.RightToLeft = RightToLeft.No;
			LblMe.Size = new Size(209, 15);
			LblMe.TabIndex = 2;
			LblMe.Text = "Open Source: github.com/MadMerick";
			LblMe.TextAlign = ContentAlignment.TopCenter;
			// 
			// LblCopyright
			// 
			LblCopyright.BackColor = Color.Transparent;
			LblCopyright.ForeColor = SystemColors.ControlText;
			LblCopyright.Location = new Point(56, 32);
			LblCopyright.Name = "LblCopyright";
			LblCopyright.RightToLeft = RightToLeft.No;
			LblCopyright.Size = new Size(209, 15);
			LblCopyright.TabIndex = 2;
			LblCopyright.Text = "Copyright 2025";
			LblCopyright.TextAlign = ContentAlignment.TopLeft;
			// 
			// lblTitle
			// 
			lblTitle.BackColor = Color.Transparent;
			lblTitle.ForeColor = SystemColors.ControlText;
			lblTitle.Location = new Point(56, 32);
			lblTitle.Name = "lblTitle";
			lblTitle.RightToLeft = RightToLeft.No;
			lblTitle.Size = new Size(209, 15);
			lblTitle.TabIndex = 2;
			lblTitle.Text = "Application Title";
			lblTitle.TextAlign = ContentAlignment.TopCenter;
			// 
			// _Line1_1
			// 
			_Line1_1.BackColor = Color.FromArgb(128, 128, 128);
			_Line1_1.ForeColor = SystemColors.ControlText;
			_Line1_1.Location = new Point(56, 32);
			_Line1_1.Name = "_Line1_1";
			_Line1_1.RightToLeft = RightToLeft.No;
			_Line1_1.Size = new Size(209, 15);
			_Line1_1.TabIndex = 2;
			_Line1_0.AutoSize = false;
			_Line1_1.AutoSize = false;
			_Line1_0.Text = " ";
			_Line1_1.Text = " ";
			// 
			// _Line1_0
			// 
			_Line1_0.BackColor = Color.White;
			_Line1_0.ForeColor = SystemColors.ControlText;
			_Line1_0.Location = new Point(56, 32);
			_Line1_0.Name = "_Line1_0";
			_Line1_0.RightToLeft = RightToLeft.No;
			_Line1_0.Size = new Size(209, 15);
			_Line1_0.TabIndex = 2;
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
			// lblDisclaimer
			// 
			lblDisclaimer.BackColor = Color.Transparent;
			lblDisclaimer.ForeColor = SystemColors.ControlText;
			lblDisclaimer.Location = new Point(8, 72);
			lblDisclaimer.Name = "lblDisclaimer";
			lblDisclaimer.RightToLeft = RightToLeft.No;
			lblDisclaimer.Size = new Size(305, 17);
			lblDisclaimer.TabIndex = 1;
			lblDisclaimer.Text = "Note: Please reproduce and distribute this program freely.";
			lblDisclaimer.TextAlign = ContentAlignment.TopLeft;
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
			// frmAbout
			// 
			AutoScaleBaseSize = new Size(5, 13);
			BackColor = SystemColors.Control;
			ClientSize = new Size(323, 104);
			ControlBox = false;
			Controls.Add(imgIcon);
			Controls.Add(cmdOK);
			Controls.Add(cmdSysInfo);
			Controls.Add(lblVersion);
			Controls.Add(lblDisclaimer);
			Controls.Add(lblTech);
			Controls.Add(LblMe);
			Controls.Add(LblCopyright);
			Controls.Add(lblTitle);
			Controls.Add(_Line1_1);
			Controls.Add(_Line1_0);
			Text = "About Random Art";
			Font = new Font("Arial", 8F, FontStyle.Regular, GraphicsUnit.Point, 0);
			FormBorderStyle = FormBorderStyle.FixedDialog;
			Location = new Point(3, 22);
			Size = new Size(391, 170);
			MaximizeBox = false;
			MinimizeBox = false;
			ControlBox = true;
			WindowState = FormWindowState.Normal;
			Name = "frmAbout";
			RightToLeft = RightToLeft.No;
			ShowInTaskbar = false;
			StartPosition = FormStartPosition.CenterParent;
			Load += AboutScreen_Load;
			((ISupportInitialize)imgIcon).EndInit();
            ResumeLayout(false);
        }

        private void cmdSysInfo_Click(object? sender, EventArgs e)
        {
			string cplPath = System.IO.Path.Combine(Environment.SystemDirectory, "MSINFO32.exe");
			System.Diagnostics.Process.Start(cplPath);
		}

        private void cmdOK_Click(object? sender, EventArgs e)
        {
            this.Close();
        }
        private void AboutScreen_Load(object? sender, EventArgs e)
		{
			int ScaleDiffW = ClientRectangle.Width - Width;
			int ScaleDiffH = ClientRectangle.Height - Height;
			imgIcon.Top = 8;
			imgIcon.Left = 8;
			imgIcon.Size = new Size(89,89);
			lblTitle.Top = 8;
			lblTitle.Left = imgIcon.Left + imgIcon.Width + 8;
			lblTitle.Width = 217;
			lblTitle.Height = Program.TextHeight(lblTitle.Text, lblTitle.Font) + 8;
			Width = lblTitle.Left + lblTitle.Width + 8;
			lblVersion.Top = lblTitle.Top + lblTitle.Height + 8;
			lblVersion.Left = lblTitle.Left;
			lblVersion.Width = lblTitle.Width;
			lblVersion.Text = "Version " + Program.Version; // Or some other default value
			lblVersion.Height = lblTitle.Height;
			lblTech.Left = lblVersion.Left;
			lblTech.Top = lblVersion.Top + lblVersion.Height + 8;
			lblTech.Width = lblVersion.Width;
			lblTech.Height = lblVersion.Height;
			LblMe.Left = lblTitle.Left;
			LblMe.Width = lblTitle.Width;
			LblMe.Top = lblTech.Top + lblTech.Height + 8;
			LblMe.Height = lblTech.Height;
			imgIcon.Height = LblMe.Top + LblMe.Height - imgIcon.Top;
			imgIcon.Width = imgIcon.Width;
			_Line1_0.Top = imgIcon.Top + imgIcon.Height + 8;
			_Line1_0.Left = imgIcon.Left;
			_Line1_0.Width = lblTitle.Left + lblTitle.Width - _Line1_0.Left - 8 - ScaleDiffW;
			_Line1_0.Height = 1;
			_Line1_1.Top= _Line1_0.Top + _Line1_0.Height;
			_Line1_1.Left = _Line1_0.Left;
			_Line1_1.Width = _Line1_0.Width;
			_Line1_1.Height = _Line1_0.Height;
			LblCopyright.Left = _Line1_0.Left;
			LblCopyright.Top = _Line1_1.Top + _Line1_1.Height + 8;
			cmdOK.Top = LblCopyright.Top;
			cmdOK.Width = 100;
			cmdOK.Left = this.Width - cmdOK.Width - 24;
			cmdSysInfo.Left = cmdOK.Left;
			cmdSysInfo.Width = cmdOK.Width;
			cmdSysInfo.Top = cmdOK.Top + cmdOK.Height + 8;
			LblCopyright.Width = cmdOK.Left - LblCopyright.Left;
			lblDisclaimer.Left = LblCopyright.Left;
			lblDisclaimer.Width = LblCopyright.Width;
			lblDisclaimer.Top = LblCopyright.Top + LblCopyright.Height + 8;
			lblDisclaimer.Height = (cmdSysInfo.Top + cmdSysInfo.Height) - lblDisclaimer.Top;
			this.Height = cmdSysInfo.Top + cmdSysInfo.Height + 8 - ScaleDiffH;
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
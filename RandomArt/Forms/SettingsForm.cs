using System.ComponentModel;
using RandomArtScreensaver.Entities;

namespace RandomArtScreensaver.Forms
{
    public partial class SettingsForm : Form
    {
        public SettingsForm()
        {
            InitializeComponent();
        }
        #region Controls
        private IContainer components = new Container();
        private ToolTip ToolTip1 = new ToolTip();
        private Button cmdPreview = new Button();
        private Button cmdDefault = new Button();
        private Button cmdAbout = new Button();
        private CheckBox chkPlasmaVariationRand = new CheckBox();
        private CheckBox chkPlasmaColorRand = new CheckBox();
        private TrackBar sldPlasmaVariation = new TrackBar();
        private TrackBar sldPlasmaColor = new TrackBar();
        private RadioButton _optPlasma_2 = new RadioButton();
        private RadioButton _optPlasma_1 = new RadioButton();
        private RadioButton _optPlasma_0 = new RadioButton();
        private TextBox txtSpeed = new TextBox();
        private CheckBox chkWarpSmooth = new CheckBox();
        private CheckBox chkWarpRand = new CheckBox();
        private TrackBar sldAngles = new TrackBar();
        private Label lblLightTrans = new Label();
        private TrackBar sldLightTrans = new TrackBar();
        private Label lblBubbleTrans = new Label();
        private TrackBar sldBubbleTrans = new TrackBar();
        private Label lblLightCenter = new Label();
        private TrackBar sldLightCenter = new TrackBar();
        private Label lblBubbleCenter = new Label();
        private TrackBar sldBubbleCenter = new TrackBar();
        private Label lblSpeed = new Label();
        private Label lblSpeedMS = new Label();
        private CheckBox chkAlpha = new CheckBox();
        private CheckBox chkLarge = new CheckBox();
        private Label lblWarp = new Label();
        private Label lblWarpSpeed = new Label();
        private TrackBar sldWarpSpeed = new TrackBar();
        private Label lblPlasmaTransistion = new Label();
        private TextBox txtPlasmaTransition = new TextBox();
        private GroupBox frmSettings = new GroupBox();
        private GroupBox frmOptions = new GroupBox();
        private Button cmdCancel = new Button();
        private Button cmdSave = new Button();
        private PictureBox Picture1 = new PictureBox();
        private RandomArt? randomArt;
        private CheckBox chkSetWalpaper = new CheckBox();
        private CheckBox chkAllScreens = new CheckBox();
        private CheckBox chkUseBack = new CheckBox();
        private Button cmdW = new Button();
        private Button cmdB = new Button();
        private CheckBox chkBackRand = new CheckBox();
        private TrackBar sldBlue = new TrackBar();
        private TrackBar sldGreen = new TrackBar();
        private TrackBar sldRed = new TrackBar();
        private Label lblBlue = new Label();
        private Label lblGreen = new Label();
        private Label lblRed = new Label();
        private Label lblScribbleLen = new Label();
        private TrackBar sldScribbleLen = new TrackBar();
        private GroupBox frmBackGround = new GroupBox();
        private TextBox txtListEdit = new TextBox();
        private ListView lstTypes = new ListView();
        private GroupBox frmArtType = new GroupBox();
        private Label lblDemo = new Label();
        private List<RadioButton> optPlasma = new List<RadioButton>();
        private ColumnHeader clhType = new ColumnHeader();
        private ColumnHeader clhPercentage = new ColumnHeader();
        private bool DoDemo = false;
        #endregion
        private void InitializeComponent()
        {
            SuspendLayout();
            components = new Container();
            ToolTip1 = new ToolTip(components);
            chkPlasmaVariationRand = new CheckBox();
            chkPlasmaColorRand = new CheckBox();
            Picture1 = new PictureBox();
            cmdW = new Button();
            cmdB = new Button();
            cmdPreview = new Button();
            cmdDefault = new Button();
            cmdAbout = new Button();
            frmSettings = new GroupBox();
            sldPlasmaVariation = new TrackBar();
            sldPlasmaColor = new TrackBar();
            lblLightTrans = new Label();
            lblLightCenter = new Label();
            lblBubbleTrans = new Label();
            lblBubbleCenter = new Label();
            sldLightCenter = new TrackBar();
            sldLightTrans = new TrackBar();
            sldBubbleCenter = new TrackBar();
            sldBubbleTrans = new TrackBar();
            _optPlasma_2 = new RadioButton();
            _optPlasma_1 = new RadioButton();
            _optPlasma_0 = new RadioButton();
            txtSpeed = new TextBox();
            chkWarpSmooth = new CheckBox();
            chkWarpRand = new CheckBox();
            sldAngles = new TrackBar();
            lblSpeed = new Label();
            lblSpeedMS = new Label();
            chkAlpha = new CheckBox();
            chkLarge = new CheckBox();
            lblWarp = new Label();
            lblWarpSpeed = new Label();
            sldWarpSpeed = new TrackBar();
            lblPlasmaTransistion = new Label();
            txtPlasmaTransition = new TextBox();
            cmdCancel = new Button();
            cmdSave = new Button();
            frmBackGround = new GroupBox();
            frmOptions = new GroupBox();
            chkSetWalpaper = new CheckBox();
            chkAllScreens = new CheckBox();
            chkUseBack = new CheckBox();
            chkBackRand = new CheckBox();
            sldBlue = new TrackBar();
            sldGreen = new TrackBar();
            sldRed = new TrackBar();
            lblBlue = new Label();
            lblGreen = new Label();
            lblRed = new Label();
            lblScribbleLen = new Label();
            sldScribbleLen = new TrackBar();
            frmArtType = new GroupBox();
            txtListEdit = new TextBox();
            lstTypes = new ListView();
            clhType = new ColumnHeader();
            clhPercentage = new ColumnHeader();
            lblDemo = new Label();
            ((ISupportInitialize)Picture1).BeginInit();
            frmSettings.SuspendLayout();
            ((ISupportInitialize)sldPlasmaVariation).BeginInit();
            ((ISupportInitialize)sldPlasmaColor).BeginInit();
            ((ISupportInitialize)sldAngles).BeginInit();
            frmBackGround.SuspendLayout();
            frmOptions.SuspendLayout();
            ((ISupportInitialize)sldBlue).BeginInit();
            ((ISupportInitialize)sldGreen).BeginInit();
            ((ISupportInitialize)sldRed).BeginInit();
            frmArtType.SuspendLayout();
            SuspendLayout();
            // 
            // chkPlasmaVariationRand
            // 
            chkPlasmaVariationRand.BackColor = SystemColors.Control;
            chkPlasmaVariationRand.ForeColor = SystemColors.ControlText;
            chkPlasmaVariationRand.Location = new Point(47, 71);
            chkPlasmaVariationRand.Name = "chkPlasmaVariationRand";
            chkPlasmaVariationRand.RightToLeft = RightToLeft.No;
            chkPlasmaVariationRand.Size = new Size(17, 17);
            chkPlasmaVariationRand.TabIndex = 10;
            chkPlasmaVariationRand.Text = "Random Color Variation:";
            ToolTip1.SetToolTip(chkPlasmaVariationRand, "Randomize the variety of color");
            chkPlasmaVariationRand.UseVisualStyleBackColor = false;
            chkPlasmaVariationRand.CheckedChanged += chkPlasmaVariationRand_CheckedChanged;
            chkPlasmaVariationRand.Cursor = System.Windows.Forms.Cursors.Hand;
            // 
            // chkPlasmaColorRand
            // 
            chkPlasmaColorRand.BackColor = SystemColors.Control;
            chkPlasmaColorRand.ForeColor = SystemColors.ControlText;
            chkPlasmaColorRand.Location = new Point(24, 71);
            chkPlasmaColorRand.Name = "chkPlasmaColorRand";
            chkPlasmaColorRand.RightToLeft = RightToLeft.No;
            chkPlasmaColorRand.Size = new Size(17, 17);
            chkPlasmaColorRand.TabIndex = 8;
            chkPlasmaColorRand.Text = "Random Color Amount:";
            ToolTip1.SetToolTip(chkPlasmaColorRand, "Randomize the frequancy of color changes");
            chkPlasmaColorRand.UseVisualStyleBackColor = false;
            chkPlasmaColorRand.CheckedChanged += chkPlasmaColorRand_CheckedChanged;
            chkPlasmaColorRand.Cursor = System.Windows.Forms.Cursors.Hand;
            // 
            // Picture1
            // 
            Picture1.BackColor = SystemColors.Control;
            Picture1.BorderStyle = BorderStyle.Fixed3D;
            Picture1.ForeColor = SystemColors.ControlText;
            Picture1.Location = new Point(0, 0);
            Picture1.Name = "Picture";
            Picture1.RightToLeft = RightToLeft.No;
            Picture1.Size = new Size(10, 10);
            Picture1.TabIndex = 4;
            Picture1.TabStop = false;
            ToolTip1.SetToolTip(Picture1, "Click to refresh");
            Picture1.Cursor = System.Windows.Forms.Cursors.AppStarting;
            // 
            // cmdW
            // 
            cmdW.BackColor = SystemColors.Control;
            cmdW.ForeColor = SystemColors.ControlText;
            cmdW.Location = new Point(128, 56);
            cmdW.Name = "cmdW";
            cmdW.RightToLeft = RightToLeft.No;
            cmdW.Size = new Size(17, 17);
            cmdW.TabIndex = 21;
            cmdW.Text = "W";
            ToolTip1.SetToolTip(cmdW, "White background");
            cmdW.UseVisualStyleBackColor = false;
            cmdW.Click += cmdW_Click;
            cmdW.Cursor = System.Windows.Forms.Cursors.Hand;
            // 
            // cmdB
            // 
            cmdB.BackColor = SystemColors.Control;
            cmdB.ForeColor = SystemColors.ControlText;
            cmdB.Location = new Point(104, 56);
            cmdB.Name = "cmdB";
            cmdB.RightToLeft = RightToLeft.No;
            cmdB.Size = new Size(17, 17);
            cmdB.TabIndex = 20;
            cmdB.Text = "B";
            ToolTip1.SetToolTip(cmdB, "Black background");
            cmdB.UseVisualStyleBackColor = false;
            cmdB.Click += cmdB_Click;
            cmdB.Cursor = System.Windows.Forms.Cursors.Hand;
            // 
            // cmdPreview
            // 
            cmdPreview.BackColor = SystemColors.Control;
            cmdPreview.ForeColor = SystemColors.ControlText;
            cmdPreview.Location = new Point(248, 360);
            cmdPreview.Name = "cmdPreview";
            cmdPreview.RightToLeft = RightToLeft.No;
            cmdPreview.Size = new Size(65, 25);
            cmdPreview.TabIndex = 29;
            cmdPreview.Text = "Preview";
            ToolTip1.SetToolTip(cmdPreview, "Preview in full screen mode");
            cmdPreview.UseVisualStyleBackColor = false;
            cmdPreview.Click += cmdPreview_Click;
            cmdPreview.Cursor = System.Windows.Forms.Cursors.Hand;
            // 
            // cmdDefault
            // 
            cmdDefault.BackColor = SystemColors.Control;
            cmdDefault.ForeColor = SystemColors.ControlText;
            cmdDefault.Location = new Point(176, 360);
            cmdDefault.Name = "cmdDefault";
            cmdDefault.RightToLeft = RightToLeft.No;
            cmdDefault.Size = new Size(65, 25);
            cmdDefault.TabIndex = 28;
            cmdDefault.Text = "Default";
            ToolTip1.SetToolTip(cmdDefault, "Reset all settings to default");
            cmdDefault.UseVisualStyleBackColor = false;
            cmdDefault.Click += cmdDefault_Click;
            cmdDefault.Cursor = System.Windows.Forms.Cursors.Hand;
            // 
            // cmdAbout
            // 
            cmdAbout.BackColor = SystemColors.Control;
            cmdAbout.ForeColor = SystemColors.ControlText;
            cmdAbout.Location = new Point(48, 360);
            cmdAbout.Name = "cmdAbout";
            cmdAbout.RightToLeft = RightToLeft.No;
            cmdAbout.Size = new Size(121, 25);
            cmdAbout.TabIndex = 27;
            cmdAbout.Text = "About Random Art";
            ToolTip1.SetToolTip(cmdAbout, "Click to view more");
            cmdAbout.UseVisualStyleBackColor = false;
            cmdAbout.Click += cmdAbout_Click;
            cmdAbout.Cursor = System.Windows.Forms.Cursors.Hand;
            // 
            // frmSettings
            // 
            frmSettings.BackColor = SystemColors.Control;
            frmSettings.Controls.Add(chkPlasmaVariationRand);
            frmSettings.Controls.Add(chkPlasmaColorRand);
            frmSettings.Controls.Add(sldPlasmaVariation);
            frmSettings.Controls.Add(sldPlasmaColor);
            frmSettings.Controls.Add(_optPlasma_2);
            frmSettings.Controls.Add(_optPlasma_1);
            frmSettings.Controls.Add(_optPlasma_0);
            frmSettings.Controls.Add(txtSpeed);
            frmSettings.Controls.Add(chkWarpSmooth);
            frmSettings.Controls.Add(chkWarpRand);
            frmSettings.Controls.Add(sldAngles);
            frmSettings.Controls.Add(lblSpeed);
            frmSettings.Controls.Add(lblSpeedMS);
            frmSettings.Controls.Add(chkAlpha);
            frmSettings.Controls.Add(chkLarge);
            frmSettings.Controls.Add(lblWarp);
            frmSettings.Controls.Add(lblWarpSpeed);
            frmSettings.Controls.Add(sldWarpSpeed);
            frmSettings.Controls.Add(lblPlasmaTransistion);
            frmSettings.Controls.Add(txtPlasmaTransition);
            frmSettings.Controls.Add(lblLightCenter);
            frmSettings.Controls.Add(sldLightCenter);
            frmSettings.Controls.Add(lblLightTrans);
            frmSettings.Controls.Add(sldLightTrans);
            frmSettings.Controls.Add(lblBubbleCenter);
            frmSettings.Controls.Add(sldBubbleCenter);
            frmSettings.Controls.Add(lblBubbleTrans);
            frmSettings.Controls.Add(sldBubbleTrans);
            frmSettings.Controls.Add(lblScribbleLen);
            frmSettings.Controls.Add(sldScribbleLen);
            frmSettings.ForeColor = SystemColors.ControlText;
            frmSettings.Location = new Point(480, 60);
            frmSettings.Name = "frmSettings";
            frmSettings.RightToLeft = RightToLeft.No;
            frmSettings.Size = new Size(185, 241);
            frmSettings.TabIndex = 12;
            frmSettings.TabStop = false;
            frmSettings.Text = "Art Type Settings:";
            // 
            // sldPlasmaVariation
            // 
            sldPlasmaVariation.Location = new Point(10, 192);
            sldPlasmaVariation.Maximum = 255;
            sldPlasmaVariation.Minimum = 0;
            sldPlasmaVariation.Name = "sldPlasmaVariation";
            sldPlasmaVariation.Size = new Size(17, 45);
            sldPlasmaVariation.TabIndex = 11;
            ToolTip1.SetToolTip(sldPlasmaVariation, "Manually set the amount of color variation");
            sldPlasmaVariation.Cursor = System.Windows.Forms.Cursors.Hand;
            sldPlasmaVariation.ValueChanged += sldPlasmaVariation_ValueChanged;
            sldPlasmaVariation.TickStyle = TickStyle.None;
            // 
            // sldLightCenter
            // 
            sldLightCenter.Location = new Point(10, 192);
            sldLightCenter.Maximum = 100;
            sldLightCenter.Minimum = 0;
            sldLightCenter.Name = "sldLightCenter";
            sldLightCenter.Size = new Size(17, 45);
            sldLightCenter.TabIndex = 11;
            ToolTip1.SetToolTip(sldLightCenter, "The size of the center before faiding");
            sldLightCenter.Cursor = System.Windows.Forms.Cursors.Hand;
            sldLightCenter.ValueChanged += sldLightCenter_ValueChanged;
            // 
            // sldLightTrans
            // 
            sldLightTrans.Location = new Point(10, 192);
            sldLightTrans.Maximum = 99;
            sldLightTrans.Minimum = 0;
            sldLightTrans.Name = "sldLightTrans";
            sldLightTrans.Size = new Size(17, 45);
            sldLightTrans.TabIndex = 11;
            ToolTip1.SetToolTip(sldLightTrans, "The transparency of the light");
            sldLightTrans.Cursor = System.Windows.Forms.Cursors.Hand;
            sldLightTrans.ValueChanged += sldLightTrans_ValueChanged;
            // 
            // sldBubbleCenter
            // 
            sldBubbleCenter.Location = new Point(10, 192);
            sldBubbleCenter.Maximum = 100;
            sldBubbleCenter.Minimum = 0;
            sldBubbleCenter.Name = "sldBubbleCenter";
            sldBubbleCenter.Size = new Size(17, 45);
            sldBubbleCenter.TabIndex = 11;
            ToolTip1.SetToolTip(sldBubbleCenter, "The size of the center before faiding");
            sldBubbleCenter.Cursor = System.Windows.Forms.Cursors.Hand;
            sldBubbleCenter.ValueChanged += sldBubbleCenter_ValueChanged;
            // 
            // sldBubbleTrans
            // 
            sldBubbleTrans.Location = new Point(10, 192);
            sldBubbleTrans.Maximum = 99;
            sldBubbleTrans.Minimum = 0;
            sldBubbleTrans.Name = "sldBubbleTrans";
            sldBubbleTrans.Size = new Size(17, 45);
            sldBubbleTrans.TabIndex = 11;
            ToolTip1.SetToolTip(sldBubbleTrans, "The transparency of the bubble");
            sldBubbleTrans.Cursor = System.Windows.Forms.Cursors.Hand;
            sldBubbleTrans.ValueChanged += sldBubbleTrans_ValueChanged;
            // 
            // sldPlasmaColor
            // 
            sldPlasmaColor.Location = new Point(33, 190);
            sldPlasmaColor.Maximum = 8;
            sldPlasmaColor.Minimum = 1;
            sldPlasmaColor.Name = "sldPlasmaColor";
            sldPlasmaColor.Size = new Size(17, 45);
            sldPlasmaColor.TabIndex = 9;
            ToolTip1.SetToolTip(sldPlasmaColor, "Manually set the frequancy of color changes");
            sldPlasmaColor.Cursor = System.Windows.Forms.Cursors.Hand;
            sldPlasmaColor.ValueChanged += sldPlasmaColor_ValueChanged;
            sldPlasmaColor.TickStyle = TickStyle.None;
            // 
            // _optPlasma_2
            // 
            _optPlasma_2.BackColor = SystemColors.Control;
            _optPlasma_2.ForeColor = SystemColors.ControlText;
            _optPlasma_2.Location = new Point(6, 119);
            _optPlasma_2.Name = "_optPlasma_2";
            _optPlasma_2.RightToLeft = RightToLeft.No;
            _optPlasma_2.Size = new Size(121, 17);
            _optPlasma_2.TabIndex = 7;
            _optPlasma_2.TabStop = true;
            _optPlasma_2.Text = "No Mirror";
            _optPlasma_2.UseVisualStyleBackColor = false;
            _optPlasma_2.Cursor = System.Windows.Forms.Cursors.Hand;
            _optPlasma_2.CheckedChanged += _optPlasma_2_CheckedChanged;
            ToolTip1.SetToolTip(_optPlasma_2, "Plasma will not be mirrored and will be full screen");
            // 
            // _optPlasma_1
            // 
            _optPlasma_1.BackColor = SystemColors.Control;
            _optPlasma_1.ForeColor = SystemColors.ControlText;
            _optPlasma_1.Location = new Point(8, 142);
            _optPlasma_1.Name = "_optPlasma_1";
            _optPlasma_1.RightToLeft = RightToLeft.No;
            _optPlasma_1.Size = new Size(121, 17);
            _optPlasma_1.TabIndex = 6;
            _optPlasma_1.TabStop = true;
            _optPlasma_1.Text = "Mirror";
            _optPlasma_1.UseVisualStyleBackColor = false;
            _optPlasma_1.Cursor = System.Windows.Forms.Cursors.Hand;
            _optPlasma_1.CheckedChanged += _optPlasma_1_CheckedChanged;
            ToolTip1.SetToolTip(_optPlasma_1, "Mirror the plasma left to right and top to bottom");
            // 
            // _optPlasma_0
            // 
            _optPlasma_0.BackColor = SystemColors.Control;
            _optPlasma_0.ForeColor = SystemColors.ControlText;
            _optPlasma_0.Location = new Point(6, 103);
            _optPlasma_0.Name = "_optPlasma_0";
            _optPlasma_0.RightToLeft = RightToLeft.No;
            _optPlasma_0.Size = new Size(121, 17);
            _optPlasma_0.TabIndex = 5;
            _optPlasma_0.TabStop = true;
            _optPlasma_0.Text = "Random";
            _optPlasma_0.UseVisualStyleBackColor = false;
            _optPlasma_0.CheckedChanged += _optPlasma_0_CheckedChanged;
            _optPlasma_0.Cursor = System.Windows.Forms.Cursors.Hand;

            ToolTip1.SetToolTip(_optPlasma_0, "Randomly mirror or full screen");
            // 
            // txtSpeed
            // 
            txtSpeed.AcceptsReturn = true;
            txtSpeed.BackColor = SystemColors.Window;
            txtSpeed.Cursor = Cursors.IBeam;
            txtSpeed.ForeColor = SystemColors.WindowText;
            txtSpeed.Location = new Point(48, 24);
            txtSpeed.MaxLength = 0;
            txtSpeed.Name = "txtSpeed";
            txtSpeed.RightToLeft = RightToLeft.No;
            txtSpeed.Size = new Size(57, 20);
            txtSpeed.TabIndex = 13;
            txtSpeed.Cursor = System.Windows.Forms.Cursors.IBeam;
            txtSpeed.LostFocus += txtSpeed_TextChanged;
            ToolTip1.SetToolTip(txtSpeed, "The frequancy of refreshing the art. Caution: changing this may cause latency issues.");
            // 
            // txtPlasmaTransition
            // 
            txtPlasmaTransition.AcceptsReturn = true;
            txtPlasmaTransition.BackColor = SystemColors.Window;
            txtPlasmaTransition.Cursor = Cursors.IBeam;
            txtPlasmaTransition.ForeColor = SystemColors.WindowText;
            txtPlasmaTransition.Location = new Point(48, 24);
            txtPlasmaTransition.MaxLength = 0;
            txtPlasmaTransition.Name = "txtPlasmaTransition";
            txtPlasmaTransition.RightToLeft = RightToLeft.No;
            txtPlasmaTransition.Size = new Size(57, 20);
            txtPlasmaTransition.TabIndex = 13;
            txtPlasmaTransition.Cursor = System.Windows.Forms.Cursors.IBeam;
            txtPlasmaTransition.LostFocus += txtPlasmaTransition_TextChanged;
            ToolTip1.SetToolTip(txtPlasmaTransition, "The spee to transition between scenes. Caution: changing this may cause latency issues.");
            // 
            // chkWarpSmooth
            // 
            chkWarpSmooth.BackColor = SystemColors.Control;
            chkWarpSmooth.ForeColor = SystemColors.ControlText;
            chkWarpSmooth.Location = new Point(32, 48);
            chkWarpSmooth.Name = "chkWarpSmooth";
            chkWarpSmooth.RightToLeft = RightToLeft.No;
            chkWarpSmooth.Size = new Size(105, 17);
            chkWarpSmooth.TabIndex = 15;
            chkWarpSmooth.Text = "Smooth Colors";
            chkWarpSmooth.UseVisualStyleBackColor = false;
            chkWarpSmooth.CheckedChanged += chkWarpSmooth_CheckedChanged;
            chkWarpSmooth.Cursor = System.Windows.Forms.Cursors.Hand;
            ToolTip1.SetToolTip(chkWarpSmooth, "The color variation and angles will transition smoothly.");
            // 
            // chkWarpRand
            // 
            chkWarpRand.BackColor = SystemColors.Control;
            chkWarpRand.ForeColor = SystemColors.ControlText;
            chkWarpRand.Location = new Point(8, 167);
            chkWarpRand.Name = "chkWarpRand";
            chkWarpRand.RightToLeft = RightToLeft.No;
            chkWarpRand.Size = new Size(73, 17);
            chkWarpRand.TabIndex = 14;
            chkWarpRand.Text = "Randomize:";
            chkWarpRand.UseVisualStyleBackColor = false;
            chkWarpRand.CheckedChanged += chkWarpRand_CheckedChanged;
            chkWarpRand.Cursor = System.Windows.Forms.Cursors.Hand;
            ToolTip1.SetToolTip(chkWarpRand, "Randomize the shape of the warp tunnel.");
            // 
            // sldAngles
            // 
            sldAngles.Location = new Point(104, 190);
            sldAngles.Maximum = 100;
            sldAngles.Minimum = 4;
            sldAngles.Name = "sldAngles";
            sldAngles.Size = new Size(73, 45);
            sldAngles.TabIndex = 16;
            sldAngles.Cursor = System.Windows.Forms.Cursors.Hand;
            sldAngles.ValueChanged += sldAngles_ValueChanged;
            ToolTip1.SetToolTip(sldAngles, "Manually set the shape of the warp tunnel.");
            // 
            // sldScribbleLen
            // 
            sldScribbleLen.Location = new Point(104, 190);
            sldScribbleLen.Maximum = 100;
            sldScribbleLen.Minimum = 1;
            sldScribbleLen.Name = "sldAngles";
            sldScribbleLen.Size = new Size(73, 45);
            sldScribbleLen.TabIndex = 16;
            sldScribbleLen.Cursor = System.Windows.Forms.Cursors.Hand;
            sldScribbleLen.ValueChanged += sldScribbleLen_ValueChanged;
            ToolTip1.SetToolTip(sldScribbleLen, "The length or size of the scribble.");
            // 
            // lblSpeed
            // 
            lblSpeed.BackColor = Color.Transparent;
            lblSpeed.ForeColor = SystemColors.ControlText;
            lblSpeed.Location = new Point(120, 16);
            lblSpeed.Name = "lblSpeed";
            lblSpeed.RightToLeft = RightToLeft.No;
            lblSpeed.Size = new Size(41, 17);
            lblSpeed.TabIndex = 34;
            lblSpeed.Text = "Timer Speed:";
            // 
            // lblSpeedMS
            // 
            lblSpeedMS.BackColor = Color.Transparent;
            lblSpeedMS.ForeColor = SystemColors.ControlText;
            lblSpeedMS.Location = new Point(120, 16);
            lblSpeedMS.Name = "lblSpeedMS";
            lblSpeedMS.RightToLeft = RightToLeft.No;
            lblSpeedMS.Size = new Size(41, 17);
            lblSpeedMS.TabIndex = 34;
            lblSpeedMS.Text = "ms";
            // 
            // chkAlpha
            // 
            chkAlpha.BackColor = SystemColors.Control;
            chkAlpha.ForeColor = SystemColors.ControlText;
            chkAlpha.Location = new Point(8, 152);
            chkAlpha.Name = "chkAlpha";
            chkAlpha.RightToLeft = RightToLeft.No;
            chkAlpha.Size = new Size(153, 17);
            chkAlpha.TabIndex = 35;
            chkAlpha.Text = "No Transparent Colors";
            chkAlpha.UseVisualStyleBackColor = false;
            chkAlpha.Cursor = System.Windows.Forms.Cursors.Hand;
            chkAlpha.CheckedChanged += chkAlpha_CheckedChanged;
            ToolTip1.SetToolTip(chkAlpha, "Colors are always opaque vs allow transparent colors.");
            // 
            // chkLarge
            // 
            chkLarge.BackColor = SystemColors.Control;
            chkLarge.ForeColor = SystemColors.ControlText;
            chkLarge.Location = new Point(8, 152);
            chkLarge.Name = "chkLarge";
            chkLarge.RightToLeft = RightToLeft.No;
            chkLarge.Size = new Size(153, 17);
            chkLarge.TabIndex = 35;
            chkLarge.Text = "Large Pixel";
            chkLarge.UseVisualStyleBackColor = false;
            chkLarge.Cursor = System.Windows.Forms.Cursors.Hand;
            chkLarge.CheckedChanged += chkLarge_CheckedChanged;
            ToolTip1.SetToolTip(chkLarge, "Use an extra large pixel.");
            // 
            // lblWarp
            // 
            lblWarp.BackColor = Color.Transparent;
            lblWarp.ForeColor = SystemColors.ControlText;
            lblWarp.Location = new Point(8, 24);
            lblWarp.Name = "lblWarp";
            lblWarp.RightToLeft = RightToLeft.No;
            lblWarp.Size = new Size(33, 17);
            lblWarp.TabIndex = 33;
            lblWarp.Text = "Shape:";
            lblWarp.TextAlign = ContentAlignment.TopCenter;
            // 
            // lblWarpSpeed
            // 
            lblWarpSpeed.BackColor = Color.Transparent;
            lblWarpSpeed.ForeColor = SystemColors.ControlText;
            lblWarpSpeed.Location = new Point(8, 24);
            lblWarpSpeed.Name = "lblWarpSpeed";
            lblWarpSpeed.RightToLeft = RightToLeft.No;
            lblWarpSpeed.Size = new Size(33, 17);
            lblWarpSpeed.TabIndex = 33;
            lblWarpSpeed.Text = "Speed:";
            lblWarpSpeed.TextAlign = ContentAlignment.TopCenter;
            // 
            // lblLightCenter
            // 
            lblLightCenter.BackColor = Color.Transparent;
            lblLightCenter.ForeColor = SystemColors.ControlText;
            lblLightCenter.Location = new Point(8, 24);
            lblLightCenter.Name = "lblLightCenter";
            lblLightCenter.RightToLeft = RightToLeft.No;
            lblLightCenter.Size = new Size(33, 17);
            lblLightCenter.TabIndex = 33;
            lblLightCenter.Text = "Center Size:";
            lblLightCenter.TextAlign = ContentAlignment.TopCenter;
            // 
            // lblLightTrans
            // 
            lblLightTrans.BackColor = Color.Transparent;
            lblLightTrans.ForeColor = SystemColors.ControlText;
            lblLightTrans.Location = new Point(8, 24);
            lblLightTrans.Name = "lblLightTrans";
            lblLightTrans.RightToLeft = RightToLeft.No;
            lblLightTrans.Size = new Size(33, 17);
            lblLightTrans.TabIndex = 33;
            lblLightTrans.Text = "Transparency:";
            lblLightTrans.TextAlign = ContentAlignment.TopCenter;
            // 
            // lblScribbleLen
            // 
            lblScribbleLen.BackColor = Color.Transparent;
            lblScribbleLen.ForeColor = SystemColors.ControlText;
            lblScribbleLen.Location = new Point(8, 24);
            lblScribbleLen.Name = "lblScribbleLen";
            lblScribbleLen.RightToLeft = RightToLeft.No;
            lblScribbleLen.Size = new Size(33, 17);
            lblScribbleLen.TabIndex = 33;
            lblScribbleLen.Text = "Length:";
            lblScribbleLen.TextAlign = ContentAlignment.TopCenter;
            // 
            // lblBubbleCenter
            // 
            lblBubbleCenter.BackColor = Color.Transparent;
            lblBubbleCenter.ForeColor = SystemColors.ControlText;
            lblBubbleCenter.Location = new Point(8, 24);
            lblBubbleCenter.Name = "lblBubbleCenter";
            lblBubbleCenter.RightToLeft = RightToLeft.No;
            lblBubbleCenter.Size = new Size(33, 17);
            lblBubbleCenter.TabIndex = 33;
            lblBubbleCenter.Text = "Center Size:";
            lblBubbleCenter.TextAlign = ContentAlignment.TopCenter;
            // 
            // lblBubbleTrans
            // 
            lblBubbleTrans.BackColor = Color.Transparent;
            lblBubbleTrans.ForeColor = SystemColors.ControlText;
            lblBubbleTrans.Location = new Point(8, 24);
            lblBubbleTrans.Name = "lblBubbleTrans";
            lblBubbleTrans.RightToLeft = RightToLeft.No;
            lblBubbleTrans.Size = new Size(33, 17);
            lblBubbleTrans.TabIndex = 33;
            lblBubbleTrans.Text = "Transparency:";
            lblBubbleTrans.TextAlign = ContentAlignment.TopCenter;
            // 
            // lblPlasmaTransistion
            // 
            lblPlasmaTransistion.BackColor = Color.Transparent;
            lblPlasmaTransistion.ForeColor = SystemColors.ControlText;
            lblPlasmaTransistion.Location = new Point(8, 24);
            lblPlasmaTransistion.Name = "lblPlasmaTransistion";
            lblPlasmaTransistion.RightToLeft = RightToLeft.No;
            lblPlasmaTransistion.Size = new Size(33, 17);
            lblPlasmaTransistion.TabIndex = 33;
            lblPlasmaTransistion.Text = "Transistion:";
            lblPlasmaTransistion.TextAlign = ContentAlignment.TopCenter;
            // 
            // cmdCancel
            // 
            cmdCancel.BackColor = SystemColors.Control;
            cmdCancel.ForeColor = SystemColors.ControlText;
            cmdCancel.Location = new Point(486, 341);
            cmdCancel.Name = "cmdCancel";
            cmdCancel.RightToLeft = RightToLeft.No;
            cmdCancel.Size = new Size(65, 25);
            cmdCancel.TabIndex = 26;
            cmdCancel.Text = "Cancel";
            cmdCancel.UseVisualStyleBackColor = false;
            cmdCancel.Click += cmdCancel_Click;
            cmdCancel.Cursor = System.Windows.Forms.Cursors.Hand;
            ToolTip1.SetToolTip(cmdCancel, "Do not save any changes and exit settings.");
            // 
            // cmdSave
            // 
            cmdSave.BackColor = SystemColors.Control;
            cmdSave.ForeColor = SystemColors.ControlText;
            cmdSave.Location = new Point(369, 360);
            cmdSave.Name = "cmdSave";
            cmdSave.RightToLeft = RightToLeft.No;
            cmdSave.Size = new Size(65, 25);
            cmdSave.TabIndex = 25;
            cmdSave.Text = "Save";
            cmdSave.UseVisualStyleBackColor = false;
            cmdSave.Click += cmdSave_Click;
            cmdSave.Cursor = System.Windows.Forms.Cursors.Hand;
            ToolTip1.SetToolTip(cmdSave, "Save all changes and exit settings.");
            // 
            // frmBackGround
            // 
            frmBackGround.BackColor = SystemColors.Control;
            frmBackGround.Controls.Add(chkUseBack);
            frmBackGround.Controls.Add(cmdW);
            frmBackGround.Controls.Add(cmdB);
            frmBackGround.Controls.Add(chkBackRand);
            frmBackGround.Controls.Add(sldBlue);
            frmBackGround.Controls.Add(sldGreen);
            frmBackGround.Controls.Add(sldRed);
            frmBackGround.Controls.Add(lblBlue);
            frmBackGround.Controls.Add(lblGreen);
            frmBackGround.Controls.Add(lblRed);
            frmBackGround.ForeColor = SystemColors.ControlText;
            frmBackGround.Location = new Point(192, 152);
            frmBackGround.Name = "frmBackGround";
            frmBackGround.RightToLeft = RightToLeft.No;
            frmBackGround.Size = new Size(169, 193);
            frmBackGround.TabIndex = 17;
            frmBackGround.TabStop = false;
            frmBackGround.Text = "Background:";
            // 
            // frmOptions
            // 
            frmOptions.BackColor = SystemColors.Control;
            frmOptions.Controls.Add(chkSetWalpaper);
            frmOptions.Controls.Add(chkAllScreens);
            frmOptions.ForeColor = SystemColors.ControlText;
            frmOptions.Location = new Point(192, 152);
            frmOptions.Name = "frmOptions";
            frmOptions.RightToLeft = RightToLeft.No;
            frmOptions.Size = new Size(169, 193);
            frmOptions.TabIndex = 17;
            frmOptions.TabStop = false;
            frmOptions.Text = "Options:";
            // 
            // chkSetWalpaper
            // 
            chkSetWalpaper.BackColor = SystemColors.Control;
            chkSetWalpaper.ForeColor = SystemColors.ControlText;
            chkSetWalpaper.Location = new Point(8, 152);
            chkSetWalpaper.Name = "chkSetWalpaper";
            chkSetWalpaper.RightToLeft = RightToLeft.No;
            chkSetWalpaper.Size = new Size(153, 17);
            chkSetWalpaper.TabIndex = 35;
            chkSetWalpaper.Text = "Save screen as jpeg";
            chkSetWalpaper.UseVisualStyleBackColor = false;
            chkSetWalpaper.Cursor = System.Windows.Forms.Cursors.Hand;
            chkSetWalpaper.CheckedChanged += chkSetWalpaper_CheckedChanged;
            ToolTip1.SetToolTip(chkSetWalpaper, "Save the art in your pictures folder.");
            // 
            // chkAllScreens
            // 
            chkAllScreens.BackColor = SystemColors.Control;
            chkAllScreens.ForeColor = SystemColors.ControlText;
            chkAllScreens.Location = new Point(8, 152);
            chkAllScreens.Name = "chkAllScreens";
            chkAllScreens.RightToLeft = RightToLeft.No;
            chkAllScreens.Size = new Size(153, 17);
            chkAllScreens.TabIndex = 35;
            chkAllScreens.Text = "All screens same art";
            chkAllScreens.UseVisualStyleBackColor = false;
            chkAllScreens.Cursor = System.Windows.Forms.Cursors.Hand;
            chkAllScreens.CheckedChanged += chkAllScreens_CheckedChanged;
            ToolTip1.SetToolTip(chkAllScreens, "All screens use the same art type.");
            // 
            // chkUseBack
            // 
            chkUseBack.BackColor = SystemColors.Control;
            chkUseBack.ForeColor = SystemColors.ControlText;
            chkUseBack.Location = new Point(8, 24);
            chkUseBack.Name = "chkUseBack";
            chkUseBack.RightToLeft = RightToLeft.No;
            chkUseBack.Size = new Size(153, 17);
            chkUseBack.TabIndex = 18;
            chkUseBack.Text = "Use Windows Background";
            chkUseBack.UseVisualStyleBackColor = false;
            chkUseBack.CheckedChanged += chkUseBack_CheckedChanged;
            chkUseBack.Cursor = System.Windows.Forms.Cursors.Hand;
            ToolTip1.SetToolTip(chkUseBack, "Display the art ontop of the screen (Transparent background color).");
            // 
            // chkBackRand
            // 
            chkBackRand.BackColor = SystemColors.Control;
            chkBackRand.ForeColor = SystemColors.ControlText;
            chkBackRand.Location = new Point(8, 56);
            chkBackRand.Name = "chkBackRand";
            chkBackRand.RightToLeft = RightToLeft.No;
            chkBackRand.Size = new Size(129, 17);
            chkBackRand.TabIndex = 19;
            chkBackRand.Text = "Randomize";
            chkBackRand.UseVisualStyleBackColor = false;
            chkBackRand.CheckedChanged += chkBackRand_CheckedChanged;
            chkBackRand.Cursor = System.Windows.Forms.Cursors.Hand;
            ToolTip1.SetToolTip(chkBackRand, "Randomize the background color");
            // 
            // sldBlue
            // 
            sldBlue.Location = new Point(24, 128);
            sldBlue.Maximum = 255;
            sldBlue.Minimum = 0;
            sldBlue.Name = "sldBlue";
            sldBlue.Size = new Size(137, 45);
            sldBlue.TabIndex = 24;
            sldBlue.Cursor = System.Windows.Forms.Cursors.Hand;
            sldBlue.ValueChanged += sldBlue_ValueChanged;
            ToolTip1.SetToolTip(sldBlue, "Manually set the amount of blue used in the background color");
            // 
            // sldGreen
            // 
            sldGreen.Location = new Point(24, 104);
            sldGreen.Maximum = 255;
            sldGreen.Minimum = 0;
            sldGreen.Name = "sldGreen";
            sldGreen.Size = new Size(137, 45);
            sldGreen.TabIndex = 23;
            sldGreen.Cursor = System.Windows.Forms.Cursors.Hand;
            sldGreen.ValueChanged += sldGreen_ValueChanged;
            ToolTip1.SetToolTip(sldGreen, "Manually set the amount of green used in the background color");
            // 
            // sldWarpSpeed
            // 
            sldWarpSpeed.Location = new Point(24, 104);
            sldWarpSpeed.Maximum = 250;
            sldWarpSpeed.Minimum = 1;
            sldWarpSpeed.Name = "sldWarpSpeed";
            sldWarpSpeed.Size = new Size(137, 45);
            sldWarpSpeed.TabIndex = 23;
            sldWarpSpeed.Cursor = System.Windows.Forms.Cursors.Hand;
            sldWarpSpeed.ValueChanged += sldWarpSpeed_ValueChanged;
            ToolTip1.SetToolTip(sldWarpSpeed, "The speed through the warp tunnel");
            // 
            // sldRed
            // 
            sldRed.Location = new Point(24, 80);
            sldRed.Maximum = 255;
            sldRed.Minimum = 0;
            sldRed.Name = "sldRed";
            sldRed.Size = new Size(137, 45);
            sldRed.TabIndex = 22;
            sldRed.Cursor = System.Windows.Forms.Cursors.Hand;
            sldRed.ValueChanged += sldRed_ValueChanged;
            ToolTip1.SetToolTip(sldRed, "Manually set the amount of red used in the background color");
            // 
            // lblBlue
            // 
            lblBlue.BackColor = SystemColors.Control;
            lblBlue.ForeColor = SystemColors.ControlText;
            lblBlue.Location = new Point(8, 128);
            lblBlue.Name = "lblBlue";
            lblBlue.RightToLeft = RightToLeft.No;
            lblBlue.Size = new Size(41, 17);
            lblBlue.TabIndex = 32;
            lblBlue.Text = "Blue:";
            // 
            // lblGreen
            // 
            lblGreen.BackColor = SystemColors.Control;
            lblGreen.ForeColor = SystemColors.ControlText;
            lblGreen.Location = new Point(8, 104);
            lblGreen.Name = "lblGreen";
            lblGreen.RightToLeft = RightToLeft.No;
            lblGreen.Size = new Size(41, 17);
            lblGreen.TabIndex = 31;
            lblGreen.Text = "Green:";
            // 
            // lblRed
            // 
            lblRed.BackColor = SystemColors.Control;
            lblRed.ForeColor = SystemColors.ControlText;
            lblRed.Location = new Point(8, 80);
            lblRed.Name = "lblRed";
            lblRed.RightToLeft = RightToLeft.No;
            lblRed.Size = new Size(33, 17);
            lblRed.TabIndex = 30;
            lblRed.Text = "Red:";
            // 
            // frmArtType
            // 
            frmArtType.BackColor = SystemColors.Control;
            frmArtType.Controls.Add(txtListEdit);
            frmArtType.Controls.Add(lstTypes);
            frmArtType.ForeColor = SystemColors.ControlText;
            frmArtType.Location = new Point(4, 4);
            frmArtType.Name = "frmArtType";
            frmArtType.RightToLeft = RightToLeft.No;
            frmArtType.Size = new Size(121, 137);
            frmArtType.TabIndex = 0;
            frmArtType.TabStop = false;
            frmArtType.Text = "Art Type:";
            // 
            // txtListEdit
            // 
            txtListEdit.AcceptsReturn = true;
            txtListEdit.BackColor = SystemColors.Window;
            txtListEdit.BorderStyle = BorderStyle.FixedSingle;
            txtListEdit.Cursor = Cursors.IBeam;
            txtListEdit.ForeColor = SystemColors.WindowText;
            txtListEdit.Location = new Point(88, 24);
            txtListEdit.MaxLength = 0;
            txtListEdit.Name = "txtListEdit";
            txtListEdit.RightToLeft = RightToLeft.No;
            txtListEdit.Size = new Size(17, 20);
            txtListEdit.TabIndex = 2;
            txtListEdit.Visible = false;
            txtListEdit.Cursor = System.Windows.Forms.Cursors.IBeam;
            txtListEdit.LostFocus += txtListEdit_TextChanged;
            txtListEdit.KeyPress += txtListEdit_KeyPressed;
            ToolTip1.SetToolTip(txtListEdit, "Set how frequant this art type will be selected");
            // 
            // lstTypes
            // 
            lstTypes.Columns.AddRange(new ColumnHeader[] { clhType, clhPercentage });
            lstTypes.Location = new Point(8, 16);
            lstTypes.Name = "lstTypes";
            lstTypes.Size = new Size(250, 200);
            lstTypes.View = View.Details;
            lstTypes.TabIndex = 1;
            lstTypes.UseCompatibleStateImageBehavior = false;
            lstTypes.LabelEdit = false;
            lstTypes.LabelWrap = false;
            lstTypes.MultiSelect = false;
            lstTypes.Activation = ItemActivation.OneClick;
            lstTypes.FullRowSelect = true;
            lstTypes.Sorting = SortOrder.Ascending;
            lstTypes.ItemSelectionChanged += lstTypes_SelectItemChanged;
            lstTypes.Cursor = System.Windows.Forms.Cursors.Hand;
            ToolTip1.SetToolTip(lstTypes, "Select the art type to edit");
            // 
            // clhType
            // 
            clhType.Text = "Type";
            // 
            // clhPercentage
            // 
            clhPercentage.Text = "%";
            // 
            // lblDemo
            // 
            lblDemo.BackColor = Color.Transparent;
            lblDemo.BorderStyle = BorderStyle.Fixed3D;
            lblDemo.ForeColor = SystemColors.ControlText;
            lblDemo.Location = new Point(344, 32);
            lblDemo.Name = "lblDemo";
            lblDemo.RightToLeft = RightToLeft.No;
            lblDemo.Size = new Size(129, 17);
            lblDemo.TabIndex = 3;
            lblDemo.Text = "Demo";
            lblDemo.TextAlign = ContentAlignment.TopCenter;
            // 
            // frmConfiguration
            // 
            AutoScaleBaseSize = new Size(5, 13);
            BackColor = SystemColors.Control;
            CancelButton = cmdCancel;
            ClientSize = new Size(710, 553);
            Controls.Add(cmdPreview);
            Controls.Add(cmdDefault);
            Controls.Add(cmdAbout);
            Controls.Add(frmSettings);
            Controls.Add(cmdCancel);
            Controls.Add(cmdSave);
            Controls.Add(Picture1);
            Controls.Add(frmBackGround);
            Controls.Add(frmOptions);
            Controls.Add(frmArtType);
            Controls.Add(lblDemo);
            Font = new Font("Arial", 8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Location = new Point(3, 22);
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "frmConfiguration";
            RightToLeft = RightToLeft.No;
            StartPosition = FormStartPosition.CenterParent;
            Text = "Random Art";
            FormClosed += SettingsForm_Closed;
            Load += SettingsForm_Load;
            ((ISupportInitialize)Picture1).EndInit();
            frmSettings.ResumeLayout(false);
            frmSettings.PerformLayout();
            ((ISupportInitialize)sldPlasmaVariation).EndInit();
            ((ISupportInitialize)sldPlasmaColor).EndInit();
            ((ISupportInitialize)sldAngles).EndInit();
            frmBackGround.ResumeLayout(false);
            frmBackGround.PerformLayout();
            frmOptions.ResumeLayout(false);
            frmOptions.PerformLayout();
            ((ISupportInitialize)sldBlue).EndInit();
            ((ISupportInitialize)sldGreen).EndInit();
            ((ISupportInitialize)sldRed).EndInit();
            frmArtType.ResumeLayout(false);
            frmArtType.PerformLayout();  
            ResumeLayout(false);
        }
        private void SettingsForm_Load(object? sender, EventArgs e)
        {
            // frmArtType
            frmArtType.Top = 4;
            frmArtType.Left = 8;
            lstTypes.Top = 16;
            lstTypes.Left = 4;
            lstTypes.Columns[0].Width = Program.TextWidth("Bubbles", lstTypes.Font) + 10;
            lstTypes.Columns[1].Width = Program.TextWidth("100%", lstTypes.Font) + 10;
            lstTypes.Width = lstTypes.Columns[0].Width + lstTypes.Columns[1].Width + 12;
            lstTypes.Height = (Program.TextHeight("Iy", lstTypes.Font) * 11) + 32;
            frmArtType.Width = lstTypes.Left + lstTypes.Width + 4;
            frmArtType.Height = lstTypes.Top + lstTypes.Height + 4;
            
            //cmd widths
            cmdSave.Width = Program.TextWidth("Save", cmdSave.Font) + 40;
            cmdCancel.Width = Program.TextWidth("Cancel", cmdCancel.Font) + 40;

            // frmSettings
            frmSettings.Top = frmArtType.Top + frmArtType.Height + 4;
            frmSettings.Left = frmArtType.Left;
            frmSettings.Width = (cmdSave.Width + cmdCancel.Width) * 2;
            lblSpeed.Width = Program.TextWidth(lblSpeed.Text, lblSpeed.Font) + 4;
            lblSpeed.Height = Program.TextHeight(lblSpeed.Text, lblSpeed.Font) + 8;
            lblSpeed.Top = lstTypes.Top + 8;
            lblSpeed.Left = lstTypes.Left + 8;
            txtSpeed.Top = lblSpeed.Top - 4;
            txtSpeed.Left = lblSpeed.Left + lblSpeed.Width + 4;
            txtSpeed.Width = Program.TextWidth("10000", txtSpeed.Font) + 8;
            txtSpeed.Height = lblSpeed.Height;
            lblSpeedMS.Top = lblSpeed.Top;
            lblSpeedMS.Left = txtSpeed.Left + txtSpeed.Width + 4;
            lblSpeedMS.Height = txtSpeed.Height;
            lblSpeedMS.Width = Program.TextWidth(lblSpeedMS.Text, lblSpeedMS.Font) + 4;
            chkAlpha.Left = lblSpeed.Left;
            chkAlpha.Top = txtSpeed.Top + txtSpeed.Height + 8;
            chkAlpha.Height = txtSpeed.Height;
            chkAlpha.Width = Program.TextWidth(chkAlpha.Text, chkAlpha.Font) + 22;
            chkLarge.Left = chkAlpha.Left;
            chkLarge.Top = chkAlpha.Top + chkAlpha.Height + 8;
            chkLarge.Height = chkAlpha.Height;
            chkLarge.Width = Program.TextWidth(chkLarge.Text, chkLarge.Font) + 22;
            lblScribbleLen.Top = chkAlpha.Top + chkAlpha.Height + 8;
            lblScribbleLen.Left = lblSpeed.Left;
            lblScribbleLen.Height= lblSpeed.Height;
            lblScribbleLen.Width = Program.TextWidth(lblScribbleLen.Text, lblScribbleLen.Font) + 4;
            sldScribbleLen.Top = lblScribbleLen.Top;
            sldScribbleLen.Left = lblScribbleLen.Left + lblScribbleLen.Width + 4;
            sldScribbleLen.Width = frmSettings.Width - (sldScribbleLen.Left + 8);
            lblLightTrans.Left = lblLightCenter.Left;
            lblLightTrans.Top = chkAlpha.Top + chkAlpha.Height + 8;
            lblLightTrans.Height = lblLightCenter.Height;
            lblLightTrans.Width = Program.TextWidth(lblLightTrans.Text, lblLightTrans.Font) + 4;
            sldLightTrans.Left = lblLightTrans.Left + lblLightTrans.Width + 4;
            sldLightTrans.Top = lblLightTrans.Top;
            sldLightTrans.Width = frmSettings.Width - (sldLightTrans.Left + 8);
            lblLightCenter.Top = sldLightTrans.Top + sldLightTrans.Height + 4;
            lblLightCenter.Left = lblSpeed.Left;
            lblLightCenter.Width = Program.TextWidth(lblLightCenter.Text, lblLightCenter.Font) + 4;
            lblLightCenter.Height = lblSpeed.Height;
            sldLightCenter.Left = lblLightCenter.Left + lblLightCenter.Width + 4;
            sldLightCenter.Top = lblLightCenter.Top;
            sldLightCenter.Width = frmSettings.Width - (sldLightCenter.Left + 8);
            lblBubbleTrans.Left = lblBubbleCenter.Left;
            lblBubbleTrans.Top = chkAlpha.Top + chkAlpha.Height + 8;
            lblBubbleTrans.Height = lblBubbleCenter.Height;
            lblBubbleTrans.Width = Program.TextWidth(lblBubbleTrans.Text, lblBubbleTrans.Font) + 4;
            sldBubbleTrans.Left = lblBubbleTrans.Left + lblBubbleTrans.Width + 4;
            sldBubbleTrans.Top = lblBubbleTrans.Top;
            sldBubbleTrans.Width = frmSettings.Width - (sldBubbleTrans.Left + 8);
            lblBubbleCenter.Top = sldBubbleTrans.Top + sldBubbleTrans.Height + 4;
            lblBubbleCenter.Left = lblSpeed.Left;
            lblBubbleCenter.Height = lblSpeed.Height;
            lblBubbleCenter.Width = Program.TextWidth(lblBubbleCenter.Text, lblBubbleCenter.Font) + 4;
            sldBubbleCenter.Left = lblBubbleCenter.Left + lblBubbleCenter.Width + 4;
            sldBubbleCenter.Top = lblBubbleCenter.Top;
            sldBubbleCenter.Width = frmSettings.Width - (sldBubbleCenter.Left + 8);
            lblPlasmaTransistion.Top = chkAlpha.Top + chkAlpha.Height + 8;
            lblPlasmaTransistion.Height = txtSpeed.Height;
            lblPlasmaTransistion.Left = lblSpeed.Left;
            lblPlasmaTransistion.Width = Program.TextWidth(lblPlasmaTransistion.Text, lblPlasmaTransistion.Font) + 4;
            txtPlasmaTransition.Top = lblPlasmaTransistion.Top;
            txtPlasmaTransition.Left = lblPlasmaTransistion.Left + lblPlasmaTransistion.Width + 4;
            txtPlasmaTransition.Width = Program.TextWidth("1000", txtSpeed.Font) + 8;
            txtPlasmaTransition.Height = txtSpeed.Height;
            chkWarpSmooth.Top = chkAlpha.Top + chkAlpha.Height + 8;
            chkWarpSmooth.Left = lblSpeed.Left;
            chkWarpSmooth.Width = frmSettings.Width - 16;
            lblWarpSpeed.Top = chkWarpSmooth.Top + chkWarpSmooth.Height + 8;
            lblWarpSpeed.Left = chkWarpSmooth.Left;
            lblWarpSpeed.Height = chkWarpSmooth.Height;
            lblWarpSpeed.Width = Program.TextWidth(lblWarpSpeed.Text, lblWarpSpeed.Font) + 4;
            sldWarpSpeed.Top = lblWarpSpeed.Top;
            sldWarpSpeed.Left = lblWarpSpeed.Left + lblWarpSpeed.Width + 4;
            sldWarpSpeed.Width = frmSettings.Width - (sldWarpSpeed.Left + 8);
            chkWarpRand.Top = sldWarpSpeed.Top + sldWarpSpeed.Height + 8;
            chkWarpRand.Left = chkWarpSmooth.Left;
            chkWarpRand.Width = chkWarpSmooth.Width;
            lblWarp.Top = chkWarpRand.Top + chkWarpRand.Height + 8;
            lblWarp.Left = chkWarpRand.Left;
            lblWarp.Width = Program.TextWidth(lblWarp.Text, lblWarp.Font) + 4;
            sldAngles.Top = lblWarp.Top;
            sldAngles.Left = lblWarp.Left + lblWarp.Width + 4;
            sldAngles.Width = frmSettings.Width - (sldAngles.Left + 8);
            optPlasma = new List<RadioButton>();
            optPlasma.Add(_optPlasma_0);
            optPlasma.Add(_optPlasma_1);
            optPlasma.Add(_optPlasma_2);
            optPlasma[0].Top = txtPlasmaTransition.Top + txtPlasmaTransition.Height + 8;
            optPlasma[1].Top = optPlasma[0].Top + optPlasma[0].Height;
            optPlasma[2].Top = optPlasma[1].Top + optPlasma[1].Height;
            for (int i = 0; i <= 2; i++)
            {
                optPlasma[i].Left = lblSpeed.Left;
                optPlasma[i].Width = frmSettings.Width - 32;
            }
            chkPlasmaColorRand.Top = optPlasma[2].Top + optPlasma[2].Height + 8;
            chkPlasmaColorRand.Left = optPlasma[2].Left;
            chkPlasmaColorRand.Width = Program.TextWidth(chkPlasmaColorRand.Text, chkPlasmaColorRand.Font) + 22;
            chkPlasmaColorRand.Height = Program.TextHeight(chkPlasmaColorRand.Text, chkPlasmaColorRand.Font) + 8;
            sldPlasmaColor.Top = chkPlasmaColorRand.Top;
            sldPlasmaColor.Left = chkPlasmaColorRand.Left + chkPlasmaColorRand.Width + 4;
            sldPlasmaColor.Width = frmSettings.Width - (sldPlasmaColor.Left + 8);
            sldPlasmaColor.Height = chkPlasmaColorRand.Height;
            chkPlasmaVariationRand.Top = chkPlasmaColorRand.Top + chkPlasmaColorRand.Height + 8;
            chkPlasmaVariationRand.Left = chkPlasmaColorRand.Left;
            chkPlasmaVariationRand.Width = Program.TextWidth(chkPlasmaVariationRand.Text, chkPlasmaVariationRand.Font) + 22;
            chkPlasmaVariationRand.Height = Program.TextHeight(chkPlasmaVariationRand.Text, chkPlasmaVariationRand.Font) + 8;
            sldPlasmaVariation.Top = chkPlasmaVariationRand.Top;
            sldPlasmaVariation.Left = chkPlasmaVariationRand.Left + chkPlasmaVariationRand.Width + 4;
            sldPlasmaVariation.Width = frmSettings.Width - (sldPlasmaVariation.Left + 8);
            sldPlasmaVariation.Height = chkPlasmaVariationRand.Height;
            frmSettings.Height = sldPlasmaVariation.Top + sldPlasmaVariation.Height + 2;

            // frmBackground
            frmBackGround.Top = frmSettings.Top;
            frmBackGround.Left = frmSettings. Left + frmSettings.Width + 8;
            chkUseBack.Left = lblSpeed.Left;
            chkUseBack.Top = lblSpeed.Top;
            chkUseBack.Width = Program.TextWidth(chkUseBack.Text, chkUseBack.Font) + 32;
            chkUseBack.Height = Program.TextHeight(chkUseBack.Text, chkUseBack.Font) + 8;
            chkBackRand.Left = chkUseBack.Left;
            chkBackRand.Top = chkUseBack.Height + chkUseBack.Top + 4;
            chkBackRand.Width = chkUseBack.Width;
            chkBackRand.Height = chkUseBack.Height;
            cmdW.Top = chkUseBack.Top;
            cmdW.Width = Program.TextWidth(cmdW.Text, cmdW.Font) + 8;
            cmdW.Height = cmdW.Width;
            cmdW.Left = chkUseBack.Left + chkUseBack.Width + cmdW.Width + 8;
            cmdB.Top = cmdW.Top;
            cmdB.Width = cmdW.Width;
            cmdB.Height = cmdW.Height;
            cmdB.Left = cmdW.Left - cmdB.Width - 4;
            frmBackGround.Width = cmdW.Left + cmdW.Width + 16;
            lblRed.Top = chkBackRand.Top + chkBackRand.Height + 8;
            lblRed.Left = lblBlue.Left;
            lblRed.Width = Program.TextWidth(lblGreen.Text, lblBlue.Font) + 8;
            sldRed.Left = lblRed.Left + lblRed.Width + 4;
            sldRed.Width = frmBackGround.Width - (sldRed.Left + 8);
            sldRed.Top = lblRed.Top;
            lblGreen.Top = sldRed.Top + sldRed.Height;
            lblGreen.Left = lblRed.Left;
            lblGreen.Width = lblRed.Width;
            sldGreen.Width = sldRed.Width;
            sldGreen.Top = lblGreen.Top;
            sldGreen.Left = sldRed.Left;
            lblBlue.Top = sldGreen.Top + sldGreen.Height;
            lblBlue.Left = lblRed.Left;
            lblBlue.Width = lblRed.Width;
            sldBlue.Top = lblBlue.Top;
            sldBlue.Left = sldRed.Left;
            sldBlue.Width = sldRed.Width;
            
            frmBackGround.Height = sldBlue.Top + sldBlue.Height + 16;
            this.Width = frmBackGround.Left + frmBackGround.Width + 24;

            //frmOptions
            frmOptions.Top = frmSettings.Top + frmSettings.Height + 4;
            frmOptions.Left = frmSettings.Left;
            frmOptions.Width = frmSettings.Width;
            chkSetWalpaper.Top = chkUseBack.Top;
            chkSetWalpaper.Left = chkUseBack.Left;
            chkSetWalpaper.Width = Program.TextWidth(chkSetWalpaper.Text, chkSetWalpaper.Font) + 32;
            chkAllScreens.Top = chkSetWalpaper.Top;
            chkAllScreens.Left = chkSetWalpaper.Left + chkSetWalpaper.Width + 4;
            chkAllScreens.Width = Program.TextWidth(chkAllScreens.Text, chkAllScreens.Font) + 32;
            frmOptions.Height = chkAllScreens.Top + chkAllScreens.Height + 8;

            // picture1
            lblDemo.Top = frmArtType.Top + 4;
            lblDemo.Left = frmArtType.Left + frmArtType.Width + 8;
            lblDemo.Height = Program.TextHeight(lblDemo.Text, lblDemo.Font) + 8;
            lblDemo.Width = frmBackGround.Left + frmBackGround.Width - lblDemo.Left;
            Picture1.Top = lblDemo.Top + lblDemo.Height;
            Picture1.Left = lblDemo.Left;
            Picture1.Height = frmArtType.Height - Picture1.Top + 4;
            Picture1.Width = lblDemo.Width;

            // command buttons
            cmdAbout.Top = frmBackGround.Top + frmBackGround.Height + 8;
            cmdAbout.Left = frmBackGround.Left;
            cmdAbout.Width = frmBackGround.Width;
            cmdPreview.Left = frmOptions.Left;
            cmdPreview.Top = frmOptions.Top + frmOptions.Height + 8;
            cmdPreview.Width = (frmBackGround.Left + frmBackGround.Width - frmSettings.Left - (8 * 3)) / 4;
            cmdDefault.Top = cmdPreview.Top;
            cmdDefault.Left = cmdPreview.Left + cmdPreview.Width + 8;
            cmdDefault.Width = cmdPreview.Width;
            cmdSave.Top = cmdPreview.Top;
            cmdSave.Left = cmdDefault.Left + cmdDefault.Width + 8;
            cmdSave.Width = cmdPreview.Width;
            cmdCancel.Left = cmdSave.Left + cmdSave.Width + 8;
            cmdCancel.Top = cmdPreview.Top;
            cmdCancel.Width = cmdPreview.Width;
            this.Height = cmdPreview.Top + cmdPreview.Height + 48;

            // Make this form a TOPMOST window, so it won't get lost under
            // the Display Properties window.
            TopMost = true;

            // set up settings
            Settings.LoadSettings();
            LoadSettings();
        }
        private void LoadSettings() {
            DoDemo = false;
            Application.DoEvents();
            if (Settings.saverSettings == null) return;
            foreach (Entities.ArtType a in Settings.saverSettings.artTypes) {
                string? sName = Enum.GetName(typeof(ArtTypeEnum), a.Type);
                if (string.IsNullOrEmpty(sName)) sName = a.Type.ToString();
                System.Windows.Forms.ListViewItem ItmX = lstTypes.Items.Add(sName, sName);
                ItmX.SubItems.Add(a.Percentage + "%");
            }
            lstTypes.Items[0].Selected = true;
            SetTypeSettings(lstTypes.SelectedItems[0].Text);
            CalPer(lstTypes.Items[0]);

            sldBlue.Value = Settings.saverSettings.backGround.B;
            sldGreen.Value = Settings.saverSettings.backGround.G;
            sldRed.Value = Settings.saverSettings.backGround.R;
            if (Settings.saverSettings.backGround.Rand == false)
                chkBackRand.CheckState = System.Windows.Forms.CheckState.Unchecked;
            else
                chkBackRand.CheckState = System.Windows.Forms.CheckState.Checked;
            chkBackRand_CheckedChanged(chkBackRand, new System.EventArgs());

            if (Settings.saverSettings.UseBack == false)
                chkUseBack.CheckState = System.Windows.Forms.CheckState.Unchecked;
            else
                chkUseBack.CheckState = System.Windows.Forms.CheckState.Checked;
            chkUseBack_CheckedChanged(chkUseBack, new EventArgs());

            if (Settings.saverSettings.AllScreens == false)
                chkAllScreens.CheckState = System.Windows.Forms.CheckState.Unchecked;
            else
                chkAllScreens.CheckState = System.Windows.Forms.CheckState.Checked;
            chkAllScreens_CheckedChanged(chkAllScreens, new EventArgs());

            if (Settings.saverSettings.warp.Rand == false)
                chkWarpRand.CheckState = System.Windows.Forms.CheckState.Unchecked;
            else
                chkWarpRand.CheckState = System.Windows.Forms.CheckState.Checked;
            chkWarpRand_CheckedChanged(chkWarpRand, new System.EventArgs());

            sldScribbleLen.Value = Settings.saverSettings.scribble.Length;

            sldAngles.Value = Settings.saverSettings.warp.Angles;
            sldWarpSpeed.Value = Settings.saverSettings.warp.Speed;
            if (Settings.saverSettings.warp.Smooth == false)
                chkWarpSmooth.CheckState = System.Windows.Forms.CheckState.Unchecked;
            else
                chkWarpSmooth.CheckState = System.Windows.Forms.CheckState.Checked;
            chkWarpSmooth_CheckedChanged(chkWarpSmooth, new EventArgs());

            sldLightCenter.Value = (int)(Settings.saverSettings.light.Center * 100);
            sldLightTrans.Value = (int)(Settings.saverSettings.light.Transparent * 100);
            sldBubbleCenter.Value = (int)(Settings.saverSettings.bubble.Center * 100);
            sldBubbleTrans.Value = (int)(Settings.saverSettings.bubble.Transparent * 100);

            if (System.Convert.ToBoolean(Settings.saverSettings.UseBack) == false)
                chkUseBack.CheckState = System.Windows.Forms.CheckState.Unchecked;
            else
                chkUseBack.CheckState = System.Windows.Forms.CheckState.Checked;
            chkUseBack_CheckedChanged(chkUseBack, new System.EventArgs());

            if (Settings.saverSettings.setWallpaper == true)
                chkSetWalpaper.CheckState = System.Windows.Forms.CheckState.Checked;
            else
                chkSetWalpaper.CheckState = System.Windows.Forms.CheckState.Unchecked;
            
            optPlasma[Settings.saverSettings.plasma.Type].Checked = true;

            sldPlasmaVariation.Value = Settings.saverSettings.plasma.ColorV;
            if (Settings.saverSettings.plasma.ColorVRand == true)
                chkPlasmaVariationRand.CheckState = System.Windows.Forms.CheckState.Checked;
            else
                chkPlasmaVariationRand.CheckState = System.Windows.Forms.CheckState.Unchecked;
            chkPlasmaVariationRand_CheckedChanged(chkPlasmaVariationRand, new System.EventArgs());

            sldPlasmaColor.Value = Settings.saverSettings.plasma.Color;
            if (Settings.saverSettings.plasma.ColorRand == true)
                chkPlasmaColorRand.CheckState = System.Windows.Forms.CheckState.Checked;
            else
                chkPlasmaColorRand.CheckState = System.Windows.Forms.CheckState.Unchecked;
            chkPlasmaColorRand_CheckedChanged(chkPlasmaColorRand, new System.EventArgs());

            txtPlasmaTransition.Text = Settings.saverSettings.plasma.Transition.ToString();

            Cursor = System.Windows.Forms.Cursors.Default;

            DoDemo = true;
            Application.DoEvents();
            // display results
            NewDemo();
        }
        private void SetTypeSettings(string ItmX)
        {
            if (Settings.saverSettings == null) return;
            // Assuming Me refers to the current form or control
            chkWarpRand.Visible = false;
            chkWarpSmooth.Visible = false;
            sldAngles.Visible = false;
            lblWarp.Visible = false;
            lblWarpSpeed.Visible = false;
            sldWarpSpeed.Visible = false;

            lblLightCenter.Visible = false;
            lblLightTrans.Visible = false;
            sldLightCenter.Visible = false;
            sldLightTrans.Visible = false;

            lblBubbleCenter.Visible = false;
            lblBubbleTrans.Visible = false;
            sldBubbleCenter.Visible = false;
            sldBubbleTrans.Visible = false;

            lblScribbleLen.Visible = false;
            sldScribbleLen.Visible = false;

            chkLarge.Visible = false;

            // Assuming optPlasma is a Control array or a List<Control>
            for (int i = 0; i <= 2; i++)
            {
                if (optPlasma.Count > i) // Ensure index is within bounds if it's an array
                {
                    optPlasma[i].Visible = false;
                }
            }

            chkPlasmaColorRand.Visible = false;
            chkPlasmaVariationRand.Visible = false;
            sldPlasmaColor.Visible = false;
            sldPlasmaVariation.Visible = false;
            txtPlasmaTransition.Visible = false;
            lblPlasmaTransistion.Visible = false;

            ArtType? s = null;
            if (ItmX == Enum.GetName(typeof(ArtTypeEnum), ArtTypeEnum.Dots))
            {
                s = Settings.saverSettings.artTypes.Find(o => o.Type == ArtTypeEnum.Dots);
                txtSpeed.Text = s != null ? s.Speed.ToString() : "10"; // Assuming lSpeed is an array or List
                chkAlpha.Checked = s != null ? s.Alpha : true;
                chkLarge.Visible = true;
                chkLarge.Checked = Settings.saverSettings.dot.Large;
            }
            else if (ItmX == Enum.GetName(typeof(ArtTypeEnum), ArtTypeEnum.Grow))
            {
                s = Settings.saverSettings.artTypes.Find(o => o.Type == ArtTypeEnum.Grow);
                txtSpeed.Text = s != null ? s.Speed.ToString() : "10";
                chkAlpha.Checked = s != null ? s.Alpha : true;
                chkLarge.Visible = true;
                chkLarge.Checked = Settings.saverSettings.grow.Large;
            }
            else if (ItmX == Enum.GetName(typeof(ArtTypeEnum), ArtTypeEnum.Weeds))
            {
                s = Settings.saverSettings.artTypes.Find(o => o.Type == ArtTypeEnum.Weeds);
                txtSpeed.Text = s != null ? s.Speed.ToString() : "500";
                chkAlpha.Checked = s != null ? s.Alpha : true;
            }
            else if (ItmX == Enum.GetName(typeof(ArtTypeEnum), ArtTypeEnum.Light))
            {
                lblLightCenter.Visible = true;
                lblLightTrans.Visible = true;
                sldLightCenter.Visible = true;
                sldLightTrans.Visible = true;
                s = Settings.saverSettings.artTypes.Find(o => o.Type == ArtTypeEnum.Light);
                txtSpeed.Text = s != null ? s.Speed.ToString() : "1000";
                chkAlpha.Checked = s != null ? s.Alpha : false;
            }
            else if (ItmX == Enum.GetName(typeof(ArtTypeEnum), ArtTypeEnum.Warp))
            {
                chkWarpRand.Visible = true;
                chkWarpSmooth.Visible = true;
                sldAngles.Visible = true;
                lblWarp.Visible = true;
                lblWarpSpeed.Visible = true;
                sldWarpSpeed.Visible = true;
                s = Settings.saverSettings.artTypes.Find(o => o.Type == ArtTypeEnum.Warp);
                txtSpeed.Text = s != null ? s.Speed.ToString() : "100";
                chkAlpha.Checked = s != null ? s.Alpha : false;
            }
            else if (ItmX == Enum.GetName(typeof(ArtTypeEnum), ArtTypeEnum.Bubbles))
            {
                lblBubbleCenter.Visible = true;
                lblBubbleTrans.Visible = true;
                sldBubbleCenter.Visible = true;
                sldBubbleTrans.Visible = true;
                s = Settings.saverSettings.artTypes.Find(o => o.Type == ArtTypeEnum.Bubbles);
                txtSpeed.Text = s != null ? s.Speed.ToString() : "1000";
                chkAlpha.Checked = s != null ? s.Alpha : false;
            }
            else if (ItmX == Enum.GetName(typeof(ArtTypeEnum), ArtTypeEnum.Scribble))
            {
                lblScribbleLen.Visible = true;
                sldScribbleLen.Visible = true;
                s = Settings.saverSettings.artTypes.Find(o => o.Type == ArtTypeEnum.Scribble);
                txtSpeed.Text = s != null ? s.Speed.ToString() : "100";
                chkAlpha.Checked = s != null ? s.Alpha : true;
            }
            else if (ItmX == Enum.GetName(typeof(ArtTypeEnum), ArtTypeEnum.Plasma))
            {
                for (int i = 0; i <= 2; i++)
                {
                    if (optPlasma.Count > i) // Ensure index is within bounds if it's an array
                    {
                        optPlasma[i].Visible = true;
                    }
                }
                chkPlasmaColorRand.Visible = true;
                chkPlasmaVariationRand.Visible = true;
                sldPlasmaColor.Visible = true;
                sldPlasmaVariation.Visible = true;
                txtPlasmaTransition.Visible = true;
                lblPlasmaTransistion.Visible = true;
                s = Settings.saverSettings.artTypes.Find(o => o.Type == ArtTypeEnum.Plasma);
                txtSpeed.Text = s != null ? s.Speed.ToString() : "5000";
                chkAlpha.Checked = s != null ? s.Alpha : false;
            }
        }
        public void NewDemo()
        {
            if (!DoDemo) return;
            if (randomArt != null) {
                randomArt.Stop();
                randomArt.Close();
                randomArt.Dispose(); // It's good practice to dispose of the form
                randomArt = null;
            }
            
            if (Picture1.IsHandleCreated) // Check if the handle is created
            {
                if (Settings.saverSettings == null) return;
                Settings.screensaverForms = new List<RandomArt>();
                Rectangle parentRect = Picture1.ClientRectangle;
                randomArt = new RandomArt(parentRect, 1); // Pass parent rectangle
                ArtTypeEnum? s = null;
                if (lstTypes.SelectedItems.Count > 0) 
                    if (Enum.TryParse<ArtTypeEnum>(lstTypes.SelectedItems[0].Text, out ArtTypeEnum parsedType))
                        s = parsedType;
                randomArt.TopLevel = false;
                randomArt.Parent = Picture1;
                randomArt.Show();
                bool allS = Settings.saverSettings.AllScreens;
                Settings.saverSettings.AllScreens = true;
                if (s != null)
                    Settings.All_artType = (int)s;
                randomArt.Start();
                Settings.saverSettings.AllScreens = allS;
                Settings.screensaverForms.Add(randomArt);
            }
        }
        private void txtListEdit_TextChanged(object? sender, EventArgs e) {
            if (Settings.saverSettings == null) return;
            txtListEdit.Text = Val(txtListEdit.Text).ToString();
            if (Val(txtListEdit.Text) > 100) txtListEdit.Text = "100";
            if (Val(txtListEdit.Text) < 0) txtListEdit.Text = "0";
            if (lstTypes.SelectedItems.Count > 0) {
                ListViewItem Itm = lstTypes.SelectedItems[0];
                foreach (ArtType a in Settings.saverSettings.artTypes) {
                    string? sName = Enum.GetName(typeof(ArtTypeEnum), a.Type);
                    if (string.IsNullOrEmpty(sName)) sName = a.Type.ToString();
                    if (Itm.Text == sName) {
                        a.Percentage = Convert.ToInt32(txtListEdit.Text);
                        Itm.SubItems[1].Text = txtListEdit.Text + "%";
                        //CalPer(Itm);
                        break;
                    }
                }
            } 
        }
        private void sldRed_ValueChanged(object? sender, EventArgs e)
        {
            if (Settings.saverSettings == null) return;
            Settings.saverSettings.backGround.R = sldRed.Value;
        }
        private void sldGreen_ValueChanged(object? sender, EventArgs e)
        {
            if (Settings.saverSettings == null) return;
            Settings.saverSettings.backGround.G = sldGreen.Value;
        }
        private void sldBlue_ValueChanged(object? sender, EventArgs e)
        {
            if (Settings.saverSettings == null) return;
            Settings.saverSettings.backGround.B = sldBlue.Value;
        }
        private void sldWarpSpeed_ValueChanged(object? sender, EventArgs e)
        {
            if (Settings.saverSettings == null) return;
            Settings.saverSettings.warp.Speed = sldWarpSpeed.Value;
        }
        private void sldScribbleLen_ValueChanged(object? sender, EventArgs e)
        {
            if (Settings.saverSettings == null) return;
            Settings.saverSettings.scribble.Length = sldScribbleLen.Value;
        }
        private void chkSetWalpaper_CheckedChanged(object? sender, EventArgs e)
        {
            if (Settings.saverSettings == null) return;
            if (chkSetWalpaper.CheckState == CheckState.Checked)
                Settings.saverSettings.setWallpaper = true;
            else
                Settings.saverSettings.setWallpaper = false;
        }
        private void chkAllScreens_CheckedChanged(object? sender, EventArgs e)
        {
            if (Settings.saverSettings == null) return;
            if (chkAllScreens.CheckState == CheckState.Checked)
                Settings.saverSettings.AllScreens = true;
            else
                Settings.saverSettings.AllScreens = false;
        }
        private void txtPlasmaTransition_TextChanged(object? sender, EventArgs e)
        {
            if (Settings.saverSettings == null) return;
            txtPlasmaTransition.Text = Val(txtPlasmaTransition.Text).ToString();
            if (Val(txtPlasmaTransition.Text) < 0) txtPlasmaTransition.Text = "0";
            Settings.saverSettings.plasma.Transition = (int)Val(txtPlasmaTransition.Text);
        }
        private void sldAngles_ValueChanged(object? sender, EventArgs e)
        {
            if (Settings.saverSettings == null) return;
            Settings.saverSettings.warp.Angles = sldAngles.Value;
        }
        private void _optPlasma_0_CheckedChanged(object? sender, EventArgs e)
        {
            if (Settings.saverSettings == null) return;
            Settings.saverSettings.plasma.Type = 0;
        }
        private void _optPlasma_1_CheckedChanged(object? sender, EventArgs e)
        {
            if (Settings.saverSettings == null) return;
            Settings.saverSettings.plasma.Type = 1;
        }
        private void _optPlasma_2_CheckedChanged(object? sender, EventArgs e)
        {
            if (Settings.saverSettings == null) return;
            Settings.saverSettings.plasma.Type = 2;
        }
        private void sldPlasmaColor_ValueChanged(object? sender, EventArgs e)
        {
            if (Settings.saverSettings == null) return;
            Settings.saverSettings.plasma.Color = sldPlasmaColor.Value;
        }
        private void sldPlasmaVariation_ValueChanged(object? sender, EventArgs e)
        {
            if (Settings.saverSettings == null) return;
            Settings.saverSettings.plasma.ColorV = sldPlasmaVariation.Value;
        }
        private void sldBubbleTrans_ValueChanged(object? sender, EventArgs e)
        {
            if (Settings.saverSettings == null) return;
            Settings.saverSettings.bubble.Transparent = Decimal.Divide(sldBubbleTrans.Value, 100);
        }
        private void sldBubbleCenter_ValueChanged(object? sender, EventArgs e)
        {
             if (Settings.saverSettings == null) return;
            Settings.saverSettings.bubble.Center = Decimal.Divide(sldBubbleCenter.Value, 100);
        }
        private void sldLightTrans_ValueChanged(object? sender, EventArgs e)
        {
             if (Settings.saverSettings == null) return;
            Settings.saverSettings.light.Transparent = Decimal.Divide(sldLightTrans.Value, 100);
        }
        private void sldLightCenter_ValueChanged(object? sender, EventArgs e)
        {
             if (Settings.saverSettings == null) return;
            Settings.saverSettings.light.Center = Decimal.Divide(sldLightCenter.Value, 100);
        }
        private void txtSpeed_TextChanged(object? sender, EventArgs e)
        {
            if (Settings.saverSettings == null) return;
            txtSpeed.Text = Val(txtSpeed.Text).ToString();
            if (Val(txtSpeed.Text) < 0) txtSpeed.Text = "0";
            if(lstTypes.SelectedItems.Count > 0) {
                ListViewItem Itm = lstTypes.SelectedItems[0];
                foreach (ArtType a in Settings.saverSettings.artTypes) {
                    string? sName = Enum.GetName(typeof(ArtTypeEnum), a.Type);
                    if (string.IsNullOrEmpty(sName)) sName = a.Type.ToString();
                    if (Itm.Text == sName) {
                        a.Speed = (int)Val(txtSpeed.Text);
                        break;
                    }
                }
            }
        }
        private void chkUseBack_CheckedChanged(object? sender, EventArgs e)
        {
            if (Settings.saverSettings == null) return;
            if (chkUseBack.CheckState == CheckState.Unchecked)
            {
                Settings.saverSettings.UseBack = false;
                chkBackRand.Enabled = true; 
                cmdB.Enabled = true; 
                cmdW.Enabled = true; 
                lblBlue.Enabled = true; 
                lblGreen.Enabled = true; 
                lblRed.Enabled = true; 
                sldBlue.Enabled = true; 
                sldGreen.Enabled = true; 
                sldRed.Enabled = true; 
            }
            else
            {
                Settings.saverSettings.UseBack = true;
                chkBackRand.Enabled = false; 
                cmdB.Enabled = false; 
                cmdW.Enabled = false; 
                lblBlue.Enabled = false; 
                lblGreen.Enabled = false; 
                lblRed.Enabled = false; 
                sldBlue.Enabled = false; 
                sldGreen.Enabled = false; 
                sldRed.Enabled = false; 
            }
            NewDemo();
        }
        private void chkBackRand_CheckedChanged(object? sender, EventArgs e)
        {
            if (Settings.saverSettings == null) return;
            if (chkBackRand.CheckState == CheckState.Checked)
            {
                Settings.saverSettings.backGround.Rand = true;
                sldBlue.Enabled = false;
                sldGreen.Enabled = false;
                sldRed.Enabled = false;
                cmdB.Enabled = false;
                cmdW.Enabled = false;
                lblBlue.Enabled = false;
                lblGreen.Enabled = false;
                lblRed.Enabled = false;
            }
            else
            {
                Settings.saverSettings.backGround.Rand = false;
                sldBlue.Enabled = true;
                sldGreen.Enabled = true;
                sldRed.Enabled = true;
                cmdB.Enabled = true;
                cmdW.Enabled = true;
                lblBlue.Enabled = true;
                lblGreen.Enabled = true;
                lblRed.Enabled = true;
            }
            NewDemo();
        }
        private void chkPlasmaVariationRand_CheckedChanged(object? sender, EventArgs e)
        {
            if (Settings.saverSettings == null) return;
            if (chkPlasmaVariationRand.CheckState == CheckState.Checked)
            {
                Settings.saverSettings.plasma.ColorVRand = true;
                sldPlasmaVariation.Enabled = false;
            }
            else
            {
                Settings.saverSettings.plasma.ColorVRand = false;
                sldPlasmaVariation.Enabled = true;
            }
            NewDemo();
        }
        private void chkPlasmaColorRand_CheckedChanged(object? sender, EventArgs e)
        {
            if (Settings.saverSettings == null) return;
            if (chkPlasmaColorRand.CheckState == CheckState.Checked)
            {
                Settings.saverSettings.plasma.ColorRand = true;
                sldPlasmaColor.Enabled = false;
            }
            else
            {
                Settings.saverSettings.plasma.ColorRand = false;
                sldPlasmaColor.Enabled = true;
            }
            NewDemo();
        }
        private void chkWarpRand_CheckedChanged(object? sender, EventArgs e)
        {
            if (Settings.saverSettings == null) return;
            if (chkWarpRand.CheckState == CheckState.Checked)
            {
                Settings.saverSettings.warp.Rand = true;
                sldAngles.Enabled = false; ;
                lblWarp.Enabled = false; ;
            }
            else
            {
                Settings.saverSettings.warp.Rand = false;
                sldAngles.Enabled = true; ;
                lblWarp.Enabled = true; ;
            }
            NewDemo();
        }
        private void chkWarpSmooth_CheckedChanged(object? sender, EventArgs e)
        {
            if (Settings.saverSettings == null) return;
            if (chkWarpSmooth.CheckState == CheckState.Checked) {
                Settings.saverSettings.warp.Smooth = true;
                lblWarpSpeed.Enabled = true;
                sldWarpSpeed.Enabled = true;
            }
            else {
                Settings.saverSettings.warp.Smooth = false;
                lblWarpSpeed.Enabled = false;
                sldWarpSpeed.Enabled = false;
            }
            NewDemo();
        }
        private void chkLarge_CheckedChanged(object? sender, EventArgs e)
        {
            if (Settings.saverSettings == null) return;
            if(lstTypes.SelectedItems.Count > 0)
            {
                ListViewItem Itm = lstTypes.SelectedItems[0];
                if (Itm.Text == Enum.GetName(typeof(ArtTypeEnum), ArtTypeEnum.Dots))
                    Settings.saverSettings.dot.Large = chkLarge.Checked;
                else if (Itm.Text == Enum.GetName(typeof(ArtTypeEnum), ArtTypeEnum.Grow))
                    Settings.saverSettings.grow.Large = chkLarge.Checked;
            }
        }
        private void chkAlpha_CheckedChanged(object? sender, EventArgs e)
        {
            if (Settings.saverSettings == null) return;
            if(lstTypes.SelectedItems.Count > 0) {
                ListViewItem Itm = lstTypes.SelectedItems[0];
                foreach (ArtType a in Settings.saverSettings.artTypes)
                {
                    string? sName = Enum.GetName(typeof(ArtTypeEnum), a.Type);
                    if (string.IsNullOrEmpty(sName)) sName = a.Type.ToString();
                    if (Itm.Text == sName)
                    {
                        a.Alpha = chkAlpha.Checked;
                        if (a.Type == ArtTypeEnum.Light)
                        {
                            lblLightTrans.Enabled = !chkAlpha.Checked;
                            sldLightTrans.Enabled = !chkAlpha.Checked;
                        }
                        else if (a.Type == ArtTypeEnum.Bubbles)
                        {
                            lblBubbleTrans.Enabled = !chkAlpha.Checked;
                            sldBubbleTrans.Enabled = !chkAlpha.Checked;
                        }
                        break;
                    }
                }
            }
        }
        private void cmdB_Click(object? sender, EventArgs e)
        {
            sldBlue.Value = 0;
            sldGreen.Value = 0;
            sldRed.Value = 0;
            NewDemo();
        }
        private void cmdCancel_Click(object? sender, EventArgs e)
        {
            Close();
            Application.Exit();
        }
        private void cmdW_Click(object? sender, EventArgs e)
		{
			sldBlue.Value = 255;
			sldGreen.Value = 255;
			sldRed.Value = 255;
            NewDemo();
		}
		private void SettingsForm_Closed(object? sender, FormClosedEventArgs e)
		{
            if (randomArt != null) {
                randomArt.Stop();
                randomArt.Close();
                randomArt.Dispose(); // It's good practice to dispose of the form
                randomArt = null;
            }
			Application.Exit();
		}
        private void lstTypes_SelectItemChanged(object? sender, ListViewItemSelectionChangedEventArgs e)
        {
            if (e.Item == null) return;
            if (randomArt != null) randomArt.Stop();
            SetTypeSettings(e.Item.Text);
            txtListEdit.Text = Convert.ToString(Val(e.Item.SubItems[1].Text));
            txtListEdit.SetBounds(lstTypes.Columns[0].Width + lstTypes.Left, e.Item.Bounds.Top + lstTypes.Top, lstTypes.Columns[1].Width, e.Item.Bounds.Height);
            txtListEdit.Visible = true;
            txtListEdit.SelectAll();
            txtListEdit.Focus();
            NewDemo();
        }
        private void txtListEdit_KeyPressed(object? sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Return)
            {
                int selectedIndex = 0;
                if (lstTypes.SelectedIndices.Count > 0) {
                    selectedIndex = lstTypes.SelectedIndices[0];
                    selectedIndex++;
                }  
                if (selectedIndex < lstTypes.Items.Count)
                {
                    lstTypes.Items[selectedIndex].Selected = true;
                    lstTypes.Items[selectedIndex].Focused = true;
                }
                else {
                    lstTypes.Items[0].Selected = true;
                    lstTypes.Items[0].Focused = true;
                }
            }
        }
        private void cmdDefault_Click(object? sender, EventArgs e)
        {
            Settings.saverSettings = new SaverSettings();
            LoadSettings();
        }
        private void cmdPreview_Click(object? sender, EventArgs e)
        {
            if (lstTypes.SelectedItems.Count > 0)
                CalPer(lstTypes.SelectedItems[0]);
            else
                CalPer(lstTypes.Items[0]);
            
            Settings.screensaverForms = new List<RandomArt>();

            // Run the screen saver on all screens
            foreach (Screen screen in Screen.AllScreens)
            {
                //if (screen.Bounds.Left != 0) break;
                RandomArt scr = new RandomArt(screen.Bounds, 1);
                scr.Show();
                scr.Start();
                Settings.screensaverForms.Add(scr);
            }
           //Application.Run();
        }
        private void cmdAbout_Click(object? sender, EventArgs e)
        {
            Settings.Log("Started ShowSettingsForm");
            AboutForm aboutScreen = new AboutForm();
            aboutScreen.TopMost = true;
            aboutScreen.Show();
        }
        private void cmdSave_Click(object? sender, EventArgs e)
        {
            if (lstTypes.SelectedItems.Count > 0)
                CalPer(lstTypes.SelectedItems[0]);
            else
                CalPer(lstTypes.Items[0]);
            Settings.SaveSettings();
            Close();
            Application.Exit();
        }
        private void CalPer(ListViewItem ItmX)
        {
            if (Settings.saverSettings == null) return;
            double Cntr = 0;
            foreach (ListViewItem Item in lstTypes.Items)
                Cntr = Cntr + Val(Item.SubItems[1].Text);
            if (Cntr > 100)
            {
                while (Cntr != 100)
                {
                    foreach (ListViewItem Item in lstTypes.Items)
                    {
                        if (Item.Text != ItmX.Text)
                        {
                            if (Val(Item.SubItems[1].Text) > 0)
                            {
                                Item.SubItems[1].Text = Val(Item.SubItems[1].Text) - 1 + "%";
                                foreach (ArtType a in Settings.saverSettings.artTypes) {
                                    string? sName = Enum.GetName(typeof(ArtTypeEnum), a.Type);
                                    if (string.IsNullOrEmpty(sName)) sName = a.Type.ToString();
                                    if (Item.Text == sName) {
                                        a.Percentage = Convert.ToInt32(Val(Item.SubItems[1].Text));
                                        break;
                                    }
                                }
                                Cntr = Cntr - 1;
                                if (Cntr == 100)
                                    break;
                            }
                        }
                    }
                }
            }
            else if (Cntr < 100)
            {
                while (Cntr < 100)
                {
                    foreach (ListViewItem Item in lstTypes.Items)
                    {
                        if (Item.Text != ItmX.Text)
                        {
                            Item.SubItems[1].Text = Val(Item.SubItems[1].Text) + 1 + "%";
                            foreach (ArtType a in Settings.saverSettings.artTypes) {
                                string? sName = Enum.GetName(typeof(ArtTypeEnum), a.Type);
                                if (string.IsNullOrEmpty(sName)) sName = a.Type.ToString();
                                if (Item.Text == sName) {
                                    a.Percentage = Convert.ToInt32(Val(Item.SubItems[1].Text));
                                    break;
                                }
                            }
                            Cntr = Cntr + 1;
                            if (Cntr == 100)
                                break;
                        }
                    }
                }
            }
        }
        public static Double Val(string value)
		{
			String result = String.Empty;
			foreach (char c in value)
			{
				if (Char.IsNumber(c) || (c.Equals('.') && result.Count(x => x.Equals('.')) == 0))
					result += c;
				else if (!c.Equals(' '))
					return String.IsNullOrEmpty(result) ? 0 : Convert.ToDouble(result);
			}
			return String.IsNullOrEmpty(result) ? 0 : Convert.ToDouble(result);
		}
    }
}
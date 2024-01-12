namespace MainServer
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.bt_UserManage = new Sunny.UI.UIButton();
            this.bt_Configuration = new Sunny.UI.UIButton();
            this.bt_Login = new Sunny.UI.UIButton();
            this.bt_Set = new Sunny.UI.UIButton();
            this.panel1 = new System.Windows.Forms.Panel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.uiButton2 = new Sunny.UI.UIButton();
            this.bt_Home = new Sunny.UI.UIButton();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.PBMax = new System.Windows.Forms.PictureBox();
            this.PBMin = new System.Windows.Forms.PictureBox();
            this.PBExit = new System.Windows.Forms.PictureBox();
            this.gifBox1 = new CCWin.SkinControl.GifBox();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).BeginInit();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PBMax)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PBMin)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PBExit)).BeginInit();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.splitContainer1.IsSplitterFixed = true;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.splitContainer1.Panel1.Controls.Add(this.bt_UserManage);
            this.splitContainer1.Panel1.Controls.Add(this.bt_Configuration);
            this.splitContainer1.Panel1.Controls.Add(this.bt_Login);
            this.splitContainer1.Panel1.Controls.Add(this.bt_Set);
            this.splitContainer1.Panel1.Controls.Add(this.panel1);
            this.splitContainer1.Panel1.Controls.Add(this.bt_Home);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.splitContainer2);
            this.splitContainer1.Size = new System.Drawing.Size(787, 499);
            this.splitContainer1.SplitterDistance = 124;
            this.splitContainer1.SplitterWidth = 1;
            this.splitContainer1.TabIndex = 3;
            this.splitContainer1.TabStop = false;
            // 
            // bt_UserManage
            // 
            this.bt_UserManage.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.bt_UserManage.Cursor = System.Windows.Forms.Cursors.Hand;
            this.bt_UserManage.FillColor = System.Drawing.SystemColors.ControlDarkDark;
            this.bt_UserManage.FillColor2 = System.Drawing.SystemColors.ControlDarkDark;
            this.bt_UserManage.FillDisableColor = System.Drawing.SystemColors.ControlDarkDark;
            this.bt_UserManage.Font = new System.Drawing.Font("新細明體", 12F);
            this.bt_UserManage.Location = new System.Drawing.Point(13, 244);
            this.bt_UserManage.MinimumSize = new System.Drawing.Size(1, 1);
            this.bt_UserManage.Name = "bt_UserManage";
            this.bt_UserManage.RectColor = System.Drawing.SystemColors.ControlDarkDark;
            this.bt_UserManage.RectDisableColor = System.Drawing.SystemColors.ControlDarkDark;
            this.bt_UserManage.Size = new System.Drawing.Size(92, 34);
            this.bt_UserManage.TabIndex = 10;
            this.bt_UserManage.Text = "用户管理";
            this.bt_UserManage.TipsFont = new System.Drawing.Font("新細明體", 9F);
            this.bt_UserManage.Click += new System.EventHandler(this.bt_UserManage_Click);
            // 
            // bt_Configuration
            // 
            this.bt_Configuration.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.bt_Configuration.Cursor = System.Windows.Forms.Cursors.Hand;
            this.bt_Configuration.FillColor = System.Drawing.SystemColors.ControlDarkDark;
            this.bt_Configuration.FillColor2 = System.Drawing.SystemColors.ControlDarkDark;
            this.bt_Configuration.FillDisableColor = System.Drawing.SystemColors.ControlDarkDark;
            this.bt_Configuration.Font = new System.Drawing.Font("新細明體", 12F);
            this.bt_Configuration.Location = new System.Drawing.Point(13, 204);
            this.bt_Configuration.MinimumSize = new System.Drawing.Size(1, 1);
            this.bt_Configuration.Name = "bt_Configuration";
            this.bt_Configuration.RectColor = System.Drawing.SystemColors.ControlDarkDark;
            this.bt_Configuration.RectDisableColor = System.Drawing.SystemColors.ControlDarkDark;
            this.bt_Configuration.Size = new System.Drawing.Size(92, 34);
            this.bt_Configuration.TabIndex = 9;
            this.bt_Configuration.Text = "任务配置";
            this.bt_Configuration.TipsFont = new System.Drawing.Font("新細明體", 9F);
            this.bt_Configuration.Click += new System.EventHandler(this.bt_Configuration_Click);
            // 
            // bt_Login
            // 
            this.bt_Login.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.bt_Login.Cursor = System.Windows.Forms.Cursors.Hand;
            this.bt_Login.FillColor = System.Drawing.SystemColors.ControlDarkDark;
            this.bt_Login.FillColor2 = System.Drawing.SystemColors.ControlDarkDark;
            this.bt_Login.FillDisableColor = System.Drawing.SystemColors.ControlDarkDark;
            this.bt_Login.Font = new System.Drawing.Font("新細明體", 12F);
            this.bt_Login.Location = new System.Drawing.Point(13, 453);
            this.bt_Login.MinimumSize = new System.Drawing.Size(1, 1);
            this.bt_Login.Name = "bt_Login";
            this.bt_Login.RectColor = System.Drawing.SystemColors.ControlDarkDark;
            this.bt_Login.RectDisableColor = System.Drawing.SystemColors.ControlDarkDark;
            this.bt_Login.Size = new System.Drawing.Size(92, 34);
            this.bt_Login.TabIndex = 8;
            this.bt_Login.Text = "登录";
            this.bt_Login.TipsFont = new System.Drawing.Font("新細明體", 9F);
            this.bt_Login.Click += new System.EventHandler(this.bt_Login_Click);
            // 
            // bt_Set
            // 
            this.bt_Set.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.bt_Set.Cursor = System.Windows.Forms.Cursors.Hand;
            this.bt_Set.FillColor = System.Drawing.SystemColors.ControlDarkDark;
            this.bt_Set.FillColor2 = System.Drawing.SystemColors.ControlDarkDark;
            this.bt_Set.FillDisableColor = System.Drawing.SystemColors.ControlDarkDark;
            this.bt_Set.Font = new System.Drawing.Font("新細明體", 12F);
            this.bt_Set.Location = new System.Drawing.Point(13, 164);
            this.bt_Set.MinimumSize = new System.Drawing.Size(1, 1);
            this.bt_Set.Name = "bt_Set";
            this.bt_Set.RectColor = System.Drawing.SystemColors.ControlDarkDark;
            this.bt_Set.RectDisableColor = System.Drawing.SystemColors.ControlDarkDark;
            this.bt_Set.Size = new System.Drawing.Size(92, 34);
            this.bt_Set.TabIndex = 7;
            this.bt_Set.Text = "设置";
            this.bt_Set.TipsFont = new System.Drawing.Font("新細明體", 9F);
            this.bt_Set.Click += new System.EventHandler(this.bt_Set_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Black;
            this.panel1.Controls.Add(this.pictureBox1);
            this.panel1.Controls.Add(this.uiButton2);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Padding = new System.Windows.Forms.Padding(10);
            this.panel1.Size = new System.Drawing.Size(124, 99);
            this.panel1.TabIndex = 6;
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pictureBox1.BackgroundImage")));
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBox1.Location = new System.Drawing.Point(3, 10);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(116, 44);
            this.pictureBox1.TabIndex = 2;
            this.pictureBox1.TabStop = false;
            // 
            // uiButton2
            // 
            this.uiButton2.Cursor = System.Windows.Forms.Cursors.Hand;
            this.uiButton2.FillColor = System.Drawing.Color.Black;
            this.uiButton2.FillColor2 = System.Drawing.Color.Black;
            this.uiButton2.FillDisableColor = System.Drawing.Color.Black;
            this.uiButton2.FillHoverColor = System.Drawing.Color.Black;
            this.uiButton2.FillPressColor = System.Drawing.Color.Black;
            this.uiButton2.FillSelectedColor = System.Drawing.Color.Black;
            this.uiButton2.Font = new System.Drawing.Font("標楷體", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.uiButton2.ForeDisableColor = System.Drawing.Color.White;
            this.uiButton2.Location = new System.Drawing.Point(13, 51);
            this.uiButton2.MinimumSize = new System.Drawing.Size(1, 1);
            this.uiButton2.Name = "uiButton2";
            this.uiButton2.RectColor = System.Drawing.Color.Black;
            this.uiButton2.RectDisableColor = System.Drawing.Color.Black;
            this.uiButton2.RectHoverColor = System.Drawing.Color.Black;
            this.uiButton2.RectPressColor = System.Drawing.Color.Black;
            this.uiButton2.RectSelectedColor = System.Drawing.Color.Black;
            this.uiButton2.RectSides = System.Windows.Forms.ToolStripStatusLabelBorderSides.None;
            this.uiButton2.Size = new System.Drawing.Size(92, 35);
            this.uiButton2.TabIndex = 5;
            this.uiButton2.Text = "森林系统";
            this.uiButton2.TipsColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.uiButton2.TipsFont = new System.Drawing.Font("標楷體", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            // 
            // bt_Home
            // 
            this.bt_Home.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.bt_Home.Cursor = System.Windows.Forms.Cursors.Hand;
            this.bt_Home.FillColor = System.Drawing.SystemColors.ControlDarkDark;
            this.bt_Home.FillColor2 = System.Drawing.SystemColors.ControlDarkDark;
            this.bt_Home.FillDisableColor = System.Drawing.SystemColors.ControlDarkDark;
            this.bt_Home.Font = new System.Drawing.Font("新細明體", 12F);
            this.bt_Home.Location = new System.Drawing.Point(13, 124);
            this.bt_Home.MinimumSize = new System.Drawing.Size(1, 1);
            this.bt_Home.Name = "bt_Home";
            this.bt_Home.RectColor = System.Drawing.SystemColors.ControlDarkDark;
            this.bt_Home.RectDisableColor = System.Drawing.SystemColors.ControlDarkDark;
            this.bt_Home.Size = new System.Drawing.Size(92, 34);
            this.bt_Home.TabIndex = 5;
            this.bt_Home.Text = "首页";
            this.bt_Home.TipsFont = new System.Drawing.Font("新細明體", 9F);
            this.bt_Home.Click += new System.EventHandler(this.bt_Home_Click);
            // 
            // splitContainer2
            // 
            this.splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer2.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.splitContainer2.Location = new System.Drawing.Point(0, 0);
            this.splitContainer2.Name = "splitContainer2";
            this.splitContainer2.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer2.Panel1
            // 
            this.splitContainer2.Panel1.BackColor = System.Drawing.Color.DimGray;
            this.splitContainer2.Panel1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.splitContainer2.Panel1.Controls.Add(this.PBMax);
            this.splitContainer2.Panel1.Controls.Add(this.PBMin);
            this.splitContainer2.Panel1.Controls.Add(this.PBExit);
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.Controls.Add(this.gifBox1);
            this.splitContainer2.Panel2.SizeChanged += new System.EventHandler(this.splitContainer2_Panel2_SizeChanged);
            this.splitContainer2.Size = new System.Drawing.Size(662, 499);
            this.splitContainer2.SplitterDistance = 56;
            this.splitContainer2.SplitterWidth = 1;
            this.splitContainer2.TabIndex = 0;
            // 
            // PBMax
            // 
            this.PBMax.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.PBMax.BackColor = System.Drawing.Color.Transparent;
            this.PBMax.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("PBMax.BackgroundImage")));
            this.PBMax.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.PBMax.Location = new System.Drawing.Point(588, 13);
            this.PBMax.Name = "PBMax";
            this.PBMax.Size = new System.Drawing.Size(28, 27);
            this.PBMax.TabIndex = 2;
            this.PBMax.TabStop = false;
            this.PBMax.Click += new System.EventHandler(this.PBMax_Click);
            this.PBMax.MouseEnter += new System.EventHandler(this.PBMax_MouseEnter);
            this.PBMax.MouseLeave += new System.EventHandler(this.PBMax_MouseLeave);
            // 
            // PBMin
            // 
            this.PBMin.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.PBMin.BackColor = System.Drawing.Color.Transparent;
            this.PBMin.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("PBMin.BackgroundImage")));
            this.PBMin.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.PBMin.Location = new System.Drawing.Point(554, 13);
            this.PBMin.Name = "PBMin";
            this.PBMin.Size = new System.Drawing.Size(28, 27);
            this.PBMin.TabIndex = 1;
            this.PBMin.TabStop = false;
            this.PBMin.Click += new System.EventHandler(this.PBMin_Click);
            this.PBMin.MouseEnter += new System.EventHandler(this.PBMin_MouseEnter);
            this.PBMin.MouseLeave += new System.EventHandler(this.PBMin_MouseLeave);
            // 
            // PBExit
            // 
            this.PBExit.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.PBExit.BackColor = System.Drawing.Color.Transparent;
            this.PBExit.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("PBExit.BackgroundImage")));
            this.PBExit.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.PBExit.Location = new System.Drawing.Point(622, 12);
            this.PBExit.Name = "PBExit";
            this.PBExit.Size = new System.Drawing.Size(28, 28);
            this.PBExit.TabIndex = 0;
            this.PBExit.TabStop = false;
            this.PBExit.Click += new System.EventHandler(this.PBExit_Click);
            this.PBExit.MouseEnter += new System.EventHandler(this.PBExit_MouseEnter);
            this.PBExit.MouseLeave += new System.EventHandler(this.PBExit_MouseLeave);
            // 
            // gifBox1
            // 
            this.gifBox1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("gifBox1.BackgroundImage")));
            this.gifBox1.BorderColor = System.Drawing.Color.Transparent;
            this.gifBox1.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.gifBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gifBox1.Image = ((System.Drawing.Image)(resources.GetObject("gifBox1.Image")));
            this.gifBox1.Location = new System.Drawing.Point(0, 0);
            this.gifBox1.Name = "gifBox1";
            this.gifBox1.Size = new System.Drawing.Size(662, 442);
            this.gifBox1.TabIndex = 0;
            this.gifBox1.Text = "gifBox1";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(787, 499);
            this.Controls.Add(this.splitContainer1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "森林系统";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).EndInit();
            this.splitContainer2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.PBMax)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PBMin)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PBExit)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.SplitContainer splitContainer2;
        private System.Windows.Forms.PictureBox PBExit;
        private System.Windows.Forms.PictureBox PBMax;
        private System.Windows.Forms.PictureBox PBMin;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private Sunny.UI.UIButton uiButton2;
        private Sunny.UI.UIButton bt_Home;
        private Sunny.UI.UIButton bt_Configuration;
        private Sunny.UI.UIButton bt_Login;
        private Sunny.UI.UIButton bt_Set;
        private CCWin.SkinControl.GifBox gifBox1;
        private Sunny.UI.UIButton bt_UserManage;
    }
}
namespace MainServer.Forms
{
    partial class FormSet
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormSet));
            this.bt_AddArea = new Sunny.UI.UIButton();
            this.uiGroupBox1 = new Sunny.UI.UIGroupBox();
            this.ExitArea = new System.Windows.Forms.Label();
            this.bt_DisableArea = new Sunny.UI.UIButton();
            this.StorageAreaListBox = new Sunny.UI.UIListBox();
            this.InputArea = new Sunny.UI.UITextBox();
            this.bt_DelArea = new Sunny.UI.UIButton();
            this.uiGroupBox2 = new Sunny.UI.UIGroupBox();
            this.bt_DelPoint = new Sunny.UI.UIButton();
            this.bt_DisablePoint = new Sunny.UI.UIButton();
            this.bt_AddPoint = new Sunny.UI.UIButton();
            this.cb_StoragePoint = new Sunny.UI.UIComboBox();
            this.StoragePointListBox = new Sunny.UI.UIListBox();
            this.InputPoint = new Sunny.UI.UITextBox();
            this.lb_ExitPoint = new System.Windows.Forms.Label();
            this.uiGroupBox1.SuspendLayout();
            this.uiGroupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // bt_AddArea
            // 
            this.bt_AddArea.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.bt_AddArea.Cursor = System.Windows.Forms.Cursors.Hand;
            this.bt_AddArea.Font = new System.Drawing.Font("新細明體", 12F);
            this.bt_AddArea.Location = new System.Drawing.Point(203, 304);
            this.bt_AddArea.MinimumSize = new System.Drawing.Size(1, 1);
            this.bt_AddArea.Name = "bt_AddArea";
            this.bt_AddArea.Size = new System.Drawing.Size(75, 29);
            this.bt_AddArea.TabIndex = 1;
            this.bt_AddArea.Text = "区域增加";
            this.bt_AddArea.TipsFont = new System.Drawing.Font("新細明體", 9F);
            this.bt_AddArea.Click += new System.EventHandler(this.bt_AddArea_Click);
            // 
            // uiGroupBox1
            // 
            this.uiGroupBox1.Controls.Add(this.ExitArea);
            this.uiGroupBox1.Controls.Add(this.bt_DisableArea);
            this.uiGroupBox1.Controls.Add(this.StorageAreaListBox);
            this.uiGroupBox1.Controls.Add(this.InputArea);
            this.uiGroupBox1.Controls.Add(this.bt_AddArea);
            this.uiGroupBox1.Controls.Add(this.bt_DelArea);
            this.uiGroupBox1.Font = new System.Drawing.Font("新細明體", 12F);
            this.uiGroupBox1.Location = new System.Drawing.Point(4, 4);
            this.uiGroupBox1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.uiGroupBox1.MinimumSize = new System.Drawing.Size(1, 1);
            this.uiGroupBox1.Name = "uiGroupBox1";
            this.uiGroupBox1.Padding = new System.Windows.Forms.Padding(0, 32, 0, 0);
            this.uiGroupBox1.Size = new System.Drawing.Size(285, 342);
            this.uiGroupBox1.TabIndex = 1;
            this.uiGroupBox1.Text = "区域管理";
            this.uiGroupBox1.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // ExitArea
            // 
            this.ExitArea.AutoSize = true;
            this.ExitArea.Font = new System.Drawing.Font("新細明體", 9.75F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.ExitArea.Location = new System.Drawing.Point(126, 144);
            this.ExitArea.Name = "ExitArea";
            this.ExitArea.Size = new System.Drawing.Size(33, 13);
            this.ExitArea.TabIndex = 17;
            this.ExitArea.Text = "取消";
            this.ExitArea.Click += new System.EventHandler(this.ExitArea_Click);
            // 
            // bt_DisableArea
            // 
            this.bt_DisableArea.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.bt_DisableArea.Cursor = System.Windows.Forms.Cursors.Hand;
            this.bt_DisableArea.Font = new System.Drawing.Font("新細明體", 12F);
            this.bt_DisableArea.Location = new System.Drawing.Point(105, 304);
            this.bt_DisableArea.MinimumSize = new System.Drawing.Size(1, 1);
            this.bt_DisableArea.Name = "bt_DisableArea";
            this.bt_DisableArea.Size = new System.Drawing.Size(77, 29);
            this.bt_DisableArea.TabIndex = 5;
            this.bt_DisableArea.Text = "区域禁用";
            this.bt_DisableArea.TipsFont = new System.Drawing.Font("新細明體", 9F);
            this.bt_DisableArea.Click += new System.EventHandler(this.bt_DisableArea_Click);
            // 
            // StorageAreaListBox
            // 
            this.StorageAreaListBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.StorageAreaListBox.Font = new System.Drawing.Font("新細明體", 12F);
            this.StorageAreaListBox.HoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(155)))), ((int)(((byte)(200)))), ((int)(((byte)(255)))));
            this.StorageAreaListBox.ItemSelectForeColor = System.Drawing.Color.White;
            this.StorageAreaListBox.Location = new System.Drawing.Point(8, 28);
            this.StorageAreaListBox.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.StorageAreaListBox.MinimumSize = new System.Drawing.Size(1, 1);
            this.StorageAreaListBox.Name = "StorageAreaListBox";
            this.StorageAreaListBox.Padding = new System.Windows.Forms.Padding(2);
            this.StorageAreaListBox.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
            this.StorageAreaListBox.ShowText = false;
            this.StorageAreaListBox.Size = new System.Drawing.Size(270, 268);
            this.StorageAreaListBox.TabIndex = 4;
            this.StorageAreaListBox.Text = "uiListBox1";
            // 
            // InputArea
            // 
            this.InputArea.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.InputArea.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.InputArea.Font = new System.Drawing.Font("新細明體", 12F);
            this.InputArea.Location = new System.Drawing.Point(6, 77);
            this.InputArea.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.InputArea.MinimumSize = new System.Drawing.Size(1, 16);
            this.InputArea.Name = "InputArea";
            this.InputArea.Padding = new System.Windows.Forms.Padding(5);
            this.InputArea.ShowText = false;
            this.InputArea.Size = new System.Drawing.Size(272, 43);
            this.InputArea.TabIndex = 2;
            this.InputArea.Text = "请输入需新增区域：";
            this.InputArea.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            this.InputArea.Watermark = "";
            this.InputArea.MouseDown += new System.Windows.Forms.MouseEventHandler(this.InputArea_MouseDown);
            // 
            // bt_DelArea
            // 
            this.bt_DelArea.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.bt_DelArea.Cursor = System.Windows.Forms.Cursors.Hand;
            this.bt_DelArea.Font = new System.Drawing.Font("新細明體", 12F);
            this.bt_DelArea.Location = new System.Drawing.Point(8, 304);
            this.bt_DelArea.MinimumSize = new System.Drawing.Size(1, 1);
            this.bt_DelArea.Name = "bt_DelArea";
            this.bt_DelArea.Size = new System.Drawing.Size(77, 29);
            this.bt_DelArea.TabIndex = 3;
            this.bt_DelArea.Text = "区域删除";
            this.bt_DelArea.TipsFont = new System.Drawing.Font("新細明體", 9F);
            this.bt_DelArea.Click += new System.EventHandler(this.bt_DelArea_Click);
            // 
            // uiGroupBox2
            // 
            this.uiGroupBox2.Controls.Add(this.bt_DelPoint);
            this.uiGroupBox2.Controls.Add(this.bt_DisablePoint);
            this.uiGroupBox2.Controls.Add(this.bt_AddPoint);
            this.uiGroupBox2.Controls.Add(this.cb_StoragePoint);
            this.uiGroupBox2.Controls.Add(this.StoragePointListBox);
            this.uiGroupBox2.Controls.Add(this.InputPoint);
            this.uiGroupBox2.Controls.Add(this.lb_ExitPoint);
            this.uiGroupBox2.Font = new System.Drawing.Font("新細明體", 12F);
            this.uiGroupBox2.Location = new System.Drawing.Point(297, 4);
            this.uiGroupBox2.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.uiGroupBox2.MinimumSize = new System.Drawing.Size(1, 1);
            this.uiGroupBox2.Name = "uiGroupBox2";
            this.uiGroupBox2.Padding = new System.Windows.Forms.Padding(0, 32, 0, 0);
            this.uiGroupBox2.Size = new System.Drawing.Size(285, 342);
            this.uiGroupBox2.TabIndex = 2;
            this.uiGroupBox2.Text = " 点位管理";
            this.uiGroupBox2.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // bt_DelPoint
            // 
            this.bt_DelPoint.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.bt_DelPoint.Cursor = System.Windows.Forms.Cursors.Hand;
            this.bt_DelPoint.Font = new System.Drawing.Font("新細明體", 12F);
            this.bt_DelPoint.Location = new System.Drawing.Point(8, 304);
            this.bt_DelPoint.MinimumSize = new System.Drawing.Size(1, 1);
            this.bt_DelPoint.Name = "bt_DelPoint";
            this.bt_DelPoint.Size = new System.Drawing.Size(75, 29);
            this.bt_DelPoint.TabIndex = 8;
            this.bt_DelPoint.Text = "点位删除";
            this.bt_DelPoint.TipsFont = new System.Drawing.Font("新細明體", 9F);
            this.bt_DelPoint.Click += new System.EventHandler(this.bt_DelPoint_Click);
            // 
            // bt_DisablePoint
            // 
            this.bt_DisablePoint.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.bt_DisablePoint.Cursor = System.Windows.Forms.Cursors.Hand;
            this.bt_DisablePoint.Font = new System.Drawing.Font("新細明體", 12F);
            this.bt_DisablePoint.Location = new System.Drawing.Point(105, 304);
            this.bt_DisablePoint.MinimumSize = new System.Drawing.Size(1, 1);
            this.bt_DisablePoint.Name = "bt_DisablePoint";
            this.bt_DisablePoint.Size = new System.Drawing.Size(75, 29);
            this.bt_DisablePoint.TabIndex = 7;
            this.bt_DisablePoint.Text = "点位禁用";
            this.bt_DisablePoint.TipsFont = new System.Drawing.Font("新細明體", 9F);
            this.bt_DisablePoint.Click += new System.EventHandler(this.bt_DisablePoint_Click);
            // 
            // bt_AddPoint
            // 
            this.bt_AddPoint.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.bt_AddPoint.Cursor = System.Windows.Forms.Cursors.Hand;
            this.bt_AddPoint.Font = new System.Drawing.Font("新細明體", 12F);
            this.bt_AddPoint.Location = new System.Drawing.Point(205, 304);
            this.bt_AddPoint.MinimumSize = new System.Drawing.Size(1, 1);
            this.bt_AddPoint.Name = "bt_AddPoint";
            this.bt_AddPoint.Size = new System.Drawing.Size(75, 29);
            this.bt_AddPoint.TabIndex = 6;
            this.bt_AddPoint.Text = "点位增加";
            this.bt_AddPoint.TipsFont = new System.Drawing.Font("新細明體", 9F);
            this.bt_AddPoint.Click += new System.EventHandler(this.bt_AddPoint_Click);
            // 
            // cb_StoragePoint
            // 
            this.cb_StoragePoint.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.cb_StoragePoint.DataSource = null;
            this.cb_StoragePoint.FillColor = System.Drawing.Color.White;
            this.cb_StoragePoint.Font = new System.Drawing.Font("新細明體", 12F);
            this.cb_StoragePoint.ItemHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(155)))), ((int)(((byte)(200)))), ((int)(((byte)(255)))));
            this.cb_StoragePoint.ItemSelectForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(243)))), ((int)(((byte)(255)))));
            this.cb_StoragePoint.Location = new System.Drawing.Point(8, 267);
            this.cb_StoragePoint.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.cb_StoragePoint.MinimumSize = new System.Drawing.Size(63, 0);
            this.cb_StoragePoint.Name = "cb_StoragePoint";
            this.cb_StoragePoint.Padding = new System.Windows.Forms.Padding(0, 0, 30, 2);
            this.cb_StoragePoint.Size = new System.Drawing.Size(271, 29);
            this.cb_StoragePoint.TabIndex = 5;
            this.cb_StoragePoint.Text = "所有区域点位";
            this.cb_StoragePoint.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            this.cb_StoragePoint.Watermark = "";
            // 
            // StoragePointListBox
            // 
            this.StoragePointListBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.StoragePointListBox.Font = new System.Drawing.Font("新細明體", 12F);
            this.StoragePointListBox.HoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(155)))), ((int)(((byte)(200)))), ((int)(((byte)(255)))));
            this.StoragePointListBox.ItemSelectForeColor = System.Drawing.Color.White;
            this.StoragePointListBox.Location = new System.Drawing.Point(8, 28);
            this.StoragePointListBox.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.StoragePointListBox.MinimumSize = new System.Drawing.Size(1, 1);
            this.StoragePointListBox.Name = "StoragePointListBox";
            this.StoragePointListBox.Padding = new System.Windows.Forms.Padding(2);
            this.StoragePointListBox.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
            this.StoragePointListBox.ShowText = false;
            this.StoragePointListBox.Size = new System.Drawing.Size(272, 229);
            this.StoragePointListBox.TabIndex = 4;
            this.StoragePointListBox.Text = "uiListBox1";
            // 
            // InputPoint
            // 
            this.InputPoint.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.InputPoint.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.InputPoint.Font = new System.Drawing.Font("新細明體", 12F);
            this.InputPoint.Location = new System.Drawing.Point(6, 77);
            this.InputPoint.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.InputPoint.MinimumSize = new System.Drawing.Size(1, 16);
            this.InputPoint.Name = "InputPoint";
            this.InputPoint.Padding = new System.Windows.Forms.Padding(5);
            this.InputPoint.ShowText = false;
            this.InputPoint.Size = new System.Drawing.Size(274, 43);
            this.InputPoint.TabIndex = 2;
            this.InputPoint.Text = "请输入需新增区域：";
            this.InputPoint.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            this.InputPoint.Watermark = "";
            // 
            // lb_ExitPoint
            // 
            this.lb_ExitPoint.AutoSize = true;
            this.lb_ExitPoint.Font = new System.Drawing.Font("新細明體", 9.75F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.lb_ExitPoint.Location = new System.Drawing.Point(111, 144);
            this.lb_ExitPoint.Name = "lb_ExitPoint";
            this.lb_ExitPoint.Size = new System.Drawing.Size(33, 13);
            this.lb_ExitPoint.TabIndex = 18;
            this.lb_ExitPoint.Text = "取消";
            this.lb_ExitPoint.Click += new System.EventHandler(this.lb_ExitPoint_Click);
            // 
            // FormSet
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(931, 556);
            this.Controls.Add(this.uiGroupBox2);
            this.Controls.Add(this.uiGroupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FormSet";
            this.Text = "FormSet";
            this.Load += new System.EventHandler(this.FormSet_Load);
            this.uiGroupBox1.ResumeLayout(false);
            this.uiGroupBox1.PerformLayout();
            this.uiGroupBox2.ResumeLayout(false);
            this.uiGroupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private Sunny.UI.UIButton bt_AddArea;
        private Sunny.UI.UIGroupBox uiGroupBox1;
        private Sunny.UI.UIButton bt_DelArea;
        private Sunny.UI.UIListBox StorageAreaListBox;
        private Sunny.UI.UITextBox InputArea;
        private Sunny.UI.UIButton bt_DisableArea;
        private Sunny.UI.UIGroupBox uiGroupBox2;
        private Sunny.UI.UIListBox StoragePointListBox;
        private Sunny.UI.UITextBox InputPoint;
        private Sunny.UI.UIComboBox cb_StoragePoint;
        private Sunny.UI.UIButton bt_DelPoint;
        private Sunny.UI.UIButton bt_DisablePoint;
        private Sunny.UI.UIButton bt_AddPoint;
        private System.Windows.Forms.Label ExitArea;
        private System.Windows.Forms.Label lb_ExitPoint;
    }
}
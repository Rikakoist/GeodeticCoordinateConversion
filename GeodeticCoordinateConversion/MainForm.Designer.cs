namespace GeodeticCoordinateConversion
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.ConvertTabControl = new System.Windows.Forms.TabControl();
            this.CoordTabPage = new System.Windows.Forms.TabPage();
            this.Coord = new GeodeticCoordinateConversion.CoordConvertLayout();
            this.ZoneTabPage = new System.Windows.Forms.TabPage();
            this.Zone = new GeodeticCoordinateConversion.CoordConvertLayout();
            this.DBTabPage = new System.Windows.Forms.TabPage();
            this.CtrlToolTip = new System.Windows.Forms.ToolTip(this.components);
            this.BottomStatusStrip = new System.Windows.Forms.StatusStrip();
            this.HintLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.TopToolStrip = new System.Windows.Forms.ToolStrip();
            this.SettingsBtn = new System.Windows.Forms.ToolStripButton();
            this.AboutBtn = new System.Windows.Forms.ToolStripButton();
            this.ConvertTabControl.SuspendLayout();
            this.CoordTabPage.SuspendLayout();
            this.ZoneTabPage.SuspendLayout();
            this.BottomStatusStrip.SuspendLayout();
            this.TopToolStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // ConvertTabControl
            // 
            this.ConvertTabControl.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ConvertTabControl.Controls.Add(this.CoordTabPage);
            this.ConvertTabControl.Controls.Add(this.ZoneTabPage);
            this.ConvertTabControl.Controls.Add(this.DBTabPage);
            this.ConvertTabControl.Location = new System.Drawing.Point(0, 31);
            this.ConvertTabControl.Margin = new System.Windows.Forms.Padding(0);
            this.ConvertTabControl.Multiline = true;
            this.ConvertTabControl.Name = "ConvertTabControl";
            this.ConvertTabControl.Padding = new System.Drawing.Point(0, 0);
            this.ConvertTabControl.SelectedIndex = 0;
            this.ConvertTabControl.Size = new System.Drawing.Size(1045, 485);
            this.ConvertTabControl.TabIndex = 0;
            // 
            // CoordTabPage
            // 
            this.CoordTabPage.Controls.Add(this.Coord);
            this.CoordTabPage.Location = new System.Drawing.Point(4, 25);
            this.CoordTabPage.Margin = new System.Windows.Forms.Padding(0);
            this.CoordTabPage.Name = "CoordTabPage";
            this.CoordTabPage.Size = new System.Drawing.Size(1037, 456);
            this.CoordTabPage.TabIndex = 0;
            this.CoordTabPage.Text = "坐标转换";
            this.CoordTabPage.UseVisualStyleBackColor = true;
            // 
            // Coord
            // 
            this.Coord.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Coord.Location = new System.Drawing.Point(0, 0);
            this.Coord.Margin = new System.Windows.Forms.Padding(0);
            this.Coord.Name = "Coord";
            this.Coord.Size = new System.Drawing.Size(1037, 456);
            this.Coord.TabIndex = 0;
            // 
            // ZoneTabPage
            // 
            this.ZoneTabPage.Controls.Add(this.Zone);
            this.ZoneTabPage.Location = new System.Drawing.Point(4, 25);
            this.ZoneTabPage.Margin = new System.Windows.Forms.Padding(0);
            this.ZoneTabPage.Name = "ZoneTabPage";
            this.ZoneTabPage.Size = new System.Drawing.Size(1037, 456);
            this.ZoneTabPage.TabIndex = 1;
            this.ZoneTabPage.Text = "换带计算";
            this.ZoneTabPage.UseVisualStyleBackColor = true;
            // 
            // Zone
            // 
            this.Zone.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Zone.Location = new System.Drawing.Point(0, 0);
            this.Zone.Margin = new System.Windows.Forms.Padding(0);
            this.Zone.Name = "Zone";
            this.Zone.Size = new System.Drawing.Size(1037, 456);
            this.Zone.TabIndex = 0;
            // 
            // DBTabPage
            // 
            this.DBTabPage.Location = new System.Drawing.Point(4, 25);
            this.DBTabPage.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.DBTabPage.Name = "DBTabPage";
            this.DBTabPage.Size = new System.Drawing.Size(1037, 456);
            this.DBTabPage.TabIndex = 2;
            this.DBTabPage.Text = "数据查看";
            this.DBTabPage.UseVisualStyleBackColor = true;
            // 
            // BottomStatusStrip
            // 
            this.BottomStatusStrip.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.BottomStatusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.HintLabel});
            this.BottomStatusStrip.Location = new System.Drawing.Point(0, 518);
            this.BottomStatusStrip.Name = "BottomStatusStrip";
            this.BottomStatusStrip.Padding = new System.Windows.Forms.Padding(1, 0, 19, 0);
            this.BottomStatusStrip.Size = new System.Drawing.Size(1045, 25);
            this.BottomStatusStrip.TabIndex = 2;
            // 
            // HintLabel
            // 
            this.HintLabel.Image = global::GeodeticCoordinateConversion.Properties.Resources.Key;
            this.HintLabel.Name = "HintLabel";
            this.HintLabel.Size = new System.Drawing.Size(53, 20);
            this.HintLabel.Text = "test";
            // 
            // TopToolStrip
            // 
            this.TopToolStrip.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.TopToolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.SettingsBtn,
            this.AboutBtn});
            this.TopToolStrip.Location = new System.Drawing.Point(0, 0);
            this.TopToolStrip.Name = "TopToolStrip";
            this.TopToolStrip.Size = new System.Drawing.Size(1045, 27);
            this.TopToolStrip.TabIndex = 1;
            // 
            // SettingsBtn
            // 
            this.SettingsBtn.Image = global::GeodeticCoordinateConversion.Properties.Resources.Twowheels;
            this.SettingsBtn.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.SettingsBtn.Name = "SettingsBtn";
            this.SettingsBtn.Size = new System.Drawing.Size(65, 24);
            this.SettingsBtn.Text = "设置";
            this.SettingsBtn.Click += new System.EventHandler(this.OpenSettings);
            // 
            // AboutBtn
            // 
            this.AboutBtn.Image = global::GeodeticCoordinateConversion.Properties.Resources.Exclamation;
            this.AboutBtn.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.AboutBtn.Name = "AboutBtn";
            this.AboutBtn.Size = new System.Drawing.Size(65, 24);
            this.AboutBtn.Text = "关于";
            this.AboutBtn.Click += new System.EventHandler(this.ShowAbout);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1045, 543);
            this.Controls.Add(this.TopToolStrip);
            this.Controls.Add(this.ConvertTabControl);
            this.Controls.Add(this.BottomStatusStrip);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "MainForm";
            this.Text = "大地坐标转换实习程序";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.ConvertTabControl.ResumeLayout(false);
            this.CoordTabPage.ResumeLayout(false);
            this.ZoneTabPage.ResumeLayout(false);
            this.BottomStatusStrip.ResumeLayout(false);
            this.BottomStatusStrip.PerformLayout();
            this.TopToolStrip.ResumeLayout(false);
            this.TopToolStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private CoordConvertLayout Coord;
        private System.Windows.Forms.TabControl ConvertTabControl;
        private System.Windows.Forms.TabPage CoordTabPage;
        private System.Windows.Forms.TabPage ZoneTabPage;
        private CoordConvertLayout Zone;
        private System.Windows.Forms.TabPage DBTabPage;
        private System.Windows.Forms.ToolTip CtrlToolTip;
        private System.Windows.Forms.StatusStrip BottomStatusStrip;
        private System.Windows.Forms.ToolStripStatusLabel HintLabel;
        private System.Windows.Forms.ToolStrip TopToolStrip;
        private System.Windows.Forms.ToolStripButton SettingsBtn;
        private System.Windows.Forms.ToolStripButton AboutBtn;
    }
}
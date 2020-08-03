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
            this.ConvertTabControl = new System.Windows.Forms.TabControl();
            this.CoordTabPage = new System.Windows.Forms.TabPage();
            this.ZoneTabPage = new System.Windows.Forms.TabPage();
            this.DBTabPage = new System.Windows.Forms.TabPage();
            this.CtrlToolTip = new System.Windows.Forms.ToolTip(this.components);
            this.Coord = new GeodeticCoordinateConversion.CoordConvertLayout();
            this.Zone = new GeodeticCoordinateConversion.CoordConvertLayout();
            this.ConvertTabControl.SuspendLayout();
            this.CoordTabPage.SuspendLayout();
            this.ZoneTabPage.SuspendLayout();
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
            this.ConvertTabControl.Location = new System.Drawing.Point(9, 88);
            this.ConvertTabControl.Margin = new System.Windows.Forms.Padding(0);
            this.ConvertTabControl.Multiline = true;
            this.ConvertTabControl.Name = "ConvertTabControl";
            this.ConvertTabControl.Padding = new System.Drawing.Point(0, 0);
            this.ConvertTabControl.SelectedIndex = 0;
            this.ConvertTabControl.Size = new System.Drawing.Size(1046, 584);
            this.ConvertTabControl.TabIndex = 0;
            // 
            // CoordTabPage
            // 
            this.CoordTabPage.Controls.Add(this.Coord);
            this.CoordTabPage.Location = new System.Drawing.Point(4, 22);
            this.CoordTabPage.Margin = new System.Windows.Forms.Padding(0);
            this.CoordTabPage.Name = "CoordTabPage";
            this.CoordTabPage.Size = new System.Drawing.Size(1038, 558);
            this.CoordTabPage.TabIndex = 0;
            this.CoordTabPage.Text = "坐标转换";
            this.CoordTabPage.UseVisualStyleBackColor = true;
            // 
            // ZoneTabPage
            // 
            this.ZoneTabPage.Controls.Add(this.Zone);
            this.ZoneTabPage.Location = new System.Drawing.Point(4, 22);
            this.ZoneTabPage.Margin = new System.Windows.Forms.Padding(0);
            this.ZoneTabPage.Name = "ZoneTabPage";
            this.ZoneTabPage.Size = new System.Drawing.Size(1038, 558);
            this.ZoneTabPage.TabIndex = 1;
            this.ZoneTabPage.Text = "换带计算";
            this.ZoneTabPage.UseVisualStyleBackColor = true;
            // 
            // DBTabPage
            // 
            this.DBTabPage.Location = new System.Drawing.Point(4, 22);
            this.DBTabPage.Name = "DBTabPage";
            this.DBTabPage.Size = new System.Drawing.Size(1038, 558);
            this.DBTabPage.TabIndex = 2;
            this.DBTabPage.Text = "数据查看";
            this.DBTabPage.UseVisualStyleBackColor = true;
            // 
            // Coord
            // 
            this.Coord.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Coord.Location = new System.Drawing.Point(0, 0);
            this.Coord.Margin = new System.Windows.Forms.Padding(0);
            this.Coord.Name = "Coord";
            this.Coord.Size = new System.Drawing.Size(1038, 558);
            this.Coord.TabIndex = 0;
            // 
            // Zone
            // 
            this.Zone.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Zone.Location = new System.Drawing.Point(0, 0);
            this.Zone.Margin = new System.Windows.Forms.Padding(0);
            this.Zone.Name = "Zone";
            this.Zone.Size = new System.Drawing.Size(1038, 558);
            this.Zone.TabIndex = 0;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1064, 681);
            this.Controls.Add(this.ConvertTabControl);
            this.Name = "MainForm";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.ConvertTabControl.ResumeLayout(false);
            this.CoordTabPage.ResumeLayout(false);
            this.ZoneTabPage.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private CoordConvertLayout Coord;
        private System.Windows.Forms.TabControl ConvertTabControl;
        private System.Windows.Forms.TabPage CoordTabPage;
        private System.Windows.Forms.TabPage ZoneTabPage;
        private CoordConvertLayout Zone;
        private System.Windows.Forms.TabPage DBTabPage;
        private System.Windows.Forms.ToolTip CtrlToolTip;
    }
}
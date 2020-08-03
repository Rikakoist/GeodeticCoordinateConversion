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
            this.ConvertTabControl = new System.Windows.Forms.TabControl();
            this.CoordTabPage = new System.Windows.Forms.TabPage();
            this.ZoneTabPage = new System.Windows.Forms.TabPage();
            this.DBTabPage = new System.Windows.Forms.TabPage();
            this.TableListComboBox = new System.Windows.Forms.ComboBox();
            this.DBDGV = new System.Windows.Forms.DataGridView();
            this.DataTableFlowLayoutPanel = new System.Windows.Forms.FlowLayoutPanel();
            this.ReloadTableBtn = new System.Windows.Forms.Button();
            this.Coord = new GeodeticCoordinateConversion.CoordConvertLayout();
            this.Zone = new GeodeticCoordinateConversion.CoordConvertLayout();
            this.TableLabel = new System.Windows.Forms.Label();
            this.ConvertTabControl.SuspendLayout();
            this.CoordTabPage.SuspendLayout();
            this.ZoneTabPage.SuspendLayout();
            this.DBTabPage.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DBDGV)).BeginInit();
            this.DataTableFlowLayoutPanel.SuspendLayout();
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
            this.DBTabPage.Controls.Add(this.DataTableFlowLayoutPanel);
            this.DBTabPage.Controls.Add(this.DBDGV);
            this.DBTabPage.Location = new System.Drawing.Point(4, 22);
            this.DBTabPage.Name = "DBTabPage";
            this.DBTabPage.Size = new System.Drawing.Size(1038, 558);
            this.DBTabPage.TabIndex = 2;
            this.DBTabPage.Text = "数据查看";
            this.DBTabPage.UseVisualStyleBackColor = true;
            // 
            // TableListComboBox
            // 
            this.TableListComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.TableListComboBox.FormattingEnabled = true;
            this.TableListComboBox.Location = new System.Drawing.Point(67, 3);
            this.TableListComboBox.Margin = new System.Windows.Forms.Padding(0, 3, 10, 0);
            this.TableListComboBox.Name = "TableListComboBox";
            this.TableListComboBox.Size = new System.Drawing.Size(163, 21);
            this.TableListComboBox.TabIndex = 0;
            this.TableListComboBox.SelectedValueChanged += new System.EventHandler(this.SelectedTableNameChanged);
            // 
            // DBDGV
            // 
            this.DBDGV.AllowUserToAddRows = false;
            this.DBDGV.AllowUserToDeleteRows = false;
            this.DBDGV.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.DBDGV.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.DBDGV.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DBDGV.Location = new System.Drawing.Point(3, 86);
            this.DBDGV.Name = "DBDGV";
            this.DBDGV.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.DBDGV.Size = new System.Drawing.Size(1032, 469);
            this.DBDGV.TabIndex = 0;
            // 
            // DataTableFlowLayoutPanel
            // 
            this.DataTableFlowLayoutPanel.AutoSize = true;
            this.DataTableFlowLayoutPanel.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.DataTableFlowLayoutPanel.Controls.Add(this.TableLabel);
            this.DataTableFlowLayoutPanel.Controls.Add(this.TableListComboBox);
            this.DataTableFlowLayoutPanel.Controls.Add(this.ReloadTableBtn);
            this.DataTableFlowLayoutPanel.Location = new System.Drawing.Point(112, 15);
            this.DataTableFlowLayoutPanel.Margin = new System.Windows.Forms.Padding(0);
            this.DataTableFlowLayoutPanel.Name = "DataTableFlowLayoutPanel";
            this.DataTableFlowLayoutPanel.Size = new System.Drawing.Size(267, 27);
            this.DataTableFlowLayoutPanel.TabIndex = 1;
            // 
            // ReloadTableBtn
            // 
            this.ReloadTableBtn.BackgroundImage = global::GeodeticCoordinateConversion.Properties.Resources.Recycle;
            this.ReloadTableBtn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.ReloadTableBtn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.ReloadTableBtn.Location = new System.Drawing.Point(240, 0);
            this.ReloadTableBtn.Margin = new System.Windows.Forms.Padding(0);
            this.ReloadTableBtn.Name = "ReloadTableBtn";
            this.ReloadTableBtn.Size = new System.Drawing.Size(27, 27);
            this.ReloadTableBtn.TabIndex = 1;
            this.ReloadTableBtn.UseVisualStyleBackColor = true;
            this.ReloadTableBtn.Click += new System.EventHandler(this.ReloadTable);
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
            // TableLabel
            // 
            this.TableLabel.AutoSize = true;
            this.TableLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TableLabel.Location = new System.Drawing.Point(3, 5);
            this.TableLabel.Margin = new System.Windows.Forms.Padding(3, 5, 3, 0);
            this.TableLabel.Name = "TableLabel";
            this.TableLabel.Size = new System.Drawing.Size(61, 16);
            this.TableLabel.TabIndex = 2;
            this.TableLabel.Text = "数据表：";
            this.TableLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
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
            this.DBTabPage.ResumeLayout(false);
            this.DBTabPage.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DBDGV)).EndInit();
            this.DataTableFlowLayoutPanel.ResumeLayout(false);
            this.DataTableFlowLayoutPanel.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private CoordConvertLayout Coord;
        private System.Windows.Forms.TabControl ConvertTabControl;
        private System.Windows.Forms.TabPage CoordTabPage;
        private System.Windows.Forms.TabPage ZoneTabPage;
        private CoordConvertLayout Zone;
        private System.Windows.Forms.TabPage DBTabPage;
        private System.Windows.Forms.DataGridView DBDGV;
        private System.Windows.Forms.ComboBox TableListComboBox;
        private System.Windows.Forms.Button ReloadTableBtn;
        private System.Windows.Forms.FlowLayoutPanel DataTableFlowLayoutPanel;
        private System.Windows.Forms.Label TableLabel;
    }
}
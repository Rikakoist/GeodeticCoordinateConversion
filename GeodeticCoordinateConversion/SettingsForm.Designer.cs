﻿namespace GeodeticCoordinateConversion
{
    partial class SettingsForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SettingsForm));
            this.TitleLabel = new System.Windows.Forms.Label();
            this.WorkFolderLabel = new System.Windows.Forms.Label();
            this.WorkFolderTextBox = new System.Windows.Forms.TextBox();
            this.WorkFolderBtn = new System.Windows.Forms.Button();
            this.DataFileNameLabel = new System.Windows.Forms.Label();
            this.DataFileNameTextBox = new System.Windows.Forms.TextBox();
            this.DBNameLabel = new System.Windows.Forms.Label();
            this.DBNameTextBox = new System.Windows.Forms.TextBox();
            this.DefaultEllipseTypeLabel = new System.Windows.Forms.Label();
            this.DefaultEllipseTypeComboBox = new System.Windows.Forms.ComboBox();
            this.DefaultZoneTypeLabel = new System.Windows.Forms.Label();
            this.DefaultZoneTypeComboBox = new System.Windows.Forms.ComboBox();
            this.BtnFlowLayoutPanel = new System.Windows.Forms.FlowLayoutPanel();
            this.ConfirmBtn = new System.Windows.Forms.Button();
            this.CancelBtn = new System.Windows.Forms.Button();
            this.ResetBtn = new System.Windows.Forms.Button();
            this.BtnToolTip = new System.Windows.Forms.ToolTip(this.components);
            this.SettingsTabControl = new System.Windows.Forms.TabControl();
            this.GeneralTabPage = new System.Windows.Forms.TabPage();
            this.DataTabPage = new System.Windows.Forms.TabPage();
            this.ClearExistingRecordFile2DBCheckBox = new System.Windows.Forms.CheckBox();
            this.ClearExistingRecordDB2FileCheckBox = new System.Windows.Forms.CheckBox();
            this.ClearExistingRecordData2DBCheckBox = new System.Windows.Forms.CheckBox();
            this.ClearExistingRecordData2FileCheckBox = new System.Windows.Forms.CheckBox();
            this.SwitchAfterGaussTransferCheckBox = new System.Windows.Forms.CheckBox();
            this.OpenWorkFolder = new System.Windows.Forms.Button();
            this.PicPictureBox = new System.Windows.Forms.PictureBox();
            this.BtnFlowLayoutPanel.SuspendLayout();
            this.SettingsTabControl.SuspendLayout();
            this.GeneralTabPage.SuspendLayout();
            this.DataTabPage.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PicPictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // TitleLabel
            // 
            this.TitleLabel.AutoSize = true;
            this.TitleLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TitleLabel.Location = new System.Drawing.Point(100, 34);
            this.TitleLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.TitleLabel.Name = "TitleLabel";
            this.TitleLabel.Size = new System.Drawing.Size(281, 37);
            this.TitleLabel.TabIndex = 1;
            this.TitleLabel.Text = "大地坐标转换设置";
            this.TitleLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // WorkFolderLabel
            // 
            this.WorkFolderLabel.AutoSize = true;
            this.WorkFolderLabel.Font = new System.Drawing.Font("Microsoft YaHei", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.WorkFolderLabel.Location = new System.Drawing.Point(39, 50);
            this.WorkFolderLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.WorkFolderLabel.Name = "WorkFolderLabel";
            this.WorkFolderLabel.Size = new System.Drawing.Size(106, 22);
            this.WorkFolderLabel.TabIndex = 0;
            this.WorkFolderLabel.Text = "工作文件夹：";
            this.WorkFolderLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // WorkFolderTextBox
            // 
            this.WorkFolderTextBox.Location = new System.Drawing.Point(164, 49);
            this.WorkFolderTextBox.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.WorkFolderTextBox.Name = "WorkFolderTextBox";
            this.WorkFolderTextBox.ReadOnly = true;
            this.WorkFolderTextBox.Size = new System.Drawing.Size(384, 25);
            this.WorkFolderTextBox.TabIndex = 0;
            this.WorkFolderTextBox.TabStop = false;
            // 
            // WorkFolderBtn
            // 
            this.WorkFolderBtn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.WorkFolderBtn.Location = new System.Drawing.Point(558, 49);
            this.WorkFolderBtn.Name = "WorkFolderBtn";
            this.WorkFolderBtn.Size = new System.Drawing.Size(40, 25);
            this.WorkFolderBtn.TabIndex = 0;
            this.WorkFolderBtn.Text = "...";
            this.BtnToolTip.SetToolTip(this.WorkFolderBtn, "选择工作文件夹");
            this.WorkFolderBtn.UseVisualStyleBackColor = true;
            this.WorkFolderBtn.Click += new System.EventHandler(this.BrowseWorkFolder);
            // 
            // DataFileNameLabel
            // 
            this.DataFileNameLabel.AutoSize = true;
            this.DataFileNameLabel.Font = new System.Drawing.Font("Microsoft YaHei", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DataFileNameLabel.Location = new System.Drawing.Point(39, 97);
            this.DataFileNameLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.DataFileNameLabel.Name = "DataFileNameLabel";
            this.DataFileNameLabel.Size = new System.Drawing.Size(106, 22);
            this.DataFileNameLabel.TabIndex = 0;
            this.DataFileNameLabel.Text = "数据文件名：";
            this.DataFileNameLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // DataFileNameTextBox
            // 
            this.DataFileNameTextBox.Location = new System.Drawing.Point(164, 96);
            this.DataFileNameTextBox.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.DataFileNameTextBox.Name = "DataFileNameTextBox";
            this.DataFileNameTextBox.Size = new System.Drawing.Size(384, 25);
            this.DataFileNameTextBox.TabIndex = 2;
            // 
            // DBNameLabel
            // 
            this.DBNameLabel.AutoSize = true;
            this.DBNameLabel.Font = new System.Drawing.Font("Microsoft YaHei", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DBNameLabel.Location = new System.Drawing.Point(39, 144);
            this.DBNameLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.DBNameLabel.Name = "DBNameLabel";
            this.DBNameLabel.Size = new System.Drawing.Size(122, 22);
            this.DBNameLabel.TabIndex = 0;
            this.DBNameLabel.Text = "数据库文件名：";
            this.DBNameLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // DBNameTextBox
            // 
            this.DBNameTextBox.Location = new System.Drawing.Point(164, 143);
            this.DBNameTextBox.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.DBNameTextBox.Name = "DBNameTextBox";
            this.DBNameTextBox.Size = new System.Drawing.Size(384, 25);
            this.DBNameTextBox.TabIndex = 3;
            // 
            // DefaultEllipseTypeLabel
            // 
            this.DefaultEllipseTypeLabel.AutoSize = true;
            this.DefaultEllipseTypeLabel.Font = new System.Drawing.Font("Microsoft YaHei", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DefaultEllipseTypeLabel.Location = new System.Drawing.Point(39, 191);
            this.DefaultEllipseTypeLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.DefaultEllipseTypeLabel.Name = "DefaultEllipseTypeLabel";
            this.DefaultEllipseTypeLabel.Size = new System.Drawing.Size(90, 22);
            this.DefaultEllipseTypeLabel.TabIndex = 0;
            this.DefaultEllipseTypeLabel.Text = "默认椭球：";
            this.DefaultEllipseTypeLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // DefaultEllipseTypeComboBox
            // 
            this.DefaultEllipseTypeComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.DefaultEllipseTypeComboBox.FormattingEnabled = true;
            this.DefaultEllipseTypeComboBox.Location = new System.Drawing.Point(164, 189);
            this.DefaultEllipseTypeComboBox.Name = "DefaultEllipseTypeComboBox";
            this.DefaultEllipseTypeComboBox.Size = new System.Drawing.Size(201, 27);
            this.DefaultEllipseTypeComboBox.TabIndex = 4;
            this.BtnToolTip.SetToolTip(this.DefaultEllipseTypeComboBox, "添加新记录时的默认椭球");
            // 
            // DefaultZoneTypeLabel
            // 
            this.DefaultZoneTypeLabel.AutoSize = true;
            this.DefaultZoneTypeLabel.Font = new System.Drawing.Font("Microsoft YaHei", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DefaultZoneTypeLabel.Location = new System.Drawing.Point(39, 238);
            this.DefaultZoneTypeLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.DefaultZoneTypeLabel.Name = "DefaultZoneTypeLabel";
            this.DefaultZoneTypeLabel.Size = new System.Drawing.Size(90, 22);
            this.DefaultZoneTypeLabel.TabIndex = 0;
            this.DefaultZoneTypeLabel.Text = "默认分带：";
            this.DefaultZoneTypeLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // DefaultZoneTypeComboBox
            // 
            this.DefaultZoneTypeComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.DefaultZoneTypeComboBox.FormattingEnabled = true;
            this.DefaultZoneTypeComboBox.Location = new System.Drawing.Point(164, 236);
            this.DefaultZoneTypeComboBox.Name = "DefaultZoneTypeComboBox";
            this.DefaultZoneTypeComboBox.Size = new System.Drawing.Size(201, 27);
            this.DefaultZoneTypeComboBox.TabIndex = 5;
            this.BtnToolTip.SetToolTip(this.DefaultZoneTypeComboBox, "添加新记录时的默认分带");
            // 
            // BtnFlowLayoutPanel
            // 
            this.BtnFlowLayoutPanel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.BtnFlowLayoutPanel.AutoSize = true;
            this.BtnFlowLayoutPanel.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BtnFlowLayoutPanel.Controls.Add(this.ConfirmBtn);
            this.BtnFlowLayoutPanel.Controls.Add(this.CancelBtn);
            this.BtnFlowLayoutPanel.Controls.Add(this.ResetBtn);
            this.BtnFlowLayoutPanel.Location = new System.Drawing.Point(395, 463);
            this.BtnFlowLayoutPanel.Name = "BtnFlowLayoutPanel";
            this.BtnFlowLayoutPanel.Size = new System.Drawing.Size(277, 36);
            this.BtnFlowLayoutPanel.TabIndex = 1;
            // 
            // ConfirmBtn
            // 
            this.ConfirmBtn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.ConfirmBtn.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.ConfirmBtn.Location = new System.Drawing.Point(3, 3);
            this.ConfirmBtn.Name = "ConfirmBtn";
            this.ConfirmBtn.Size = new System.Drawing.Size(80, 30);
            this.ConfirmBtn.TabIndex = 0;
            this.ConfirmBtn.Text = "保存";
            this.BtnToolTip.SetToolTip(this.ConfirmBtn, "保存更改（需要重启）");
            this.ConfirmBtn.UseVisualStyleBackColor = true;
            this.ConfirmBtn.Click += new System.EventHandler(this.SaveChanges);
            // 
            // CancelBtn
            // 
            this.CancelBtn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.CancelBtn.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.CancelBtn.Location = new System.Drawing.Point(89, 3);
            this.CancelBtn.Name = "CancelBtn";
            this.CancelBtn.Size = new System.Drawing.Size(80, 30);
            this.CancelBtn.TabIndex = 1;
            this.CancelBtn.Text = "取消";
            this.BtnToolTip.SetToolTip(this.CancelBtn, "放弃更改");
            this.CancelBtn.UseVisualStyleBackColor = true;
            // 
            // ResetBtn
            // 
            this.ResetBtn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.ResetBtn.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.ResetBtn.Location = new System.Drawing.Point(175, 3);
            this.ResetBtn.Name = "ResetBtn";
            this.ResetBtn.Size = new System.Drawing.Size(99, 30);
            this.ResetBtn.TabIndex = 2;
            this.ResetBtn.Text = "恢复默认值";
            this.BtnToolTip.SetToolTip(this.ResetBtn, "将所有设置恢复到默认值（需要重启）");
            this.ResetBtn.UseVisualStyleBackColor = true;
            this.ResetBtn.Click += new System.EventHandler(this.ResetDefault);
            // 
            // SettingsTabControl
            // 
            this.SettingsTabControl.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.SettingsTabControl.Controls.Add(this.GeneralTabPage);
            this.SettingsTabControl.Controls.Add(this.DataTabPage);
            this.SettingsTabControl.Location = new System.Drawing.Point(12, 96);
            this.SettingsTabControl.Name = "SettingsTabControl";
            this.SettingsTabControl.SelectedIndex = 0;
            this.SettingsTabControl.Size = new System.Drawing.Size(660, 361);
            this.SettingsTabControl.TabIndex = 0;
            // 
            // GeneralTabPage
            // 
            this.GeneralTabPage.Controls.Add(this.OpenWorkFolder);
            this.GeneralTabPage.Controls.Add(this.WorkFolderLabel);
            this.GeneralTabPage.Controls.Add(this.WorkFolderTextBox);
            this.GeneralTabPage.Controls.Add(this.DataFileNameLabel);
            this.GeneralTabPage.Controls.Add(this.DefaultZoneTypeComboBox);
            this.GeneralTabPage.Controls.Add(this.DataFileNameTextBox);
            this.GeneralTabPage.Controls.Add(this.DefaultEllipseTypeComboBox);
            this.GeneralTabPage.Controls.Add(this.DBNameLabel);
            this.GeneralTabPage.Controls.Add(this.WorkFolderBtn);
            this.GeneralTabPage.Controls.Add(this.DefaultEllipseTypeLabel);
            this.GeneralTabPage.Controls.Add(this.DefaultZoneTypeLabel);
            this.GeneralTabPage.Controls.Add(this.DBNameTextBox);
            this.GeneralTabPage.Location = new System.Drawing.Point(4, 28);
            this.GeneralTabPage.Name = "GeneralTabPage";
            this.GeneralTabPage.Padding = new System.Windows.Forms.Padding(3);
            this.GeneralTabPage.Size = new System.Drawing.Size(652, 329);
            this.GeneralTabPage.TabIndex = 0;
            this.GeneralTabPage.Text = "通用";
            this.GeneralTabPage.UseVisualStyleBackColor = true;
            // 
            // DataTabPage
            // 
            this.DataTabPage.Controls.Add(this.ClearExistingRecordFile2DBCheckBox);
            this.DataTabPage.Controls.Add(this.ClearExistingRecordDB2FileCheckBox);
            this.DataTabPage.Controls.Add(this.ClearExistingRecordData2DBCheckBox);
            this.DataTabPage.Controls.Add(this.ClearExistingRecordData2FileCheckBox);
            this.DataTabPage.Controls.Add(this.SwitchAfterGaussTransferCheckBox);
            this.DataTabPage.Location = new System.Drawing.Point(4, 28);
            this.DataTabPage.Name = "DataTabPage";
            this.DataTabPage.Padding = new System.Windows.Forms.Padding(3);
            this.DataTabPage.Size = new System.Drawing.Size(652, 329);
            this.DataTabPage.TabIndex = 1;
            this.DataTabPage.Text = "数据";
            this.DataTabPage.UseVisualStyleBackColor = true;
            // 
            // ClearExistingRecordFile2DBCheckBox
            // 
            this.ClearExistingRecordFile2DBCheckBox.AutoSize = true;
            this.ClearExistingRecordFile2DBCheckBox.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.ClearExistingRecordFile2DBCheckBox.Font = new System.Drawing.Font("Microsoft YaHei", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ClearExistingRecordFile2DBCheckBox.Location = new System.Drawing.Point(45, 248);
            this.ClearExistingRecordFile2DBCheckBox.Name = "ClearExistingRecordFile2DBCheckBox";
            this.ClearExistingRecordFile2DBCheckBox.Size = new System.Drawing.Size(381, 26);
            this.ClearExistingRecordFile2DBCheckBox.TabIndex = 4;
            this.ClearExistingRecordFile2DBCheckBox.Text = "将文件数据导入到数据库时，清空目标数据库记录";
            this.ClearExistingRecordFile2DBCheckBox.UseVisualStyleBackColor = true;
            // 
            // ClearExistingRecordDB2FileCheckBox
            // 
            this.ClearExistingRecordDB2FileCheckBox.AutoSize = true;
            this.ClearExistingRecordDB2FileCheckBox.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.ClearExistingRecordDB2FileCheckBox.Font = new System.Drawing.Font("Microsoft YaHei", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ClearExistingRecordDB2FileCheckBox.Location = new System.Drawing.Point(45, 200);
            this.ClearExistingRecordDB2FileCheckBox.Name = "ClearExistingRecordDB2FileCheckBox";
            this.ClearExistingRecordDB2FileCheckBox.Size = new System.Drawing.Size(333, 26);
            this.ClearExistingRecordDB2FileCheckBox.TabIndex = 3;
            this.ClearExistingRecordDB2FileCheckBox.Text = "将数据库导出到文件时，清空目标文件记录";
            this.ClearExistingRecordDB2FileCheckBox.UseVisualStyleBackColor = true;
            // 
            // ClearExistingRecordData2DBCheckBox
            // 
            this.ClearExistingRecordData2DBCheckBox.AutoSize = true;
            this.ClearExistingRecordData2DBCheckBox.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.ClearExistingRecordData2DBCheckBox.Font = new System.Drawing.Font("Microsoft YaHei", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ClearExistingRecordData2DBCheckBox.Location = new System.Drawing.Point(45, 152);
            this.ClearExistingRecordData2DBCheckBox.Name = "ClearExistingRecordData2DBCheckBox";
            this.ClearExistingRecordData2DBCheckBox.Size = new System.Drawing.Size(381, 26);
            this.ClearExistingRecordData2DBCheckBox.TabIndex = 2;
            this.ClearExistingRecordData2DBCheckBox.Text = "将应用数据保存到数据库时，清空目标数据库记录";
            this.ClearExistingRecordData2DBCheckBox.UseVisualStyleBackColor = true;
            // 
            // ClearExistingRecordData2FileCheckBox
            // 
            this.ClearExistingRecordData2FileCheckBox.AutoSize = true;
            this.ClearExistingRecordData2FileCheckBox.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.ClearExistingRecordData2FileCheckBox.Font = new System.Drawing.Font("Microsoft YaHei", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ClearExistingRecordData2FileCheckBox.Location = new System.Drawing.Point(45, 104);
            this.ClearExistingRecordData2FileCheckBox.Name = "ClearExistingRecordData2FileCheckBox";
            this.ClearExistingRecordData2FileCheckBox.Size = new System.Drawing.Size(349, 26);
            this.ClearExistingRecordData2FileCheckBox.TabIndex = 1;
            this.ClearExistingRecordData2FileCheckBox.Text = "将应用数据保存到文件时，清空目标文件记录";
            this.ClearExistingRecordData2FileCheckBox.UseVisualStyleBackColor = true;
            // 
            // SwitchAfterGaussTransferCheckBox
            // 
            this.SwitchAfterGaussTransferCheckBox.AutoSize = true;
            this.SwitchAfterGaussTransferCheckBox.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.SwitchAfterGaussTransferCheckBox.Font = new System.Drawing.Font("Microsoft YaHei", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SwitchAfterGaussTransferCheckBox.Location = new System.Drawing.Point(45, 56);
            this.SwitchAfterGaussTransferCheckBox.Name = "SwitchAfterGaussTransferCheckBox";
            this.SwitchAfterGaussTransferCheckBox.Size = new System.Drawing.Size(317, 26);
            this.SwitchAfterGaussTransferCheckBox.TabIndex = 0;
            this.SwitchAfterGaussTransferCheckBox.Text = "坐标转换转移至换带后，自动切换标签页";
            this.SwitchAfterGaussTransferCheckBox.UseVisualStyleBackColor = true;
            // 
            // OpenWorkFolder
            // 
            this.OpenWorkFolder.BackgroundImage = global::GeodeticCoordinateConversion.Properties.Resources.Open;
            this.OpenWorkFolder.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.OpenWorkFolder.Cursor = System.Windows.Forms.Cursors.Hand;
            this.OpenWorkFolder.Location = new System.Drawing.Point(604, 49);
            this.OpenWorkFolder.Name = "OpenWorkFolder";
            this.OpenWorkFolder.Size = new System.Drawing.Size(25, 25);
            this.OpenWorkFolder.TabIndex = 1;
            this.BtnToolTip.SetToolTip(this.OpenWorkFolder, "打开工作文件夹");
            this.OpenWorkFolder.UseVisualStyleBackColor = true;
            this.OpenWorkFolder.Click += new System.EventHandler(this.OpenFolder);
            // 
            // PicPictureBox
            // 
            this.PicPictureBox.BackgroundImage = global::GeodeticCoordinateConversion.Properties.Resources.Globe;
            this.PicPictureBox.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.PicPictureBox.Location = new System.Drawing.Point(28, 20);
            this.PicPictureBox.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.PicPictureBox.Name = "PicPictureBox";
            this.PicPictureBox.Size = new System.Drawing.Size(64, 64);
            this.PicPictureBox.TabIndex = 0;
            this.PicPictureBox.TabStop = false;
            // 
            // SettingsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(684, 511);
            this.Controls.Add(this.SettingsTabControl);
            this.Controls.Add(this.BtnFlowLayoutPanel);
            this.Controls.Add(this.TitleLabel);
            this.Controls.Add(this.PicPictureBox);
            this.Font = new System.Drawing.Font("Microsoft YaHei", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(700, 500);
            this.Name = "SettingsForm";
            this.Text = "设置";
            this.BtnFlowLayoutPanel.ResumeLayout(false);
            this.SettingsTabControl.ResumeLayout(false);
            this.GeneralTabPage.ResumeLayout(false);
            this.GeneralTabPage.PerformLayout();
            this.DataTabPage.ResumeLayout(false);
            this.DataTabPage.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PicPictureBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox PicPictureBox;
        private System.Windows.Forms.Label TitleLabel;
        private System.Windows.Forms.Label WorkFolderLabel;
        private System.Windows.Forms.TextBox WorkFolderTextBox;
        private System.Windows.Forms.Button WorkFolderBtn;
        private System.Windows.Forms.Label DataFileNameLabel;
        private System.Windows.Forms.TextBox DataFileNameTextBox;
        private System.Windows.Forms.Label DBNameLabel;
        private System.Windows.Forms.TextBox DBNameTextBox;
        private System.Windows.Forms.Label DefaultEllipseTypeLabel;
        private System.Windows.Forms.ComboBox DefaultEllipseTypeComboBox;
        private System.Windows.Forms.Label DefaultZoneTypeLabel;
        private System.Windows.Forms.ComboBox DefaultZoneTypeComboBox;
        private System.Windows.Forms.FlowLayoutPanel BtnFlowLayoutPanel;
        private System.Windows.Forms.Button ConfirmBtn;
        private System.Windows.Forms.Button CancelBtn;
        private System.Windows.Forms.Button ResetBtn;
        private System.Windows.Forms.ToolTip BtnToolTip;
        private System.Windows.Forms.TabControl SettingsTabControl;
        private System.Windows.Forms.TabPage GeneralTabPage;
        private System.Windows.Forms.TabPage DataTabPage;
        private System.Windows.Forms.CheckBox SwitchAfterGaussTransferCheckBox;
        private System.Windows.Forms.CheckBox ClearExistingRecordData2FileCheckBox;
        private System.Windows.Forms.CheckBox ClearExistingRecordData2DBCheckBox;
        private System.Windows.Forms.CheckBox ClearExistingRecordDB2FileCheckBox;
        private System.Windows.Forms.CheckBox ClearExistingRecordFile2DBCheckBox;
        private System.Windows.Forms.Button OpenWorkFolder;
    }
}
﻿namespace GeodeticCoordinateConversion
{
    partial class CoordConvertLayout
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CoordConvertLayout));
            this.CoordConvertDGV = new System.Windows.Forms.DataGridView();
            this.DirectBtn = new System.Windows.Forms.Button();
            this.ReverseBtn = new System.Windows.Forms.Button();
            this.TransferBtn = new System.Windows.Forms.Button();
            this.SelectAllBtn = new System.Windows.Forms.Button();
            this.SelectNoneBtn = new System.Windows.Forms.Button();
            this.ReverseSelectBtn = new System.Windows.Forms.Button();
            this.DataFlowLayoutPanel = new System.Windows.Forms.FlowLayoutPanel();
            this.AddRowPictureBox = new System.Windows.Forms.PictureBox();
            this.DeletePictureBox = new System.Windows.Forms.PictureBox();
            this.LoadPictureBox = new System.Windows.Forms.PictureBox();
            this.SavePictureBox = new System.Windows.Forms.PictureBox();
            this.AddRowBtn = new System.Windows.Forms.Button();
            this.DeleteBtn = new System.Windows.Forms.Button();
            this.LoadBtn = new System.Windows.Forms.Button();
            this.SaveBtn = new System.Windows.Forms.Button();
            this.SelectionFlowLayoutPanel = new System.Windows.Forms.FlowLayoutPanel();
            this.gEODataTablesBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            ((System.ComponentModel.ISupportInitialize)(this.CoordConvertDGV)).BeginInit();
            this.DataFlowLayoutPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.AddRowPictureBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DeletePictureBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.LoadPictureBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SavePictureBox)).BeginInit();
            this.SelectionFlowLayoutPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gEODataTablesBindingSource)).BeginInit();
            this.flowLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // CoordConvertDGV
            // 
            this.CoordConvertDGV.AllowUserToAddRows = false;
            this.CoordConvertDGV.AllowUserToDeleteRows = false;
            this.CoordConvertDGV.AllowUserToOrderColumns = true;
            this.CoordConvertDGV.AllowUserToResizeRows = false;
            this.CoordConvertDGV.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.CoordConvertDGV.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.CoordConvertDGV.Location = new System.Drawing.Point(48, 34);
            this.CoordConvertDGV.Name = "CoordConvertDGV";
            this.CoordConvertDGV.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.CoordConvertDGV.Size = new System.Drawing.Size(827, 420);
            this.CoordConvertDGV.TabIndex = 0;
            this.CoordConvertDGV.DataSourceChanged += new System.EventHandler(this.CoordConvertDGV_DataSourceChanged);
            this.CoordConvertDGV.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.CoordConvertDGV_CellEndEdit);
            this.CoordConvertDGV.RowsAdded += new System.Windows.Forms.DataGridViewRowsAddedEventHandler(this.CoordConvertDGV_RowsAdded);
            // 
            // DirectBtn
            // 
            this.DirectBtn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.DirectBtn.Location = new System.Drawing.Point(0, 0);
            this.DirectBtn.Margin = new System.Windows.Forms.Padding(0, 0, 20, 0);
            this.DirectBtn.Name = "DirectBtn";
            this.DirectBtn.Size = new System.Drawing.Size(75, 23);
            this.DirectBtn.TabIndex = 0;
            this.DirectBtn.Text = ">>";
            this.DirectBtn.UseVisualStyleBackColor = true;
            this.DirectBtn.Click += new System.EventHandler(this.ConvertOperation);
            // 
            // ReverseBtn
            // 
            this.ReverseBtn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.ReverseBtn.Location = new System.Drawing.Point(95, 0);
            this.ReverseBtn.Margin = new System.Windows.Forms.Padding(0);
            this.ReverseBtn.Name = "ReverseBtn";
            this.ReverseBtn.Size = new System.Drawing.Size(75, 23);
            this.ReverseBtn.TabIndex = 1;
            this.ReverseBtn.Text = "<<";
            this.ReverseBtn.UseVisualStyleBackColor = true;
            this.ReverseBtn.Click += new System.EventHandler(this.ConvertOperation);
            // 
            // TransferBtn
            // 
            this.TransferBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.TransferBtn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.TransferBtn.Location = new System.Drawing.Point(800, 5);
            this.TransferBtn.Name = "TransferBtn";
            this.TransferBtn.Size = new System.Drawing.Size(75, 23);
            this.TransferBtn.TabIndex = 5;
            this.TransferBtn.Text = ">>";
            this.TransferBtn.UseVisualStyleBackColor = true;
            this.TransferBtn.Click += new System.EventHandler(this.TransferBtn_Click);
            // 
            // SelectAllBtn
            // 
            this.SelectAllBtn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.SelectAllBtn.Location = new System.Drawing.Point(67, 0);
            this.SelectAllBtn.Margin = new System.Windows.Forms.Padding(0, 0, 10, 0);
            this.SelectAllBtn.Name = "SelectAllBtn";
            this.SelectAllBtn.Size = new System.Drawing.Size(57, 23);
            this.SelectAllBtn.TabIndex = 1;
            this.SelectAllBtn.Tag = "SelectAll";
            this.SelectAllBtn.Text = "全选";
            this.SelectAllBtn.UseVisualStyleBackColor = true;
            this.SelectAllBtn.Click += new System.EventHandler(this.ConvertSelection);
            // 
            // SelectNoneBtn
            // 
            this.SelectNoneBtn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.SelectNoneBtn.Location = new System.Drawing.Point(0, 0);
            this.SelectNoneBtn.Margin = new System.Windows.Forms.Padding(0, 0, 10, 0);
            this.SelectNoneBtn.Name = "SelectNoneBtn";
            this.SelectNoneBtn.Size = new System.Drawing.Size(57, 23);
            this.SelectNoneBtn.TabIndex = 0;
            this.SelectNoneBtn.Tag = "SelectNone";
            this.SelectNoneBtn.Text = "全不选";
            this.SelectNoneBtn.UseVisualStyleBackColor = true;
            this.SelectNoneBtn.Click += new System.EventHandler(this.ConvertSelection);
            // 
            // ReverseSelectBtn
            // 
            this.ReverseSelectBtn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.ReverseSelectBtn.Location = new System.Drawing.Point(134, 0);
            this.ReverseSelectBtn.Margin = new System.Windows.Forms.Padding(0);
            this.ReverseSelectBtn.Name = "ReverseSelectBtn";
            this.ReverseSelectBtn.Size = new System.Drawing.Size(57, 23);
            this.ReverseSelectBtn.TabIndex = 2;
            this.ReverseSelectBtn.Tag = "ReverseSelect";
            this.ReverseSelectBtn.Text = "反选";
            this.ReverseSelectBtn.UseVisualStyleBackColor = true;
            this.ReverseSelectBtn.Click += new System.EventHandler(this.ConvertSelection);
            // 
            // DataFlowLayoutPanel
            // 
            this.DataFlowLayoutPanel.AutoSize = true;
            this.DataFlowLayoutPanel.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.DataFlowLayoutPanel.Controls.Add(this.AddRowBtn);
            this.DataFlowLayoutPanel.Controls.Add(this.DeleteBtn);
            this.DataFlowLayoutPanel.Controls.Add(this.LoadBtn);
            this.DataFlowLayoutPanel.Controls.Add(this.SaveBtn);
            this.DataFlowLayoutPanel.Controls.Add(this.AddRowPictureBox);
            this.DataFlowLayoutPanel.Controls.Add(this.DeletePictureBox);
            this.DataFlowLayoutPanel.Controls.Add(this.LoadPictureBox);
            this.DataFlowLayoutPanel.Controls.Add(this.SavePictureBox);
            this.DataFlowLayoutPanel.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.DataFlowLayoutPanel.Location = new System.Drawing.Point(8, 34);
            this.DataFlowLayoutPanel.Margin = new System.Windows.Forms.Padding(0);
            this.DataFlowLayoutPanel.Name = "DataFlowLayoutPanel";
            this.DataFlowLayoutPanel.Size = new System.Drawing.Size(32, 289);
            this.DataFlowLayoutPanel.TabIndex = 9;
            // 
            // AddRowPictureBox
            // 
            this.AddRowPictureBox.BackColor = System.Drawing.Color.DeepSkyBlue;
            this.AddRowPictureBox.Cursor = System.Windows.Forms.Cursors.Hand;
            this.AddRowPictureBox.Image = ((System.Drawing.Image)(resources.GetObject("AddRowPictureBox.Image")));
            this.AddRowPictureBox.Location = new System.Drawing.Point(0, 140);
            this.AddRowPictureBox.Margin = new System.Windows.Forms.Padding(0, 0, 0, 3);
            this.AddRowPictureBox.Name = "AddRowPictureBox";
            this.AddRowPictureBox.Size = new System.Drawing.Size(32, 32);
            this.AddRowPictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.AddRowPictureBox.TabIndex = 4;
            this.AddRowPictureBox.TabStop = false;
            // 
            // DeletePictureBox
            // 
            this.DeletePictureBox.BackColor = System.Drawing.Color.Transparent;
            this.DeletePictureBox.Cursor = System.Windows.Forms.Cursors.Hand;
            this.DeletePictureBox.Image = ((System.Drawing.Image)(resources.GetObject("DeletePictureBox.Image")));
            this.DeletePictureBox.Location = new System.Drawing.Point(0, 178);
            this.DeletePictureBox.Margin = new System.Windows.Forms.Padding(0, 3, 0, 3);
            this.DeletePictureBox.Name = "DeletePictureBox";
            this.DeletePictureBox.Size = new System.Drawing.Size(32, 32);
            this.DeletePictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.DeletePictureBox.TabIndex = 4;
            this.DeletePictureBox.TabStop = false;
            this.DeletePictureBox.Click += new System.EventHandler(this.DeleteRow);
            // 
            // LoadPictureBox
            // 
            this.LoadPictureBox.BackColor = System.Drawing.Color.Transparent;
            this.LoadPictureBox.Cursor = System.Windows.Forms.Cursors.Hand;
            this.LoadPictureBox.Image = ((System.Drawing.Image)(resources.GetObject("LoadPictureBox.Image")));
            this.LoadPictureBox.Location = new System.Drawing.Point(0, 216);
            this.LoadPictureBox.Margin = new System.Windows.Forms.Padding(0, 3, 0, 3);
            this.LoadPictureBox.Name = "LoadPictureBox";
            this.LoadPictureBox.Size = new System.Drawing.Size(32, 32);
            this.LoadPictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.LoadPictureBox.TabIndex = 4;
            this.LoadPictureBox.TabStop = false;
            this.LoadPictureBox.Click += new System.EventHandler(this.LoadData);
            // 
            // SavePictureBox
            // 
            this.SavePictureBox.BackColor = System.Drawing.Color.Transparent;
            this.SavePictureBox.Cursor = System.Windows.Forms.Cursors.Hand;
            this.SavePictureBox.Image = ((System.Drawing.Image)(resources.GetObject("SavePictureBox.Image")));
            this.SavePictureBox.Location = new System.Drawing.Point(0, 254);
            this.SavePictureBox.Margin = new System.Windows.Forms.Padding(0, 3, 0, 3);
            this.SavePictureBox.Name = "SavePictureBox";
            this.SavePictureBox.Size = new System.Drawing.Size(32, 32);
            this.SavePictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.SavePictureBox.TabIndex = 4;
            this.SavePictureBox.TabStop = false;
            this.SavePictureBox.Click += new System.EventHandler(this.SaveData);
            // 
            // AddRowBtn
            // 
            this.AddRowBtn.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("AddRowBtn.BackgroundImage")));
            this.AddRowBtn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.AddRowBtn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.AddRowBtn.Location = new System.Drawing.Point(0, 0);
            this.AddRowBtn.Margin = new System.Windows.Forms.Padding(0, 0, 0, 3);
            this.AddRowBtn.Name = "AddRowBtn";
            this.AddRowBtn.Size = new System.Drawing.Size(32, 32);
            this.AddRowBtn.TabIndex = 0;
            this.AddRowBtn.UseVisualStyleBackColor = true;
            this.AddRowBtn.Click += new System.EventHandler(this.AddRow);
            // 
            // DeleteBtn
            // 
            this.DeleteBtn.BackgroundImage = global::GeodeticCoordinateConversion.Properties.Resources.Multiply;
            this.DeleteBtn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.DeleteBtn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.DeleteBtn.Location = new System.Drawing.Point(0, 35);
            this.DeleteBtn.Margin = new System.Windows.Forms.Padding(0, 0, 0, 3);
            this.DeleteBtn.Name = "DeleteBtn";
            this.DeleteBtn.Size = new System.Drawing.Size(32, 32);
            this.DeleteBtn.TabIndex = 1;
            this.DeleteBtn.UseVisualStyleBackColor = true;
            this.DeleteBtn.Click += new System.EventHandler(this.DeleteRow);
            // 
            // LoadBtn
            // 
            this.LoadBtn.BackgroundImage = global::GeodeticCoordinateConversion.Properties.Resources.Load;
            this.LoadBtn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.LoadBtn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.LoadBtn.Location = new System.Drawing.Point(0, 70);
            this.LoadBtn.Margin = new System.Windows.Forms.Padding(0, 0, 0, 3);
            this.LoadBtn.Name = "LoadBtn";
            this.LoadBtn.Size = new System.Drawing.Size(32, 32);
            this.LoadBtn.TabIndex = 2;
            this.LoadBtn.UseVisualStyleBackColor = true;
            this.LoadBtn.Click += new System.EventHandler(this.LoadData);
            // 
            // SaveBtn
            // 
            this.SaveBtn.BackgroundImage = global::GeodeticCoordinateConversion.Properties.Resources.Floppydisk;
            this.SaveBtn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.SaveBtn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.SaveBtn.Location = new System.Drawing.Point(0, 105);
            this.SaveBtn.Margin = new System.Windows.Forms.Padding(0, 0, 0, 3);
            this.SaveBtn.Name = "SaveBtn";
            this.SaveBtn.Size = new System.Drawing.Size(32, 32);
            this.SaveBtn.TabIndex = 3;
            this.SaveBtn.UseVisualStyleBackColor = true;
            this.SaveBtn.Click += new System.EventHandler(this.SaveData);
            // 
            // SelectionFlowLayoutPanel
            // 
            this.SelectionFlowLayoutPanel.AutoSize = true;
            this.SelectionFlowLayoutPanel.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.SelectionFlowLayoutPanel.Controls.Add(this.SelectNoneBtn);
            this.SelectionFlowLayoutPanel.Controls.Add(this.SelectAllBtn);
            this.SelectionFlowLayoutPanel.Controls.Add(this.ReverseSelectBtn);
            this.SelectionFlowLayoutPanel.Location = new System.Drawing.Point(48, 5);
            this.SelectionFlowLayoutPanel.Margin = new System.Windows.Forms.Padding(0);
            this.SelectionFlowLayoutPanel.Name = "SelectionFlowLayoutPanel";
            this.SelectionFlowLayoutPanel.Size = new System.Drawing.Size(191, 23);
            this.SelectionFlowLayoutPanel.TabIndex = 10;
            // 
            // gEODataTablesBindingSource
            // 
            this.gEODataTablesBindingSource.DataSource = typeof(GeodeticCoordinateConversion.GEODataTables);
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.AutoSize = true;
            this.flowLayoutPanel1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.flowLayoutPanel1.Controls.Add(this.DirectBtn);
            this.flowLayoutPanel1.Controls.Add(this.ReverseBtn);
            this.flowLayoutPanel1.Location = new System.Drawing.Point(378, 5);
            this.flowLayoutPanel1.Margin = new System.Windows.Forms.Padding(0);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(170, 23);
            this.flowLayoutPanel1.TabIndex = 11;
            // 
            // CoordConvertLayout
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.flowLayoutPanel1);
            this.Controls.Add(this.SelectionFlowLayoutPanel);
            this.Controls.Add(this.DataFlowLayoutPanel);
            this.Controls.Add(this.TransferBtn);
            this.Controls.Add(this.CoordConvertDGV);
            this.Name = "CoordConvertLayout";
            this.Size = new System.Drawing.Size(878, 457);
            this.Load += new System.EventHandler(this.CoordConvertLayout_Load);
            ((System.ComponentModel.ISupportInitialize)(this.CoordConvertDGV)).EndInit();
            this.DataFlowLayoutPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.AddRowPictureBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DeletePictureBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.LoadPictureBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SavePictureBox)).EndInit();
            this.SelectionFlowLayoutPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gEODataTablesBindingSource)).EndInit();
            this.flowLayoutPanel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.PictureBox AddRowPictureBox;
        private System.Windows.Forms.PictureBox LoadPictureBox;
        private System.Windows.Forms.PictureBox SavePictureBox;
        private System.Windows.Forms.BindingSource gEODataTablesBindingSource;
        private System.Windows.Forms.PictureBox DeletePictureBox;
        private System.Windows.Forms.FlowLayoutPanel DataFlowLayoutPanel;
        private System.Windows.Forms.FlowLayoutPanel SelectionFlowLayoutPanel;
        internal System.Windows.Forms.DataGridView CoordConvertDGV;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        internal System.Windows.Forms.Button DirectBtn;
        internal System.Windows.Forms.Button ReverseBtn;
        internal System.Windows.Forms.Button TransferBtn;
        internal System.Windows.Forms.Button SelectAllBtn;
        internal System.Windows.Forms.Button SelectNoneBtn;
        internal System.Windows.Forms.Button ReverseSelectBtn;
        internal System.Windows.Forms.Button AddRowBtn;
        internal System.Windows.Forms.Button DeleteBtn;
        internal System.Windows.Forms.Button LoadBtn;
        internal System.Windows.Forms.Button SaveBtn;
    }
}

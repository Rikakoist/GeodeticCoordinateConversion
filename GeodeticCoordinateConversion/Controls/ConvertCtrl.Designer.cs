namespace GeodeticCoordinateConversion
{
    partial class ConvertCtrl
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
            this.DGV = new System.Windows.Forms.DataGridView();
            this.DirectBtn = new System.Windows.Forms.Button();
            this.ReverseBtn = new System.Windows.Forms.Button();
            this.TransferBtn = new System.Windows.Forms.Button();
            this.SelectAllBtn = new System.Windows.Forms.Button();
            this.SelectNoneBtn = new System.Windows.Forms.Button();
            this.InvertSelectBtn = new System.Windows.Forms.Button();
            this.DataFlowLayoutPanel = new System.Windows.Forms.FlowLayoutPanel();
            this.AddRowBtn = new System.Windows.Forms.Button();
            this.DeleteBtn = new System.Windows.Forms.Button();
            this.LoadFileBtn = new System.Windows.Forms.Button();
            this.SaveFileBtn = new System.Windows.Forms.Button();
            this.LoadDBBtn = new System.Windows.Forms.Button();
            this.SaveDBBtn = new System.Windows.Forms.Button();
            this.SelectionFlowLayoutPanel = new System.Windows.Forms.FlowLayoutPanel();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.BtnToolTip = new System.Windows.Forms.ToolTip(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.DGV)).BeginInit();
            this.DataFlowLayoutPanel.SuspendLayout();
            this.SelectionFlowLayoutPanel.SuspendLayout();
            this.flowLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // DGV
            // 
            this.DGV.AllowUserToAddRows = false;
            this.DGV.AllowUserToDeleteRows = false;
            this.DGV.AllowUserToOrderColumns = true;
            this.DGV.AllowUserToResizeRows = false;
            this.DGV.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.DGV.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.DGV.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DGV.Location = new System.Drawing.Point(48, 34);
            this.DGV.Name = "DGV";
            this.DGV.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.DGV.Size = new System.Drawing.Size(827, 420);
            this.DGV.TabIndex = 0;
            this.DGV.DataSourceChanged += new System.EventHandler(this.DGV_DataSourceChanged);
            this.DGV.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.DGV_CellEndEdit);
            this.DGV.DataError += new System.Windows.Forms.DataGridViewDataErrorEventHandler(this.DGV_DataError);
            this.DGV.RowsAdded += new System.Windows.Forms.DataGridViewRowsAddedEventHandler(this.DGV_RowsAdded);
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
            // 
            // TransferBtn
            // 
            this.TransferBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.TransferBtn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.TransferBtn.Location = new System.Drawing.Point(800, 5);
            this.TransferBtn.Name = "TransferBtn";
            this.TransferBtn.Size = new System.Drawing.Size(75, 23);
            this.TransferBtn.TabIndex = 4;
            this.TransferBtn.Text = ">>";
            this.TransferBtn.UseVisualStyleBackColor = true;
            // 
            // SelectAllBtn
            // 
            this.SelectAllBtn.AutoSize = true;
            this.SelectAllBtn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.SelectAllBtn.Location = new System.Drawing.Point(67, 0);
            this.SelectAllBtn.Margin = new System.Windows.Forms.Padding(0, 0, 10, 0);
            this.SelectAllBtn.Name = "SelectAllBtn";
            this.SelectAllBtn.Size = new System.Drawing.Size(57, 23);
            this.SelectAllBtn.TabIndex = 1;
            this.SelectAllBtn.Tag = "SelectAll";
            this.SelectAllBtn.Text = "全选";
            this.SelectAllBtn.UseVisualStyleBackColor = true;
            this.SelectAllBtn.Click += new System.EventHandler(this.ChangeSelection);
            // 
            // SelectNoneBtn
            // 
            this.SelectNoneBtn.AutoSize = true;
            this.SelectNoneBtn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.SelectNoneBtn.Location = new System.Drawing.Point(0, 0);
            this.SelectNoneBtn.Margin = new System.Windows.Forms.Padding(0, 0, 10, 0);
            this.SelectNoneBtn.Name = "SelectNoneBtn";
            this.SelectNoneBtn.Size = new System.Drawing.Size(57, 23);
            this.SelectNoneBtn.TabIndex = 0;
            this.SelectNoneBtn.Tag = "SelectNone";
            this.SelectNoneBtn.Text = "全不选";
            this.SelectNoneBtn.UseVisualStyleBackColor = true;
            this.SelectNoneBtn.Click += new System.EventHandler(this.ChangeSelection);
            // 
            // InvertSelectBtn
            // 
            this.InvertSelectBtn.AutoSize = true;
            this.InvertSelectBtn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.InvertSelectBtn.Location = new System.Drawing.Point(134, 0);
            this.InvertSelectBtn.Margin = new System.Windows.Forms.Padding(0);
            this.InvertSelectBtn.Name = "InvertSelectBtn";
            this.InvertSelectBtn.Size = new System.Drawing.Size(57, 23);
            this.InvertSelectBtn.TabIndex = 2;
            this.InvertSelectBtn.Tag = "ReverseSelect";
            this.InvertSelectBtn.Text = "反选";
            this.InvertSelectBtn.UseVisualStyleBackColor = true;
            this.InvertSelectBtn.Click += new System.EventHandler(this.ChangeSelection);
            // 
            // DataFlowLayoutPanel
            // 
            this.DataFlowLayoutPanel.AutoSize = true;
            this.DataFlowLayoutPanel.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.DataFlowLayoutPanel.Controls.Add(this.AddRowBtn);
            this.DataFlowLayoutPanel.Controls.Add(this.DeleteBtn);
            this.DataFlowLayoutPanel.Controls.Add(this.LoadFileBtn);
            this.DataFlowLayoutPanel.Controls.Add(this.SaveFileBtn);
            this.DataFlowLayoutPanel.Controls.Add(this.LoadDBBtn);
            this.DataFlowLayoutPanel.Controls.Add(this.SaveDBBtn);
            this.DataFlowLayoutPanel.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.DataFlowLayoutPanel.Location = new System.Drawing.Point(8, 34);
            this.DataFlowLayoutPanel.Margin = new System.Windows.Forms.Padding(0);
            this.DataFlowLayoutPanel.Name = "DataFlowLayoutPanel";
            this.DataFlowLayoutPanel.Size = new System.Drawing.Size(32, 210);
            this.DataFlowLayoutPanel.TabIndex = 1;
            // 
            // AddRowBtn
            // 
            this.AddRowBtn.BackgroundImage = global::GeodeticCoordinateConversion.Properties.Resources.Plus;
            this.AddRowBtn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.AddRowBtn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.AddRowBtn.Location = new System.Drawing.Point(0, 0);
            this.AddRowBtn.Margin = new System.Windows.Forms.Padding(0, 0, 0, 3);
            this.AddRowBtn.Name = "AddRowBtn";
            this.AddRowBtn.Size = new System.Drawing.Size(32, 32);
            this.AddRowBtn.TabIndex = 0;
            this.AddRowBtn.UseVisualStyleBackColor = true;
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
            // LoadFileBtn
            // 
            this.LoadFileBtn.BackgroundImage = global::GeodeticCoordinateConversion.Properties.Resources.LoadFromFile;
            this.LoadFileBtn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.LoadFileBtn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.LoadFileBtn.Location = new System.Drawing.Point(0, 70);
            this.LoadFileBtn.Margin = new System.Windows.Forms.Padding(0, 0, 0, 3);
            this.LoadFileBtn.Name = "LoadFileBtn";
            this.LoadFileBtn.Size = new System.Drawing.Size(32, 32);
            this.LoadFileBtn.TabIndex = 2;
            this.LoadFileBtn.UseVisualStyleBackColor = true;
            // 
            // SaveFileBtn
            // 
            this.SaveFileBtn.BackgroundImage = global::GeodeticCoordinateConversion.Properties.Resources.SaveToFile;
            this.SaveFileBtn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.SaveFileBtn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.SaveFileBtn.Location = new System.Drawing.Point(0, 105);
            this.SaveFileBtn.Margin = new System.Windows.Forms.Padding(0, 0, 0, 3);
            this.SaveFileBtn.Name = "SaveFileBtn";
            this.SaveFileBtn.Size = new System.Drawing.Size(32, 32);
            this.SaveFileBtn.TabIndex = 3;
            this.SaveFileBtn.UseVisualStyleBackColor = true;
            // 
            // LoadDBBtn
            // 
            this.LoadDBBtn.BackgroundImage = global::GeodeticCoordinateConversion.Properties.Resources.LoadFromDB;
            this.LoadDBBtn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.LoadDBBtn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.LoadDBBtn.Location = new System.Drawing.Point(0, 140);
            this.LoadDBBtn.Margin = new System.Windows.Forms.Padding(0, 0, 0, 3);
            this.LoadDBBtn.Name = "LoadDBBtn";
            this.LoadDBBtn.Size = new System.Drawing.Size(32, 32);
            this.LoadDBBtn.TabIndex = 4;
            this.LoadDBBtn.UseVisualStyleBackColor = true;
            // 
            // SaveDBBtn
            // 
            this.SaveDBBtn.BackgroundImage = global::GeodeticCoordinateConversion.Properties.Resources.SaveToDB;
            this.SaveDBBtn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.SaveDBBtn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.SaveDBBtn.Location = new System.Drawing.Point(0, 175);
            this.SaveDBBtn.Margin = new System.Windows.Forms.Padding(0, 0, 0, 3);
            this.SaveDBBtn.Name = "SaveDBBtn";
            this.SaveDBBtn.Size = new System.Drawing.Size(32, 32);
            this.SaveDBBtn.TabIndex = 5;
            this.SaveDBBtn.UseVisualStyleBackColor = true;
            // 
            // SelectionFlowLayoutPanel
            // 
            this.SelectionFlowLayoutPanel.AutoSize = true;
            this.SelectionFlowLayoutPanel.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.SelectionFlowLayoutPanel.Controls.Add(this.SelectNoneBtn);
            this.SelectionFlowLayoutPanel.Controls.Add(this.SelectAllBtn);
            this.SelectionFlowLayoutPanel.Controls.Add(this.InvertSelectBtn);
            this.SelectionFlowLayoutPanel.Location = new System.Drawing.Point(48, 5);
            this.SelectionFlowLayoutPanel.Margin = new System.Windows.Forms.Padding(0);
            this.SelectionFlowLayoutPanel.Name = "SelectionFlowLayoutPanel";
            this.SelectionFlowLayoutPanel.Size = new System.Drawing.Size(191, 23);
            this.SelectionFlowLayoutPanel.TabIndex = 2;
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
            this.flowLayoutPanel1.TabIndex = 3;
            // 
            // CoordConvertLayout
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.flowLayoutPanel1);
            this.Controls.Add(this.SelectionFlowLayoutPanel);
            this.Controls.Add(this.DataFlowLayoutPanel);
            this.Controls.Add(this.TransferBtn);
            this.Controls.Add(this.DGV);
            this.Margin = new System.Windows.Forms.Padding(0);
            this.Name = "CoordConvertLayout";
            this.Size = new System.Drawing.Size(878, 457);
            this.Load += new System.EventHandler(this.CoordConvertLayout_Load);
            ((System.ComponentModel.ISupportInitialize)(this.DGV)).EndInit();
            this.DataFlowLayoutPanel.ResumeLayout(false);
            this.SelectionFlowLayoutPanel.ResumeLayout(false);
            this.SelectionFlowLayoutPanel.PerformLayout();
            this.flowLayoutPanel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.FlowLayoutPanel DataFlowLayoutPanel;
        private System.Windows.Forms.FlowLayoutPanel SelectionFlowLayoutPanel;
        internal System.Windows.Forms.DataGridView DGV;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        internal System.Windows.Forms.Button DirectBtn;
        internal System.Windows.Forms.Button ReverseBtn;
        internal System.Windows.Forms.Button TransferBtn;
        internal System.Windows.Forms.Button SelectAllBtn;
        internal System.Windows.Forms.Button SelectNoneBtn;
        internal System.Windows.Forms.Button InvertSelectBtn;
        internal System.Windows.Forms.Button AddRowBtn;
        internal System.Windows.Forms.Button DeleteBtn;
        internal System.Windows.Forms.Button LoadFileBtn;
        internal System.Windows.Forms.Button SaveFileBtn;
        private System.Windows.Forms.ToolTip BtnToolTip;
        internal System.Windows.Forms.Button SaveDBBtn;
        internal System.Windows.Forms.Button LoadDBBtn;
    }
}

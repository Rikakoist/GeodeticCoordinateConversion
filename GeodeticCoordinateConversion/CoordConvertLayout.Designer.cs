namespace GeodeticCoordinateConversion
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
            this.AddRowPictureBox = new System.Windows.Forms.PictureBox();
            this.LoadPictureBox = new System.Windows.Forms.PictureBox();
            this.SavePictureBox = new System.Windows.Forms.PictureBox();
            this.DeletePictureBox = new System.Windows.Forms.PictureBox();
            this.DirectBtn = new System.Windows.Forms.Button();
            this.ReverseBtn = new System.Windows.Forms.Button();
            this.B = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.L = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Ellipse = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.X = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Y = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ZoneType = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.Zone = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gEODataTablesBindingSource = new System.Windows.Forms.BindingSource(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.CoordConvertDGV)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.AddRowPictureBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.LoadPictureBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SavePictureBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DeletePictureBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gEODataTablesBindingSource)).BeginInit();
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
            this.CoordConvertDGV.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.B,
            this.L,
            this.Ellipse,
            this.X,
            this.Y,
            this.ZoneType,
            this.Zone});
            this.CoordConvertDGV.Location = new System.Drawing.Point(48, 3);
            this.CoordConvertDGV.Name = "CoordConvertDGV";
            this.CoordConvertDGV.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.CoordConvertDGV.Size = new System.Drawing.Size(807, 346);
            this.CoordConvertDGV.TabIndex = 0;
            this.CoordConvertDGV.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.CoordConvertDGV_CellEndEdit);
            // 
            // AddRowPictureBox
            // 
            this.AddRowPictureBox.BackColor = System.Drawing.Color.DeepSkyBlue;
            this.AddRowPictureBox.Cursor = System.Windows.Forms.Cursors.Hand;
            this.AddRowPictureBox.Image = ((System.Drawing.Image)(resources.GetObject("AddRowPictureBox.Image")));
            this.AddRowPictureBox.Location = new System.Drawing.Point(8, 7);
            this.AddRowPictureBox.Margin = new System.Windows.Forms.Padding(0);
            this.AddRowPictureBox.Name = "AddRowPictureBox";
            this.AddRowPictureBox.Size = new System.Drawing.Size(32, 32);
            this.AddRowPictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.AddRowPictureBox.TabIndex = 4;
            this.AddRowPictureBox.TabStop = false;
            this.AddRowPictureBox.Click += new System.EventHandler(this.AddRow);
            // 
            // LoadPictureBox
            // 
            this.LoadPictureBox.BackColor = System.Drawing.Color.Transparent;
            this.LoadPictureBox.Cursor = System.Windows.Forms.Cursors.Hand;
            this.LoadPictureBox.Image = ((System.Drawing.Image)(resources.GetObject("LoadPictureBox.Image")));
            this.LoadPictureBox.Location = new System.Drawing.Point(8, 136);
            this.LoadPictureBox.Margin = new System.Windows.Forms.Padding(0);
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
            this.SavePictureBox.Location = new System.Drawing.Point(8, 93);
            this.SavePictureBox.Margin = new System.Windows.Forms.Padding(0);
            this.SavePictureBox.Name = "SavePictureBox";
            this.SavePictureBox.Size = new System.Drawing.Size(32, 32);
            this.SavePictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.SavePictureBox.TabIndex = 4;
            this.SavePictureBox.TabStop = false;
            this.SavePictureBox.Click += new System.EventHandler(this.SaveData);
            // 
            // DeletePictureBox
            // 
            this.DeletePictureBox.BackColor = System.Drawing.Color.Transparent;
            this.DeletePictureBox.Cursor = System.Windows.Forms.Cursors.Hand;
            this.DeletePictureBox.Image = ((System.Drawing.Image)(resources.GetObject("DeletePictureBox.Image")));
            this.DeletePictureBox.Location = new System.Drawing.Point(8, 50);
            this.DeletePictureBox.Margin = new System.Windows.Forms.Padding(0);
            this.DeletePictureBox.Name = "DeletePictureBox";
            this.DeletePictureBox.Size = new System.Drawing.Size(32, 32);
            this.DeletePictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.DeletePictureBox.TabIndex = 4;
            this.DeletePictureBox.TabStop = false;
            this.DeletePictureBox.Click += new System.EventHandler(this.DeleteRow);
            // 
            // DirectBtn
            // 
            this.DirectBtn.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.DirectBtn.Location = new System.Drawing.Point(247, 368);
            this.DirectBtn.Name = "DirectBtn";
            this.DirectBtn.Size = new System.Drawing.Size(75, 23);
            this.DirectBtn.TabIndex = 5;
            this.DirectBtn.Text = ">>";
            this.DirectBtn.UseVisualStyleBackColor = true;
            this.DirectBtn.Click += new System.EventHandler(this.DirectBtn_Click);
            // 
            // ReverseBtn
            // 
            this.ReverseBtn.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.ReverseBtn.Location = new System.Drawing.Point(359, 368);
            this.ReverseBtn.Name = "ReverseBtn";
            this.ReverseBtn.Size = new System.Drawing.Size(75, 23);
            this.ReverseBtn.TabIndex = 5;
            this.ReverseBtn.Text = "<<";
            this.ReverseBtn.UseVisualStyleBackColor = true;
            this.ReverseBtn.Click += new System.EventHandler(this.ReverseBtn_Click);
            // 
            // B
            // 
            this.B.HeaderText = "B";
            this.B.Name = "B";
            // 
            // L
            // 
            this.L.HeaderText = "L";
            this.L.Name = "L";
            // 
            // Ellipse
            // 
            this.Ellipse.HeaderText = "Ellipse";
            this.Ellipse.Name = "Ellipse";
            this.Ellipse.ReadOnly = true;
            this.Ellipse.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.Ellipse.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // X
            // 
            this.X.HeaderText = "X";
            this.X.Name = "X";
            // 
            // Y
            // 
            this.Y.HeaderText = "Y";
            this.Y.Name = "Y";
            // 
            // ZoneType
            // 
            this.ZoneType.HeaderText = "ZoneType";
            this.ZoneType.Name = "ZoneType";
            this.ZoneType.ReadOnly = true;
            this.ZoneType.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.ZoneType.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // Zone
            // 
            this.Zone.HeaderText = "Zone";
            this.Zone.Name = "Zone";
            // 
            // gEODataTablesBindingSource
            // 
            this.gEODataTablesBindingSource.DataSource = typeof(GeodeticCoordinateConversion.GEODataTables);
            // 
            // CoordConvertLayout
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.ReverseBtn);
            this.Controls.Add(this.DirectBtn);
            this.Controls.Add(this.SavePictureBox);
            this.Controls.Add(this.LoadPictureBox);
            this.Controls.Add(this.DeletePictureBox);
            this.Controls.Add(this.AddRowPictureBox);
            this.Controls.Add(this.CoordConvertDGV);
            this.Name = "CoordConvertLayout";
            this.Size = new System.Drawing.Size(858, 414);
            this.Load += new System.EventHandler(this.CoordConvertLayout_Load);
            ((System.ComponentModel.ISupportInitialize)(this.CoordConvertDGV)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.AddRowPictureBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.LoadPictureBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SavePictureBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DeletePictureBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gEODataTablesBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView CoordConvertDGV;
        private System.Windows.Forms.PictureBox AddRowPictureBox;
        private System.Windows.Forms.PictureBox LoadPictureBox;
        private System.Windows.Forms.PictureBox SavePictureBox;
        private System.Windows.Forms.BindingSource gEODataTablesBindingSource;
        private System.Windows.Forms.PictureBox DeletePictureBox;
        private System.Windows.Forms.Button DirectBtn;
        private System.Windows.Forms.Button ReverseBtn;
        private System.Windows.Forms.DataGridViewTextBoxColumn B;
        private System.Windows.Forms.DataGridViewTextBoxColumn L;
        private System.Windows.Forms.DataGridViewComboBoxColumn Ellipse;
        private System.Windows.Forms.DataGridViewTextBoxColumn X;
        private System.Windows.Forms.DataGridViewTextBoxColumn Y;
        private System.Windows.Forms.DataGridViewComboBoxColumn ZoneType;
        private System.Windows.Forms.DataGridViewTextBoxColumn Zone;
    }
}

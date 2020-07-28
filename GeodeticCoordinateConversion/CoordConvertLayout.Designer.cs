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
            this.CoordConvertDataGridView = new System.Windows.Forms.DataGridView();
            this.AddRowPictureBox = new System.Windows.Forms.PictureBox();
            this.LoadPictureBox = new System.Windows.Forms.PictureBox();
            this.SavePictureBox = new System.Windows.Forms.PictureBox();
            this.gEODataTablesBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.B = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.L = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Ellipse = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.Delete = new System.Windows.Forms.DataGridViewButtonColumn();
            this.X = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Y = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Zone = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ZoneType = new System.Windows.Forms.DataGridViewComboBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.CoordConvertDataGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.AddRowPictureBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.LoadPictureBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SavePictureBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gEODataTablesBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // CoordConvertDataGridView
            // 
            this.CoordConvertDataGridView.AllowUserToAddRows = false;
            this.CoordConvertDataGridView.AllowUserToDeleteRows = false;
            this.CoordConvertDataGridView.AllowUserToResizeRows = false;
            this.CoordConvertDataGridView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.CoordConvertDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.CoordConvertDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.B,
            this.L,
            this.Ellipse,
            this.Delete,
            this.X,
            this.Y,
            this.Zone,
            this.ZoneType});
            this.CoordConvertDataGridView.Location = new System.Drawing.Point(48, 3);
            this.CoordConvertDataGridView.Name = "CoordConvertDataGridView";
            this.CoordConvertDataGridView.Size = new System.Drawing.Size(570, 321);
            this.CoordConvertDataGridView.TabIndex = 0;
            this.CoordConvertDataGridView.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DeleteRow);
            this.CoordConvertDataGridView.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.CoordConvertDataGridView_CellEndEdit);
            this.CoordConvertDataGridView.EditingControlShowing += new System.Windows.Forms.DataGridViewEditingControlShowingEventHandler(this.EditComboBox);
            this.CoordConvertDataGridView.RowsAdded += new System.Windows.Forms.DataGridViewRowsAddedEventHandler(this.CoordConvertDataGridView_RowsAdded);
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
            this.LoadPictureBox.Location = new System.Drawing.Point(8, 91);
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
            this.SavePictureBox.Location = new System.Drawing.Point(8, 49);
            this.SavePictureBox.Margin = new System.Windows.Forms.Padding(0);
            this.SavePictureBox.Name = "SavePictureBox";
            this.SavePictureBox.Size = new System.Drawing.Size(32, 32);
            this.SavePictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.SavePictureBox.TabIndex = 4;
            this.SavePictureBox.TabStop = false;
            this.SavePictureBox.Click += new System.EventHandler(this.SaveData);
            // 
            // gEODataTablesBindingSource
            // 
            this.gEODataTablesBindingSource.DataSource = typeof(GeodeticCoordinateConversion.GEODataTables);
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
            // Delete
            // 
            this.Delete.HeaderText = "Delete";
            this.Delete.MinimumWidth = 30;
            this.Delete.Name = "Delete";
            this.Delete.ReadOnly = true;
            this.Delete.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.Delete.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.Delete.Text = "Delete";
            this.Delete.UseColumnTextForButtonValue = true;
            this.Delete.Width = 60;
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
            // Zone
            // 
            this.Zone.HeaderText = "Zone";
            this.Zone.Name = "Zone";
            // 
            // ZoneType
            // 
            this.ZoneType.HeaderText = "ZoneType";
            this.ZoneType.Name = "ZoneType";
            this.ZoneType.ReadOnly = true;
            this.ZoneType.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.ZoneType.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // CoordConvertLayout
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.SavePictureBox);
            this.Controls.Add(this.LoadPictureBox);
            this.Controls.Add(this.AddRowPictureBox);
            this.Controls.Add(this.CoordConvertDataGridView);
            this.Name = "CoordConvertLayout";
            this.Size = new System.Drawing.Size(621, 369);
            this.Load += new System.EventHandler(this.CoordConvertLayout_Load);
            ((System.ComponentModel.ISupportInitialize)(this.CoordConvertDataGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.AddRowPictureBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.LoadPictureBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SavePictureBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gEODataTablesBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView CoordConvertDataGridView;
        private System.Windows.Forms.PictureBox AddRowPictureBox;
        private System.Windows.Forms.PictureBox LoadPictureBox;
        private System.Windows.Forms.PictureBox SavePictureBox;
        private System.Windows.Forms.BindingSource gEODataTablesBindingSource;
        private System.Windows.Forms.DataGridViewTextBoxColumn B;
        private System.Windows.Forms.DataGridViewTextBoxColumn L;
        private System.Windows.Forms.DataGridViewComboBoxColumn Ellipse;
        private System.Windows.Forms.DataGridViewButtonColumn Delete;
        private System.Windows.Forms.DataGridViewTextBoxColumn X;
        private System.Windows.Forms.DataGridViewTextBoxColumn Y;
        private System.Windows.Forms.DataGridViewTextBoxColumn Zone;
        private System.Windows.Forms.DataGridViewComboBoxColumn ZoneType;
    }
}

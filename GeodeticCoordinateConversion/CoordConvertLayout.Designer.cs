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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CoordConvertLayout));
            this.CoordConvertDataGridView = new System.Windows.Forms.DataGridView();
            this.B = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.L = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Ellipse = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.Delete = new System.Windows.Forms.DataGridViewButtonColumn();
            this.X = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Y = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Zone = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ZoneType = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.AddRowPictureBox = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.CoordConvertDataGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.AddRowPictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // CoordConvertDataGridView
            // 
            this.CoordConvertDataGridView.AllowUserToAddRows = false;
            this.CoordConvertDataGridView.AllowUserToDeleteRows = false;
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
            this.CoordConvertDataGridView.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.CoordConvertDataGridView_CellEndEdit);
            this.CoordConvertDataGridView.RowsAdded += new System.Windows.Forms.DataGridViewRowsAddedEventHandler(this.CoordConvertDataGridView_RowsAdded);
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
            this.Delete.Name = "Delete";
            this.Delete.ReadOnly = true;
            this.Delete.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.Delete.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
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
            // button2
            // 
            this.button2.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.button2.Location = new System.Drawing.Point(260, 343);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 2;
            this.button2.Text = "load";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button3
            // 
            this.button3.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.button3.Location = new System.Drawing.Point(380, 343);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(75, 23);
            this.button3.TabIndex = 3;
            this.button3.Text = "save";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
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
            // CoordConvertLayout
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.AddRowPictureBox);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.CoordConvertDataGridView);
            this.Name = "CoordConvertLayout";
            this.Size = new System.Drawing.Size(621, 369);
            this.Load += new System.EventHandler(this.CoordConvertLayout_Load);
            ((System.ComponentModel.ISupportInitialize)(this.CoordConvertDataGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.AddRowPictureBox)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView CoordConvertDataGridView;
        private System.Windows.Forms.DataGridViewTextBoxColumn B;
        private System.Windows.Forms.DataGridViewTextBoxColumn L;
        private System.Windows.Forms.DataGridViewComboBoxColumn Ellipse;
        private System.Windows.Forms.DataGridViewButtonColumn Delete;
        private System.Windows.Forms.DataGridViewTextBoxColumn X;
        private System.Windows.Forms.DataGridViewTextBoxColumn Y;
        private System.Windows.Forms.DataGridViewTextBoxColumn Zone;
        private System.Windows.Forms.DataGridViewComboBoxColumn ZoneType;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.PictureBox AddRowPictureBox;
    }
}

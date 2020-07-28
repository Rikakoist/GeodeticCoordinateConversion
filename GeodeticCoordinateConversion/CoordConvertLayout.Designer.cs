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
            this.CoordConvertDataGridView = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.CoordConvertDataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // CoordConvertDataGridView
            // 
            this.CoordConvertDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.CoordConvertDataGridView.Location = new System.Drawing.Point(3, 3);
            this.CoordConvertDataGridView.Name = "CoordConvertDataGridView";
            this.CoordConvertDataGridView.Size = new System.Drawing.Size(480, 283);
            this.CoordConvertDataGridView.TabIndex = 0;
            this.CoordConvertDataGridView.RowsAdded += new System.Windows.Forms.DataGridViewRowsAddedEventHandler(this.CoordConvertDataGridView_RowsAdded);
            // 
            // CoordConvertLayout
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.CoordConvertDataGridView);
            this.Name = "CoordConvertLayout";
            this.Size = new System.Drawing.Size(486, 289);
            ((System.ComponentModel.ISupportInitialize)(this.CoordConvertDataGridView)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView CoordConvertDataGridView;
    }
}

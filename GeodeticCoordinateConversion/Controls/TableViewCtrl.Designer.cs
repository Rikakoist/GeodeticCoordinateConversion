namespace GeodeticCoordinateConversion
{
    partial class TableViewCtrl
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TableViewCtrl));
            this.DataFlowLayoutPanel = new System.Windows.Forms.FlowLayoutPanel();
            this.AddRowBtn = new System.Windows.Forms.Button();
            this.DeleteBtn = new System.Windows.Forms.Button();
            this.DataTableFlowLayoutPanel = new System.Windows.Forms.FlowLayoutPanel();
            this.TableLabel = new System.Windows.Forms.Label();
            this.TableListComboBox = new System.Windows.Forms.ComboBox();
            this.ReloadTableBtn = new System.Windows.Forms.Button();
            this.DBDGV = new System.Windows.Forms.DataGridView();
            this.SaveFileBtn = new System.Windows.Forms.Button();
            this.DataFlowLayoutPanel.SuspendLayout();
            this.DataTableFlowLayoutPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DBDGV)).BeginInit();
            this.SuspendLayout();
            // 
            // DataFlowLayoutPanel
            // 
            this.DataFlowLayoutPanel.AutoSize = true;
            this.DataFlowLayoutPanel.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.DataFlowLayoutPanel.Controls.Add(this.AddRowBtn);
            this.DataFlowLayoutPanel.Controls.Add(this.DeleteBtn);
            this.DataFlowLayoutPanel.Controls.Add(this.SaveFileBtn);
            this.DataFlowLayoutPanel.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.DataFlowLayoutPanel.Location = new System.Drawing.Point(6, 45);
            this.DataFlowLayoutPanel.Margin = new System.Windows.Forms.Padding(0);
            this.DataFlowLayoutPanel.Name = "DataFlowLayoutPanel";
            this.DataFlowLayoutPanel.Size = new System.Drawing.Size(32, 105);
            this.DataFlowLayoutPanel.TabIndex = 5;
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
            this.DeleteBtn.Click += new System.EventHandler(this.DelRow);
            // 
            // DataTableFlowLayoutPanel
            // 
            this.DataTableFlowLayoutPanel.AutoSize = true;
            this.DataTableFlowLayoutPanel.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.DataTableFlowLayoutPanel.Controls.Add(this.TableLabel);
            this.DataTableFlowLayoutPanel.Controls.Add(this.TableListComboBox);
            this.DataTableFlowLayoutPanel.Controls.Add(this.ReloadTableBtn);
            this.DataTableFlowLayoutPanel.Location = new System.Drawing.Point(46, 8);
            this.DataTableFlowLayoutPanel.Margin = new System.Windows.Forms.Padding(0);
            this.DataTableFlowLayoutPanel.Name = "DataTableFlowLayoutPanel";
            this.DataTableFlowLayoutPanel.Size = new System.Drawing.Size(267, 27);
            this.DataTableFlowLayoutPanel.TabIndex = 4;
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
            // DBDGV
            // 
            this.DBDGV.AllowUserToAddRows = false;
            this.DBDGV.AllowUserToDeleteRows = false;
            this.DBDGV.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.DBDGV.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.DBDGV.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DBDGV.Location = new System.Drawing.Point(46, 45);
            this.DBDGV.Margin = new System.Windows.Forms.Padding(0);
            this.DBDGV.Name = "DBDGV";
            this.DBDGV.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.DBDGV.Size = new System.Drawing.Size(842, 444);
            this.DBDGV.TabIndex = 3;
            this.DBDGV.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.UpdateDB);
            // 
            // SaveFileBtn
            // 
            this.SaveFileBtn.BackgroundImage = global::GeodeticCoordinateConversion.Properties.Resources.Floppydisk;
            this.SaveFileBtn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.SaveFileBtn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.SaveFileBtn.Location = new System.Drawing.Point(0, 70);
            this.SaveFileBtn.Margin = new System.Windows.Forms.Padding(0, 0, 0, 3);
            this.SaveFileBtn.Name = "SaveFileBtn";
            this.SaveFileBtn.Size = new System.Drawing.Size(32, 32);
            this.SaveFileBtn.TabIndex = 6;
            this.SaveFileBtn.UseVisualStyleBackColor = true;
            this.SaveFileBtn.Click += new System.EventHandler(this.SaveChanges);
            // 
            // TableViewCtrl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.DataFlowLayoutPanel);
            this.Controls.Add(this.DataTableFlowLayoutPanel);
            this.Controls.Add(this.DBDGV);
            this.Margin = new System.Windows.Forms.Padding(0);
            this.Name = "TableViewCtrl";
            this.Size = new System.Drawing.Size(891, 492);
            this.Load += new System.EventHandler(this.DBLoad);
            this.DataFlowLayoutPanel.ResumeLayout(false);
            this.DataTableFlowLayoutPanel.ResumeLayout(false);
            this.DataTableFlowLayoutPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DBDGV)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.FlowLayoutPanel DataFlowLayoutPanel;
        internal System.Windows.Forms.Button AddRowBtn;
        internal System.Windows.Forms.Button DeleteBtn;
        private System.Windows.Forms.FlowLayoutPanel DataTableFlowLayoutPanel;
        private System.Windows.Forms.Label TableLabel;
        private System.Windows.Forms.ComboBox TableListComboBox;
        private System.Windows.Forms.Button ReloadTableBtn;
        private System.Windows.Forms.DataGridView DBDGV;
        internal System.Windows.Forms.Button SaveFileBtn;
    }
}

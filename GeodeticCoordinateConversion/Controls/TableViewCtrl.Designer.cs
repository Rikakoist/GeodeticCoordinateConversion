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
            this.components = new System.ComponentModel.Container();
            this.DataFlowLayoutPanel = new System.Windows.Forms.FlowLayoutPanel();
            this.SaveDBChangesBtn = new System.Windows.Forms.Button();
            this.AddRowBtn = new System.Windows.Forms.Button();
            this.DeleteBtn = new System.Windows.Forms.Button();
            this.DataTableFlowLayoutPanel = new System.Windows.Forms.FlowLayoutPanel();
            this.TableLabel = new System.Windows.Forms.Label();
            this.TableListComboBox = new System.Windows.Forms.ComboBox();
            this.ReloadTableBtn = new System.Windows.Forms.Button();
            this.DGV = new System.Windows.Forms.DataGridView();
            this.CtrlToolTip = new System.Windows.Forms.ToolTip(this.components);
            this.SaveDBToFileBtn = new System.Windows.Forms.Button();
            this.LoadDBFromFileBtn = new System.Windows.Forms.Button();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.DataFlowLayoutPanel.SuspendLayout();
            this.DataTableFlowLayoutPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DGV)).BeginInit();
            this.flowLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // DataFlowLayoutPanel
            // 
            this.DataFlowLayoutPanel.AutoSize = true;
            this.DataFlowLayoutPanel.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.DataFlowLayoutPanel.Controls.Add(this.SaveDBChangesBtn);
            this.DataFlowLayoutPanel.Controls.Add(this.AddRowBtn);
            this.DataFlowLayoutPanel.Controls.Add(this.DeleteBtn);
            this.DataFlowLayoutPanel.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.DataFlowLayoutPanel.Location = new System.Drawing.Point(6, 45);
            this.DataFlowLayoutPanel.Margin = new System.Windows.Forms.Padding(0);
            this.DataFlowLayoutPanel.Name = "DataFlowLayoutPanel";
            this.DataFlowLayoutPanel.Size = new System.Drawing.Size(32, 105);
            this.DataFlowLayoutPanel.TabIndex = 1;
            // 
            // SaveDBChangesBtn
            // 
            this.SaveDBChangesBtn.BackgroundImage = global::GeodeticCoordinateConversion.Properties.Resources.Floppydisk;
            this.SaveDBChangesBtn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.SaveDBChangesBtn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.SaveDBChangesBtn.Location = new System.Drawing.Point(0, 0);
            this.SaveDBChangesBtn.Margin = new System.Windows.Forms.Padding(0, 0, 0, 3);
            this.SaveDBChangesBtn.Name = "SaveDBChangesBtn";
            this.SaveDBChangesBtn.Size = new System.Drawing.Size(32, 32);
            this.SaveDBChangesBtn.TabIndex = 0;
            this.SaveDBChangesBtn.UseVisualStyleBackColor = true;
            this.SaveDBChangesBtn.Click += new System.EventHandler(this.SaveChanges);
            // 
            // AddRowBtn
            // 
            this.AddRowBtn.BackgroundImage = global::GeodeticCoordinateConversion.Properties.Resources.Plus;
            this.AddRowBtn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.AddRowBtn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.AddRowBtn.Location = new System.Drawing.Point(0, 35);
            this.AddRowBtn.Margin = new System.Windows.Forms.Padding(0, 0, 0, 3);
            this.AddRowBtn.Name = "AddRowBtn";
            this.AddRowBtn.Size = new System.Drawing.Size(32, 32);
            this.AddRowBtn.TabIndex = 1;
            this.AddRowBtn.UseVisualStyleBackColor = true;
            this.AddRowBtn.Click += new System.EventHandler(this.AddRow);
            // 
            // DeleteBtn
            // 
            this.DeleteBtn.BackgroundImage = global::GeodeticCoordinateConversion.Properties.Resources.Multiply;
            this.DeleteBtn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.DeleteBtn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.DeleteBtn.Location = new System.Drawing.Point(0, 70);
            this.DeleteBtn.Margin = new System.Windows.Forms.Padding(0, 0, 0, 3);
            this.DeleteBtn.Name = "DeleteBtn";
            this.DeleteBtn.Size = new System.Drawing.Size(32, 32);
            this.DeleteBtn.TabIndex = 2;
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
            this.DataTableFlowLayoutPanel.Location = new System.Drawing.Point(46, 9);
            this.DataTableFlowLayoutPanel.Margin = new System.Windows.Forms.Padding(0);
            this.DataTableFlowLayoutPanel.Name = "DataTableFlowLayoutPanel";
            this.DataTableFlowLayoutPanel.Size = new System.Drawing.Size(267, 27);
            this.DataTableFlowLayoutPanel.TabIndex = 2;
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
            // DGV
            // 
            this.DGV.AllowUserToAddRows = false;
            this.DGV.AllowUserToDeleteRows = false;
            this.DGV.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.DGV.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.DGV.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DGV.Location = new System.Drawing.Point(46, 45);
            this.DGV.Margin = new System.Windows.Forms.Padding(0);
            this.DGV.Name = "DGV";
            this.DGV.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.DGV.Size = new System.Drawing.Size(842, 444);
            this.DGV.TabIndex = 0;
            // 
            // SaveDBToFileBtn
            // 
            this.SaveDBToFileBtn.BackgroundImage = global::GeodeticCoordinateConversion.Properties.Resources.SaveToFile;
            this.SaveDBToFileBtn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.SaveDBToFileBtn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.SaveDBToFileBtn.Location = new System.Drawing.Point(0, 0);
            this.SaveDBToFileBtn.Margin = new System.Windows.Forms.Padding(0, 0, 15, 0);
            this.SaveDBToFileBtn.Name = "SaveDBToFileBtn";
            this.SaveDBToFileBtn.Size = new System.Drawing.Size(32, 32);
            this.SaveDBToFileBtn.TabIndex = 0;
            this.SaveDBToFileBtn.UseVisualStyleBackColor = true;
            this.SaveDBToFileBtn.Click += new System.EventHandler(this.SaveDBToFile);
            // 
            // LoadDBFromFileBtn
            // 
            this.LoadDBFromFileBtn.BackgroundImage = global::GeodeticCoordinateConversion.Properties.Resources.LoadFromFile;
            this.LoadDBFromFileBtn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.LoadDBFromFileBtn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.LoadDBFromFileBtn.Location = new System.Drawing.Point(47, 0);
            this.LoadDBFromFileBtn.Margin = new System.Windows.Forms.Padding(0, 0, 15, 0);
            this.LoadDBFromFileBtn.Name = "LoadDBFromFileBtn";
            this.LoadDBFromFileBtn.Size = new System.Drawing.Size(32, 32);
            this.LoadDBFromFileBtn.TabIndex = 1;
            this.LoadDBFromFileBtn.UseVisualStyleBackColor = true;
            this.LoadDBFromFileBtn.Click += new System.EventHandler(this.LoadDBFromFile);
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.AutoSize = true;
            this.flowLayoutPanel1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.flowLayoutPanel1.Controls.Add(this.SaveDBToFileBtn);
            this.flowLayoutPanel1.Controls.Add(this.LoadDBFromFileBtn);
            this.flowLayoutPanel1.Location = new System.Drawing.Point(364, 6);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(94, 32);
            this.flowLayoutPanel1.TabIndex = 3;
            // 
            // TableViewCtrl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.Controls.Add(this.flowLayoutPanel1);
            this.Controls.Add(this.DataFlowLayoutPanel);
            this.Controls.Add(this.DataTableFlowLayoutPanel);
            this.Controls.Add(this.DGV);
            this.Margin = new System.Windows.Forms.Padding(0);
            this.Name = "TableViewCtrl";
            this.Size = new System.Drawing.Size(891, 492);
            this.Load += new System.EventHandler(this.DBLoad);
            this.DataFlowLayoutPanel.ResumeLayout(false);
            this.DataTableFlowLayoutPanel.ResumeLayout(false);
            this.DataTableFlowLayoutPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DGV)).EndInit();
            this.flowLayoutPanel1.ResumeLayout(false);
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
        private System.Windows.Forms.DataGridView DGV;
        internal System.Windows.Forms.Button SaveDBChangesBtn;
        private System.Windows.Forms.ToolTip CtrlToolTip;
        internal System.Windows.Forms.Button SaveDBToFileBtn;
        internal System.Windows.Forms.Button LoadDBFromFileBtn;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
    }
}

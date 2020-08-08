using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GeodeticCoordinateConversion
{
    public partial class SettingsForm : Form
    {
        Properties.Settings S = new Properties.Settings();

        public SettingsForm()
        {
            InitializeComponent();
            //通用
            WorkFolderTextBox.DataBindings.Add(nameof(TextBox.Text), S, nameof(S.WorkFolder));
            DataFileNameTextBox.DataBindings.Add(nameof(TextBox.Text), S, nameof(S.DataFileName));
            DBNameTextBox.DataBindings.Add(nameof(TextBox.Text), S, nameof(S.DBName));

            DefaultEllipseTypeComboBox.DataSource = GEODataTables.GetEllipseType();
            DefaultEllipseTypeComboBox.DisplayMember = nameof(GEOEllipseType);
            DefaultEllipseTypeComboBox.ValueMember = "Value";
            DefaultEllipseTypeComboBox.DataBindings.Add(nameof(ComboBox.SelectedValue), S, nameof(S.DefaultEllipseType));

            DefaultZoneTypeComboBox.DataSource = GEODataTables.GetZoneType();
            DefaultZoneTypeComboBox.DisplayMember = nameof(GEOZoneType);
            DefaultZoneTypeComboBox.ValueMember = "Value";
            DefaultZoneTypeComboBox.DataBindings.Add(nameof(ComboBox.SelectedValue), S, nameof(S.DefaultZoneType));

            SwitchAfterGaussTransferCheckBox.DataBindings.Add(nameof(CheckBox.Checked), S, nameof(S.SwitchAfterGaussTransfer));

            //数据 
            ClearExistingRecordData2FileCheckBox.DataBindings.Add(nameof(CheckBox.Checked), S, nameof(S.ClearExistingRecordData2File));
            ClearExistingRecordData2DBCheckBox.DataBindings.Add(nameof(CheckBox.Checked), S, nameof(S.ClearExistingRecordData2DB));
            ClearExistingRecordDB2FileCheckBox.DataBindings.Add(nameof(CheckBox.Checked), S, nameof(S.ClearExistingRecordDB2File));
            ClearExistingRecordFile2DBCheckBox.DataBindings.Add(nameof(CheckBox.Checked), S, nameof(S.ClearExistingRecordFile2DB));

            //外观
            DefaultCellColorBtn.DataBindings.Add(nameof(Button.BackColor),S,nameof(S.DefaultCellColor));
            SelectedColorBtn.DataBindings.Add(nameof(Button.BackColor), S, nameof(S.SelectedColor));
            ErrorColorBtn.DataBindings.Add(nameof(Button.BackColor), S, nameof(S.ErrorColor));
            CorrectColorBtn.DataBindings.Add(nameof(Button.BackColor), S, nameof(S.CorrectColor));
            DirtyColorBtn.DataBindings.Add(nameof(Button.BackColor), S, nameof(S.DirtyColor));
            CalculatedColorBtn.DataBindings.Add(nameof(Button.BackColor), S, nameof(S.CalculatedColor));
        }

        private void BrowseWorkFolder(object sender, EventArgs e)
        {
            FolderBrowserDialog F = new FolderBrowserDialog()
            {
                SelectedPath = S.WorkFolder,
                ShowNewFolderButton = true
            };
            if (F.ShowDialog() == DialogResult.OK)
            {
                S.WorkFolder = F.SelectedPath;
            }
        }

        private void OpenFolder(object sender, EventArgs e)
        {
            if (System.IO.Directory.Exists(S.WorkFolder))
                System.Diagnostics.Process.Start("Explorer.exe", S.WorkFolder);
        }

        private void ChangeColor(object sender, EventArgs e)
        {
            Button B = sender as Button;
            ColorDialog CD = new ColorDialog()
            {
                AllowFullOpen = true,
                Color = B.BackColor,
            };
            if (CD.ShowDialog() == DialogResult.OK)
            {
                B.BackColor = CD.Color;
            }
            CD.Dispose();
        }

        private void SaveChanges(object sender, EventArgs e)
        {
            S.Save();
        }

        private void ResetDefault(object sender, EventArgs e)
        {
            S.Reset();
            S.WorkFolder = Application.StartupPath;
            S.Save();
        }
    }
}

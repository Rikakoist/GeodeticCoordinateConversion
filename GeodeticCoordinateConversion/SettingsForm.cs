using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Resources;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GeodeticCoordinateConversion
{
    public partial class SettingsForm : Form
    {
        static Properties.Settings S = new Properties.Settings();
        public static ResourceManager rm = new ResourceManager("GeodeticCoordinateConversion.Resources." + S.Language, Assembly.GetExecutingAssembly());

        public SettingsForm()
        {
            InitializeComponent();

            #region Multi-language
            this.Text = rm.GetString("Settings");
            TitleLabel.Text = rm.GetString("SettingTitle");

            GeneralTabPage.Text = rm.GetString("General");
            DataTabPage.Text = rm.GetString("Data");
            DataColorTabPage.Text = rm.GetString("Appearance");

            LanguageLabel.Text = rm.GetString("Language");
            BtnToolTip.SetToolTip(LanguageComboBox, rm.GetString("SetAppLanguage"));
            WorkFolderLabel.Text = rm.GetString("WorkFolder");
            BtnToolTip.SetToolTip(WorkFolderBtn, rm.GetString("SelectWorkFolder"));
            BtnToolTip.SetToolTip(OpenWorkFolder, rm.GetString("OpenWorkFolder"));
            DataFileNameLabel.Text = rm.GetString("DataFileName");
            DBNameLabel.Text = rm.GetString("DBName");
            DefaultEllipseTypeLabel.Text = rm.GetString("DefaultEllipse");
            BtnToolTip.SetToolTip(DefaultEllipseTypeComboBox, rm.GetString("DefaultEllipseAddingRow"));
            DefaultZoneTypeLabel.Text = rm.GetString("DefaultZoneType");
            BtnToolTip.SetToolTip(DefaultZoneTypeComboBox, rm.GetString("DefaultZoneTypeAddingRow"));

            SwitchAfterGaussTransferCheckBox.Text = rm.GetString("SwitchAfterGaussTransfer");
            ClearExistingRecordData2FileCheckBox.Text = rm.GetString("ClearExistingRecordData2File");
            ClearExistingRecordData2DBCheckBox.Text = rm.GetString("ClearExistingRecordData2DB");
            ClearExistingRecordDB2FileCheckBox.Text = rm.GetString("ClearExistingRecordDB2File");
            ClearExistingRecordFile2DBCheckBox.Text = rm.GetString("ClearExistingRecordFile2DB");

            DefaultCellColorLabel.Text = rm.GetString("DefaultCellColor");
            SelectedColorLabel.Text = rm.GetString("SelectedColor");
            ErrorColorLabel.Text = rm.GetString("ErrorColor");
            CorrectColorLabel.Text = rm.GetString("CorrectColor");
            DirtyColorLabel.Text = rm.GetString("DirtyColor");
            CalculatedColorLabel.Text = rm.GetString("CalculatedColor");

            ConfirmBtn.Text = rm.GetString("Save");
            CancelBtn.Text = rm.GetString("Cancel");
            ResetBtn.Text = rm.GetString("ResetDefault");
            BtnToolTip.SetToolTip(ConfirmBtn, rm.GetString("SaveBtnRequireRestart"));
            BtnToolTip.SetToolTip(CancelBtn, rm.GetString("AbortChange"));
            BtnToolTip.SetToolTip(ResetBtn, rm.GetString("ResetDefaultRequireStart"));
            #endregion

            //通用
            LanguageComboBox.DataSource = GEODataTables.GetLangType();
            LanguageComboBox.DisplayMember = nameof(GEOLang);
            LanguageComboBox.ValueMember = "Name";
            LanguageComboBox.DataBindings.Add(nameof(ComboBox.SelectedValue), S, nameof(S.Language));

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

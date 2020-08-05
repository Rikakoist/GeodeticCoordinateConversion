﻿using System;
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
            WorkFolderTextBox.DataBindings.Add(nameof(WorkFolderTextBox.Text),S,nameof(S.WorkFolder));
            DataFileNameTextBox.DataBindings.Add(nameof(DataFileNameTextBox.Text),S,nameof(S.DataFileName));
            DBNameTextBox.DataBindings.Add(nameof(DBNameTextBox.Text), S, nameof(S.DBName));

            DefaultEllipseTypeComboBox.DataSource = GEODataTables.GetEllipseType();
            DefaultEllipseTypeComboBox.DisplayMember = nameof(GEOEllipseType);
            DefaultEllipseTypeComboBox.ValueMember = "Value";
            DefaultEllipseTypeComboBox.DataBindings.Add(nameof(DefaultEllipseTypeComboBox.SelectedValue),S,nameof(S.DefaultEllipseType));

            DefaultZoneTypeComboBox.DataSource = GEODataTables.GetZoneType();
            DefaultZoneTypeComboBox.DisplayMember = nameof(GEOZoneType);
            DefaultZoneTypeComboBox.ValueMember = "Value";
            DefaultZoneTypeComboBox.DataBindings.Add(nameof(DefaultZoneTypeComboBox.SelectedValue), S, nameof(S.DefaultZoneType));

            SwitchAfterGaussTransferCheckBox.DataBindings.Add(nameof(SwitchAfterGaussTransferCheckBox.Checked), S, nameof(S.SwitchAfterGaussTransfer));
        }

        private void BrowseWorkFolder(object sender, EventArgs e)
        {
            FolderBrowserDialog F = new FolderBrowserDialog()
            {
               SelectedPath=S.WorkFolder,
               ShowNewFolderButton = true
            };
            if(F.ShowDialog()==DialogResult.OK)
            {
                S.WorkFolder = F.SelectedPath;
            }
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

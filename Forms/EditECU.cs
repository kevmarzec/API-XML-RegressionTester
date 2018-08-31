using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace TestBuilder.Forms
{
    public partial class EditECU : Form
    {
        private Models.Ecu _ecu = null;

        public string EcuName => tbEcuName.Text.Trim();

        public bool UseProjectFile => rbProjectFile.Checked;

        public string ProjectFileName => tbProjectFile.Text.Trim();

        public string DeviceName => tbProjectDeviceName.Text.Trim();

        public string DeviceECUName => tbProjectEcuName.Text.Trim();

        public string RequestAddress => tbRequest.Text.Trim();

        public string ResponseAddress => tbResponse.Text.Trim();

        public string DataFile => tbDataFile.Text.Trim();

        public bool Extended => cbExtended.Checked;

        public List<KeyValuePair<string, string>> Parameters => 
            editParameters
                .Parameters
                .ToList()
                .Select(p => new KeyValuePair<string, string>(p.Key, p.Value))
                .ToList();

        public EditECU(Models.Ecu ecu = null)
        {
            InitializeComponent();
                        
            _ecu = ecu;
            if(_ecu != null)
            {
                tbEcuName.Text = _ecu.Name;
                rbProjectFile.Checked = !string.IsNullOrEmpty(_ecu.ProjectFile);
                if(rbProjectFile.Checked)
                {
                    tbProjectFile.Text = _ecu.ProjectFile;
                    tbProjectDeviceName.Text = _ecu.DeviceName;
                    tbProjectEcuName.Text = _ecu.EcuName;
                }
                else
                {
                    rbManual.Checked = true;
                    tbRequest.Text = _ecu.RequestId;
                    tbResponse.Text = _ecu.ResponseId;
                    tbDataFile.Text = _ecu.DataFile;
                    cbExtended.Checked = _ecu.IsExtended;
                }

                Text = $"Edit ECU: {_ecu.Name}";
                
                editParameters.SetParameters(ecu.Parameters.Select(p => (Models.Parameter)p).ToList());
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            // validate
            if(tbEcuName.Text.Trim().Length == 0)
            {
                MessageBox.Show("Please enter a name.");
                tbEcuName.Focus();
                DialogResult = DialogResult.None;
            }
            else
            {
                DialogResult = DialogResult.OK;
            }
        }

        private void EditECU_Load(object sender, EventArgs e)
        {
            tbEcuName.SelectAll();
            tbEcuName.Focus();
        }

        private void rbProjectFile_CheckedChanged(object sender, EventArgs e)
        {
            gbManual.Enabled = false;
            gbProject.Enabled = true;
        }

        private void rbManual_CheckedChanged(object sender, EventArgs e)
        {
            gbManual.Enabled = true;
            gbProject.Enabled = false;
        }

        private void btnSelectProjectFile_Click(object sender, EventArgs e)
        {
            var dialog = new OpenFileDialog
            {
                CheckFileExists = true,
                DefaultExt = ".vpj",
                Filter = "VISION Project Files|*.vpj",
                Title = "Select VISION Project File",
                Multiselect = false
            };

            if(dialog.ShowDialog() == DialogResult.OK)
            {
                tbProjectFile.Text = dialog.FileName;
            }
        }

        private void tbSelectDataFile_Click(object sender, EventArgs e)
        {
            var dialog = new OpenFileDialog
            {
                CheckFileExists = true,
                DefaultExt = ".vpj",
                Filter = "Data Files|*.odx;*.mdx",
                Title = "Select Diagnostic Data File",
                Multiselect = false
            };

            if(dialog.ShowDialog() == DialogResult.OK)
            {
                tbDataFile.Text = dialog.FileName;
            }
        }
    }
}

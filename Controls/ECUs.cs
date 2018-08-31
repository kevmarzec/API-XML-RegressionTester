using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TestBuilder.Controls
{
    public partial class ECUs : UserControl
    {
        public ECUs()
        {
            InitializeComponent();
        }
        
        public void Initialise()
        {
            LoadECUs();
        }
        
        private void btnAddECU_Click(object sender, EventArgs e)
        {
            var form = new Forms.EditECU();
            
            if(form.ShowDialog() == DialogResult.OK)
            {
                using(var db = new DataContext())
                {
                    var ecu = new Models.Ecu
                    {
                        Name = form.EcuName,
                        ProjectFile = form.UseProjectFile ? form.ProjectFileName : null,
                        DeviceName = form.UseProjectFile ? form.DeviceName : null,
                        EcuName = form.UseProjectFile ? form.DeviceECUName : null,
                        RequestId = !form.UseProjectFile ? form.RequestAddress : null,
                        ResponseId = !form.UseProjectFile ? form.ResponseAddress : null,
                        DataFile = !form.UseProjectFile ? form.DataFile : null,
                        IsExtended = !form.UseProjectFile ? form.Extended : false,
                        Parameters = new List<Models.EcuParameter>()
                    };
                    
                    db.Ecus.Add(ecu);
                    ecu.SetParameters(db, form.Parameters);

                    db.SaveChanges();
                }

                LoadECUs();
            }
        }

        private void btnRemoveECUs_Click(object sender, EventArgs e)
        {
            using(var db = new DataContext())
            {
                db.Ecus.RemoveRange(GetSelectedECUs(db));
                db.SaveChanges();
            }
            
            LoadECUs();
        }

        private void btnRunECUTests_Click(object sender, EventArgs e)
        {
            var form = new Forms.SelectTests();
            if(form.ShowDialog() != DialogResult.OK)
            {
                return;
            }
                       
            tbOutputECU.Text = string.Empty;

            GetSelectedECUs(new DataContext()).ForEach(ecu =>
            {
                foreach(var test in form.SelectedTests)
                {                    
                    Executor.ExecuteTest(test, ecu, tbOutputECU);
                }
            });

            Program.MainForm.ReloadResults();
        }

        private void LoadECUs()
        {
            listECUs.Items.Clear();

            using(var db = new DataContext())
            {
                Models
                    .Ecu
                    .FindAll(db)
                    .ForEach(ecu => {
                        listECUs.Items.Add(new ListViewItem
                        {
                            Text = ecu.Name,
                            Tag = ecu.Id
                        });
                    });
            }
        }

        private List<Models.Ecu> GetSelectedECUs(DataContext db)
        {
            var ecus = new List<Models.Ecu>();

            foreach(var item in listECUs.CheckedItems)
            {
                var ecu = Models.Ecu.Find(db, (int)(item as ListViewItem).Tag);
                if(ecu != null)
                {
                    ecus.Add(ecu);
                }
            }

            return ecus;
        }

        private void listECUs_DoubleClick(object sender, EventArgs e)
        {
            if(listECUs.FocusedItem != null)
            {
                using(var db = new DataContext())
                {
                    var ecu = Models.Ecu.Find(db, (int)listECUs.FocusedItem.Tag);
                    if(ecu == null)
                    {
                        MessageBox.Show("Unable to load ECU.");
                        return;
                    }

                    var form = new Forms.EditECU(ecu);
                    if(form.ShowDialog() == DialogResult.OK)
                    {
                        // Save changes
                        ecu.Name = form.EcuName;
                        ecu.ProjectFile = form.UseProjectFile ? form.ProjectFileName : null;
                        ecu.DeviceName = form.UseProjectFile ? form.DeviceName : null;
                        ecu.EcuName = form.UseProjectFile ? form.DeviceECUName : null;
                        ecu.RequestId = !form.UseProjectFile ? form.RequestAddress : null;
                        ecu.ResponseId = !form.UseProjectFile ? form.ResponseAddress : null;
                        ecu.DataFile = !form.UseProjectFile ? form.DataFile : null;
                        ecu.IsExtended = !form.UseProjectFile ? form.Extended : false;                        
                        ecu.SetParameters(db, form.Parameters);

                        db.SaveChanges();
                        LoadECUs();
                    }
                }
            }
        }

        private void listECUs_ItemChecked(object sender, ItemCheckedEventArgs e)
        {
            btnRemoveEcu.Enabled = btnRunTests.Enabled = listECUs.CheckedItems.Count > 0;
        }
    }
}

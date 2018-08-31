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
    public partial class Tests : UserControl
    {
        public Tests()
        {
            InitializeComponent();
        }

        public void Initialise()
        {
            LoadTests();
        }

        private List<Models.Test> GetSelectedTests(DataContext db)
        {
            var tests = new List<Models.Test>();

            foreach(var item in listTests.CheckedItems)
            {
                var test = Models.Test.Find(db, (int)(item as ListViewItem).Tag);
                if(test != null)
                {
                    tests.Add(test);
                }
            }

            return tests;
        }
                
        private void LoadTests()
        {
            listTests.Items.Clear();
            
            using(var db = new DataContext())
            {
                Models
                    .Test
                    .FindAll(db)
                    .ForEach(test => {
                        listTests.Items.Add(new ListViewItem
                        {
                            Text = test.Name,
                            Tag = test.Id
                        });
                    });
            }
        }

        private void btnAddTest_Click(object sender, EventArgs e)
        {
            var form = new Forms.EditTest();
            
            if(form.ShowDialog() == DialogResult.OK)
            {
                using(var db = new DataContext())
                {
                    var test = new Models.Test
                    {
                        Name = form.TestName,
                        Script = form.Script,
                        Parameters = new List<Models.TestParameter>()
                    };

                    db.Tests.Add(test);
                    test.SetParameters(db, form.Parameters);;

                    db.SaveChanges();
                }

                LoadTests();
            }
        }

        private void btnRemoveTest_Click(object sender, EventArgs e)
        {
            using(var db = new DataContext())
            {
                db.Tests.RemoveRange(GetSelectedTests(db));
                db.SaveChanges();
            }
            
            LoadTests();
        }

        private void btnRunTests_Click(object sender, EventArgs e)
        {
            var form = new Forms.SelectECUs();
            if(form.ShowDialog() != DialogResult.OK)
            {
                return;
            }
                       
            tbOutput.Text = string.Empty;

            GetSelectedTests(new DataContext()).ForEach(test =>
            {
                foreach(var ecu in form.SelectedECUs)
                {                    
                    Executor.ExecuteTest(test, ecu, tbOutput);
                }
            });

            Program.MainForm.ReloadResults();
        }

        private void listTests_ItemChecked(object sender, ItemCheckedEventArgs e)
        {
            btnRemoveTest.Enabled = btnRunTests.Enabled = listTests.CheckedItems.Count > 0;
        }
        
        private void listTests_DoubleClick(object sender, EventArgs e)
        {
            if(listTests.FocusedItem != null)
            {
                using(var db = new DataContext())
                {
                    var test = Models.Test.Find(db, (int)listTests.FocusedItem.Tag);
                    if(test == null)
                    {
                        MessageBox.Show("Unable to load test.");
                        return;
                    }

                    var form = new Forms.EditTest(test);
                    if(form.ShowDialog() == DialogResult.OK)
                    {
                        // Save changes
                        test.Name = form.TestName;
                        test.Script = form.Script;
                        test.SetParameters(db, form.Parameters);

                        db.SaveChanges();
                        LoadTests();
                    }
                }
            }
        }
    }
}

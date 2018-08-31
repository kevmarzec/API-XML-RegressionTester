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
    public partial class Results : UserControl
    {
        private List<Models.TestResult> _results = null;
        
        private int _sortColumn = 0;
        private bool[] _sortOrder = new[] { false, true, true, true };

        public Results()
        {
            InitializeComponent();
        }

        public void Initialise()
        {
            using(var db = new DataContext())
            {
                // Set up filters
                comboResult.Items.Add("-- All Results --");
                comboResult.Items.AddRange(Enum.GetNames(typeof(Models.ResultState)));
                comboResult.SelectedIndex = 0;

                comboTest.Items.Add("-- All Tests --");
                Models.Test.FindAll(db).ForEach(test => comboTest.Items.Add(test));
                comboTest.SelectedIndex = 0;

                comboECU.Items.Add("-- All ECUs --");
                Models.Ecu.FindAll(db).ForEach(ecu => comboECU.Items.Add(ecu));
                comboECU.SelectedIndex = 0;
            }

            LoadResults();
        }

        private void LoadResults()
        {
            using(var db = new DataContext())
            {
                _results = db
                    .TestResults
                    .Include("Test")
                    .Include("Ecu")
                    .Include("Parameters")
                    .OrderByDescending(r => r.TestTime)
                    //.Take(50)
                    .ToList();

                DisplayResults();
            }
        }

        private void DisplayResults()
        {
            if(_results == null)
            {
                LoadResults();
            }

            listResults.Items.Clear();

            var ordered = _results;
            switch(_sortColumn)
            {
                case 0: 
                    ordered = (_sortOrder[0] 
                        ? _results.OrderBy(r => r.TestTime) 
                        : _results.OrderByDescending(r => r.TestTime)).ToList(); 
                    break;

                case 1: 
                    ordered = (_sortOrder[1] 
                        ? _results.OrderBy(r => r.Test?.Name) 
                        : _results.OrderByDescending(r => r.Test?.Name)).ToList(); 
                    break;

                case 2: 
                    ordered = (_sortOrder[2] 
                        ? _results.OrderBy(r => r.Ecu?.Name) 
                        : _results.OrderByDescending(r => r.Ecu?.Name)).ToList(); 
                    break;

                case 3: 
                    ordered = (_sortOrder[3] 
                        ? _results.OrderBy(r => Enum.GetName(typeof(Models.ResultState), r.Verified)).ToList()
                        : _results.OrderByDescending(r => Enum.GetName(typeof(Models.ResultState), r.Verified)).ToList()); 
                    break;
            }

            /* TODO: Fix column header sort images!  Setting ImageIndex to -1 doesn't clear the image for some reason....
            for(var i = 0; i < listResults.Columns.Count; i++)
            {
                listResults.Columns[i].ImageIndex = _sortColumn == i ? (_sortOrder[_sortColumn] ? 0 : 1) : -1;
            }*/
                        
            ordered?.ForEach(result =>
                {
                    // Filters
                    if(comboResult.SelectedIndex > 0 && Enum.GetName(typeof(Models.ResultState), result.Verified) != comboResult.Text)
                    {
                        return;
                    }
                    
                    if(comboTest.SelectedIndex > 0 && result.TestId != (comboTest.SelectedItem as Models.Test).Id)
                    {
                        return;
                    }
                    
                    if(comboECU.SelectedIndex > 0 && result.EcuId != (comboECU.SelectedItem as Models.Ecu).Id)
                    {
                        return;
                    }
                    
                    var item = new ListViewItem
                    {
                        Text = $"{result.TestTime.ToShortDateString()} {result.TestTime.ToShortTimeString()}",
                        Tag = result
                    };

                    item.SubItems.AddRange(new[]
                    {
                        new ListViewItem.ListViewSubItem { Text = result.Version },
                        new ListViewItem.ListViewSubItem { Text = result.Test?.Name ?? "--" },
                        new ListViewItem.ListViewSubItem { Text = result.Ecu?.Name ?? "--" },
                        new ListViewItem.ListViewSubItem { Text = Enum.GetName(typeof(Models.ResultState), result.Verified) }
                    });

                    switch(result.Verified)
                    {
                        case Models.ResultState.Verified:
                            item.BackColor = Color.LightGreen;
                            break;

                        case Models.ResultState.FailedVerification:
                            item.BackColor = Color.LightSalmon;
                            break;

                        case Models.ResultState.IsVerifiedResult:
                            item.BackColor = Color.LightBlue;
                            break;
                    }

                    listResults.Items.Add(item);
                });

            UpdateButtons();
        }

        private void UpdateButtons()
        {
            btnClear.Enabled = listResults.Items.Count > 0;
            btnMarkCorrect.Enabled = listResults.FocusedItem != null;
            btnRemoveResult.Enabled = listResults.CheckedItems.Count > 0;
        }

        private void listResults_DoubleClick(object sender, EventArgs e)
        {
            if(listResults.FocusedItem == null)
            {
                return;
            }

            new Forms
                    .ViewTestResult(listResults.FocusedItem.Tag as Models.TestResult)
                    .Show();
        }

        private void btnMarkCorrect_Click(object sender, EventArgs e)
        {
            if(listResults.FocusedItem == null)
            {
                return;
            }

            var result = listResults.FocusedItem.Tag as Models.TestResult;

            using(var db = new DataContext())
            {
                // Unmark any other 'verified' results for the same test and ECU
                db
                    .TestResults
                    .Where(r => r.EcuId == result.EcuId && r.TestId == result.TestId && r.TestTime >= result.TestTime)
                    .ToList()
                    .ForEach(r => r.Verified = Models.ResultState.NoVerifiedResult);

                // Mark this 'verified'
                var dbResult = db.TestResults.Find(result.Id);
                if(dbResult != null)
                {
                    dbResult.Verified = Models.ResultState.IsVerifiedResult;
                }

                // Re-check all future results against the newly verified result
                db
                    .TestResults
                    .Where(r => r.EcuId == result.EcuId && r.TestId == result.TestId && r.TestTime > dbResult.TestTime)
                    .ToList()
                    .ForEach(r => 
                        r.Verified = (r.Output == dbResult.Output) 
                                        ? Models.ResultState.Verified 
                                        : Models.ResultState.FailedVerification);

                db.SaveChanges();

                
                // TODO: Just update the list items here, don't reload the entire thing
                /*foreach(ListViewItem item in listResults.Items)
                {
                    var r = item.Tag as Models.TestResult;
                    if(r.TestId == result.TestId && r.EcuId == result.EcuId)
                    {
                        var thisResult = db.TestResults.Find(r.Id);
                        if(thisResult != null)
                        {
                            // TODO: Refactor to avoid duplicated code
                            item.SubItems[3].Text =  Enum.GetName(typeof(Models.ResultState), thisResult.Verified);
                            
                            switch(thisResult.Verified)
                            {
                                case Models.ResultState.Verified:
                                    item.BackColor = Color.LightGreen;
                                    break;

                                case Models.ResultState.FailedVerification:
                                    item.BackColor = Color.LightSalmon;
                                    break;

                                case Models.ResultState.IsVerifiedResult:
                                    item.BackColor = Color.LightBlue;
                                    break;

                                default:
                                    item.BackColor = Color.White;
                                    break;
                            }
                        }
                    }
                }*/
            }

            LoadResults();
        }

        private void listResults_SelectedIndexChanged(object sender, EventArgs e)
        {
            UpdateButtons();
        }

        private void listResults_ItemChecked(object sender, ItemCheckedEventArgs e)
        {
            UpdateButtons();
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            if(MessageBox.Show("Are you sure you want to clear all the test results?  This can't be undone!") != DialogResult.OK)
            {
                return;
            }

            using(var db = new DataContext())
            {
                db.TestResults.RemoveRange(db.TestResults);
                db.TestResultParameters.RemoveRange(db.TestResultParameters);
                db.SaveChanges();

                LoadResults();
            }
        }

        private void comboResult_SelectedIndexChanged(object sender, EventArgs e)
        {
            DisplayResults();
        }

        private void comboTest_SelectedIndexChanged(object sender, EventArgs e)
        {
            DisplayResults();
        }

        private void comboECU_SelectedIndexChanged(object sender, EventArgs e)
        {
            DisplayResults();
        }

        private void listResults_ColumnClick(object sender, ColumnClickEventArgs e)
        {
            if(_sortColumn == e.Column)
            {
                _sortOrder[e.Column] = !_sortOrder[e.Column];
            }
            else
            {
                _sortColumn = e.Column;
            }
            
            DisplayResults();
        }
    }
}

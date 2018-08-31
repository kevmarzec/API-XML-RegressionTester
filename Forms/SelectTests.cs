using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TestBuilder.Forms
{
    public partial class SelectTests : Form
    {
        public List<Models.Test> SelectedTests
        {
            get
            {
                var list = new List<Models.Test>();

                using(var db = new DataContext())
                {
                    foreach(var item in listTests.CheckedItems)
                    {
                        var test = Models.Test.Find(db, (int)(item as ListViewItem).Tag);
                        if(test != null)
                        {
                            list.Add(test);
                        }
                    }
                }

                return list;
            }
        }

        public SelectTests()
        {
            InitializeComponent();
        }

        private void SelectTests_Load(object sender, System.EventArgs e)
        {
            listTests.Items.Clear();

            using(var db = new DataContext())
            {
                Models.Test.FindAll(db).ForEach(test => {
                    listTests.Items.Add(new ListViewItem
                    {
                        Text = test.Name,
                        Tag = test.Id
                    });
                });
            }
        }
    }
}

using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace TestBuilder.Forms
{
    public partial class SelectECUs : Form
    {
        public List<Models.Ecu> SelectedECUs
        {
            get
            {
                var list = new List<Models.Ecu>();

                using(var db = new DataContext())
                {
                    foreach(var item in listECUs.CheckedItems)
                    {
                        var ecu = Models.Ecu.Find(db, (int)(item as ListViewItem).Tag);
                        if(ecu != null)
                        {
                            list.Add(ecu);
                        }
                    }
                }

                return list;
            }
        }

        public SelectECUs()
        {
            InitializeComponent();
        }

        private void SelectECUs_Load(object sender, System.EventArgs e)
        {
            listECUs.Items.Clear();

            using(var db = new DataContext())
            {
                Models.Ecu.FindAll(db).ForEach(ecu => {
                    listECUs.Items.Add(new ListViewItem
                    {
                        Text = ecu.Name,
                        Tag = ecu.Id
                    });
                });
            }
        }
    }
}

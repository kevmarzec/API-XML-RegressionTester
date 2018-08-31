using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace TestBuilder.Controls
{
    public partial class EditParameters : UserControl
    {
        public bool Editable 
        { 
            set
            {
                tools.Visible = listParameters.Enabled = value;
            }
        }

        public Dictionary<string, string> Parameters { get; } = new Dictionary<string, string>();

        public EditParameters()
        {
            InitializeComponent();
        }

        public void SetParameters(List<Models.Parameter> parameters)
        {
            if(parameters == null)
            {
                return;
            }

            parameters.ForEach(parameter => Parameters[parameter.Name] = parameter.Value);
            UpdateList();
        }
                
        private void UpdateList()
        {
            listParameters.Items.Clear();
            Parameters.Keys.ToList().ForEach(key => 
                listParameters.Items.Add(
                    new ListViewItem 
                    { 
                        Text = key
                    }).SubItems.Add(Parameters[key]));
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            var form = new Forms.EditParameter();
            if(form.ShowDialog() == DialogResult.OK)
            {
                Parameters[form.Key] = form.Value;
                UpdateList();
            }
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            listParameters
                .SelectedItems
                .Cast<ListViewItem>()
                .ToList()
                .ForEach(item => Parameters.Remove(item.Text));

            UpdateList();
        }

        private void listParameters_DoubleClick(object sender, EventArgs e)
        {
            var item = listParameters.FocusedItem;
            if(item == null || !tools.Visible)
            {
                return;
            }
            
            var form = new Forms.EditParameter(item.Text, item.SubItems[1].Text);
            if(form.ShowDialog() == DialogResult.OK)
            {
                // Update the parameter
                if(form.Key != item.Text)
                {
                    Parameters.Remove(item.Text);
                }

                Parameters[form.Key] = form.Value;
                UpdateList();
            }
        }
    }
}

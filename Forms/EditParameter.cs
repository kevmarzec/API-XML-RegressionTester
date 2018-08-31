using System;
using System.Windows.Forms;

namespace TestBuilder.Forms
{
    public partial class EditParameter : Form
    {
        public string Key => tbName.Text.Trim();

        public string Value => tbValue.Text.Trim();

        public EditParameter(string name = null, string value = null)
        {
            InitializeComponent();

            if(!string.IsNullOrEmpty(name))
            {
                tbName.Text = name;
                Text = $"Edit Parameter: {name}";
                btnAdd.Text = "Save Changes";
            }
            
            if(!string.IsNullOrEmpty(value))
            {
                tbValue.Text = value;
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            // validate
            if(string.IsNullOrEmpty(Key))
            {
                MessageBox.Show("Invalid name specified.  Please try again.");
                DialogResult = DialogResult.None;
                return;
            }

            DialogResult = DialogResult.OK;
        }
        
        private void EditParameter_Shown(object sender, EventArgs e)
        {
            tbName.SelectAll();
            tbName.Focus();
        }
    }
}

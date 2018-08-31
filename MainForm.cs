using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace TestBuilder
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            ctrlEcus.Initialise();
            ctrlTests.Initialise();
            ctrlResults.Initialise();
        }

        public void ReloadResults()
        {
            ctrlResults.Initialise();
        }
    }
}

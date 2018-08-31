namespace TestBuilder.Controls
{
    partial class ECUs
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ECUs));
            this.panel1 = new System.Windows.Forms.Panel();
            this.tbOutputECU = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.listECUs = new TestBuilder.Controls.NoCheckListView();
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ecuToolstrip = new System.Windows.Forms.ToolStrip();
            this.btnAddEcu = new System.Windows.Forms.ToolStripButton();
            this.btnRemoveEcu = new System.Windows.Forms.ToolStripButton();
            this.btnRunTests = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.ecuToolstrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.AutoSize = true;
            this.panel1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.panel1.Controls.Add(this.tbOutputECU);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(324, 495);
            this.panel1.TabIndex = 18;
            // 
            // tbOutputECU
            // 
            this.tbOutputECU.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbOutputECU.Location = new System.Drawing.Point(0, 13);
            this.tbOutputECU.Multiline = true;
            this.tbOutputECU.Name = "tbOutputECU";
            this.tbOutputECU.ReadOnly = true;
            this.tbOutputECU.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.tbOutputECU.Size = new System.Drawing.Size(324, 482);
            this.tbOutputECU.TabIndex = 16;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Dock = System.Windows.Forms.DockStyle.Top;
            this.label2.Location = new System.Drawing.Point(0, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(42, 13);
            this.label2.TabIndex = 17;
            this.label2.Text = "Output:";
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.listECUs);
            this.splitContainer1.Panel1.Controls.Add(this.ecuToolstrip);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.panel1);
            this.splitContainer1.Size = new System.Drawing.Size(876, 495);
            this.splitContainer1.SplitterDistance = 548;
            this.splitContainer1.TabIndex = 22;
            // 
            // listECUs
            // 
            this.listECUs.CheckBoxes = true;
            this.listECUs.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader2});
            this.listECUs.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listECUs.FullRowSelect = true;
            this.listECUs.GridLines = true;
            this.listECUs.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None;
            this.listECUs.Location = new System.Drawing.Point(0, 38);
            this.listECUs.MultiSelect = false;
            this.listECUs.Name = "listECUs";
            this.listECUs.Size = new System.Drawing.Size(548, 457);
            this.listECUs.TabIndex = 24;
            this.listECUs.UseCompatibleStateImageBehavior = false;
            this.listECUs.View = System.Windows.Forms.View.List;
            this.listECUs.ItemChecked += new System.Windows.Forms.ItemCheckedEventHandler(this.listECUs_ItemChecked);
            this.listECUs.DoubleClick += new System.EventHandler(this.listECUs_DoubleClick);
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Name";
            this.columnHeader2.Width = 400;
            // 
            // ecuToolstrip
            // 
            this.ecuToolstrip.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.ecuToolstrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnAddEcu,
            this.toolStripSeparator1,
            this.btnRemoveEcu,
            this.toolStripSeparator2,
            this.btnRunTests});
            this.ecuToolstrip.Location = new System.Drawing.Point(0, 0);
            this.ecuToolstrip.Name = "ecuToolstrip";
            this.ecuToolstrip.Size = new System.Drawing.Size(548, 38);
            this.ecuToolstrip.TabIndex = 23;
            this.ecuToolstrip.Text = "toolStrip1";
            // 
            // btnAddEcu
            // 
            this.btnAddEcu.Image = ((System.Drawing.Image)(resources.GetObject("btnAddEcu.Image")));
            this.btnAddEcu.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnAddEcu.Name = "btnAddEcu";
            this.btnAddEcu.Size = new System.Drawing.Size(60, 35);
            this.btnAddEcu.Text = "New ECU";
            this.btnAddEcu.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnAddEcu.Click += new System.EventHandler(this.btnAddECU_Click);
            // 
            // btnRemoveEcu
            // 
            this.btnRemoveEcu.Image = ((System.Drawing.Image)(resources.GetObject("btnRemoveEcu.Image")));
            this.btnRemoveEcu.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnRemoveEcu.Name = "btnRemoveEcu";
            this.btnRemoveEcu.Size = new System.Drawing.Size(92, 35);
            this.btnRemoveEcu.Text = "Remove ECU(s)";
            this.btnRemoveEcu.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnRemoveEcu.Click += new System.EventHandler(this.btnRemoveECUs_Click);
            // 
            // btnRunTests
            // 
            this.btnRunTests.Image = ((System.Drawing.Image)(resources.GetObject("btnRunTests.Image")));
            this.btnRunTests.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnRunTests.Name = "btnRunTests";
            this.btnRunTests.Size = new System.Drawing.Size(69, 35);
            this.btnRunTests.Text = "Run &Test(s)";
            this.btnRunTests.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnRunTests.Click += new System.EventHandler(this.btnRunECUTests_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 38);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 38);
            // 
            // ECUs
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.splitContainer1);
            this.Name = "ECUs";
            this.Size = new System.Drawing.Size(876, 495);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.ecuToolstrip.ResumeLayout(false);
            this.ecuToolstrip.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TextBox tbOutputECU;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private NoCheckListView listECUs;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ToolStrip ecuToolstrip;
        private System.Windows.Forms.ToolStripButton btnAddEcu;
        private System.Windows.Forms.ToolStripButton btnRemoveEcu;
        private System.Windows.Forms.ToolStripButton btnRunTests;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
    }
}

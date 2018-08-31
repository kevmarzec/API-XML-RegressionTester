namespace TestBuilder.Controls
{
    partial class Tests
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Tests));
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.btnAddTest = new System.Windows.Forms.ToolStripButton();
            this.btnRemoveTest = new System.Windows.Forms.ToolStripButton();
            this.btnRunTests = new System.Windows.Forms.ToolStripButton();
            this.tbOutput = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.listTests = new TestBuilder.Controls.NoCheckListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.listTests);
            this.splitContainer1.Panel1.Controls.Add(this.toolStrip1);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.tbOutput);
            this.splitContainer1.Panel2.Controls.Add(this.label1);
            this.splitContainer1.Size = new System.Drawing.Size(749, 453);
            this.splitContainer1.SplitterDistance = 444;
            this.splitContainer1.TabIndex = 12;
            // 
            // toolStrip1
            // 
            this.toolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnAddTest,
            this.toolStripSeparator2,
            this.btnRemoveTest,
            this.toolStripSeparator1,
            this.btnRunTests});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(444, 38);
            this.toolStrip1.TabIndex = 0;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // btnAddTest
            // 
            this.btnAddTest.Image = ((System.Drawing.Image)(resources.GetObject("btnAddTest.Image")));
            this.btnAddTest.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnAddTest.Name = "btnAddTest";
            this.btnAddTest.Size = new System.Drawing.Size(59, 35);
            this.btnAddTest.Text = "New Test";
            this.btnAddTest.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnAddTest.Click += new System.EventHandler(this.btnAddTest_Click);
            // 
            // btnRemoveTest
            // 
            this.btnRemoveTest.Image = ((System.Drawing.Image)(resources.GetObject("btnRemoveTest.Image")));
            this.btnRemoveTest.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnRemoveTest.Name = "btnRemoveTest";
            this.btnRemoveTest.Size = new System.Drawing.Size(91, 35);
            this.btnRemoveTest.Text = "Remove Test(s)";
            this.btnRemoveTest.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnRemoveTest.Click += new System.EventHandler(this.btnRemoveTest_Click);
            // 
            // btnRunTests
            // 
            this.btnRunTests.Image = ((System.Drawing.Image)(resources.GetObject("btnRunTests.Image")));
            this.btnRunTests.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnRunTests.Name = "btnRunTests";
            this.btnRunTests.Size = new System.Drawing.Size(69, 35);
            this.btnRunTests.Text = "Run Test(s)";
            this.btnRunTests.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnRunTests.Click += new System.EventHandler(this.btnRunTests_Click);
            // 
            // tbOutput
            // 
            this.tbOutput.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbOutput.Location = new System.Drawing.Point(0, 13);
            this.tbOutput.Multiline = true;
            this.tbOutput.Name = "tbOutput";
            this.tbOutput.ReadOnly = true;
            this.tbOutput.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.tbOutput.Size = new System.Drawing.Size(301, 440);
            this.tbOutput.TabIndex = 13;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Dock = System.Windows.Forms.DockStyle.Top;
            this.label1.Location = new System.Drawing.Point(0, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(42, 13);
            this.label1.TabIndex = 12;
            this.label1.Text = "Output:";
            // 
            // listTests
            // 
            this.listTests.CheckBoxes = true;
            this.listTests.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1});
            this.listTests.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listTests.FullRowSelect = true;
            this.listTests.GridLines = true;
            this.listTests.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None;
            this.listTests.Location = new System.Drawing.Point(0, 38);
            this.listTests.MultiSelect = false;
            this.listTests.Name = "listTests";
            this.listTests.Size = new System.Drawing.Size(444, 415);
            this.listTests.TabIndex = 8;
            this.listTests.UseCompatibleStateImageBehavior = false;
            this.listTests.View = System.Windows.Forms.View.List;
            this.listTests.ItemChecked += new System.Windows.Forms.ItemCheckedEventHandler(this.listTests_ItemChecked);
            this.listTests.DoubleClick += new System.EventHandler(this.listTests_DoubleClick);
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Name";
            this.columnHeader1.Width = 357;
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
            // Tests
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.splitContainer1);
            this.Name = "Tests";
            this.Size = new System.Drawing.Size(749, 453);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private NoCheckListView listTests;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton btnAddTest;
        private System.Windows.Forms.ToolStripButton btnRemoveTest;
        private System.Windows.Forms.ToolStripButton btnRunTests;
        private System.Windows.Forms.TextBox tbOutput;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
    }
}

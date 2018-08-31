namespace TestBuilder.Controls
{
    partial class Results
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Results));
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.btnRemoveResult = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.btnMarkCorrect = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.btnClear = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator5 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripLabel1 = new System.Windows.Forms.ToolStripLabel();
            this.comboECU = new System.Windows.Forms.ToolStripComboBox();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.lblTest = new System.Windows.Forms.ToolStripLabel();
            this.comboTest = new System.Windows.Forms.ToolStripComboBox();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripLabel3 = new System.Windows.Forms.ToolStripLabel();
            this.comboResult = new System.Windows.Forms.ToolStripComboBox();
            this.listResults = new TestBuilder.Controls.NoCheckListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader5 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ilColumns = new System.Windows.Forms.ImageList(this.components);
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolStrip1
            // 
            this.toolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnRemoveResult,
            this.toolStripSeparator1,
            this.btnMarkCorrect,
            this.toolStripSeparator2,
            this.btnClear,
            this.toolStripSeparator5,
            this.toolStripLabel1,
            this.comboECU,
            this.toolStripSeparator3,
            this.lblTest,
            this.comboTest,
            this.toolStripSeparator4,
            this.toolStripLabel3,
            this.comboResult});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(957, 38);
            this.toolStrip1.TabIndex = 0;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // btnRemoveResult
            // 
            this.btnRemoveResult.Enabled = false;
            this.btnRemoveResult.Image = ((System.Drawing.Image)(resources.GetObject("btnRemoveResult.Image")));
            this.btnRemoveResult.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnRemoveResult.Name = "btnRemoveResult";
            this.btnRemoveResult.Size = new System.Drawing.Size(102, 35);
            this.btnRemoveResult.Text = "Remove Result(s)";
            this.btnRemoveResult.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 38);
            // 
            // btnMarkCorrect
            // 
            this.btnMarkCorrect.Enabled = false;
            this.btnMarkCorrect.Image = ((System.Drawing.Image)(resources.GetObject("btnMarkCorrect.Image")));
            this.btnMarkCorrect.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnMarkCorrect.Name = "btnMarkCorrect";
            this.btnMarkCorrect.Size = new System.Drawing.Size(80, 35);
            this.btnMarkCorrect.Text = "Mark Correct";
            this.btnMarkCorrect.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnMarkCorrect.Click += new System.EventHandler(this.btnMarkCorrect_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 38);
            // 
            // btnClear
            // 
            this.btnClear.Enabled = false;
            this.btnClear.Image = ((System.Drawing.Image)(resources.GetObject("btnClear.Image")));
            this.btnClear.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(78, 35);
            this.btnClear.Text = "Clear Results";
            this.btnClear.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // toolStripSeparator5
            // 
            this.toolStripSeparator5.Name = "toolStripSeparator5";
            this.toolStripSeparator5.Size = new System.Drawing.Size(6, 38);
            // 
            // toolStripLabel1
            // 
            this.toolStripLabel1.Name = "toolStripLabel1";
            this.toolStripLabel1.Size = new System.Drawing.Size(32, 35);
            this.toolStripLabel1.Text = "ECU:";
            // 
            // comboECU
            // 
            this.comboECU.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.comboECU.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.comboECU.Name = "comboECU";
            this.comboECU.Size = new System.Drawing.Size(121, 38);
            this.comboECU.Sorted = true;
            this.comboECU.SelectedIndexChanged += new System.EventHandler(this.comboECU_SelectedIndexChanged);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(6, 38);
            // 
            // lblTest
            // 
            this.lblTest.Name = "lblTest";
            this.lblTest.Size = new System.Drawing.Size(31, 35);
            this.lblTest.Text = "Test:";
            // 
            // comboTest
            // 
            this.comboTest.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.comboTest.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.comboTest.Name = "comboTest";
            this.comboTest.Size = new System.Drawing.Size(250, 38);
            this.comboTest.Sorted = true;
            this.comboTest.SelectedIndexChanged += new System.EventHandler(this.comboTest_SelectedIndexChanged);
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(6, 38);
            // 
            // toolStripLabel3
            // 
            this.toolStripLabel3.Name = "toolStripLabel3";
            this.toolStripLabel3.Size = new System.Drawing.Size(42, 35);
            this.toolStripLabel3.Text = "Result:";
            // 
            // comboResult
            // 
            this.comboResult.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboResult.Name = "comboResult";
            this.comboResult.Size = new System.Drawing.Size(150, 38);
            this.comboResult.SelectedIndexChanged += new System.EventHandler(this.comboResult_SelectedIndexChanged);
            // 
            // listResults
            // 
            this.listResults.CheckBoxes = true;
            this.listResults.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader5,
            this.columnHeader2,
            this.columnHeader3,
            this.columnHeader4});
            this.listResults.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listResults.FullRowSelect = true;
            this.listResults.GridLines = true;
            this.listResults.Location = new System.Drawing.Point(0, 38);
            this.listResults.Name = "listResults";
            this.listResults.Size = new System.Drawing.Size(957, 537);
            this.listResults.SmallImageList = this.ilColumns;
            this.listResults.TabIndex = 1;
            this.listResults.UseCompatibleStateImageBehavior = false;
            this.listResults.View = System.Windows.Forms.View.Details;
            this.listResults.ColumnClick += new System.Windows.Forms.ColumnClickEventHandler(this.listResults_ColumnClick);
            this.listResults.ItemChecked += new System.Windows.Forms.ItemCheckedEventHandler(this.listResults_ItemChecked);
            this.listResults.SelectedIndexChanged += new System.EventHandler(this.listResults_SelectedIndexChanged);
            this.listResults.DoubleClick += new System.EventHandler(this.listResults_DoubleClick);
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Date";
            this.columnHeader1.Width = 161;
            // 
            // columnHeader5
            // 
            this.columnHeader5.Text = "Version";
            this.columnHeader5.Width = 78;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Test";
            this.columnHeader2.Width = 241;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "ECU";
            this.columnHeader3.Width = 121;
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "Result";
            this.columnHeader4.Width = 133;
            // 
            // ilColumns
            // 
            this.ilColumns.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("ilColumns.ImageStream")));
            this.ilColumns.TransparentColor = System.Drawing.Color.Transparent;
            this.ilColumns.Images.SetKeyName(0, "SortAscending.png");
            this.ilColumns.Images.SetKeyName(1, "SortDescending.png");
            // 
            // Results
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.listResults);
            this.Controls.Add(this.toolStrip1);
            this.Name = "Results";
            this.Size = new System.Drawing.Size(957, 575);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton btnRemoveResult;
        private NoCheckListView listResults;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton btnMarkCorrect;
        private System.Windows.Forms.ToolStripButton btnClear;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator5;
        private System.Windows.Forms.ToolStripLabel toolStripLabel1;
        private System.Windows.Forms.ToolStripComboBox comboECU;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripLabel lblTest;
        private System.Windows.Forms.ToolStripComboBox comboTest;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private System.Windows.Forms.ToolStripLabel toolStripLabel3;
        private System.Windows.Forms.ToolStripComboBox comboResult;
        private System.Windows.Forms.ImageList ilColumns;
        private System.Windows.Forms.ColumnHeader columnHeader5;
    }
}

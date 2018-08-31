using TestBuilder.Controls;

namespace TestBuilder
{
    partial class MainForm
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {            
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tpEcus = new System.Windows.Forms.TabPage();
            this.ctrlEcus = new TestBuilder.Controls.ECUs();
            this.tpTests = new System.Windows.Forms.TabPage();
            this.ctrlTests = new TestBuilder.Controls.Tests();
            this.tpResults = new System.Windows.Forms.TabPage();
            this.ctrlResults = new TestBuilder.Controls.Results();
            this.tabControl1.SuspendLayout();
            this.tpEcus.SuspendLayout();
            this.tpTests.SuspendLayout();
            this.tpResults.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tpEcus);
            this.tabControl1.Controls.Add(this.tpTests);
            this.tabControl1.Controls.Add(this.tpResults);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(807, 461);
            this.tabControl1.TabIndex = 0;
            // 
            // tpEcus
            // 
            this.tpEcus.Controls.Add(this.ctrlEcus);
            this.tpEcus.Location = new System.Drawing.Point(4, 22);
            this.tpEcus.Name = "tpEcus";
            this.tpEcus.Padding = new System.Windows.Forms.Padding(3);
            this.tpEcus.Size = new System.Drawing.Size(799, 435);
            this.tpEcus.TabIndex = 0;
            this.tpEcus.Text = "ECUs";
            this.tpEcus.UseVisualStyleBackColor = true;
            // 
            // ctrlEcus
            // 
            this.ctrlEcus.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ctrlEcus.Location = new System.Drawing.Point(3, 3);
            this.ctrlEcus.Name = "ctrlEcus";
            this.ctrlEcus.Size = new System.Drawing.Size(793, 429);
            this.ctrlEcus.TabIndex = 0;
            // 
            // tpTests
            // 
            this.tpTests.Controls.Add(this.ctrlTests);
            this.tpTests.Location = new System.Drawing.Point(4, 22);
            this.tpTests.Name = "tpTests";
            this.tpTests.Padding = new System.Windows.Forms.Padding(3);
            this.tpTests.Size = new System.Drawing.Size(799, 435);
            this.tpTests.TabIndex = 1;
            this.tpTests.Text = "Tests";
            this.tpTests.UseVisualStyleBackColor = true;
            // 
            // ctrlTests
            // 
            this.ctrlTests.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ctrlTests.Location = new System.Drawing.Point(3, 3);
            this.ctrlTests.Name = "ctrlTests";
            this.ctrlTests.Size = new System.Drawing.Size(793, 429);
            this.ctrlTests.TabIndex = 0;
            // 
            // tpResults
            // 
            this.tpResults.Controls.Add(this.ctrlResults);
            this.tpResults.Location = new System.Drawing.Point(4, 22);
            this.tpResults.Name = "tpResults";
            this.tpResults.Padding = new System.Windows.Forms.Padding(3);
            this.tpResults.Size = new System.Drawing.Size(799, 435);
            this.tpResults.TabIndex = 2;
            this.tpResults.Text = "Results";
            this.tpResults.UseVisualStyleBackColor = true;
            // 
            // ctrlResults
            // 
            this.ctrlResults.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ctrlResults.Location = new System.Drawing.Point(3, 3);
            this.ctrlResults.Name = "ctrlResults";
            this.ctrlResults.Size = new System.Drawing.Size(793, 429);
            this.ctrlResults.TabIndex = 0;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(807, 461);
            this.Controls.Add(this.tabControl1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "MainForm";
            this.Text = "ATI VISION Diagnostics XML API Regression Tester";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.tabControl1.ResumeLayout(false);
            this.tpEcus.ResumeLayout(false);
            this.tpTests.ResumeLayout(false);
            this.tpResults.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tpEcus;
        private System.Windows.Forms.TabPage tpTests;
        private System.Windows.Forms.TabPage tpResults;
        private ECUs ctrlEcus;
        private Tests ctrlTests;
        private Results ctrlResults;
    }
}


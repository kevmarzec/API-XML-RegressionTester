namespace TestBuilder.Forms
{
    partial class ViewTestResult
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
            this.tbScript = new System.Windows.Forms.TextBox();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.tbOutput = new System.Windows.Forms.TextBox();
            this.tbVerified = new System.Windows.Forms.TextBox();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.ctrlParameters = new TestBuilder.Controls.EditParameters();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).BeginInit();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            this.SuspendLayout();
            // 
            // tbScript
            // 
            this.tbScript.Dock = System.Windows.Forms.DockStyle.Top;
            this.tbScript.Location = new System.Drawing.Point(0, 0);
            this.tbScript.Multiline = true;
            this.tbScript.Name = "tbScript";
            this.tbScript.ReadOnly = true;
            this.tbScript.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.tbScript.Size = new System.Drawing.Size(731, 140);
            this.tbScript.TabIndex = 1;
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.splitContainer2);
            this.splitContainer1.Panel1.Controls.Add(this.tbScript);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.ctrlParameters);
            this.splitContainer1.Size = new System.Drawing.Size(1020, 697);
            this.splitContainer1.SplitterDistance = 731;
            this.splitContainer1.TabIndex = 3;
            // 
            // tbOutput
            // 
            this.tbOutput.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbOutput.Location = new System.Drawing.Point(0, 0);
            this.tbOutput.Multiline = true;
            this.tbOutput.Name = "tbOutput";
            this.tbOutput.ReadOnly = true;
            this.tbOutput.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.tbOutput.Size = new System.Drawing.Size(731, 557);
            this.tbOutput.TabIndex = 3;
            // 
            // tbVerified
            // 
            this.tbVerified.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbVerified.Location = new System.Drawing.Point(0, 0);
            this.tbVerified.Multiline = true;
            this.tbVerified.Name = "tbVerified";
            this.tbVerified.ReadOnly = true;
            this.tbVerified.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.tbVerified.Size = new System.Drawing.Size(731, 213);
            this.tbVerified.TabIndex = 4;
            // 
            // splitContainer2
            // 
            this.splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer2.Location = new System.Drawing.Point(0, 140);
            this.splitContainer2.Name = "splitContainer2";
            this.splitContainer2.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer2.Panel1
            // 
            this.splitContainer2.Panel1.Controls.Add(this.tbOutput);
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.Controls.Add(this.tbVerified);
            this.splitContainer2.Panel2Collapsed = true;
            this.splitContainer2.Size = new System.Drawing.Size(731, 557);
            this.splitContainer2.SplitterDistance = 340;
            this.splitContainer2.TabIndex = 5;
            // 
            // ctrlParameters
            // 
            this.ctrlParameters.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ctrlParameters.Location = new System.Drawing.Point(0, 0);
            this.ctrlParameters.Name = "ctrlParameters";
            this.ctrlParameters.Size = new System.Drawing.Size(285, 697);
            this.ctrlParameters.TabIndex = 0;
            // 
            // ViewTestResult
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1020, 697);
            this.Controls.Add(this.splitContainer1);
            this.Name = "ViewTestResult";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Result Output";
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel1.PerformLayout();
            this.splitContainer2.Panel2.ResumeLayout(false);
            this.splitContainer2.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).EndInit();
            this.splitContainer2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TextBox tbScript;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.TextBox tbOutput;
        private Controls.EditParameters ctrlParameters;
        private System.Windows.Forms.SplitContainer splitContainer2;
        private System.Windows.Forms.TextBox tbVerified;
    }
}
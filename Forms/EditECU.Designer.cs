namespace TestBuilder.Forms
{
    partial class EditECU
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
            this.tbEcuName = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.gbProject = new System.Windows.Forms.GroupBox();
            this.btnSelectProjectFile = new System.Windows.Forms.Button();
            this.tbProjectEcuName = new System.Windows.Forms.TextBox();
            this.tbProjectDeviceName = new System.Windows.Forms.TextBox();
            this.tbProjectFile = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.gbManual = new System.Windows.Forms.GroupBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.tbSelectDataFile = new System.Windows.Forms.Button();
            this.cbExtended = new System.Windows.Forms.CheckBox();
            this.tbDataFile = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.tbResponse = new System.Windows.Forms.TextBox();
            this.tbRequest = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.rbProjectFile = new System.Windows.Forms.RadioButton();
            this.rbManual = new System.Windows.Forms.RadioButton();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.editParameters = new TestBuilder.Controls.EditParameters();
            this.gbProject.SuspendLayout();
            this.gbManual.SuspendLayout();
            this.SuspendLayout();
            // 
            // tbEcuName
            // 
            this.tbEcuName.Location = new System.Drawing.Point(56, 12);
            this.tbEcuName.Name = "tbEcuName";
            this.tbEcuName.Size = new System.Drawing.Size(438, 20);
            this.tbEcuName.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(38, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Name:";
            // 
            // gbProject
            // 
            this.gbProject.Controls.Add(this.btnSelectProjectFile);
            this.gbProject.Controls.Add(this.tbProjectEcuName);
            this.gbProject.Controls.Add(this.tbProjectDeviceName);
            this.gbProject.Controls.Add(this.tbProjectFile);
            this.gbProject.Controls.Add(this.label4);
            this.gbProject.Controls.Add(this.label3);
            this.gbProject.Controls.Add(this.label2);
            this.gbProject.Location = new System.Drawing.Point(15, 47);
            this.gbProject.Name = "gbProject";
            this.gbProject.Size = new System.Drawing.Size(479, 93);
            this.gbProject.TabIndex = 4;
            this.gbProject.TabStop = false;
            this.gbProject.Text = "          Use VISION Project File";
            // 
            // btnSelectProjectFile
            // 
            this.btnSelectProjectFile.Location = new System.Drawing.Point(409, 25);
            this.btnSelectProjectFile.Name = "btnSelectProjectFile";
            this.btnSelectProjectFile.Size = new System.Drawing.Size(31, 23);
            this.btnSelectProjectFile.TabIndex = 7;
            this.btnSelectProjectFile.Text = "...";
            this.btnSelectProjectFile.UseVisualStyleBackColor = true;
            this.btnSelectProjectFile.Click += new System.EventHandler(this.btnSelectProjectFile_Click);
            // 
            // tbProjectEcuName
            // 
            this.tbProjectEcuName.Location = new System.Drawing.Point(308, 57);
            this.tbProjectEcuName.Name = "tbProjectEcuName";
            this.tbProjectEcuName.Size = new System.Drawing.Size(132, 20);
            this.tbProjectEcuName.TabIndex = 5;
            // 
            // tbProjectDeviceName
            // 
            this.tbProjectDeviceName.Location = new System.Drawing.Point(111, 54);
            this.tbProjectDeviceName.Name = "tbProjectDeviceName";
            this.tbProjectDeviceName.Size = new System.Drawing.Size(124, 20);
            this.tbProjectDeviceName.TabIndex = 4;
            // 
            // tbProjectFile
            // 
            this.tbProjectFile.Location = new System.Drawing.Point(111, 25);
            this.tbProjectFile.Name = "tbProjectFile";
            this.tbProjectFile.Size = new System.Drawing.Size(291, 20);
            this.tbProjectFile.TabIndex = 3;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(239, 60);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(63, 13);
            this.label4.TabIndex = 2;
            this.label4.Text = "ECU Name:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(22, 57);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(75, 13);
            this.label3.TabIndex = 1;
            this.label3.Text = "Device Name:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(22, 28);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(62, 13);
            this.label2.TabIndex = 0;
            this.label2.Text = "Project File:";
            // 
            // gbManual
            // 
            this.gbManual.Controls.Add(this.label9);
            this.gbManual.Controls.Add(this.label8);
            this.gbManual.Controls.Add(this.tbSelectDataFile);
            this.gbManual.Controls.Add(this.cbExtended);
            this.gbManual.Controls.Add(this.tbDataFile);
            this.gbManual.Controls.Add(this.label7);
            this.gbManual.Controls.Add(this.tbResponse);
            this.gbManual.Controls.Add(this.tbRequest);
            this.gbManual.Controls.Add(this.label5);
            this.gbManual.Controls.Add(this.label6);
            this.gbManual.Enabled = false;
            this.gbManual.Location = new System.Drawing.Point(15, 151);
            this.gbManual.Name = "gbManual";
            this.gbManual.Size = new System.Drawing.Size(479, 143);
            this.gbManual.TabIndex = 5;
            this.gbManual.TabStop = false;
            this.gbManual.Text = "          Use Manual Configuration";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(108, 36);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(18, 13);
            this.label9.TabIndex = 14;
            this.label9.Text = "0x";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(324, 35);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(18, 13);
            this.label8.TabIndex = 8;
            this.label8.Text = "0x";
            // 
            // tbSelectDataFile
            // 
            this.tbSelectDataFile.Location = new System.Drawing.Point(408, 65);
            this.tbSelectDataFile.Name = "tbSelectDataFile";
            this.tbSelectDataFile.Size = new System.Drawing.Size(31, 23);
            this.tbSelectDataFile.TabIndex = 8;
            this.tbSelectDataFile.Text = "...";
            this.tbSelectDataFile.UseVisualStyleBackColor = true;
            this.tbSelectDataFile.Click += new System.EventHandler(this.tbSelectDataFile_Click);
            // 
            // cbExtended
            // 
            this.cbExtended.AutoSize = true;
            this.cbExtended.Location = new System.Drawing.Point(25, 107);
            this.cbExtended.Name = "cbExtended";
            this.cbExtended.Size = new System.Drawing.Size(71, 17);
            this.cbExtended.TabIndex = 13;
            this.cbExtended.Text = "Extended";
            this.cbExtended.UseVisualStyleBackColor = true;
            // 
            // tbDataFile
            // 
            this.tbDataFile.Location = new System.Drawing.Point(111, 67);
            this.tbDataFile.Name = "tbDataFile";
            this.tbDataFile.Size = new System.Drawing.Size(291, 20);
            this.tbDataFile.TabIndex = 12;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(22, 70);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(52, 13);
            this.label7.TabIndex = 11;
            this.label7.Text = "Data File:";
            // 
            // tbResponse
            // 
            this.tbResponse.Location = new System.Drawing.Point(343, 29);
            this.tbResponse.Name = "tbResponse";
            this.tbResponse.Size = new System.Drawing.Size(97, 20);
            this.tbResponse.TabIndex = 10;
            // 
            // tbRequest
            // 
            this.tbRequest.Location = new System.Drawing.Point(126, 29);
            this.tbRequest.Name = "tbRequest";
            this.tbRequest.Size = new System.Drawing.Size(109, 20);
            this.tbRequest.TabIndex = 9;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(239, 35);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(83, 13);
            this.label5.TabIndex = 8;
            this.label5.Text = "Response Addr:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(22, 32);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(75, 13);
            this.label6.TabIndex = 7;
            this.label6.Text = "Request Addr:";
            // 
            // rbProjectFile
            // 
            this.rbProjectFile.AutoSize = true;
            this.rbProjectFile.Checked = true;
            this.rbProjectFile.Location = new System.Drawing.Point(32, 47);
            this.rbProjectFile.Name = "rbProjectFile";
            this.rbProjectFile.Size = new System.Drawing.Size(14, 13);
            this.rbProjectFile.TabIndex = 6;
            this.rbProjectFile.TabStop = true;
            this.rbProjectFile.UseVisualStyleBackColor = true;
            this.rbProjectFile.CheckedChanged += new System.EventHandler(this.rbProjectFile_CheckedChanged);
            // 
            // rbManual
            // 
            this.rbManual.AutoSize = true;
            this.rbManual.Enabled = false;
            this.rbManual.Location = new System.Drawing.Point(32, 150);
            this.rbManual.Name = "rbManual";
            this.rbManual.Size = new System.Drawing.Size(14, 13);
            this.rbManual.TabIndex = 7;
            this.rbManual.UseVisualStyleBackColor = true;
            this.rbManual.CheckedChanged += new System.EventHandler(this.rbManual_CheckedChanged);
            // 
            // btnCancel
            // 
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(15, 300);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(479, 32);
            this.btnCancel.TabIndex = 7;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // btnSave
            // 
            this.btnSave.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnSave.Location = new System.Drawing.Point(500, 300);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(468, 32);
            this.btnSave.TabIndex = 6;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // editParameters
            // 
            this.editParameters.Location = new System.Drawing.Point(500, 2);
            this.editParameters.Name = "editParameters";
            this.editParameters.Size = new System.Drawing.Size(468, 292);
            this.editParameters.TabIndex = 8;
            // 
            // EditECU
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(980, 340);
            this.Controls.Add(this.editParameters);
            this.Controls.Add(this.rbProjectFile);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.rbManual);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.gbManual);
            this.Controls.Add(this.gbProject);
            this.Controls.Add(this.tbEcuName);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "EditECU";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Add ECU";
            this.Load += new System.EventHandler(this.EditECU_Load);
            this.gbProject.ResumeLayout(false);
            this.gbProject.PerformLayout();
            this.gbManual.ResumeLayout(false);
            this.gbManual.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox tbEcuName;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox gbProject;
        private System.Windows.Forms.RadioButton rbProjectFile;
        private System.Windows.Forms.TextBox tbProjectEcuName;
        private System.Windows.Forms.TextBox tbProjectDeviceName;
        private System.Windows.Forms.TextBox tbProjectFile;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox gbManual;
        private System.Windows.Forms.TextBox tbDataFile;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox tbResponse;
        private System.Windows.Forms.RadioButton rbManual;
        private System.Windows.Forms.TextBox tbRequest;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button btnSelectProjectFile;
        private System.Windows.Forms.Button tbSelectDataFile;
        private System.Windows.Forms.CheckBox cbExtended;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private Controls.EditParameters editParameters;
    }
}
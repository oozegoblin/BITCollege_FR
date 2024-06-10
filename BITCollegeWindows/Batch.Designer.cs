namespace BITCollegeWindows
{
    partial class Batch
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
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.Label descriptionLabel;
            this.grpSelect = new System.Windows.Forms.GroupBox();
            this.descriptionComboBox = new System.Windows.Forms.ComboBox();
            this.academicProgramBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.lnkProcess = new System.Windows.Forms.LinkLabel();
            this.txtKey = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.radSelect = new System.Windows.Forms.RadioButton();
            this.radAll = new System.Windows.Forms.RadioButton();
            this.label2 = new System.Windows.Forms.Label();
            this.rtxtLog = new System.Windows.Forms.RichTextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.fileNametxtbox = new System.Windows.Forms.TextBox();
            this.decryptbtb = new System.Windows.Forms.Button();
            descriptionLabel = new System.Windows.Forms.Label();
            this.grpSelect.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.academicProgramBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // descriptionLabel
            // 
            descriptionLabel.AutoSize = true;
            descriptionLabel.Location = new System.Drawing.Point(26, 139);
            descriptionLabel.Name = "descriptionLabel";
            descriptionLabel.Size = new System.Drawing.Size(73, 20);
            descriptionLabel.TabIndex = 5;
            descriptionLabel.Text = "Program:";
            // 
            // grpSelect
            // 
            this.grpSelect.Controls.Add(this.decryptbtb);
            this.grpSelect.Controls.Add(this.fileNametxtbox);
            this.grpSelect.Controls.Add(this.label3);
            this.grpSelect.Controls.Add(descriptionLabel);
            this.grpSelect.Controls.Add(this.descriptionComboBox);
            this.grpSelect.Controls.Add(this.lnkProcess);
            this.grpSelect.Controls.Add(this.txtKey);
            this.grpSelect.Controls.Add(this.label1);
            this.grpSelect.Controls.Add(this.radSelect);
            this.grpSelect.Controls.Add(this.radAll);
            this.grpSelect.Location = new System.Drawing.Point(37, 35);
            this.grpSelect.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.grpSelect.Name = "grpSelect";
            this.grpSelect.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.grpSelect.Size = new System.Drawing.Size(786, 289);
            this.grpSelect.TabIndex = 0;
            this.grpSelect.TabStop = false;
            this.grpSelect.Text = "Batch Selection";
            // 
            // descriptionComboBox
            // 
            this.descriptionComboBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.academicProgramBindingSource, "Description", true));
            this.descriptionComboBox.DataSource = this.academicProgramBindingSource;
            this.descriptionComboBox.DisplayMember = "Description";
            this.descriptionComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.descriptionComboBox.FormattingEnabled = true;
            this.descriptionComboBox.Location = new System.Drawing.Point(118, 136);
            this.descriptionComboBox.Name = "descriptionComboBox";
            this.descriptionComboBox.Size = new System.Drawing.Size(226, 28);
            this.descriptionComboBox.TabIndex = 6;
            this.descriptionComboBox.ValueMember = "ProgramAcronym";
            // 
            // academicProgramBindingSource
            // 
            this.academicProgramBindingSource.DataSource = typeof(BITCollege_Felipe_Rincon.Models.AcademicProgram);
            // 
            // lnkProcess
            // 
            this.lnkProcess.AutoSize = true;
            this.lnkProcess.Location = new System.Drawing.Point(26, 236);
            this.lnkProcess.Name = "lnkProcess";
            this.lnkProcess.Size = new System.Drawing.Size(112, 20);
            this.lnkProcess.TabIndex = 4;
            this.lnkProcess.TabStop = true;
            this.lnkProcess.Text = "Process Batch";
            this.lnkProcess.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnkProcess_LinkClicked);
            // 
            // txtKey
            // 
            this.txtKey.Location = new System.Drawing.Point(585, 82);
            this.txtKey.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtKey.Name = "txtKey";
            this.txtKey.PasswordChar = '*';
            this.txtKey.Size = new System.Drawing.Size(112, 26);
            this.txtKey.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(600, 41);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(82, 20);
            this.label1.TabIndex = 2;
            this.label1.Text = "Enter Key:";
            // 
            // radSelect
            // 
            this.radSelect.AutoSize = true;
            this.radSelect.Location = new System.Drawing.Point(26, 82);
            this.radSelect.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.radSelect.Name = "radSelect";
            this.radSelect.Size = new System.Drawing.Size(318, 24);
            this.radSelect.TabIndex = 1;
            this.radSelect.TabStop = true;
            this.radSelect.Text = "Select a Program to Grade and Register";
            this.radSelect.UseVisualStyleBackColor = true;
            // 
            // radAll
            // 
            this.radAll.AutoSize = true;
            this.radAll.Location = new System.Drawing.Point(26, 41);
            this.radAll.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.radAll.Name = "radAll";
            this.radAll.Size = new System.Drawing.Size(302, 24);
            this.radAll.TabIndex = 0;
            this.radAll.TabStop = true;
            this.radAll.Text = "Grade and Register for ALL Programs";
            this.radAll.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(37, 354);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(40, 20);
            this.label2.TabIndex = 1;
            this.label2.Text = "Log:";
            // 
            // rtxtLog
            // 
            this.rtxtLog.Location = new System.Drawing.Point(37, 399);
            this.rtxtLog.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.rtxtLog.Name = "rtxtLog";
            this.rtxtLog.Size = new System.Drawing.Size(786, 298);
            this.rtxtLog.TabIndex = 2;
            this.rtxtLog.Text = "";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(428, 41);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(84, 20);
            this.label3.TabIndex = 7;
            this.label3.Text = "File Name:";
            // 
            // fileNametxtbox
            // 
            this.fileNametxtbox.Location = new System.Drawing.Point(420, 82);
            this.fileNametxtbox.Name = "fileNametxtbox";
            this.fileNametxtbox.Size = new System.Drawing.Size(112, 26);
            this.fileNametxtbox.TabIndex = 8;
            // 
            // decryptbtb
            // 
            this.decryptbtb.Location = new System.Drawing.Point(509, 129);
            this.decryptbtb.Name = "decryptbtb";
            this.decryptbtb.Size = new System.Drawing.Size(100, 40);
            this.decryptbtb.TabIndex = 9;
            this.decryptbtb.Text = "Decrypt";
            this.decryptbtb.UseVisualStyleBackColor = true;
            this.decryptbtb.Click += new System.EventHandler(this.decryptbtb_Click);
            // 
            // Batch
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(868, 756);
            this.Controls.Add(this.rtxtLog);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.grpSelect);
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "Batch";
            this.Text = "Batch Student Update";
            this.Load += new System.EventHandler(this.Batch_Load);
            this.grpSelect.ResumeLayout(false);
            this.grpSelect.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.academicProgramBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox grpSelect;
        private System.Windows.Forms.LinkLabel lnkProcess;
        private System.Windows.Forms.TextBox txtKey;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.RadioButton radSelect;
        private System.Windows.Forms.RadioButton radAll;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.RichTextBox rtxtLog;
        private System.Windows.Forms.ComboBox descriptionComboBox;
        private System.Windows.Forms.BindingSource academicProgramBindingSource;
        private System.Windows.Forms.Button decryptbtb;
        private System.Windows.Forms.TextBox fileNametxtbox;
        private System.Windows.Forms.Label label3;
    }
}
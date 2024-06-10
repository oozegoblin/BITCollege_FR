namespace BITCollegeWindows
{
    partial class History
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
            System.Windows.Forms.Label studentNumberLabel;
            System.Windows.Forms.Label descriptionLabel;
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.gbStudent = new System.Windows.Forms.GroupBox();
            this.descriptionLabel1 = new System.Windows.Forms.Label();
            this.studentBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.fullNameLabel1 = new System.Windows.Forms.Label();
            this.studentNumberMaskedLabel = new EWSoftware.MaskedLabelControl.MaskedLabel();
            this.registrationBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.lnkReturn = new System.Windows.Forms.LinkLabel();
            this.registrationDataGridView = new System.Windows.Forms.DataGridView();
            this.registrationIdDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.studentIdDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.courseIdDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.registrationNumberDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.registrationDateDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gradeDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.notesDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.studentDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.courseDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Course = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            studentNumberLabel = new System.Windows.Forms.Label();
            descriptionLabel = new System.Windows.Forms.Label();
            this.gbStudent.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.studentBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.registrationBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.registrationDataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // studentNumberLabel
            // 
            studentNumberLabel.AutoSize = true;
            studentNumberLabel.Location = new System.Drawing.Point(66, 57);
            studentNumberLabel.Name = "studentNumberLabel";
            studentNumberLabel.Size = new System.Drawing.Size(130, 20);
            studentNumberLabel.TabIndex = 0;
            studentNumberLabel.Text = "Student Number:";
            // 
            // descriptionLabel
            // 
            descriptionLabel.AutoSize = true;
            descriptionLabel.Location = new System.Drawing.Point(66, 116);
            descriptionLabel.Name = "descriptionLabel";
            descriptionLabel.Size = new System.Drawing.Size(73, 20);
            descriptionLabel.TabIndex = 3;
            descriptionLabel.Text = "Program:";
            // 
            // gbStudent
            // 
            this.gbStudent.Controls.Add(descriptionLabel);
            this.gbStudent.Controls.Add(this.descriptionLabel1);
            this.gbStudent.Controls.Add(this.fullNameLabel1);
            this.gbStudent.Controls.Add(studentNumberLabel);
            this.gbStudent.Controls.Add(this.studentNumberMaskedLabel);
            this.gbStudent.Location = new System.Drawing.Point(38, 29);
            this.gbStudent.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.gbStudent.Name = "gbStudent";
            this.gbStudent.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.gbStudent.Size = new System.Drawing.Size(812, 213);
            this.gbStudent.TabIndex = 1;
            this.gbStudent.TabStop = false;
            this.gbStudent.Text = "Student Data";
            // 
            // descriptionLabel1
            // 
            this.descriptionLabel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.descriptionLabel1.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.studentBindingSource, "AcademicProgram.Description", true));
            this.descriptionLabel1.Location = new System.Drawing.Point(202, 115);
            this.descriptionLabel1.Name = "descriptionLabel1";
            this.descriptionLabel1.Size = new System.Drawing.Size(298, 32);
            this.descriptionLabel1.TabIndex = 4;
            // 
            // studentBindingSource
            // 
            this.studentBindingSource.DataSource = typeof(BITCollege_Felipe_Rincon.Models.Student);
            // 
            // fullNameLabel1
            // 
            this.fullNameLabel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.fullNameLabel1.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.studentBindingSource, "FullName", true));
            this.fullNameLabel1.Location = new System.Drawing.Point(388, 57);
            this.fullNameLabel1.Name = "fullNameLabel1";
            this.fullNameLabel1.Size = new System.Drawing.Size(306, 32);
            this.fullNameLabel1.TabIndex = 3;
            // 
            // studentNumberMaskedLabel
            // 
            this.studentNumberMaskedLabel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.studentNumberMaskedLabel.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.studentBindingSource, "StudentNumber", true));
            this.studentNumberMaskedLabel.Location = new System.Drawing.Point(202, 57);
            this.studentNumberMaskedLabel.Mask = "0000-0000";
            this.studentNumberMaskedLabel.Name = "studentNumberMaskedLabel";
            this.studentNumberMaskedLabel.Size = new System.Drawing.Size(169, 32);
            this.studentNumberMaskedLabel.TabIndex = 1;
            this.studentNumberMaskedLabel.Text = "    -";
            // 
            // registrationBindingSource
            // 
            this.registrationBindingSource.DataSource = typeof(BITCollege_Felipe_Rincon.Models.Registration);
            // 
            // lnkReturn
            // 
            this.lnkReturn.AutoSize = true;
            this.lnkReturn.Location = new System.Drawing.Point(358, 660);
            this.lnkReturn.Name = "lnkReturn";
            this.lnkReturn.Size = new System.Drawing.Size(176, 20);
            this.lnkReturn.TabIndex = 2;
            this.lnkReturn.TabStop = true;
            this.lnkReturn.Text = "Return to Student Data";
            this.lnkReturn.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnkReturn_LinkClicked);
            // 
            // registrationDataGridView
            // 
            this.registrationDataGridView.AllowUserToAddRows = false;
            this.registrationDataGridView.AllowUserToDeleteRows = false;
            this.registrationDataGridView.AutoGenerateColumns = false;
            this.registrationDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.registrationDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn4,
            this.dataGridViewTextBoxColumn5,
            this.Course,
            this.dataGridViewTextBoxColumn6,
            this.dataGridViewTextBoxColumn7});
            this.registrationDataGridView.DataSource = this.registrationBindingSource;
            this.registrationDataGridView.Location = new System.Drawing.Point(59, 258);
            this.registrationDataGridView.Name = "registrationDataGridView";
            this.registrationDataGridView.ReadOnly = true;
            this.registrationDataGridView.RowHeadersWidth = 62;
            this.registrationDataGridView.RowTemplate.Height = 28;
            this.registrationDataGridView.Size = new System.Drawing.Size(777, 269);
            this.registrationDataGridView.TabIndex = 5;
            // 
            // registrationIdDataGridViewTextBoxColumn
            // 
            this.registrationIdDataGridViewTextBoxColumn.DataPropertyName = "RegistrationId";
            this.registrationIdDataGridViewTextBoxColumn.HeaderText = "RegistrationId";
            this.registrationIdDataGridViewTextBoxColumn.MinimumWidth = 8;
            this.registrationIdDataGridViewTextBoxColumn.Name = "registrationIdDataGridViewTextBoxColumn";
            this.registrationIdDataGridViewTextBoxColumn.Width = 150;
            // 
            // studentIdDataGridViewTextBoxColumn
            // 
            this.studentIdDataGridViewTextBoxColumn.DataPropertyName = "StudentId";
            this.studentIdDataGridViewTextBoxColumn.HeaderText = "StudentId";
            this.studentIdDataGridViewTextBoxColumn.MinimumWidth = 8;
            this.studentIdDataGridViewTextBoxColumn.Name = "studentIdDataGridViewTextBoxColumn";
            this.studentIdDataGridViewTextBoxColumn.Width = 150;
            // 
            // courseIdDataGridViewTextBoxColumn
            // 
            this.courseIdDataGridViewTextBoxColumn.DataPropertyName = "CourseId";
            this.courseIdDataGridViewTextBoxColumn.HeaderText = "CourseId";
            this.courseIdDataGridViewTextBoxColumn.MinimumWidth = 8;
            this.courseIdDataGridViewTextBoxColumn.Name = "courseIdDataGridViewTextBoxColumn";
            this.courseIdDataGridViewTextBoxColumn.Width = 150;
            // 
            // registrationNumberDataGridViewTextBoxColumn
            // 
            this.registrationNumberDataGridViewTextBoxColumn.DataPropertyName = "RegistrationNumber";
            this.registrationNumberDataGridViewTextBoxColumn.HeaderText = "RegistrationNumber";
            this.registrationNumberDataGridViewTextBoxColumn.MinimumWidth = 8;
            this.registrationNumberDataGridViewTextBoxColumn.Name = "registrationNumberDataGridViewTextBoxColumn";
            this.registrationNumberDataGridViewTextBoxColumn.Width = 150;
            // 
            // registrationDateDataGridViewTextBoxColumn
            // 
            this.registrationDateDataGridViewTextBoxColumn.DataPropertyName = "RegistrationDate";
            this.registrationDateDataGridViewTextBoxColumn.HeaderText = "RegistrationDate";
            this.registrationDateDataGridViewTextBoxColumn.MinimumWidth = 8;
            this.registrationDateDataGridViewTextBoxColumn.Name = "registrationDateDataGridViewTextBoxColumn";
            this.registrationDateDataGridViewTextBoxColumn.Width = 150;
            // 
            // gradeDataGridViewTextBoxColumn
            // 
            this.gradeDataGridViewTextBoxColumn.DataPropertyName = "Grade";
            this.gradeDataGridViewTextBoxColumn.HeaderText = "Grade";
            this.gradeDataGridViewTextBoxColumn.MinimumWidth = 8;
            this.gradeDataGridViewTextBoxColumn.Name = "gradeDataGridViewTextBoxColumn";
            this.gradeDataGridViewTextBoxColumn.Width = 150;
            // 
            // notesDataGridViewTextBoxColumn
            // 
            this.notesDataGridViewTextBoxColumn.DataPropertyName = "Notes";
            this.notesDataGridViewTextBoxColumn.HeaderText = "Notes";
            this.notesDataGridViewTextBoxColumn.MinimumWidth = 8;
            this.notesDataGridViewTextBoxColumn.Name = "notesDataGridViewTextBoxColumn";
            this.notesDataGridViewTextBoxColumn.Width = 150;
            // 
            // studentDataGridViewTextBoxColumn
            // 
            this.studentDataGridViewTextBoxColumn.DataPropertyName = "Student";
            this.studentDataGridViewTextBoxColumn.HeaderText = "Student";
            this.studentDataGridViewTextBoxColumn.MinimumWidth = 8;
            this.studentDataGridViewTextBoxColumn.Name = "studentDataGridViewTextBoxColumn";
            this.studentDataGridViewTextBoxColumn.Width = 150;
            // 
            // courseDataGridViewTextBoxColumn
            // 
            this.courseDataGridViewTextBoxColumn.DataPropertyName = "Course";
            this.courseDataGridViewTextBoxColumn.HeaderText = "Course";
            this.courseDataGridViewTextBoxColumn.MinimumWidth = 8;
            this.courseDataGridViewTextBoxColumn.Name = "courseDataGridViewTextBoxColumn";
            this.courseDataGridViewTextBoxColumn.Width = 150;
            // 
            // dataGridViewTextBoxColumn4
            // 
            this.dataGridViewTextBoxColumn4.DataPropertyName = "RegistrationNumber";
            this.dataGridViewTextBoxColumn4.HeaderText = "Registration Number";
            this.dataGridViewTextBoxColumn4.MinimumWidth = 8;
            this.dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
            this.dataGridViewTextBoxColumn4.ReadOnly = true;
            this.dataGridViewTextBoxColumn4.Width = 150;
            // 
            // dataGridViewTextBoxColumn5
            // 
            this.dataGridViewTextBoxColumn5.DataPropertyName = "RegistrationDate";
            dataGridViewCellStyle1.Format = "MM/dd/yyyy";
            this.dataGridViewTextBoxColumn5.DefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridViewTextBoxColumn5.HeaderText = "Date";
            this.dataGridViewTextBoxColumn5.MinimumWidth = 8;
            this.dataGridViewTextBoxColumn5.Name = "dataGridViewTextBoxColumn5";
            this.dataGridViewTextBoxColumn5.ReadOnly = true;
            this.dataGridViewTextBoxColumn5.Width = 150;
            // 
            // Course
            // 
            this.Course.DataPropertyName = "Title";
            this.Course.HeaderText = "Course";
            this.Course.MinimumWidth = 8;
            this.Course.Name = "Course";
            this.Course.ReadOnly = true;
            this.Course.Width = 150;
            // 
            // dataGridViewTextBoxColumn6
            // 
            this.dataGridViewTextBoxColumn6.DataPropertyName = "Grade";
            dataGridViewCellStyle2.Format = "P2";
            this.dataGridViewTextBoxColumn6.DefaultCellStyle = dataGridViewCellStyle2;
            this.dataGridViewTextBoxColumn6.HeaderText = "Grade";
            this.dataGridViewTextBoxColumn6.MinimumWidth = 8;
            this.dataGridViewTextBoxColumn6.Name = "dataGridViewTextBoxColumn6";
            this.dataGridViewTextBoxColumn6.ReadOnly = true;
            this.dataGridViewTextBoxColumn6.Width = 150;
            // 
            // dataGridViewTextBoxColumn7
            // 
            this.dataGridViewTextBoxColumn7.DataPropertyName = "Notes";
            this.dataGridViewTextBoxColumn7.HeaderText = "Notes";
            this.dataGridViewTextBoxColumn7.MinimumWidth = 8;
            this.dataGridViewTextBoxColumn7.Name = "dataGridViewTextBoxColumn7";
            this.dataGridViewTextBoxColumn7.ReadOnly = true;
            this.dataGridViewTextBoxColumn7.Width = 150;
            // 
            // History
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(900, 725);
            this.Controls.Add(this.registrationDataGridView);
            this.Controls.Add(this.lnkReturn);
            this.Controls.Add(this.gbStudent);
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "History";
            this.Text = "Student Registraton History";
            this.Load += new System.EventHandler(this.History_Load);
            this.gbStudent.ResumeLayout(false);
            this.gbStudent.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.studentBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.registrationBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.registrationDataGridView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox gbStudent;
        private System.Windows.Forms.LinkLabel lnkReturn;
        private EWSoftware.MaskedLabelControl.MaskedLabel studentNumberMaskedLabel;
        private System.Windows.Forms.BindingSource studentBindingSource;
        private System.Windows.Forms.Label fullNameLabel1;
        private System.Windows.Forms.Label descriptionLabel1;
        private System.Windows.Forms.BindingSource registrationBindingSource;
        private System.Windows.Forms.DataGridView registrationDataGridView;
        private System.Windows.Forms.DataGridViewTextBoxColumn registrationIdDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn studentIdDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn courseIdDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn registrationNumberDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn registrationDateDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn gradeDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn notesDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn studentDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn courseDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn9;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn5;
        private System.Windows.Forms.DataGridViewTextBoxColumn Course;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn6;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn7;
    }
}
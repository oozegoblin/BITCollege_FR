using System;
using System.Windows.Forms;

namespace BITCollegeWindows
{
    /*
* Name: Felipe Rincon
* Course: COMP-1283 C# Programming 4
* Created: 2024-05-05
* Updated: 2024-05-09
*/
    partial class StudentData
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
            System.Windows.Forms.Label cityLabel;
            System.Windows.Forms.Label registrationDateLabel;
            System.Windows.Forms.Label dateCreatedLabel;
            System.Windows.Forms.Label fullNameLabel;
            System.Windows.Forms.Label provinceLabel;
            System.Windows.Forms.Label postalCodeLabel;
            System.Windows.Forms.Label outstandingFeesLabel;
            System.Windows.Forms.Label gradePointAverageLabel;
            System.Windows.Forms.Label registrationNumberLabel;
            System.Windows.Forms.Label courseNumberLabel;
            System.Windows.Forms.Label creditHoursLabel;
            System.Windows.Forms.Label addressLabel;
            System.Windows.Forms.Label titleLabel;
            this.lnkDetails = new System.Windows.Forms.LinkLabel();
            this.lnkUpdate = new System.Windows.Forms.LinkLabel();
            this.lblReader = new System.Windows.Forms.Label();
            this.grpStudent = new System.Windows.Forms.GroupBox();
            this.addressLabel1 = new System.Windows.Forms.Label();
            this.studentBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.descriptionLabel2 = new System.Windows.Forms.Label();
            this.gradePointAverageLabel1 = new System.Windows.Forms.Label();
            this.outstandingFeesLabel1 = new System.Windows.Forms.Label();
            this.postalCodeMaskedLabel = new EWSoftware.MaskedLabelControl.MaskedLabel();
            this.provinceMaskedLabel = new EWSoftware.MaskedLabelControl.MaskedLabel();
            this.fullNameLabel1 = new System.Windows.Forms.Label();
            this.dateCreatedLabel1 = new System.Windows.Forms.Label();
            this.registrationDateLabel1 = new System.Windows.Forms.Label();
            this.registrationBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.lblCity = new System.Windows.Forms.Label();
            this.studentNumberMaskedTextBox = new System.Windows.Forms.MaskedTextBox();
            this.grpRegistration = new System.Windows.Forms.GroupBox();
            this.titleLabel2 = new System.Windows.Forms.Label();
            this.creditHoursLabel1 = new System.Windows.Forms.Label();
            this.titleLabel1 = new System.Windows.Forms.Label();
            this.courseNumberLabel1 = new System.Windows.Forms.Label();
            this.registrationNumberComboBox = new System.Windows.Forms.ComboBox();
            studentNumberLabel = new System.Windows.Forms.Label();
            cityLabel = new System.Windows.Forms.Label();
            registrationDateLabel = new System.Windows.Forms.Label();
            dateCreatedLabel = new System.Windows.Forms.Label();
            fullNameLabel = new System.Windows.Forms.Label();
            provinceLabel = new System.Windows.Forms.Label();
            postalCodeLabel = new System.Windows.Forms.Label();
            outstandingFeesLabel = new System.Windows.Forms.Label();
            gradePointAverageLabel = new System.Windows.Forms.Label();
            registrationNumberLabel = new System.Windows.Forms.Label();
            courseNumberLabel = new System.Windows.Forms.Label();
            creditHoursLabel = new System.Windows.Forms.Label();
            addressLabel = new System.Windows.Forms.Label();
            titleLabel = new System.Windows.Forms.Label();
            this.grpStudent.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.studentBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.registrationBindingSource)).BeginInit();
            this.grpRegistration.SuspendLayout();
            this.SuspendLayout();
            // 
            // studentNumberLabel
            // 
            studentNumberLabel.AutoSize = true;
            studentNumberLabel.Location = new System.Drawing.Point(40, 64);
            studentNumberLabel.Name = "studentNumberLabel";
            studentNumberLabel.Size = new System.Drawing.Size(130, 20);
            studentNumberLabel.TabIndex = 21;
            studentNumberLabel.Text = "Student Number:";
            // 
            // cityLabel
            // 
            cityLabel.AutoSize = true;
            cityLabel.Location = new System.Drawing.Point(40, 223);
            cityLabel.Name = "cityLabel";
            cityLabel.Size = new System.Drawing.Size(39, 20);
            cityLabel.TabIndex = 22;
            cityLabel.Text = "City:";
            // 
            // registrationDateLabel
            // 
            registrationDateLabel.AutoSize = true;
            registrationDateLabel.Location = new System.Drawing.Point(287, 325);
            registrationDateLabel.Name = "registrationDateLabel";
            registrationDateLabel.Size = new System.Drawing.Size(0, 20);
            registrationDateLabel.TabIndex = 23;
            // 
            // dateCreatedLabel
            // 
            dateCreatedLabel.AutoSize = true;
            dateCreatedLabel.Location = new System.Drawing.Point(40, 287);
            dateCreatedLabel.Name = "dateCreatedLabel";
            dateCreatedLabel.Size = new System.Drawing.Size(109, 20);
            dateCreatedLabel.TabIndex = 24;
            dateCreatedLabel.Text = "Date Created:";
            // 
            // fullNameLabel
            // 
            fullNameLabel.AutoSize = true;
            fullNameLabel.Location = new System.Drawing.Point(40, 119);
            fullNameLabel.Name = "fullNameLabel";
            fullNameLabel.Size = new System.Drawing.Size(84, 20);
            fullNameLabel.TabIndex = 25;
            fullNameLabel.Text = "Full Name:";
            // 
            // provinceLabel
            // 
            provinceLabel.AutoSize = true;
            provinceLabel.Location = new System.Drawing.Point(376, 232);
            provinceLabel.Name = "provinceLabel";
            provinceLabel.Size = new System.Drawing.Size(73, 20);
            provinceLabel.TabIndex = 27;
            provinceLabel.Text = "Province:";
            // 
            // postalCodeLabel
            // 
            postalCodeLabel.AutoSize = true;
            postalCodeLabel.Location = new System.Drawing.Point(640, 232);
            postalCodeLabel.Name = "postalCodeLabel";
            postalCodeLabel.Size = new System.Drawing.Size(99, 20);
            postalCodeLabel.TabIndex = 28;
            postalCodeLabel.Text = "Postal Code:";
            // 
            // outstandingFeesLabel
            // 
            outstandingFeesLabel.AutoSize = true;
            outstandingFeesLabel.Location = new System.Drawing.Point(376, 287);
            outstandingFeesLabel.Name = "outstandingFeesLabel";
            outstandingFeesLabel.Size = new System.Drawing.Size(140, 20);
            outstandingFeesLabel.TabIndex = 29;
            outstandingFeesLabel.Text = "Outstanding Fees:";
            // 
            // gradePointAverageLabel
            // 
            gradePointAverageLabel.AutoSize = true;
            gradePointAverageLabel.Location = new System.Drawing.Point(40, 339);
            gradePointAverageLabel.Name = "gradePointAverageLabel";
            gradePointAverageLabel.Size = new System.Drawing.Size(161, 20);
            gradePointAverageLabel.TabIndex = 30;
            gradePointAverageLabel.Text = "Grade Point Average:";
            // 
            // registrationNumberLabel
            // 
            registrationNumberLabel.AutoSize = true;
            registrationNumberLabel.Location = new System.Drawing.Point(40, 52);
            registrationNumberLabel.Name = "registrationNumberLabel";
            registrationNumberLabel.Size = new System.Drawing.Size(159, 20);
            registrationNumberLabel.TabIndex = 0;
            registrationNumberLabel.Text = "Registration Number:";
            // 
            // courseNumberLabel
            // 
            courseNumberLabel.AutoSize = true;
            courseNumberLabel.Location = new System.Drawing.Point(40, 119);
            courseNumberLabel.Name = "courseNumberLabel";
            courseNumberLabel.Size = new System.Drawing.Size(124, 20);
            courseNumberLabel.TabIndex = 2;
            courseNumberLabel.Text = "Course Number:";
            // 
            // creditHoursLabel
            // 
            creditHoursLabel.AutoSize = true;
            creditHoursLabel.Location = new System.Drawing.Point(40, 184);
            creditHoursLabel.Name = "creditHoursLabel";
            creditHoursLabel.Size = new System.Drawing.Size(102, 20);
            creditHoursLabel.TabIndex = 6;
            creditHoursLabel.Text = "Credit Hours:";
            // 
            // addressLabel
            // 
            addressLabel.AutoSize = true;
            addressLabel.Location = new System.Drawing.Point(40, 171);
            addressLabel.Name = "addressLabel";
            addressLabel.Size = new System.Drawing.Size(72, 20);
            addressLabel.TabIndex = 33;
            addressLabel.Text = "Address:";
            // 
            // titleLabel
            // 
            titleLabel.AutoSize = true;
            titleLabel.Location = new System.Drawing.Point(421, 119);
            titleLabel.Name = "titleLabel";
            titleLabel.Size = new System.Drawing.Size(42, 20);
            titleLabel.TabIndex = 8;
            titleLabel.Text = "Title:";
            // 
            // lnkDetails
            // 
            this.lnkDetails.AutoSize = true;
            this.lnkDetails.Location = new System.Drawing.Point(512, 844);
            this.lnkDetails.Name = "lnkDetails";
            this.lnkDetails.Size = new System.Drawing.Size(96, 20);
            this.lnkDetails.TabIndex = 5;
            this.lnkDetails.TabStop = true;
            this.lnkDetails.Text = "View Details";
            this.lnkDetails.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnkDetails_LinkClicked);
            // 
            // lnkUpdate
            // 
            this.lnkUpdate.AutoSize = true;
            this.lnkUpdate.Location = new System.Drawing.Point(246, 844);
            this.lnkUpdate.Name = "lnkUpdate";
            this.lnkUpdate.Size = new System.Drawing.Size(111, 20);
            this.lnkUpdate.TabIndex = 4;
            this.lnkUpdate.TabStop = true;
            this.lnkUpdate.Text = "Update Grade";
            this.lnkUpdate.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnkUpdate_LinkClicked);
            // 
            // lblReader
            // 
            this.lblReader.AutoSize = true;
            this.lblReader.ForeColor = System.Drawing.Color.Red;
            this.lblReader.Location = new System.Drawing.Point(465, 64);
            this.lblReader.Name = "lblReader";
            this.lblReader.Size = new System.Drawing.Size(286, 20);
            this.lblReader.TabIndex = 6;
            this.lblReader.Text = "RFID Unavailable - Enter Student Data";
            // 
            // grpStudent
            // 
            this.grpStudent.Controls.Add(addressLabel);
            this.grpStudent.Controls.Add(this.addressLabel1);
            this.grpStudent.Controls.Add(this.descriptionLabel2);
            this.grpStudent.Controls.Add(gradePointAverageLabel);
            this.grpStudent.Controls.Add(this.gradePointAverageLabel1);
            this.grpStudent.Controls.Add(outstandingFeesLabel);
            this.grpStudent.Controls.Add(this.outstandingFeesLabel1);
            this.grpStudent.Controls.Add(postalCodeLabel);
            this.grpStudent.Controls.Add(this.postalCodeMaskedLabel);
            this.grpStudent.Controls.Add(provinceLabel);
            this.grpStudent.Controls.Add(this.provinceMaskedLabel);
            this.grpStudent.Controls.Add(this.fullNameLabel1);
            this.grpStudent.Controls.Add(fullNameLabel);
            this.grpStudent.Controls.Add(dateCreatedLabel);
            this.grpStudent.Controls.Add(this.dateCreatedLabel1);
            this.grpStudent.Controls.Add(registrationDateLabel);
            this.grpStudent.Controls.Add(this.registrationDateLabel1);
            this.grpStudent.Controls.Add(cityLabel);
            this.grpStudent.Controls.Add(this.lblCity);
            this.grpStudent.Controls.Add(studentNumberLabel);
            this.grpStudent.Controls.Add(this.studentNumberMaskedTextBox);
            this.grpStudent.Controls.Add(this.lblReader);
            this.grpStudent.Location = new System.Drawing.Point(47, 54);
            this.grpStudent.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.grpStudent.Name = "grpStudent";
            this.grpStudent.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.grpStudent.Size = new System.Drawing.Size(968, 441);
            this.grpStudent.TabIndex = 7;
            this.grpStudent.TabStop = false;
            this.grpStudent.Text = "Student Data";
            // 
            // addressLabel1
            // 
            this.addressLabel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.addressLabel1.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.studentBindingSource, "Address", true));
            this.addressLabel1.Location = new System.Drawing.Point(210, 171);
            this.addressLabel1.Name = "addressLabel1";
            this.addressLabel1.Size = new System.Drawing.Size(677, 32);
            this.addressLabel1.TabIndex = 34;
            // 
            // studentBindingSource
            // 
            this.studentBindingSource.DataSource = typeof(BITCollege_Felipe_Rincon.Models.Student);
            // 
            // descriptionLabel2
            // 
            this.descriptionLabel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.descriptionLabel2.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.studentBindingSource, "GradePointState.Description", true));
            this.descriptionLabel2.Location = new System.Drawing.Point(380, 327);
            this.descriptionLabel2.Name = "descriptionLabel2";
            this.descriptionLabel2.Size = new System.Drawing.Size(189, 32);
            this.descriptionLabel2.TabIndex = 33;
            // 
            // gradePointAverageLabel1
            // 
            this.gradePointAverageLabel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.gradePointAverageLabel1.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.studentBindingSource, "GradePointAverage", true, DataSourceUpdateMode.OnValidation, null, "P2"));
            this.gradePointAverageLabel1.Location = new System.Drawing.Point(211, 327);
            this.gradePointAverageLabel1.Name = "gradePointAverageLabel1";
            this.gradePointAverageLabel1.Size = new System.Drawing.Size(124, 32);
            this.gradePointAverageLabel1.TabIndex = 31;
            // 
            // outstandingFeesLabel1
            // 
            this.outstandingFeesLabel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.outstandingFeesLabel1.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.studentBindingSource, "OutstandingFees", true, DataSourceUpdateMode.OnValidation, 0, "C"));
            this.outstandingFeesLabel1.Location = new System.Drawing.Point(537, 275);
            this.outstandingFeesLabel1.Name = "outstandingFeesLabel1";
            this.outstandingFeesLabel1.Size = new System.Drawing.Size(202, 32);
            this.outstandingFeesLabel1.TabIndex = 30;
            // 
            // postalCodeMaskedLabel
            // 
            this.postalCodeMaskedLabel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.postalCodeMaskedLabel.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.studentBindingSource, "PostalCode", true));
            this.postalCodeMaskedLabel.Location = new System.Drawing.Point(745, 220);
            this.postalCodeMaskedLabel.Name = "postalCodeMaskedLabel";
            this.postalCodeMaskedLabel.Size = new System.Drawing.Size(130, 32);
            this.postalCodeMaskedLabel.TabIndex = 29;
            // 
            // provinceMaskedLabel
            // 
            this.provinceMaskedLabel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.provinceMaskedLabel.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.studentBindingSource, "Province", true));
            this.provinceMaskedLabel.Location = new System.Drawing.Point(469, 222);
            this.provinceMaskedLabel.Name = "provinceMaskedLabel";
            this.provinceMaskedLabel.Size = new System.Drawing.Size(100, 32);
            this.provinceMaskedLabel.TabIndex = 28;
            // 
            // fullNameLabel1
            // 
            this.fullNameLabel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.fullNameLabel1.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.studentBindingSource, "FullName", true));
            this.fullNameLabel1.Location = new System.Drawing.Point(211, 119);
            this.fullNameLabel1.Name = "fullNameLabel1";
            this.fullNameLabel1.Size = new System.Drawing.Size(676, 32);
            this.fullNameLabel1.TabIndex = 26;
            // 
            // dateCreatedLabel1
            // 
            this.dateCreatedLabel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.dateCreatedLabel1.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.studentBindingSource, "DateCreated", true, DataSourceUpdateMode.OnValidation, DateTime.Now, "dd/MM/yyyy"));
            this.dateCreatedLabel1.Location = new System.Drawing.Point(211, 275);
            this.dateCreatedLabel1.Name = "dateCreatedLabel1";
            this.dateCreatedLabel1.Size = new System.Drawing.Size(124, 34);
            this.dateCreatedLabel1.TabIndex = 25;
            // 
            // registrationDateLabel1
            // 
            this.registrationDateLabel1.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.registrationBindingSource, "RegistrationDate", true));
            this.registrationDateLabel1.Location = new System.Drawing.Point(431, 325);
            this.registrationDateLabel1.Name = "registrationDateLabel1";
            this.registrationDateLabel1.Size = new System.Drawing.Size(100, 23);
            this.registrationDateLabel1.TabIndex = 24;
            // 
            // registrationBindingSource
            // 
            this.registrationBindingSource.DataSource = typeof(BITCollege_Felipe_Rincon.Models.Registration);
            // 
            // lblCity
            // 
            this.lblCity.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblCity.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.studentBindingSource, "City", true));
            this.lblCity.Location = new System.Drawing.Point(211, 220);
            this.lblCity.Name = "lblCity";
            this.lblCity.Size = new System.Drawing.Size(124, 32);
            this.lblCity.TabIndex = 23;
            // 
            // studentNumberMaskedTextBox
            // 
            this.studentNumberMaskedTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.studentBindingSource, "StudentNumber", true));
            this.studentNumberMaskedTextBox.Location = new System.Drawing.Point(211, 61);
            this.studentNumberMaskedTextBox.Mask = "0000-0000";
            this.studentNumberMaskedTextBox.Name = "studentNumberMaskedTextBox";
            this.studentNumberMaskedTextBox.Size = new System.Drawing.Size(156, 26);
            this.studentNumberMaskedTextBox.TabIndex = 22;
            this.studentNumberMaskedTextBox.TextMaskFormat = System.Windows.Forms.MaskFormat.ExcludePromptAndLiterals;
            // 
            // grpRegistration
            // 
            this.grpRegistration.Controls.Add(titleLabel);
            this.grpRegistration.Controls.Add(this.titleLabel2);
            this.grpRegistration.Controls.Add(creditHoursLabel);
            this.grpRegistration.Controls.Add(this.creditHoursLabel1);
            this.grpRegistration.Controls.Add(this.titleLabel1);
            this.grpRegistration.Controls.Add(courseNumberLabel);
            this.grpRegistration.Controls.Add(this.courseNumberLabel1);
            this.grpRegistration.Controls.Add(registrationNumberLabel);
            this.grpRegistration.Controls.Add(this.registrationNumberComboBox);
            this.grpRegistration.Location = new System.Drawing.Point(47, 541);
            this.grpRegistration.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.grpRegistration.Name = "grpRegistration";
            this.grpRegistration.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.grpRegistration.Size = new System.Drawing.Size(794, 246);
            this.grpRegistration.TabIndex = 8;
            this.grpRegistration.TabStop = false;
            this.grpRegistration.Text = "Registration Data";
            // 
            // titleLabel2
            // 
            this.titleLabel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.titleLabel2.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.registrationBindingSource, "Course.Title", true));
            this.titleLabel2.Location = new System.Drawing.Point(469, 119);
            this.titleLabel2.Name = "titleLabel2";
            this.titleLabel2.Size = new System.Drawing.Size(230, 32);
            this.titleLabel2.TabIndex = 9;
            // 
            // creditHoursLabel1
            // 
            this.creditHoursLabel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.creditHoursLabel1.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.registrationBindingSource, "Course.CreditHours", true));
            this.creditHoursLabel1.Location = new System.Drawing.Point(211, 183);
            this.creditHoursLabel1.Name = "creditHoursLabel1";
            this.creditHoursLabel1.Size = new System.Drawing.Size(156, 32);
            this.creditHoursLabel1.TabIndex = 7;
            // 
            // titleLabel1
            // 
            this.titleLabel1.Location = new System.Drawing.Point(0, 0);
            this.titleLabel1.Name = "titleLabel1";
            this.titleLabel1.Size = new System.Drawing.Size(100, 23);
            this.titleLabel1.TabIndex = 8;
            // 
            // courseNumberLabel1
            // 
            this.courseNumberLabel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.courseNumberLabel1.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.registrationBindingSource, "Course.CourseNumber", true));
            this.courseNumberLabel1.Location = new System.Drawing.Point(211, 115);
            this.courseNumberLabel1.Name = "courseNumberLabel1";
            this.courseNumberLabel1.Size = new System.Drawing.Size(156, 32);
            this.courseNumberLabel1.TabIndex = 3;
            // 
            // registrationNumberComboBox
            // 
            this.registrationNumberComboBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.registrationBindingSource, "RegistrationNumber", true));
            this.registrationNumberComboBox.DataSource = this.registrationBindingSource;
            this.registrationNumberComboBox.DisplayMember = "RegistrationNumber";
            this.registrationNumberComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.registrationNumberComboBox.FormattingEnabled = true;
            this.registrationNumberComboBox.Location = new System.Drawing.Point(211, 49);
            this.registrationNumberComboBox.Name = "registrationNumberComboBox";
            this.registrationNumberComboBox.Size = new System.Drawing.Size(156, 28);
            this.registrationNumberComboBox.TabIndex = 1;
            // 
            // StudentData
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1096, 972);
            this.Controls.Add(this.grpRegistration);
            this.Controls.Add(this.grpStudent);
            this.Controls.Add(this.lnkDetails);
            this.Controls.Add(this.lnkUpdate);
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "StudentData";
            this.Text = "StudentData";
            this.Load += new System.EventHandler(this.StudentData_Load);
            this.grpStudent.ResumeLayout(false);
            this.grpStudent.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.studentBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.registrationBindingSource)).EndInit();
            this.grpRegistration.ResumeLayout(false);
            this.grpRegistration.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.LinkLabel lnkDetails;
        private System.Windows.Forms.LinkLabel lnkUpdate;
        private System.Windows.Forms.Label lblReader;
        private System.Windows.Forms.GroupBox grpStudent;
        private System.Windows.Forms.GroupBox grpRegistration;
        private System.Windows.Forms.MaskedTextBox studentNumberMaskedTextBox;
        private System.Windows.Forms.BindingSource studentBindingSource;
        private System.Windows.Forms.Label descriptionLabel2;
        private System.Windows.Forms.Label gradePointAverageLabel1;
        private System.Windows.Forms.Label outstandingFeesLabel1;
        private EWSoftware.MaskedLabelControl.MaskedLabel postalCodeMaskedLabel;
        private EWSoftware.MaskedLabelControl.MaskedLabel provinceMaskedLabel;
        private System.Windows.Forms.Label fullNameLabel1;
        private System.Windows.Forms.Label dateCreatedLabel1;
        private System.Windows.Forms.Label registrationDateLabel1;
        private System.Windows.Forms.BindingSource registrationBindingSource;
        private System.Windows.Forms.Label lblCity;
        private System.Windows.Forms.Label creditHoursLabel1;
        private System.Windows.Forms.Label titleLabel1;
        private System.Windows.Forms.Label courseNumberLabel1;
        private System.Windows.Forms.ComboBox registrationNumberComboBox;
        private System.Windows.Forms.Label addressLabel1;
        private System.Windows.Forms.Label titleLabel2;
    }
}
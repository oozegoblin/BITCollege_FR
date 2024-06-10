using BITCollege_Felipe_Rincon.Data;
using BITCollege_Felipe_Rincon.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Utility;
/*
* Name: Felipe Rincon
* Course: COMP-1283 C# Programming 4
* Created: 2024-05-05
* Updated: 2024-05-12
*/
namespace BITCollegeWindows
{
    public partial class Grading : Form
    {
        ///given:  student and registration data will passed throughout 
        ///application. This object will be used to store the current
        ///student and selected registration
        ConstructorData constructorData;
        // Define an instance of your BITCollege_FLContext class for use in this form.
        BITCollege_Felipe_RinconContext db = new BITCollege_Felipe_RinconContext();
        //public Grading()
        //{
        //    InitializeComponent();
        //}
        /// <summary>
        /// given:  This constructor will be used when called from the
        /// Student form.  This constructor will receive 
        /// specific information about the student and registration
        /// further code required:  
        /// Grading overloaded Constructor implementation.
        /// </summary>
        /// <param name="constructorData">constructorData object containing
        /// specific student and registration data.</param>
        public Grading(ConstructorData constructorData)
        {
            InitializeComponent();
            //further code to be added
            // Populate the Grading form’s constructorData object with the corresponding data received in the constructor. 
            this.constructorData = constructorData;
            // Populate the upper controls with the corresponding data received in the constructor. 
            this.studentBindingSource.DataSource = constructorData.Student;
            // Populate the lower controls with the corresponding data received in the constructor. 
            this.registrationBindingSource.DataSource = constructorData.Registration;
            // Trigger the select clicked event to Update the form implementation. 
            this.lnkUpdate.LinkClicked += lnkUpdate_LinkClicked;
        }
        /// <summary>
        /// given: this code will navigate back to the Student form with
        /// the specific student and registration data that launched
        /// this form.
        /// lnkReturn_LinkClicked event implementation.
        /// </summary>
        private void lnkReturn_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            //return to student form with the currently data.
            StudentData student = new StudentData(constructorData);
            student.MdiParent = this.MdiParent;
            student.Show();
            this.Close();
        }
        /// <summary>
        /// lnkUpdate_LinkClicked event implementation.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void lnkUpdate_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            // Bringing  the service reference
            BitCollegeService.CollegeRegistrationClient service = new BitCollegeService.CollegeRegistrationClient();
            // Get the value from gradeTextBox
            string textBoxValue = Utility.Numeric.ClearFormatting(gradeTextBox.Text, "%");
            //Checking if the grade is numeric.
            if (!double.TryParse(textBoxValue, out double UpdateValue))
            {
                // that the grade must be entered as a decimal value such that it appropriately displays when formatted as a percent. 
                MessageBox.Show("Please enter as a numeric value.",
                                "Invalid Value", MessageBoxButtons.OK);
                return;
            }
            // Checking, If the value is not within the range. 
            if (UpdateValue < 0 || UpdateValue > 1)
            {
                // display an appropriate MessageBox to the end user and do not proceed with the update. 
                MessageBox.Show("Grade must be within the range of 0 to 100.", "Invalid Range", MessageBoxButtons.OK);
                return;
            }
            //If the data passes the above validation, use the Client Endpoint of the WCF Web Service.
            try
            {
                // to update the Grade, the Student’s GradePointAverage and corresponding Grade Point State. 
                service.UpdateGrade((double)constructorData.Registration.Grade, constructorData.Registration.RegistrationId, constructorData.Registration.Notes);
                // Disable the Grade TextBox so that no further Grade modification can be made.
                // This will also give the user a visual cue that the update has completed. 
                gradeTextBox.Enabled = false;
            }
            // Handling a possible exception.
            catch (Exception ex)
            {
                MessageBox.Show("An error has ocurred: grade as a decimal value such" + ex.Message, "Error", MessageBoxButtons.OK);
            }
        }
        /// <summary>
        /// Gradin_Load implementation.
        /// given:  open in top right of frame
        /// further code required:
        /// Grading_load event implementation.
        /// </summary>
        private void Grading_Load(object sender, EventArgs e)
        {
            this.Location = new Point(0, 0);
            // Registration Bindingdata properties available through the constructorData
            Registration registration = new Registration();
            registration = constructorData.Registration;
            registrationBindingSource.DataSource = registration;
            // Student Bindingdata properties available through the constructorData
            Student student = new Student();
            student = constructorData.Student;
            studentBindingSource.DataSource = student;
            // Use the CourseFormat method within the Utility project to set the Course Number MaskedLabel mask.
            string mask = BusinessRules.CourseFormat(registration.Course.CourseType);
            courseNumberMaskedLabel.Mask = mask;
            // If a grade has previously been entered: 
            if (registration.Grade != null)
            {
                // Disable the Grade Textbox. 
                gradeTextBox.Enabled = false;
                // Disable the Process LinkLabel. 
                lnkUpdate.Enabled = false;
                // Make visible the label indicating that grading is not possible. 
                lblExisting.Visible = true;
            }
            // If no grade has been previously entered: 
            else
            {
                // Enable the Grade Textbox. 
                gradeTextBox.Enabled = true;
                // Enable the Process LinkLabel. 
                lnkUpdate.Enabled = true;
                // Make invisible the label indicating that grading is not possible.
                lblExisting.Visible = false;
                // Focus the gradeTextBox.
                gradeTextBox.Focus();
            }
        }
    }
}

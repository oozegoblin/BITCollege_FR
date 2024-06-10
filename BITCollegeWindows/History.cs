using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BITCollege_Felipe_Rincon.Data;
using BITCollege_Felipe_Rincon.Models;
/*
* Name: Felipe Rincon
* Course: COMP-1283 C# Programming 4
* Created: 2024-05-05
* Updated: 2024-05-10
*/
namespace BITCollegeWindows
{
    public partial class History : Form
    {
        ///given:  student and registration data will passed throughout 
        ///application. This object will be used to store the current
        ///student and selected registration
        ConstructorData constructorData;
        //Define an instance of your BITCollege_FLContext class for use in this form. 
        BITCollege_Felipe_RinconContext db = new BITCollege_Felipe_RinconContext();
        //public History()
        //{
        //    InitializeComponent();
        //}
        /// <summary>
        /// given:  This constructor will be used when called from the
        /// Student form.  This constructor will receive 
        /// specific information about the student and registration
        /// further code required:  
        /// History overloaded Constructor implementation.
        /// </summary>
        /// <param name="constructorData">constructorData object containing
        /// specific student and registration data.</param>
        public History(ConstructorData constructorData)
        {
            InitializeComponent();
            //further code to be added
            // Populate the History form’s constructorData object with the corresponding data received in the constructor. 
            this.constructorData = constructorData;
            // Populate the upper controls with the corresponding data received in the constructor. 
            this.studentNumberMaskedLabel.Text = constructorData.Student.StudentNumber.ToString();
            this.fullNameLabel1.Text = constructorData.Student.FullName;
            this.descriptionLabel1.Text = constructorData.Student.AcademicProgram.Description;
        }
        /// <summary>
        /// given: this code will navigate back to the Student form with
        /// the specific student and registration data that launched
        /// this form.
        /// lnkReturn_LinkClicked event implementation
        /// </summary>
        private void lnkReturn_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            // Return to the StudentData form, keeping the currently data.
            StudentData student = new StudentData(constructorData);
            student.MdiParent = this.MdiParent;
            student.Show();
            this.Close(); 
        }

        /// <summary>
        /// given:  open in top right of frame
        /// further code required:
        /// History_load form implementation.
        /// </summary>
        private void History_Load(object sender, EventArgs e)
        {
            this.Location = new Point(0, 0);   
            try
            {
                // Set the DataSource property of the BindingSource object representing the DataGridView
                var dgvControls =
                    (from registration in db.Registrations
                     // Query selecting data from the Registrations and Courses tables, Entity Classes
                     join course in db.Courses
                     on registration.CourseId equals course.CourseId
                     // who’s StudentId corresponds to Student passed to this form. 
                     where registration.StudentId == constructorData.Student.StudentId
                     select new
                     {
                         // Populate the datagridview controls, with the current student.
                         registration.RegistrationNumber,
                         registration.RegistrationDate,
                         registration.Course.Title,
                         registration.Grade,
                         course.Notes
                     }).ToList();
                registrationBindingSource.DataSource = dgvControls;
            }
            // Ensure proper exception handling is used in this routine such that if an exception occurs.
            catch (Exception ex)
            {
                // is shown to the end user providing details to the user as to the exception that has taken place. 
                MessageBox.Show($"An error has ocurred: {ex.Message}", "Error", MessageBoxButtons.OK);
            }
        }
    }
}

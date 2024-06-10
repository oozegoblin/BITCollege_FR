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
/*
* Name: Felipe Rincon
* Course: COMP-1283 C# Programming 4
* Created: 2024-05-05
* Updated: 2024-05-12
*/
namespace BITCollegeWindows
{
    public partial class StudentData : Form
    {
        ///Given: Student and Registration data will be retrieved
        ///in this form and passed throughout application
        ///These variables will be used to store the current
        ///Student and selected Registration
        ConstructorData constructorData = new ConstructorData();
        // Define an instance of your BITCollege_FLContext class for use in this form.
        BITCollege_Felipe_RinconContext db = new BITCollege_Felipe_RinconContext();
        public StudentData()
        {
            InitializeComponent();
        }
        /// <summary>
        /// given:  This constructor will be used when returning to frmStudent
        /// from another form.  This constructor will pass back
        /// specific information about the student and registration
        /// based on activites taking place in another form
        /// StudentData overloaded Constructor implementation
        /// </summary>
        /// <param name="constructorData">constructorData object containing
        /// specific student and registration data.</param>
        public StudentData(ConstructorData constructorData)
        {
            InitializeComponent();
            //further code to be added
            // Modify the overloaded constructor as follows: 
            // Set the constructorData instance variable to the value of the corresponding argument. 
            this.constructorData = constructorData;
            // Set the Student Number MaskedTextBox value using the Student property of the constructor argument. 
            studentNumberMaskedTextBox.Text = constructorData.Student.StudentNumber.ToString();
            // Call the MaskedTextBox_Leave event passing null for each of the event arguments. 
            studentNumberMaskedTextBox_Leave(null, null);
        }
        /// <summary>
        /// given: open grading form passing constructor data
        /// lnkUpdate_LinkClicked event implementation
        /// </summary>
        private void lnkUpdate_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            // ConstructorData object is populated with the currents Student and Registration records 
            // for the Update form
            Grading grading = new Grading(constructorData);
            grading.MdiParent = this.MdiParent;
            grading.Show();
            this.Close();
        }
        /// <summary>
        /// given: open history form passing data
        /// lnkDetails_LinkClicked event implementation
        /// Populate all controls bound to the Student and registration bindingsource.
        /// </summary>
        private void lnkDetails_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            History history = new History(constructorData);
            history.MdiParent = this.MdiParent;
            history.Show();
            this.Close(); 
        }
        /// <summary>
        /// given:  opens form in top right of frame
        /// Populate all controls bound to the Student and registration bindingsource.
        /// </summary>
        private void StudentData_Load(object sender, EventArgs e)
        {
            //Maintain format static of the form when is opened or closed.
            this.Location = new Point(0, 0);
            this.lnkUpdate.Enabled = false;
            this.lnkDetails.Enabled = false;
            // Trigger the select event to deploy the form implementation. 
            studentNumberMaskedTextBox.Leave += studentNumberMaskedTextBox_Leave;
        }
        /// <summary>
        /// studentNumberMaskedTextBox_Leave Event implementation.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void studentNumberMaskedTextBox_Leave(object sender, EventArgs e)
        {
            // Set the DataSource property of the BindingSource object representing the Student controls.
            Student student = (from Results in db.Students
                               // StudentNumber matches the value in the MaskedTextBox
                               where Results.StudentNumber.ToString() == studentNumberMaskedTextBox.Text
                               select Results).SingleOrDefault();
            // If no records were retrieved: 
            if (student == null)
            {
                // Disable the link labels.
                this.lnkUpdate.Enabled = false;
                this.lnkDetails.Enabled = false;
                // set focus back to the MaskedTextBox control.
                this.studentNumberMaskedTextBox.Focus();
                // Clear each BindingSource object on the form such that any previous results do not remain visible to the end user. 
                studentBindingSource.DataSource = typeof(Student);
                registrationBindingSource.DataSource = typeof(Registration);
                // Display a MessageBox, indicating that the student number entered does not exist.  
                MessageBox.Show("Student " + studentNumberMaskedTextBox.Text + " does not exist.",
                                "Invalid Student Number");
            }
            // If a student record was retrieved: 
            else
            {
                // Set the DataSource property of the BindingSource object representing the Registration controls 
                studentBindingSource.DataSource = student;
                IQueryable<Registration> registrations = from Results in db.Registrations
                // selecting all Registrations in which the StudentId corresponds to the record represented by the StudentNumber value in the MaskedTextBox
                                                         where Results.StudentId == student.StudentId
                                                         select Results;
                // If no Registration records were retrieved: 
                if (registrations.Count() == 0)
                {
                    // Disable the link labels.
                    this.lnkUpdate.Enabled = false;
                    this.lnkDetails.Enabled = false;
                    // Clear the Registration BindingSource object.
                    registrationBindingSource.DataSource = typeof(Registration);
                }
                // If Registration record(s) were retrieved
                else if (registrations.Count() > 0)
                {
                    // Modify the MaskedTextBox_Leave event as follows: 
                    // Following the code that populates the BindingSource object associated with the Registration controls.
                    registrationBindingSource.DataSource = registrations.ToList();
                    // If the Registration object of ConstructorData is not null 
                    if (this.constructorData.Registration != null)
                    {
                        // Set the RegistrationNumber Combobox’s text property
                        // to the value of the Registration Number returned to this form. 
                        registrationNumberComboBox.Text = constructorData.Registration.RegistrationNumber.ToString();
                    }
                    // Enable the link labels at the bottom of the form. 
                    this.lnkUpdate.Enabled = true;
                    this.lnkDetails.Enabled = true;
                    // Keep the currently registration, 
                    Registration registration = (Registration)registrationBindingSource.Current;
                    // ensure the constructorData object is populated with the current Student
                    // Registration record prior to constructing the Grading and History forms.
                    this.constructorData.Student = student;
                    this.constructorData.Registration = registration;
                }
            }
        }
    }
}


using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BITCollege_Felipe_Rincon.Data;
using BITCollege_Felipe_Rincon.Models;
using BITCollegeService;
/*
* Name: Felipe Rincon
* Course: COMP-1283 C# Programming 4
* Created: 2023-04-09
* Updated: 2024-04-23
*/
namespace BITCollegeSite
{
    public partial class CourseRegistration : System.Web.UI.Page
    {
        // Declare an instance of the BITCollege_FLContext class for use in this Web form 
        readonly BITCollege_Felipe_RinconContext db = new BITCollege_Felipe_RinconContext();
        /// <summary>
        /// Page load event implementation in CourseRegistration
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                // If the form has been opened without authentication, redirect the user to the Login.aspx 
                if (!User.Identity.IsAuthenticated)
                {
                    Response.Redirect("~/Account/Login.aspx");
                }
                // Otherwise: 
                try
                {
                    // Obtain data from the Session Variables created 
                    var student = (Student)Session["Student"];
                    // Display the Student Name from the appropriate Session
                    lblStudentName.Text += student.FullName;
                    // Use LINQ-to-SQL to obtain a list of Courses that belong to the same program 
                    var programId = student.AcademicProgramId;
                    // var courses = db.Courses.ToList();
                    var courses = db.Courses
                    .Where(c => c.AcademicProgramId == programId).ToList();
                    // Bind this list to the DropDownList control such that the Title of the course is displayed to the user
                    ddlCourse.DataSource = courses;
                    ddlCourse.DataTextField = "Title";
                    ddlCourse.DataValueField = "CourseId";
                    ddlCourse.DataBind();
                    tbNotes.Enabled = false;
                }
                // Ensure any exceptions are handled appropriately with
                // all exception messages displayed in the Message Label 
                catch (Exception ex)
                {
                    lblError.Visible = true;
                    lblError.Text = "Loading Data error: " + ex.Message;
                }
            }      
        }
        //protected void ddlCourse_SelectedIndexChanged(object sender, EventArgs e)
        //{
        //    // the Title of the course is displayed to the user, and the CourseId is stored internally. 
        //    
        //}
        /// <summary>
        /// Registration Link button implementation 
        /// </summary>
        protected void lbtbRegister_Click(object sender, EventArgs e)
        {
            // Bright the service reference
            CollegeService.CollegeRegistrationClient service = new CollegeService.CollegeRegistrationClient();
            // Enable the Notes TextBox Validator control. 
            tbNotes.Enabled = true;
            // Call the Page.Validate() method to ensure data has been entered into the Notes
            Page.Validate();
            if (Page.IsValid)
            {
                try
                {
                    // Obtain the CourseId from the DropDownList selection. 
                    var CourseId = Convert.ToInt32(ddlCourse.SelectedValue);
                    // student can be obtained from the Session Variable defined in StudentRegistrations
                    var student = (Student)Session["Student"];
                    // Use the RegisterCourse Web Method of the WCF Web Service 
                    int result = service.RegisterCourse(student.StudentId, CourseId, (tbNotes.Text != null && tbNotes.Text.Length > 0)?tbNotes.Text:"");
                    // If the RegisterCourse method returns a value indicating that the Registration failed,
                    if (result != 0)
                    {
                        // use the RegisterError method in the Utility  to display an appropriate message.
                        lblError.Visible = true;
                        lblError.Text = "Registration Error: " + Utility.BusinessRules.RegisterError(result);
                    }
                    // If the RegisterCourse method returns a value indicating a successful, call the Response.Redirect() method 
                    else
                    {                       
                        Response.Redirect("~/StudentRegistrations.aspx");
                    }
                }
                // any exceptions are handled appropriately with all exception messages displayed in the Message Label on the form 
                catch (Exception ex)
                {
                    lblError.Visible = true;
                    lblError.Text = "Registration Not available: " + ex.Message;
                }
            }
        }
        /// <summary>
        /// Link button event implementation 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void lbtbReturn_Click(object sender, EventArgs e)
        {
            // Call the Response.Redirect() method return the user to the StudentRegistrations.aspx 
            Response.Redirect("~/StudentRegistrations.aspx");
        }
    }
}
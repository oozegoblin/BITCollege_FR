using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BITCollege_Felipe_Rincon.Data;
using BITCollege_Felipe_Rincon.Models;
using Utility;
/*
* Name: Felipe Rincon
* Course: COMP-1283 C# Programming 4
* Created: 2023-04-09
* Updated: 2024-04-23
*/
namespace BITCollegeSite
{
    /// <summary>
    /// StudentRegistrations webform implementation
    /// </summary>
    public partial class StudentRegistrations : System.Web.UI.Page
    {
        // Define an instance of the BITCollege_FLContext class for use in this Web form 
        BITCollege_Felipe_RinconContext db = new BITCollege_Felipe_RinconContext();
        /// <summary>
        /// Page_load event implementation
        /// </summary>
        /// <param name="sender">Bring the student number with Registration results from the course table</param>
        /// <param name="e"></param>
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                // If the form has been opened without authentication, redirect the user to the Login.aspx 
                if (!User.Identity.IsAuthenticated)
                {
                    Response.Redirect("~/Account/Login.aspx");
                }
                // Otherwise
                try
                {
                    // Obtain the StudentNumber from the logonid used to log into the Website
                    string studentNumber = User.Identity.Name;
                    // Assuming username is student number, I have to filter by just the number due the string format
                    int tail = studentNumber.IndexOf("@");
                    // in orther to bring just the studentId to int, without string format and chars.
                    int user = int.Parse(studentNumber.Substring(0, tail));
                    // Use LINQ-to-SQL Server to obtain the Student object that corresponds with the StudentNumber 
                    var student = db.Students.SingleOrDefault(s => s.StudentNumber == user);
                    // If the result is not null
                    if (student != null)
                    {
                        // Save this list of Registrations into a Session Variable
                        Session["Student"] = student;
                        // Set the Name Label to the Full Name of the Student object
                        lblStudentName.Text = student.FullName;
                        // Use LINQ-to-SQL to obtain a collection of Registration records associated with the student logged 
                        //var registrations = db.Registrations.ToList();
                        var registrations = db.Registrations
                            .Where(r => r.StudentId == student.StudentId).ToList();
                        // Save this list of Registrations into a Session Variable
                        Session["Registrations"] = registrations;
                        // bind this result set the GridView control 
                        gvCourses.DataSource = registrations;
                        gvCourses.DataBind();
                    }
                }
                // If an exception occurs during this routine, display an appropriate message in the Message Label 
                catch (Exception ex)
                {
                    lblError.Visible = true;
                    lblError.Text = "Loading Data error: " + ex.Message;
                }
            }
        }   
        /// <summary>
        /// Grid view implementation
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void gvCourses_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Set a Session Variables to the value of the selected Course Number data item 
            string courseCode = gvCourses.SelectedRow.Cells[1].Text;
            Session["SelectedCourseNumber"] = courseCode;
            // Call the Response.Redirect() method to open the ViewDrop Web Form
            Response.Redirect("~/ViewDrop.aspx");
        }

        protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                // Get the CourseDescription value from the current row
                string courseDescription = DataBinder.Eval(e.Row.DataItem, "CourseDescription").ToString();

                // Determine the CourseType based on the CourseDescription
                CourseType courseType = CourseType.GRADED;
                //CourseType courseType = GetCourseType(courseDescription);

                // Set the CourseType value in the CourseType column
                e.Row.Cells[2].Text = courseType.ToString();
            }
        }
        //protected void lbtbRegister_Click(object sender, EventArgs e)
        //{

        //}
        /// <summary>
        /// link button registration implementation 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void lbtbRegister_Click1(object sender, EventArgs e)
        {
            // Call the Response.Redirect() method return the user to the CourseRegistration Web Form. 
            try
            {
                Response.Redirect("~/CourseRegistration.aspx");
            }
            // If any exception came, handle it
            catch (Exception ex)
            {
                lblError.Visible = true;
                lblError.Text = "Unable to a new Registration: " + ex.Message;
            }
        }
        //protected void gvCourses_SelectedIndexChanged1(object sender, EventArgs e)
        //{

        //}
    }
}
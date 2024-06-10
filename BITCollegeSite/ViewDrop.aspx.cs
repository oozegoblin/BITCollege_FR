using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BITCollege_Felipe_Rincon.Data;
using BITCollege_Felipe_Rincon.Models;
/*
* Name: Felipe Rincon
* Course: COMP-1283 C# Programming 4
* Created: 2023-04-09
* Updated: 2024-05-10
*/
namespace BITCollegeSite
{
    public partial class ViewDrop : System.Web.UI.Page
    {
        // Declare an instance of the BITCollege_FLContext class for use in this Web form. 
        BITCollege_Felipe_RinconContext db = new BITCollege_Felipe_RinconContext(); 
        /// <summary>
        /// populate the gridview and implement page load event.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                // If the form has been opened without authentication, redirect the user to the Login.aspx.
                if (!User.Identity.IsAuthenticated)
                {
                    Response.Redirect("~/Acoount/Login.aspx");
                }
                // Otherwise: Obtain data from the Session Variables created in StudentRegistrations
                try
                {
                    // Use LINQ - to - SQL Server to determine the CourseId based on the CourseNumber Session Variable. 
                    string courseNumber = (string)Session["SelectedCourseNumber"];
                    var courseId = db.Courses.FirstOrDefault(c => c.CourseNumber == courseNumber)?.CourseId;
                    Session["CourseId"] = courseId;
                    // Obtain the contents of the Session Variable containing all Registration records for the student;
                    var registrations = (List<Registration>)Session["Registrations"];
                    // use LINQ-to-Sql Server (lambda or traditional syntax) to further filter this result set to only
                    // include those registrations whose CourseId matches the CourseId obtained in the previous step
                    var singleRegistration = registrations.Where(r => r.CourseId == courseId).ToList();
                    // Store the results of this revised query into a Session Variable. 
                    Session["FilteredRegistrations"] = singleRegistration;
                    // Bind this record(or records) to the DetailsView control.   
                    dvRegistrationDetails.DataSource = singleRegistration;
                    dvRegistrationDetails.DataBind();

                    UpdateDropLinkButton(singleRegistration);
                }
                // ensure that the Message Label is visible when an exception occurs. 
                catch (Exception ex)
                {
                    lblError.Visible = true;
                    lblError.Text = "Loading Data error: " + ex.Message;
                }
            }
        }
        /// <summary>
        /// UpdateDropLinkButton method implementation
        /// </summary>
        /// <param name="registrations"></param>
        private void UpdateDropLinkButton(List<Registration> registrations)
        {
            // A course can only be dropped if the Grade field is null.  If the Grade field is null,
            // enable the Drop Course Link Button otherwise disable it. 
            lbtbDropCourse.Enabled = registrations.Any(r =>r.Grade == null);
        }
        //protected void dvRegistrationDetails_PageIndexChanging(object sender, DetailsViewPageEventArgs e)
        //{

        //}
        //protected void lbtbReturn_Click(object sender, EventArgs e)
        //{
        //    Response.Redirect("~/StudentRegistrations.aspx");
        //}
        /// <summary>
        /// place author id into session variable and
        /// redirect to the next page
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void dvRegistrationDetails_PageIndexChanging1(object sender, DetailsViewPageEventArgs e)
        {
            // Obtain the data from the Session Variable
            // populated during the Page Load and re-bind to the DetailsView control. 
            dvRegistrationDetails.PageIndex = e.NewPageIndex;
            dvRegistrationDetails.DataSource = Session["FilteredRegistrations"];
            // Force the data to be pushed into the page by calling the Databind method. 
            dvRegistrationDetails.DataBind();
            // A course can only be dropped if the Grade field is null.  
            lbtbDropCourse.Enabled = ((List<Registration>)Session["FilteredRegistrations"])
                .Any(r => r.Grade == -1);
        }
        /// <summary>
        /// Drop button click event implementation 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void lbtbDropCourse_Click(object sender, EventArgs e)
        {
            // Bright the service reference
            CollegeService.CollegeRegistrationClient service = new CollegeService.CollegeRegistrationClient();
            //var courseId = Session["CourseId"];
            //// Use the DropCourse Web Method of the WCF Web Service to drop the course currently
            //// shown in the DetailsView control
            //var result = service.DropCourse((int)courseId);
            //// If the DropCourse method returns a value indicating a successful drop
            /// //if (result == true)
            //{
            //    //call the Response.Redirect() method return the user to the StudentRegistrations Web Form
            //    Response.Redirect("~/StudentRegistrations.aspx");
            //}
            //// If the dropCourse method returns a value indicating that the drop was unsuccessful
            //else
            //{
            //    // display an appropriate message in the message Label. 
            //    lblError.Visible = true;
            //    lblError.Text = "Unable to drop the course ";
            //}
            try
            {
                long registrationNumber = long.Parse(dvRegistrationDetails.Rows[0].Cells[1].Text);
                // Use the DropCourse Web Method of the WCF Web Service to drop the course currently
                // I have to run the method over the registration, otherwise It will drop the whole course.
                Registration registerToDrop =
                    (from x in db.Registrations
                     where x.RegistrationNumber == registrationNumber
                     select x).FirstOrDefault();
                int RegistrationToDrop = registerToDrop.RegistrationId;
                // shown in the DetailsView control
                service.DropCourse(RegistrationToDrop);
                // call the Response.Redirect() method return the user to the StudentRegistrations Web Form
                Response.Redirect("~/StudentRegistrations.aspx");
            }
            // If the dropCourse method returns a value indicating that the drop was unsuccessful
            catch (Exception ex)
            {
                // display an appropriate message in the message Label.
                lblError.Visible = true;
                lblError.Text = "Unable to drop the course " + ex;
            }
            //CollegeService.CollegeRegistrationClient service = new CollegeService.CollegeRegistrationClient();
        }
        /// <summary>
        /// Link click button event return implementation.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void lbtbReturn_Click1(object sender, EventArgs e)
        {
            // Call the Response.Redirect() method return the user to the StudentRegistrations Web Form. 
            Response.Redirect("~/StudentRegistrations.aspx");
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
/*
* Name: Felipe Rincon
* Course: COMP-1281 C# Programming 3
* Created: 2024-01-12
* Updated: 2024-01-28
*/
/// <summary>
/// I tested all the modifications and implementations that I did, related in the assignment 1, 
/// actually all meet with the requirements.
/// Also I have a problem with the GPA state, that is the reason of the migration folder, 
/// for that reason I prefer moved on the module 2 for further modifications. 
/// </summary>
namespace BITCollege_Felipe_Rincon.Controllers
{
    public class HomeController : Controller
    {
        /// <summary>
        /// Home controllers modified
        /// </summary>
        /// <returns></returns>
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            /// ViewBag.Message = "Your application description page.";
            ViewBag.Message = "BIT College Data Maintenance System";
            

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}
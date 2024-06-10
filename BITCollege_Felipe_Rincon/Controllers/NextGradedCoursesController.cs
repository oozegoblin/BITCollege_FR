using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using BITCollege_Felipe_Rincon.Data;
using BITCollege_Felipe_Rincon.Models;
/*
* Name: Felipe Rincon
* Course: COMP-1281 C# Programming 3
* Created: 2024-02-13
* Updated: 2024-02-19
*/
/// <summary>
/// NextGradedCoursesController Customatization.
/// </summary>
namespace BITCollege_Felipe_Rincon.Controllers
{
    public class NextGradedCoursesController : Controller
    {
        private BITCollege_Felipe_RinconContext db = new BITCollege_Felipe_RinconContext();

        // GET: NextGradedCourses
        public ActionResult Index()
        {
            /// ActionResult updated to incorporate the use of the GetInstance method.
            return View(NextGradedCourse.GetInstance());
            /// return View(db.NextGradedCourses);
            /// return View(db.NextGradedCourses.ToList());
        }

        // GET: NextGradedCourses/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            NextGradedCourse nextGradedCourse = db.NextGradedCourses.Find(id);
            if (nextGradedCourse == null)
            {
                return HttpNotFound();
            }
            return View(nextGradedCourse);
        }

        // GET: NextGradedCourses/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: NextGradedCourses/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "NextUniqueNumberId,NextAvailableNumber")] NextGradedCourse nextGradedCourse)
        {
            if (ModelState.IsValid)
            {
                db.NextGradedCourses.Add(nextGradedCourse);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(nextGradedCourse);
        }

        // GET: NextGradedCourses/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            NextGradedCourse nextGradedCourse = db.NextGradedCourses.Find(id);
            if (nextGradedCourse == null)
            {
                return HttpNotFound();
            }
            return View(nextGradedCourse);
        }

        // POST: NextGradedCourses/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "NextUniqueNumberId,NextAvailableNumber")] NextGradedCourse nextGradedCourse)
        {
            if (ModelState.IsValid)
            {
                db.Entry(nextGradedCourse).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(nextGradedCourse);
        }

        // GET: NextGradedCourses/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            NextGradedCourse nextGradedCourse = db.NextGradedCourses.Find(id);
            if (nextGradedCourse == null)
            {
                return HttpNotFound();
            }
            return View(nextGradedCourse);
        }

        // POST: NextGradedCourses/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            NextGradedCourse nextGradedCourse = db.NextGradedCourses.Find(id);
            db.NextGradedCourses.Remove(nextGradedCourse);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}

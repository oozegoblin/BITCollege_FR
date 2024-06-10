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
/// NextAuditCourses Controller Customatization.
/// </summary>
namespace BITCollege_Felipe_Rincon.Controllers
{
    public class NextAuditCoursesController : Controller
    {
        private BITCollege_Felipe_RinconContext db = new BITCollege_Felipe_RinconContext();

        // GET: NextAuditCourses
        public ActionResult Index()
        {
            /// ActionResult updated to incorporate the use of the GetInstance method.
            return View(NextAuditCourse.GetInstance());
            /// return View(db.NextAuditCourses.ToList());
        }

        // GET: NextAuditCourses/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            NextAuditCourse nextAuditCourse = db.NextAuditCourses.Find(id);
            if (nextAuditCourse == null)
            {
                return HttpNotFound();
            }
            return View(nextAuditCourse);
        }

        // GET: NextAuditCourses/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: NextAuditCourses/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "NextUniqueNumberId,NextAvailableNumber")] NextAuditCourse nextAuditCourse)
        {
            if (ModelState.IsValid)
            {
                db.NextAuditCourses.Add(nextAuditCourse);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(nextAuditCourse);
        }

        // GET: NextAuditCourses/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            NextAuditCourse nextAuditCourse = db.NextAuditCourses.Find(id);
            if (nextAuditCourse == null)
            {
                return HttpNotFound();
            }
            return View(nextAuditCourse);
        }

        // POST: NextAuditCourses/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "NextUniqueNumberId,NextAvailableNumber")] NextAuditCourse nextAuditCourse)
        {
            if (ModelState.IsValid)
            {
                db.Entry(nextAuditCourse).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(nextAuditCourse);
        }

        // GET: NextAuditCourses/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            NextAuditCourse nextAuditCourse = db.NextAuditCourses.Find(id);
            if (nextAuditCourse == null)
            {
                return HttpNotFound();
            }
            return View(nextAuditCourse);
        }

        // POST: NextAuditCourses/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            NextAuditCourse nextAuditCourse = db.NextAuditCourses.Find(id);
            db.NextAuditCourses.Remove(nextAuditCourse);
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

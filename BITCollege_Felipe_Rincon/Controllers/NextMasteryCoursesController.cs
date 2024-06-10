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
/// NextMasteryCoursesController Customatization.
/// </summary>
namespace BITCollege_Felipe_Rincon.Controllers
{
    public class NextMasteryCoursesController : Controller
    {
        private BITCollege_Felipe_RinconContext db = new BITCollege_Felipe_RinconContext();

        // GET: NextMasteryCourses
        public ActionResult Index()
        {
            /// ActionResult updated to incorporate the use of the GetInstance method.
            return View(NextMasteryCourse.GetInstance());
            // return View(db.NextMasteryCourses.ToList());
        }

        // GET: NextMasteryCourses/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            NextMasteryCourse nextMasteryCourse = db.NextMasteryCourses.Find(id);
            if (nextMasteryCourse == null)
            {
                return HttpNotFound();
            }
            return View(nextMasteryCourse);
        }

        // GET: NextMasteryCourses/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: NextMasteryCourses/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "NextUniqueNumberId,NextAvailableNumber")] NextMasteryCourse nextMasteryCourse)
        {
            if (ModelState.IsValid)
            {
                db.NextMasteryCourses.Add(nextMasteryCourse);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(nextMasteryCourse);
        }

        // GET: NextMasteryCourses/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            NextMasteryCourse nextMasteryCourse = db.NextMasteryCourses.Find(id);
            if (nextMasteryCourse == null)
            {
                return HttpNotFound();
            }
            return View(nextMasteryCourse);
        }

        // POST: NextMasteryCourses/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "NextUniqueNumberId,NextAvailableNumber")] NextMasteryCourse nextMasteryCourse)
        {
            if (ModelState.IsValid)
            {
                db.Entry(nextMasteryCourse).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(nextMasteryCourse);
        }

        // GET: NextMasteryCourses/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            NextMasteryCourse nextMasteryCourse = db.NextMasteryCourses.Find(id);
            if (nextMasteryCourse == null)
            {
                return HttpNotFound();
            }
            return View(nextMasteryCourse);
        }

        // POST: NextMasteryCourses/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            NextMasteryCourse nextMasteryCourse = db.NextMasteryCourses.Find(id);
            db.NextMasteryCourses.Remove(nextMasteryCourse);
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

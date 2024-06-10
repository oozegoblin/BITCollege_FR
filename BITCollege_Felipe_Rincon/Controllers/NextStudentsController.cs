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
/// NextStudentsController Customatization.
/// </summary>
namespace BITCollege_Felipe_Rincon.Controllers
{
    public class NextStudentsController : Controller
    {
        private BITCollege_Felipe_RinconContext db = new BITCollege_Felipe_RinconContext();

        // GET: NextStudents
        public ActionResult Index()
        {
            /// ActionResult updated to incorporate the use of the GetInstance method.
            return View(NextStudent.GetInstance());
            /// return View(db.NextStudents.ToList());
        }

        // GET: NextStudents/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            NextStudent nextStudent = db.NextStudents.Find(id);
            if (nextStudent == null)
            {
                return HttpNotFound();
            }
            return View(nextStudent);
        }

        // GET: NextStudents/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: NextStudents/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "NextUniqueNumberId,NextAvailableNumber")] NextStudent nextStudent)
        {
            if (ModelState.IsValid)
            {
                db.NextStudents.Add(nextStudent);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(nextStudent);
        }

        // GET: NextStudents/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            NextStudent nextStudent = db.NextStudents.Find(id);
            if (nextStudent == null)
            {
                return HttpNotFound();
            }
            return View(nextStudent);
        }

        // POST: NextStudents/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "NextUniqueNumberId,NextAvailableNumber")] NextStudent nextStudent)
        {
            if (ModelState.IsValid)
            {
                db.Entry(nextStudent).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(nextStudent);
        }

        // GET: NextStudents/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            NextStudent nextStudent = db.NextStudents.Find(id);
            if (nextStudent == null)
            {
                return HttpNotFound();
            }
            return View(nextStudent);
        }

        // POST: NextStudents/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            NextStudent nextStudent = db.NextStudents.Find(id);
            db.NextStudents.Remove(nextStudent);
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

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
* Updated: 2024-02-26
*/
/// <summary>
/// StudentCardsController Customatization.
/// </summary>
namespace BITCollege_Felipe_Rincon.Controllers
{
    public class StudentCardsController : Controller
    {
        private BITCollege_Felipe_RinconContext db = new BITCollege_Felipe_RinconContext();

        // GET: StudentCards
        public ActionResult Index()
        {
            var studentCards = db.StudentCards.Include(s => s.Student);
            return View(studentCards.ToList());
        }

        // GET: StudentCards/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            StudentCard studentCard = db.StudentCards.Find(id);
            if (studentCard == null)
            {
                return HttpNotFound();
            }
            return View(studentCard);
        }

        // GET: StudentCards/Create
        public ActionResult Create()
        {
            ViewBag.StudentId = new SelectList(db.Students, "StudentId", "FullName");
            /// ViewBag.StudentId = new SelectList(db.Students, "StudentId", "FirstName");
            return View();
        }

        // POST: StudentCards/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "StudentCardId,StudentId,CardNumber")] StudentCard studentCard)
        {
            if (ModelState.IsValid)
            {
                db.StudentCards.Add(studentCard);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.StudentId = new SelectList(db.Students, "StudentId", "FullName", studentCard.StudentId);
            /// ViewBag.StudentId = new SelectList(db.Students, "StudentId", "FirstName", studentCard.StudentId);
            return View(studentCard);
        }

        // GET: StudentCards/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            StudentCard studentCard = db.StudentCards.Find(id);
            if (studentCard == null)
            {
                return HttpNotFound();
            }
            ViewBag.StudentId = new SelectList(db.Students, "StudentId", "FullName", studentCard.StudentId);
            /// ViewBag.StudentId = new SelectList(db.Students, "StudentId", "FirstName", studentCard.StudentId);
            return View(studentCard);
        }

        // POST: StudentCards/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "StudentCardId,StudentId,CardNumber")] StudentCard studentCard)
        {
            if (ModelState.IsValid)
            {
                db.Entry(studentCard).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.StudentId = new SelectList(db.Students, "StudentId", "FullName", studentCard.StudentId);
            /// ViewBag.StudentId = new SelectList(db.Students, "StudentId", "FirstName", studentCard.StudentId);
            return View(studentCard);
        }

        // GET: StudentCards/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            StudentCard studentCard = db.StudentCards.Find(id);
            if (studentCard == null)
            {
                return HttpNotFound();
            }
            return View(studentCard);
        }

        // POST: StudentCards/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            StudentCard studentCard = db.StudentCards.Find(id);
            db.StudentCards.Remove(studentCard);
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

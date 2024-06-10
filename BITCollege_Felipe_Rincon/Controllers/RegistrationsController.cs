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
* Created: 2024-01-13
* Updated: 2024-02-23
*/
/// <summary>
/// Registration Controller Customatization.
/// </summary>

namespace BITCollege_Felipe_Rincon.Controllers
{
    public class RegistrationsController : Controller
    {
        private BITCollege_Felipe_RinconContext db = new BITCollege_Felipe_RinconContext();

        // GET: Registrations
        public ActionResult Index()
        {
            var registrations = db.Registrations.Include(r => r.Course).Include(r => r.Student);
            return View(registrations.ToList());
        }

        // GET: Registrations/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Registration registration = db.Registrations.Find(id);
            if (registration == null)
            {
                return HttpNotFound();
            }
            return View(registration);
        }

        // GET: Registrations/Create
        public ActionResult Create()
        {
            ViewBag.CourseId = new SelectList(db.Courses, "CourseId", "Title");
            ViewBag.StudentId = new SelectList(db.Students, "StudentId", "FullName");
            ///ViewBag.CourseId = new SelectList(db.Courses, "CourseId", "");
            ///ViewBag.StudentId = new SelectList(db.Students, "StudentId", "FullName");
            return View();
        }

        // POST: Registrations/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "RegistrationId,StudentId,CourseId,RegistrationNumber,RegistrationDate,Grade,Notes")] Registration registration)
        {
            /// calling the SetNextCourseNumber method, been the first line of code. 
            registration.SetNextRegistrationNumber();
            if (ModelState.IsValid)
            {
                
                db.Registrations.Add(registration);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CourseId = new SelectList(db.Courses, "CourseId", "Title", registration.CourseId);
            ViewBag.StudentId = new SelectList(db.Students, "StudentId", "FullName", registration.StudentId);
            /// ViewBag.CourseId = new SelectList(db.Courses, "CourseId", "CourseNumber", registration.CourseId);
            /// ViewBag.StudentId = new SelectList(db.Students, "StudentId", "FirstName", registration.StudentId);
            return View(registration);
        }

        // GET: Registrations/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Registration registration = db.Registrations.Find(id);
            if (registration == null)
            {
                return HttpNotFound();
            }
            ViewBag.CourseId = new SelectList(db.Courses, "CourseId", "Title", registration.CourseId);
            ViewBag.StudentId = new SelectList(db.Students, "StudentId", "FullName", registration.StudentId);
            /// ViewBag.CourseId = new SelectList(db.Courses, "CourseId", "CourseNumber", registration.CourseId);
            /// ViewBag.StudentId = new SelectList(db.Students, "StudentId", "FirstName", registration.StudentId);
            return View(registration);
        }

        // POST: Registrations/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "RegistrationId,StudentId,CourseId,RegistrationNumber,RegistrationDate,Grade,Notes")] Registration registration)
        {
            if (ModelState.IsValid)
            {
                db.Entry(registration).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CourseId = new SelectList(db.Courses, "CourseId", "Title", registration.CourseId);
            ViewBag.StudentId = new SelectList(db.Students, "StudentId", "FullName", registration.StudentId);
            /// ViewBag.CourseId = new SelectList(db.Courses, "CourseId", "CourseNumber", registration.CourseId);
            /// ViewBag.StudentId = new SelectList(db.Students, "StudentId", "FirstName", registration.StudentId);
            return View(registration);
        }

        // GET: Registrations/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Registration registration = db.Registrations.Find(id);
            if (registration == null)
            {
                return HttpNotFound();
            }
            return View(registration);
        }

        // POST: Registrations/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Registration registration = db.Registrations.Find(id);
            db.Registrations.Remove(registration);
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

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
/// AuditCourses Controller Customatization.
/// </summary>

namespace BITCollege_Felipe_Rincon.Controllers
{
    public class AuditCoursesController : Controller
    {
        private BITCollege_Felipe_RinconContext db = new BITCollege_Felipe_RinconContext();

        // GET: AuditCourses
        public ActionResult Index()
        {
            /// Adjust the view for the index
            /// var courses = db.Courses.Include(a => a.AcademicProgram);
            var AuditCourses = db.AuditCourses.Include(a => a.AcademicProgram);
            ViewBag.AcademicProgram = "Academic\nProgram";
            return View(AuditCourses.ToList());  
            /// return View(courses.ToList());
        }

        // GET: AuditCourses/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            /// Casting the subtype whithin the query by the entrie generated on the context, to surpase the syntax error.
            /// AuditCourse auditCourse = db.Courses.Find(id);
            AuditCourse auditCourse = db.AuditCourses.Find(id);
            if (auditCourse == null)
            {
                return HttpNotFound();
            }
            return View(auditCourse);
        }

        // GET: AuditCourses/Create
        public ActionResult Create()
        {
            /// Initialize the FK AcademicProgramId for a downlist on the view.
            /// ViewBag.AcademicProgramId = new SelectList(db.AcademicPrograms, "AcademicProgramId", "ProgramAcronym");
            ViewBag.AcademicProgramId = new SelectList(db.AcademicPrograms, "AcademicProgramId", "ProgramAcronym");
            return View();
        }

        // POST: AuditCourses/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "CourseId,AcademicProgramId,CourseNumber,Title,CreditHours,TuitionAmount,Notes")] AuditCourse auditCourse)
        {
            /// calling the SetNextCourseNumber method, been the first line of code. 
            auditCourse.SetNextCourseNumber();
            if (ModelState.IsValid)
            {
                
                db.Courses.Add(auditCourse);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            /// Initialize the FK AcademicProgramId for a downlist on the view.
            ViewBag.AcademicProgramId = new SelectList(db.AcademicPrograms, "AcademicProgramId", "ProgramAcronym", auditCourse.AcademicProgramId);
            return View(auditCourse);
        }

        // GET: AuditCourses/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            /// Casting the subtype whithin the query by the entrie generated on the context, to surpase the syntax error.
            /// AuditCourse auditCourse = db.Courses.Find(id);
            AuditCourse auditCourse = db.AuditCourses.Find(id);
            if (auditCourse == null)
            {
                return HttpNotFound();
            }
            ViewBag.AcademicProgramId = new SelectList(db.AcademicPrograms, "AcademicProgramId", "ProgramAcronym", auditCourse.AcademicProgramId);
            return View(auditCourse);
        }

        // POST: AuditCourses/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "CourseId,AcademicProgramId,CourseNumber,Title,CreditHours,TuitionAmount,Notes")] AuditCourse auditCourse)
        {
            if (ModelState.IsValid)
            {
                db.Entry(auditCourse).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.AcademicProgramId = new SelectList(db.AcademicPrograms, "AcademicProgramId", "ProgramAcronym", auditCourse.AcademicProgramId);
            return View(auditCourse);
        }

        // GET: AuditCourses/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            /// Casting the subtype whithin the query by the entrie generated on the context, to surpase the syntax error.
            /// AuditCourse auditCourse = db.Courses.Find(id);
            AuditCourse auditCourse = db.AuditCourses.Find(id);
            if (auditCourse == null)
            {
                return HttpNotFound();
            }
            return View(auditCourse);
        }

        // POST: AuditCourses/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            /// Casting the subtype whithin the query by the entrie generated on the context, to surpase the syntax error.
            /// AuditCourse auditCourse = db.Courses.Find(id);
            AuditCourse auditCourse = db.AuditCourses.Find(id);
            db.Courses.Remove(auditCourse);
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

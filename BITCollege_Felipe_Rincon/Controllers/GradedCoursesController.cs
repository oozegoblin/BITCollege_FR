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
/// GradedCourses Controller Customatization.
/// </summary>

namespace BITCollege_Felipe_Rincon.Controllers
{
    public class GradedCoursesController : Controller
    {
        private BITCollege_Felipe_RinconContext db = new BITCollege_Felipe_RinconContext();

        // GET: GradedCourses
        public ActionResult Index()
        {
            /// var courses = db.Courses.Include(g => g.AcademicProgram);
            var GradedCourse = db.GradedCourses.Include(a => a.AcademicProgram);
            ViewBag.AcademicProgram = "Academic\nProgram";
            return View(GradedCourse.ToList());
            /// return View(courses.ToList());
        }

        // GET: GradedCourses/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            /// Casting the subtype whithin the query by the entrie generated on the context, to surpase the syntax error.
            /// GradedCourse gradedCourse = db.Courses.Find(id);
            GradedCourse gradedCourse = db.GradedCourses.Find(id);
            if (gradedCourse == null)
            {
                return HttpNotFound();
            }
            return View(gradedCourse);
        }

        // GET: GradedCourses/Create
        public ActionResult Create()
        {
            ViewBag.AcademicProgramId = new SelectList(db.AcademicPrograms, "AcademicProgramId", "ProgramAcronym");
            return View();
        }

        // POST: GradedCourses/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "CourseId,AcademicProgramId,CourseNumber,Title,CreditHours,TuitionAmount,Notes,AssignmentWeight,MidtermWeight,FinalWeight")] GradedCourse gradedCourse)
        {
            /// calling the SetNextCourseNumber method, been the first line of code. 
            gradedCourse.SetNextCourseNumber();
            if (ModelState.IsValid)
            {
                db.Courses.Add(gradedCourse);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.AcademicProgramId = new SelectList(db.AcademicPrograms, "AcademicProgramId", "ProgramAcronym", gradedCourse.AcademicProgramId);
            return View(gradedCourse);
        }

        // GET: GradedCourses/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            /// Casting the subtype whithin the query by the entrie generated on the context, to surpase the syntax error.
            /// GradedCourse gradedCourse = db.Courses.Find(id);
            GradedCourse gradedCourse = db.GradedCourses.Find(id);
            if (gradedCourse == null)
            {
                return HttpNotFound();
            }
            ViewBag.AcademicProgramId = new SelectList(db.AcademicPrograms, "AcademicProgramId", "ProgramAcronym", gradedCourse.AcademicProgramId);
            return View(gradedCourse);
        }

        // POST: GradedCourses/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "CourseId,AcademicProgramId,CourseNumber,Title,CreditHours,TuitionAmount,Notes,AssignmentWeight,MidtermWeight,FinalWeight")] GradedCourse gradedCourse)
        {
            
            if (ModelState.IsValid)
            {
                db.Entry(gradedCourse).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.AcademicProgramId = new SelectList(db.AcademicPrograms, "AcademicProgramId", "ProgramAcronym", gradedCourse.AcademicProgramId);
            return View(gradedCourse);
        }

        // GET: GradedCourses/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            /// Casting the subtype whithin the query by the entrie generated on the context, to surpase the syntax error.
            /// GradedCourse gradedCourse = db.Courses.Find(id);
            GradedCourse gradedCourse = db.GradedCourses.Find(id);
            if (gradedCourse == null)
            {
                return HttpNotFound();
            }
            return View(gradedCourse);
        }

        // POST: GradedCourses/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            /// Casting the subtype whithin the query by the entrie generated on the context, to surpase the syntax error.
            /// GradedCourse gradedCourse = db.Courses.Find(id);
            GradedCourse gradedCourse = db.GradedCourses.Find(id);
            db.Courses.Remove(gradedCourse);
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

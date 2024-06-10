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
/// Student Controller Customatization and modified for Assignment 2.
/// </summary>

namespace BITCollege_Felipe_Rincon.Controllers
{
    public class StudentsController : Controller
    {
        private BITCollege_Felipe_RinconContext db = new BITCollege_Felipe_RinconContext();

        // GET: Students
        public ActionResult Index()
        {
            var students = db.Students.Include(s => s.AcademicProgram).Include(s => s.GradePointState);
            return View(students.ToList());
        }

        // GET: Students/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Student student = db.Students.Find(id);
            if (student == null)
            {
                return HttpNotFound();
            }
            return View(student);
        }

        // GET: Students/Create
        public ActionResult Create()
        {
            ViewBag.AcademicProgramId = new SelectList(db.AcademicPrograms, "AcademicProgramId", "ProgramAcronym");
            /// ViewBag.GradePointStateId = new SelectList(db.GradePointStates, "GradePointStateId", "GradePointStateId");
            ViewBag.GradePointStateId = new SelectList(db.GradePointStates, "GradePointStateId", "Description");
            return View();
        }

        // POST: Students/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "StudentId,GradePointStateId,AcademicProgramId,StudentNumber,FirstName,LastName,Address,City,Province,PostalCode,DateCreated,GradePointAverage,OutstandingFees,Notes")] Student student)
        {
            /// calling the SetNextCourseNumber method, been the first line of code. 
            student.SetNextStudentNumber();
            if (ModelState.IsValid)
            {
                /// Similar process applied to the Create view.
                db.Students.Add(student);
                db.SaveChanges();
                student.ChangeState();
                return RedirectToAction("Index");
            }
            ViewBag.AcademicProgramId = new SelectList(db.AcademicPrograms, "AcademicProgramId", "ProgramAcronym", student.AcademicProgramId);
            /// ViewBag.GradePointStateId = new SelectList(db.GradePointStates, "GradePointStateId", "GradePointStateId", student.GradePointStateId);
            ViewBag.GradePointStateId = new SelectList(db.GradePointStates, "GradePointStateId", "Description", student.GradePointStateId);
            return View(student);
        }

        // GET: Students/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Student student = db.Students.Find(id);
            if (student == null)
            {
                return HttpNotFound();
            }
            ViewBag.AcademicProgramId = new SelectList(db.AcademicPrograms, "AcademicProgramId", "ProgramAcronym", student.AcademicProgramId);
            /// ViewBag.GradePointStateId = new SelectList(db.GradePointStates, "GradePointStateId", "GradePointStateId", student.GradePointStateId);
            ViewBag.GradePointStateId = new SelectList(db.GradePointStates, "GradePointStateId", "Description", student.GradePointStateId);
            return View(student);
        }

        // POST: Students/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "StudentId,GradePointStateId,AcademicProgramId,StudentNumber,FirstName,LastName,Address,City,Province,PostalCode,DateCreated,GradePointAverage,OutstandingFees,Notes")] Student student)
        {
            
            if (ModelState.IsValid)
            {
                /// ChangeState method called, and edit view modified.
                db.Entry(student).State = EntityState.Modified;
                db.SaveChanges();
                student.ChangeState();
                return RedirectToAction("Index");
            }
            ViewBag.AcademicProgramId = new SelectList(db.AcademicPrograms, "AcademicProgramId", "ProgramAcronym", student.AcademicProgramId);
            /// ViewBag.GradePointStateId = new SelectList(db.GradePointStates, "GradePointStateId", "GradePointStateId", student.GradePointStateId);
            ViewBag.GradePointStateId = new SelectList(db.GradePointStates, "GradePointStateId", "Description", student.GradePointStateId);
            return View(student);
        }

        // GET: Students/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Student student = db.Students.Find(id);
            if (student == null)
            {
                return HttpNotFound();
            }
            return View(student);
        }
        // POST: Students/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Student student = db.Students.Find(id);
            db.Students.Remove(student);
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

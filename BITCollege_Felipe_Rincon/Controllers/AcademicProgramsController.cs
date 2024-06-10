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
* Updated: 2024-01-27
*/
/// <summary>
/// AcademicProgram Controller Customatization.
/// </summary>
namespace BITCollege_Felipe_Rincon.Controllers
{
    public class AcademicProgramsController : Controller
    {
        private BITCollege_Felipe_RinconContext db = new BITCollege_Felipe_RinconContext();

        // GET: AcademicPrograms
        public ActionResult Index()
        {
            return View(db.AcademicPrograms.ToList());
        }

        // GET: AcademicPrograms/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AcademicProgram academicProgram = db.AcademicPrograms.Find(id);
            if (academicProgram == null)
            {
                return HttpNotFound();
            }
            return View(academicProgram);
        }

        // GET: AcademicPrograms/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: AcademicPrograms/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "AcademicProgramId,ProgramAcronym,Description")] AcademicProgram academicProgram)
        {
            if (ModelState.IsValid)
            {
                db.AcademicPrograms.Add(academicProgram);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(academicProgram);
        }

        // GET: AcademicPrograms/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AcademicProgram academicProgram = db.AcademicPrograms.Find(id);
            if (academicProgram == null)
            {
                return HttpNotFound();
            }
            return View(academicProgram);
        }

        // POST: AcademicPrograms/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "AcademicProgramId,ProgramAcronym,Description")] AcademicProgram academicProgram)
        {
            if (ModelState.IsValid)
            {
                db.Entry(academicProgram).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(academicProgram);
        }

        // GET: AcademicPrograms/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AcademicProgram academicProgram = db.AcademicPrograms.Find(id);
            if (academicProgram == null)
            {
                return HttpNotFound();
            }
            return View(academicProgram);
        }

        // POST: AcademicPrograms/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        /// The following Clear methods, will prevent the deletion of any related Student or Course record, 
        /// when an cascading deletion from AcademicProgram FK, such preventing that the child records,
        /// will deleted.
        public ActionResult DeleteConfirmed(int id)
        {
 
           
            AcademicProgram academicProgram = db.AcademicPrograms.Find(id);
            /// Insertion of the clear coding, as assignment shows and proceed
            /// Clearing the relationship between AcademicProgram and Students
            academicProgram.Student.Clear();
            /// One more time, now with Courses
            academicProgram.Course.Clear();
            /// Remove the complete delete, to prevent the related records.
            db.AcademicPrograms.Remove(academicProgram);
            /// Compiled and tested with 1 created data. 
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

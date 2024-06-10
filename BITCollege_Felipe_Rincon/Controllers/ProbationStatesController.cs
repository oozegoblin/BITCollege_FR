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
* Updated: 2024-02-06
*/
/// <summary>
/// ProbationStatesController Customatization.
/// </summary>
namespace BITCollege_Felipe_Rincon.Controllers
{
    public class ProbationStatesController : Controller
    {
        private BITCollege_Felipe_RinconContext db = new BITCollege_Felipe_RinconContext();

        // GET: ProbationStates, now with implementation of the Singleton Pattern 
        public ActionResult Index()
        {
            /// ActionResult method updated.
            return View(ProbationState.GetInstance());
            /// return View(db.ProbationStates);
            /// return View(db.GradePointStates.ToList());
        }
        

        // GET: ProbationStates/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            /// Casting the subtype whithin the query by the entrie generated on the context, to surpase the syntax error.
            /// I used the other db style. 
            /// ProbationState probationState = db.GradePointStates.Find(id);
            ProbationState probationState = (ProbationState)db.GradePointStates.Find(id);
            if (probationState == null)
            {
                return HttpNotFound();
            }
            return View(probationState);
        }

        // GET: ProbationStates/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ProbationStates/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "GradePointStateId,LowerLimit,UpperLimit,TuitionRateFactor")] ProbationState probationState)
        {
            if (ModelState.IsValid)
            {
                db.GradePointStates.Add(probationState);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(probationState);
        }

        // GET: ProbationStates/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            /// Casting the subtype whithin the query by the entrie generated on the context, to surpase the syntax error.
            /// ProbationState probationState = db.GradePointStates.Find(id);
            ProbationState probationState = (ProbationState)db.GradePointStates.Find(id);
            if (probationState == null)
            {
                return HttpNotFound();
            }
            return View(probationState);
        }

        // POST: ProbationStates/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "GradePointStateId,LowerLimit,UpperLimit,TuitionRateFactor")] ProbationState probationState)
        {
            if (ModelState.IsValid)
            {
                db.Entry(probationState).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(probationState);
        }

        // GET: ProbationStates/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            /// Casting the subtype whithin the query by the entrie generated on the context, to surpase the syntax error.
            /// ProbationState probationState = db.GradePointStates.Find(id);
            ProbationState probationState = (ProbationState)db.GradePointStates.Find(id);
            if (probationState == null)
            {
                return HttpNotFound();
            }
            return View(probationState);
        }

        // POST: ProbationStates/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            /// Casting the subtype whithin the query by the entrie generated on the context, to surpase the syntax error.
            /// ProbationState probationState = db.GradePointStates.Find(id);
            ProbationState probationState = (ProbationState)db.GradePointStates.Find(id);
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

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
* Updated: 2024-02-04
*/
/// <summary>
/// SuspendedStatesController Customatization.
/// </summary>
namespace BITCollege_Felipe_Rincon.Controllers
{
    public class SuspendedStatesController : Controller
    {
        private BITCollege_Felipe_RinconContext db = new BITCollege_Felipe_RinconContext();

        // GET: SuspendedStates, now with implementation of the Singleton Pattern 
        public ActionResult Index()
        {
            /// ActionResult method updated.
            return View(SuspendedState.GetInstance());
            /// return View(db.SuspendedStates);
            /// return View(db.GradePointStates.ToList());
        }

        // GET: SuspendedStates/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            /// Casting the subtype whithin the query by the entrie generated on the context, to surpase the syntax error.
            /// SuspendedState suspendedState = db.GradePointStates.Find(id);
            SuspendedState suspendedState = db.SuspendedStates.Find(id);
            if (suspendedState == null)
            {
                return HttpNotFound();
            }
            return View(suspendedState);
        }

        // GET: SuspendedStates/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: SuspendedStates/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "GradePointStateId,LowerLimit,UpperLimit,TuitionRateFactor")] SuspendedState suspendedState)
        {
            if (ModelState.IsValid)
            {
                db.GradePointStates.Add(suspendedState);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(suspendedState);
        }

        // GET: SuspendedStates/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            /// Casting the subtype whithin the query by the entrie generated on the context, to surpase the syntax error.
            /// SuspendedState suspendedState = db.GradePointStates.Find(id);
            SuspendedState suspendedState = db.SuspendedStates.Find(id);
            if (suspendedState == null)
            {
                return HttpNotFound();
            }
            return View(suspendedState);
        }

        // POST: SuspendedStates/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "GradePointStateId,LowerLimit,UpperLimit,TuitionRateFactor")] SuspendedState suspendedState)
        {
            if (ModelState.IsValid)
            {
                db.Entry(suspendedState).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(suspendedState);
        }

        // GET: SuspendedStates/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            /// Casting the subtype whithin the query by the entrie generated on the context, to surpase the syntax error.
            /// SuspendedState suspendedState = db.GradePointStates.Find(id);
            SuspendedState suspendedState = db.SuspendedStates.Find(id);
            if (suspendedState == null)
            {
                return HttpNotFound();
            }
            return View(suspendedState);
        }

        // POST: SuspendedStates/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            /// Casting the subtype whithin the query by the entrie generated on the context, to surpase the syntax error.
            /// SuspendedState suspendedState = db.GradePointStates.Find(id);
            SuspendedState suspendedState = db.SuspendedStates.Find(id);
            db.GradePointStates.Remove(suspendedState);
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

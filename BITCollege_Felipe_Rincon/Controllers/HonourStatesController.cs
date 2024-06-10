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
* Updated: 2024-01-04
*/
/// <summary>
/// HonourStatesController Customatization.
/// </summary>
namespace BITCollege_Felipe_Rincon.Controllers
{
    public class HonourStatesController : Controller
    {
        private BITCollege_Felipe_RinconContext db = new BITCollege_Felipe_RinconContext();

        // GET: HonourStates, now with implementation of the Singleton Pattern 
        public ActionResult Index()
        {
            /// ActionResult method updated.
            return View(HonourState.GetInstance());
            /// return View(db.HonourStates);
            /// return View(db.GradePointStates.ToList());
        }

        // GET: HonourStates/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            /// Casting the subtype whithin the query by the entrie generated on the context, to surpase the syntax error.
            /// I used the other db style. 
            /// HonourState honourState = db.GradePointStates.Find(id);
            HonourState honourState = (HonourState)db.GradePointStates.Find(id);
            if (honourState == null)
            {
                return HttpNotFound();
            }
            return View(honourState);
        }

        // GET: HonourStates/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: HonourStates/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "GradePointStateId,LowerLimit,UpperLimit,TuitionRateFactor")] HonourState honourState)
        {
            if (ModelState.IsValid)
            {
                db.GradePointStates.Add(honourState);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(honourState);
        }

        // GET: HonourStates/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            /// Casting the subtype whithin the query by the entrie generated on the context, to surpase the syntax error.
            /// HonourState honourState = db.GradePointStates.Find(id);
            HonourState honourState = (HonourState)db.GradePointStates.Find(id);
            if (honourState == null)
            {
                return HttpNotFound();
            }
            return View(honourState);
        }

        // POST: HonourStates/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "GradePointStateId,LowerLimit,UpperLimit,TuitionRateFactor")] HonourState honourState)
        {
            if (ModelState.IsValid)
            {
                db.Entry(honourState).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(honourState);
        }

        // GET: HonourStates/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            /// Casting the subtype whithin the query by the entrie generated on the context, to surpase the syntax error.
            /// HonourState honourState = db.GradePointStates.Find(id);
            HonourState honourState = (HonourState)db.GradePointStates.Find(id);
            if (honourState == null)
            {
                return HttpNotFound();
            }
            return View(honourState);
        }

        // POST: HonourStates/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            /// Casting the subtype whithin the query by the entrie generated on the context, to surpase the syntax error.
            /// HonourState honourState = db.GradePointStates.Find(id);
            HonourState honourState = (HonourState)db.GradePointStates.Find(id);
            db.GradePointStates.Remove(honourState);
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

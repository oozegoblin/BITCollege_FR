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

namespace BITCollege_Felipe_Rincon.Controllers
{
    public class NextUniqueNumbersController : Controller
    {
        private BITCollege_Felipe_RinconContext db = new BITCollege_Felipe_RinconContext();

        // GET: NextUniqueNumbers
        public ActionResult Index()
        {
            return View(db.NextUniqueNumbers.ToList());
        }

        // GET: NextUniqueNumbers/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            NextUniqueNumber nextUniqueNumber = db.NextUniqueNumbers.Find(id);
            if (nextUniqueNumber == null)
            {
                return HttpNotFound();
            }
            return View(nextUniqueNumber);
        }

        // GET: NextUniqueNumbers/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: NextUniqueNumbers/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "NextUniqueNumberId,NextAvailableNumber")] NextUniqueNumber nextUniqueNumber)
        {
            if (ModelState.IsValid)
            {
                db.NextUniqueNumbers.Add(nextUniqueNumber);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(nextUniqueNumber);
        }

        // GET: NextUniqueNumbers/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            NextUniqueNumber nextUniqueNumber = db.NextUniqueNumbers.Find(id);
            if (nextUniqueNumber == null)
            {
                return HttpNotFound();
            }
            return View(nextUniqueNumber);
        }

        // POST: NextUniqueNumbers/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "NextUniqueNumberId,NextAvailableNumber")] NextUniqueNumber nextUniqueNumber)
        {
            if (ModelState.IsValid)
            {
                db.Entry(nextUniqueNumber).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(nextUniqueNumber);
        }

        // GET: NextUniqueNumbers/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            NextUniqueNumber nextUniqueNumber = db.NextUniqueNumbers.Find(id);
            if (nextUniqueNumber == null)
            {
                return HttpNotFound();
            }
            return View(nextUniqueNumber);
        }

        // POST: NextUniqueNumbers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            NextUniqueNumber nextUniqueNumber = db.NextUniqueNumbers.Find(id);
            db.NextUniqueNumbers.Remove(nextUniqueNumber);
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

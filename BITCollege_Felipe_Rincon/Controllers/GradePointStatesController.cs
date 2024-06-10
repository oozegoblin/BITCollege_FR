﻿using System;
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
* Updated: 2024-01-28
*/
/// <summary>
/// GradePointStates Controller Customatization.
/// </summary>

namespace BITCollege_Felipe_Rincon.Controllers
{
    public class GradePointStatesController : Controller
    {
        private BITCollege_Felipe_RinconContext db = new BITCollege_Felipe_RinconContext();

        // GET: GradePointStates
        public ActionResult Index()
        {
            return View(db.GradePointStates.ToList());
        }

        // GET: GradePointStates/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            GradePointState gradePointState = db.GradePointStates.Find(id);
            if (gradePointState == null)
            {
                return HttpNotFound();
            }
            return View(gradePointState);
        }

        // GET: GradePointStates/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: GradePointStates/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "GradePointStateId,LowerLimit,UpperLimit,TuitionRateFactor")] GradePointState gradePointState)
        {
            if (ModelState.IsValid)
            {
                db.GradePointStates.Add(gradePointState);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(gradePointState);
        }

        // GET: GradePointStates/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            GradePointState gradePointState = db.GradePointStates.Find(id);
            if (gradePointState == null)
            {
                return HttpNotFound();
            }
            return View(gradePointState);
        }

        // POST: GradePointStates/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "GradePointStateId,LowerLimit,UpperLimit,TuitionRateFactor")] GradePointState gradePointState)
        {
            if (ModelState.IsValid)
            {
                db.Entry(gradePointState).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(gradePointState);
        }

        // GET: GradePointStates/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            GradePointState gradePointState = db.GradePointStates.Find(id);
            if (gradePointState == null)
            {
                return HttpNotFound();
            }
            return View(gradePointState);
        }

        // POST: GradePointStates/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            GradePointState gradePointState = db.GradePointStates.Find(id);
            db.GradePointStates.Remove(gradePointState);
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

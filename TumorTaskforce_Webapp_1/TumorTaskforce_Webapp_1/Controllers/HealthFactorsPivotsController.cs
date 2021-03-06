﻿using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using TumorTaskforce_Webapp_1;
using TumorTaskforce_Webapp_1.Models;

namespace TumorTaskforce_Webapp_1.Controllers
{
    public class HealthFactorsPivotsController : Controller
    {
        private tumorDBEntities db = new tumorDBEntities();

        // GET: HealthFactorsPivots
        public ActionResult Index()
        {
            var healthFactorsPivots = db.HealthFactorsPivots.Include(h => h.Patient).Include(h => h.PossibleHealthFactor);
            if (User.Identity.IsAuthenticated)
            {
                ViewBag.displayMenu = "No";
                if (isAdminUser())
                {
                    ViewBag.displayMenu = "Yes";
                }
            }
            return View(healthFactorsPivots.ToList());
        }

        // GET: HealthFactorsPivots/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            HealthFactorsPivot healthFactorsPivot = db.HealthFactorsPivots.Find(id);
            if (healthFactorsPivot == null)
            {
                return HttpNotFound();
            }
            Patient p = healthFactorsPivot.Patient;
            if (User.Identity.IsAuthenticated)
            {
                ViewBag.displayMenu = "No";
                if (isAdminUser() || (p.isCompare && p.userName == User.Identity.GetUserName()))
                {
                    ViewBag.displayMenu = "Yes";
                }
            }
            return View(healthFactorsPivot);
        }

        // GET: HealthFactorsPivots/Create
        public ActionResult Create(int? patientID)
        {
            if (patientID == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Patient p = db.Patients.Find(patientID);
            if (p == null)
            {
                return HttpNotFound();
            }
            Patient[] sel = new Patient[1];
            sel[0] = p;
            ViewBag.showLink = isAdminUser();
            ViewBag.patientID = new SelectList(sel, "patientID", "patientID");
            ViewBag.datapieceID = new SelectList(db.PossibleHealthFactors, "Id", "Name");
            if (User.Identity.IsAuthenticated)
            {
                ViewBag.displayMenu = "No";
                if (isAdminUser() || (p.isCompare && p.userName == User.Identity.GetUserName()))
                {
                    ViewBag.displayMenu = "Yes";
                }
            }
            return View();
        }

        // POST: HealthFactorsPivots/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,patientID,datapieceID,date,frequency,notes")] HealthFactorsPivot healthFactorsPivot)
        {
            if (ModelState.IsValid)
            {
                db.HealthFactorsPivots.Add(healthFactorsPivot);
                db.SaveChanges();
                return RedirectToAction("Details", "Patients", new { id = healthFactorsPivot.patientID });
            }
            Patient[] sel = new Patient[1];
            sel[0] = db.Patients.Find(healthFactorsPivot.patientID);
            ViewBag.patientID = new SelectList(sel, "patientID", "patientID");
            ViewBag.datapieceID = new SelectList(db.PossibleHealthFactors, "Id", "Name", healthFactorsPivot.datapieceID);
            if (User.Identity.IsAuthenticated)
            {
                ViewBag.displayMenu = "No";
                if (isAdminUser() || (sel[0].isCompare && sel[0].userName == User.Identity.GetUserName()))
                {
                    ViewBag.displayMenu = "Yes";
                }
            }
            return View(healthFactorsPivot);
        }

        // GET: HealthFactorsPivots/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            HealthFactorsPivot healthFactorsPivot = db.HealthFactorsPivots.Find(id);
            if (healthFactorsPivot == null)
            {
                return HttpNotFound();
            }
            Patient[] sel = new Patient[1];
            sel[0] = db.Patients.Find(healthFactorsPivot.patientID);
            ViewBag.patientID = new SelectList(sel, "patientID", "patientID");
            ViewBag.datapieceID = new SelectList(db.PossibleHealthFactors, "Id", "Name", healthFactorsPivot.datapieceID);
            if (User.Identity.IsAuthenticated)
            {
                ViewBag.displayMenu = "No";
                if (isAdminUser() || (sel[0].isCompare && sel[0].userName == User.Identity.GetUserName()))
                {
                    ViewBag.displayMenu = "Yes";
                }
            }
            return View(healthFactorsPivot);
        }

        // POST: HealthFactorsPivots/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,patientID,datapieceID,date,frequency,notes")] HealthFactorsPivot healthFactorsPivot)
        {
            if (ModelState.IsValid)
            {
                db.Entry(healthFactorsPivot).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Details", "Patients", new { id = healthFactorsPivot.patientID });
            }
            Patient[] sel = new Patient[1];
            sel[0] = db.Patients.Find(healthFactorsPivot.patientID);
            ViewBag.patientID = new SelectList(sel, "patientID", "patientID");
            ViewBag.datapieceID = new SelectList(db.PossibleHealthFactors, "Id", "Name", healthFactorsPivot.datapieceID);
            if (User.Identity.IsAuthenticated)
            {
                ViewBag.displayMenu = "No";
                if (isAdminUser() || (sel[0].isCompare && sel[0].userName == User.Identity.GetUserName()))
                {
                    ViewBag.displayMenu = "Yes";
                }
            }
            return View(healthFactorsPivot);
        }

        // GET: HealthFactorsPivots/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            HealthFactorsPivot healthFactorsPivot = db.HealthFactorsPivots.Find(id);
            if (healthFactorsPivot == null)
            {
                return HttpNotFound();
            }
            Patient p = healthFactorsPivot.Patient;
            if (User.Identity.IsAuthenticated)
            {
                ViewBag.displayMenu = "No";
                if (isAdminUser() || (p.isCompare && p.userName == User.Identity.GetUserName()))
                {
                    ViewBag.displayMenu = "Yes";
                }
            }
            return View(healthFactorsPivot);
        }

        // POST: HealthFactorsPivots/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            HealthFactorsPivot healthFactorsPivot = db.HealthFactorsPivots.Find(id);
            db.HealthFactorsPivots.Remove(healthFactorsPivot);
            db.SaveChanges();
            return RedirectToAction("Details", "Patients", new { id = healthFactorsPivot.patientID });
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        public Boolean isAdminUser()
        {
            if (User.Identity.IsAuthenticated)
            {
                var user = User.Identity;
                ApplicationDbContext context = new ApplicationDbContext();
                var UserManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(context));
                var s = UserManager.GetRoles(user.GetUserId());
                if (s[0].ToString() == "Admin")
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            return false;
        }
    }
}

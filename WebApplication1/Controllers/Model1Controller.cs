using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class Model1Controller : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Model1
        public ActionResult Index()
        {
            return View(db.Model1.ToList());
        }

        // GET: Model1/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Model1 model1 = db.Model1.Find(id);
            if (model1 == null)
            {
                return HttpNotFound();
            }
            return View(model1);
        }

        // GET: Model1/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Model1/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Model1ID,Model1Name")] Model1 model1)
        {
            if (ModelState.IsValid)
            {
                db.Model1.Add(model1);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(model1);
        }

        // GET: Model1/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Model1 model1 = db.Model1.Find(id);
            if (model1 == null)
            {
                return HttpNotFound();
            }
            return View(model1);
        }

        // POST: Model1/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Model1ID,Model1Name")] Model1 model1)
        {
            if (ModelState.IsValid)
            {
                db.Entry(model1).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(model1);
        }

        // GET: Model1/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Model1 model1 = db.Model1.Find(id);
            if (model1 == null)
            {
                return HttpNotFound();
            }
            return View(model1);
        }

        // POST: Model1/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Model1 model1 = db.Model1.Find(id);
            db.Model1.Remove(model1);
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

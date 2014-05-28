using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace DigitalPepak
{
    public class KuisController : Controller
    {
        private DigitalPepakEntities db = new DigitalPepakEntities();

        // GET: /Kuis/
        public ActionResult Index()
        {
            var kuis = db.Kuis.Include(k => k.Kewan).Include(k => k.Tetuwuhan);
            return View(kuis.ToList());
        }

        // GET: /Kuis/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Kuis kuis = db.Kuis.Find(id);
            if (kuis == null)
            {
                return HttpNotFound();
            }
            return View(kuis);
        }

        // GET: /Kuis/Create
        public ActionResult Create()
        {
            ViewBag.KewanId = new SelectList(db.Kewan, "KewanId", "NamaKewan");
            ViewBag.KembangId = new SelectList(db.Tetuwuhan, "KembangId", "Tetuwuhan1");
            return View();
        }

        // POST: /Kuis/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="KuisId,Pertanyaan,KewanId,KembangId")] Kuis kuis)
        {
            if (ModelState.IsValid)
            {
                db.Kuis.Add(kuis);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.KewanId = new SelectList(db.Kewan, "KewanId", "NamaKewan", kuis.KewanId);
            ViewBag.KembangId = new SelectList(db.Tetuwuhan, "KembangId", "Tetuwuhan1", kuis.KembangId);
            return View(kuis);
        }

        // GET: /Kuis/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Kuis kuis = db.Kuis.Find(id);
            if (kuis == null)
            {
                return HttpNotFound();
            }
            ViewBag.KewanId = new SelectList(db.Kewan, "KewanId", "NamaKewan", kuis.KewanId);
            ViewBag.KembangId = new SelectList(db.Tetuwuhan, "KembangId", "Tetuwuhan1", kuis.KembangId);
            return View(kuis);
        }

        // POST: /Kuis/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="KuisId,Pertanyaan,KewanId,KembangId")] Kuis kuis)
        {
            if (ModelState.IsValid)
            {
                db.Entry(kuis).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.KewanId = new SelectList(db.Kewan, "KewanId", "NamaKewan", kuis.KewanId);
            ViewBag.KembangId = new SelectList(db.Tetuwuhan, "KembangId", "Tetuwuhan1", kuis.KembangId);
            return View(kuis);
        }

        // GET: /Kuis/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Kuis kuis = db.Kuis.Find(id);
            if (kuis == null)
            {
                return HttpNotFound();
            }
            return View(kuis);
        }

        // POST: /Kuis/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Kuis kuis = db.Kuis.Find(id);
            db.Kuis.Remove(kuis);
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

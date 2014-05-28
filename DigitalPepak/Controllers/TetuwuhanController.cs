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
    public class TetuwuhanController : Controller
    {
        private DigitalPepakEntities db = new DigitalPepakEntities();

        // GET: /Tetuwuhan/
        public ActionResult Index()
        {
            return View(db.Tetuwuhan.ToList());
        }

        // GET: /Tetuwuhan/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tetuwuhan tetuwuhan = db.Tetuwuhan.Find(id);
            if (tetuwuhan == null)
            {
                return HttpNotFound();
            }
            return View(tetuwuhan);
        }

        // GET: /Tetuwuhan/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: /Tetuwuhan/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="KembangId,Tetuwuhan1,AraneKembang")] Tetuwuhan tetuwuhan)
        {
            if (ModelState.IsValid)
            {
                db.Tetuwuhan.Add(tetuwuhan);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tetuwuhan);
        }

        // GET: /Tetuwuhan/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tetuwuhan tetuwuhan = db.Tetuwuhan.Find(id);
            if (tetuwuhan == null)
            {
                return HttpNotFound();
            }
            return View(tetuwuhan);
        }

        // POST: /Tetuwuhan/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="KembangId,Tetuwuhan1,AraneKembang")] Tetuwuhan tetuwuhan)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tetuwuhan).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tetuwuhan);
        }

        // GET: /Tetuwuhan/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tetuwuhan tetuwuhan = db.Tetuwuhan.Find(id);
            if (tetuwuhan == null)
            {
                return HttpNotFound();
            }
            return View(tetuwuhan);
        }

        // POST: /Tetuwuhan/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Tetuwuhan tetuwuhan = db.Tetuwuhan.Find(id);
            db.Tetuwuhan.Remove(tetuwuhan);
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

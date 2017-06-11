using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using CRUDWebApi;

namespace CRUDWebApi.Controllers
{
    public class SorunTableController : Controller
    {
        private STS2017Entities db = new STS2017Entities();

        // GET: SorunTable
        public ActionResult Index()
        {
            return View(db.TBL_SORUN_.ToList());
        }

        // GET: SorunTable/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TBL_SORUN_ tBL_SORUN_ = db.TBL_SORUN_.Find(id);
            if (tBL_SORUN_ == null)
            {
                return HttpNotFound();
            }
            return View(tBL_SORUN_);
        }

        // GET: SorunTable/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: SorunTable/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Yetkili,Bolge,Aciklama")] TBL_SORUN_ tBL_SORUN_)
        {
            if (ModelState.IsValid)
            {
                db.TBL_SORUN_.Add(tBL_SORUN_);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tBL_SORUN_);
        }

        // GET: SorunTable/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TBL_SORUN_ tBL_SORUN_ = db.TBL_SORUN_.Find(id);
            if (tBL_SORUN_ == null)
            {
                return HttpNotFound();
            }
            return View(tBL_SORUN_);
        }

        // POST: SorunTable/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Yetkili,Bolge,Aciklama")] TBL_SORUN_ tBL_SORUN_)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tBL_SORUN_).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tBL_SORUN_);
        }

        // GET: SorunTable/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TBL_SORUN_ tBL_SORUN_ = db.TBL_SORUN_.Find(id);
            if (tBL_SORUN_ == null)
            {
                return HttpNotFound();
            }
            return View(tBL_SORUN_);
        }

        // POST: SorunTable/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            TBL_SORUN_ tBL_SORUN_ = db.TBL_SORUN_.Find(id);
            db.TBL_SORUN_.Remove(tBL_SORUN_);
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

using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using BankApp.MvcUI.Entities;

namespace BankApp.MvcUI.Controllers
{
    public class MusteriController : Controller
    {
        private Entities.BankApp db = new Entities.BankApp();

        // GET: Musteri
        public ActionResult Index()
        {
            return View(db.tbl_Musteriler.ToList());
        }

        // GET: Musteri/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbl_Musteriler tbl_Musteriler = db.tbl_Musteriler.Find(id);
            if (tbl_Musteriler == null)
            {
                return HttpNotFound();
            }
            return View(tbl_Musteriler);
        }

        // GET: Musteri/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Musteri/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "musteriId,TCKN,sifre,isim,soyisim,cinsiyet,dogumTarihi,kizlikSoyadi,musteriTipi,musteriPuani")] tbl_Musteriler tbl_Musteriler)
        {
            if (ModelState.IsValid)
            {
                db.tbl_Musteriler.Add(tbl_Musteriler);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tbl_Musteriler);
        }

        // GET: Musteri/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbl_Musteriler tbl_Musteriler = db.tbl_Musteriler.Find(id);
            if (tbl_Musteriler == null)
            {
                return HttpNotFound();
            }
            return View(tbl_Musteriler);
        }

        // POST: Musteri/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "musteriId,TCKN,sifre,isim,soyisim,cinsiyet,dogumTarihi,kizlikSoyadi,musteriTipi,musteriPuani")] tbl_Musteriler tbl_Musteriler)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tbl_Musteriler).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tbl_Musteriler);
        }

        // GET: Musteri/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbl_Musteriler tbl_Musteriler = db.tbl_Musteriler.Find(id);
            if (tbl_Musteriler == null)
            {
                return HttpNotFound();
            }
            return View(tbl_Musteriler);
        }

        // POST: Musteri/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            tbl_Musteriler tbl_Musteriler = db.tbl_Musteriler.Find(id);
            db.tbl_Musteriler.Remove(tbl_Musteriler);
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

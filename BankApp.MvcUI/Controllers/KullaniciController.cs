using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using BankApp.MvcUI.Entities;
using BankApp.MvcUI.ModelView;

namespace BankApp.MvcUI.Controllers
{
    public class KullaniciController : Controller
    {
        private YazilimBakimiEntities db = new YazilimBakimiEntities();

        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(string tcNo, string sifre)
        {
            var kullanici = db.tbl_Musteriler.FirstOrDefault(x=>x.TCKN == tcNo && x.sifre == sifre);
            if (kullanici != null)
            {
                return RedirectToAction("Index","Home");
            }
            else
                return View();
        }

        // GET: Kullanici
        public ActionResult Index()
        {
            return View(db.tbl_Musteriler.ToList());
        }

        // GET: Kullanici/Details/5
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

        // GET: Kullanici/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Kullanici/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        public ActionResult Create(tbl_Musteriler register,tbl_Iletisim register2)
        {
            Random r = new Random();
            int musteriNo = r.Next(111111, 999999);
            register.musteriNo = musteriNo;
            db.tbl_Musteriler.Add(register);
            db.tbl_Iletisim.Add(register2);
            db.SaveChanges();
            return View(register);
        }

        // GET: Kullanici/Edit/5
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

        // POST: Kullanici/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "musteriNo,TCKN,sifre,isim,soyisim,cinsiyet,dogumTarihi,kizlikSoyadi,musteriTipi,musteriPuani")] tbl_Musteriler tbl_Musteriler)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tbl_Musteriler).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tbl_Musteriler);
        }

        // GET: Kullanici/Delete/5
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

        // POST: Kullanici/Delete/5
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

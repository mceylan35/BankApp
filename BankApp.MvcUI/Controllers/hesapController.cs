using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Net;
using System.Security.Cryptography.X509Certificates;
using System.Web;
using System.Web.Http;
using System.Web.Http.Results;
using System.Web.Mvc;
using BankApp.MvcUI.Entities;


namespace BankApp.MvcUI.Controllers
{
    public class hesapController : Controller
    {
        private YazilimBakimiEntities db = new YazilimBakimiEntities();

        public ActionResult ParaCek()
        {
            var Hesaplar = db.tbl_Hesaplar.Where(t => t.musteriNo == User.Identity.Name && t.aktiflik == true).ToList();
            ViewBag.cekilecekHesap = new SelectList(Hesaplar, "hesapId", "hesapNumarasi");
            return View();
        }
        [System.Web.Mvc.HttpPost]
        public ActionResult ParaCek(ParaViewModel para)
        {
            var Hesaplar = db.tbl_Hesaplar.Where(t => t.musteriNo == User.Identity.Name && t.aktiflik == true).ToList();
            ViewBag.cekilecekHesap = new SelectList(Hesaplar, "hesapId", "hesapNumarasi");

            var hesap = db.tbl_Hesaplar.FirstOrDefault(i => i.hesapId == para.hesapNo && i.musteriNo == User.Identity.Name);
            if (hesap.bakiye < para.bakiye)
            {
                return HttpNotFound("Bakiye Yetersiz!!!");
            }
            hesap.bakiye = hesap.bakiye - para.bakiye;
            db.SaveChanges();
            return View();
        }

        public ActionResult ParaYukle()
        {
            var Hesaplar = db.tbl_Hesaplar.Where(t => t.musteriNo == User.Identity.Name && t.aktiflik == true).ToList();
            ViewBag.yuklenicekHesap = new SelectList(Hesaplar, "hesapId", "hesapNumarasi");
            return View();
        }
        [System.Web.Mvc.HttpPost]
        public ActionResult ParaYukle(ParaViewModel para)
        {
            var Hesaplar = db.tbl_Hesaplar.Where(t => t.musteriNo == User.Identity.Name && t.aktiflik == true).ToList();
            ViewBag.yuklenicekHesap = new SelectList(Hesaplar, "hesapId", "hesapNumarasi");

            var hesap = db.tbl_Hesaplar.FirstOrDefault(i => i.hesapId == para.hesapNo && i.musteriNo == User.Identity.Name);
            hesap.bakiye = hesap.bakiye + para.bakiye;
            db.SaveChanges();
            return View();
        }

        // GET: hesap
        public ActionResult Index()
        {   
            var Hesaplar = db.tbl_Hesaplar.Where(t => t.musteriNo == User.Identity.Name&&t.aktiflik==true).ToList();
            
            return View(Hesaplar);

        }

        // GET: hesap/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbl_Hesaplar tbl_Hesaplar = db.tbl_Hesaplar.Find(id);
            if (tbl_Hesaplar == null)
            {
                return HttpNotFound();
            }
            return View(tbl_Hesaplar);
        }

        // GET: hesap/Create
        [System.Web.Mvc.HttpPost]
        public JsonResult Create(string hesapNo)
        {
            int hesapSayisi = db.tbl_Hesaplar.Where(t => t.musteriNo ==hesapNo).Count();
            tbl_Hesaplar hesap=new tbl_Hesaplar();
            hesap.musteriNo = hesapNo;
            hesap.bakiye = 0;
            hesap.ekNo = 1000 + hesapSayisi;
            hesap.hesapNumarasi = hesapNo + "-"+ hesap.ekNo;
            hesap.hesapAcilisTarihi=DateTime.Now;
            hesap.aktiflik = true;
            db.tbl_Hesaplar.Add(hesap);
            db.SaveChanges();
            return Json("basarili", JsonRequestBehavior.AllowGet);
        }

        // POST: hesap/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
      
        // GET: hesap/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbl_Hesaplar tbl_Hesaplar = db.tbl_Hesaplar.Find(id);
            if (tbl_Hesaplar == null)
            {
                return HttpNotFound();
            }
            ViewBag.musteriNo = new SelectList(db.tbl_Musteriler, "musteriNo", "TCKN", tbl_Hesaplar.musteriNo);
            return View(tbl_Hesaplar);
        }

        // POST: hesap/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [System.Web.Mvc.HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "hesapId,IBAN,musteriNo,hesapNumarasi,aktiflik,hesapTipi,bakiye,paraTipi,krediLimiti,hesapAcilisTarihi,hesapKapanisTarihi,hesapPuani,ekNo")] tbl_Hesaplar tbl_Hesaplar)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tbl_Hesaplar).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.musteriNo = new SelectList(db.tbl_Musteriler, "musteriNo", "TCKN", tbl_Hesaplar.musteriNo);
            return View(tbl_Hesaplar);
        }

        // GET: hesap/Delete/5
        [System.Web.Mvc.HttpPost]
        public JsonResult sil(int ekNo)
        {
            tbl_Hesaplar hesap =db.tbl_Hesaplar.FirstOrDefault(t => t.musteriNo == User.Identity.Name && t.ekNo ==ekNo);
            hesap.aktiflik = false;
            hesap.hesapKapanisTarihi = DateTime.Now;
            if(hesap.bakiye==0)
            {
                db.tbl_Hesaplar.AddOrUpdate(hesap);
                db.SaveChanges();
               return Json("silindi", JsonRequestBehavior.AllowGet);
            }
            return Json("Silinmedi", JsonRequestBehavior.AllowGet);


        }

        // POST: hesap/Delete/5
        [System.Web.Mvc.HttpPost, System.Web.Mvc.ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            tbl_Hesaplar tbl_Hesaplar = db.tbl_Hesaplar.Find(id);
            db.tbl_Hesaplar.Remove(tbl_Hesaplar);
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

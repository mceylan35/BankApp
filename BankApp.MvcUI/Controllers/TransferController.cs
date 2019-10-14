using BankApp.MvcUI.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BankApp.MvcUI.Controllers
{
    public class TransferController : Controller
    {
        private YazilimBakimiEntities db = new YazilimBakimiEntities();
        // GET: Transfer

        public ActionResult Virman()
        {
            var kisihesaplar = db.tbl_Hesaplar.Where(i => i.musteriNo == User.Identity.Name).ToList();
            ViewBag.gonderenhesaplar = new SelectList(kisihesaplar, "hesapId", "hesapNumarasi");
            ViewBag.alicihesaplar = new SelectList(kisihesaplar, "hesapId", "hesapNumarasi");
            return View();
        }
        [HttpPost]
        public ActionResult Virman(tbl_Hesaplar tbl_Hesaplar)
        {
            var kisihesaplar = db.tbl_Hesaplar.Where(i => i.musteriNo == User.Identity.Name).ToList();
            ViewBag.gonderenhesaplar = new SelectList(kisihesaplar, "hesapId", "hesapNumarasi");
            ViewBag.alicihesaplar = new SelectList(kisihesaplar, "hesapId", "hesapNumarasi");
            return View();
        }
    }
}
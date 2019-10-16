using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BankApp.MvcUI.Entities;
using BankApp.MvcUI.ModelView;

namespace BankApp.MvcUI.Controllers
{
    public class HavaleController : Controller
    {
        private YazilimBakimiEntities db = new YazilimBakimiEntities();
        // GET: Havale
        public ActionResult HavaleGonder()
        {
            var kisihesaplar = db.tbl_Hesaplar.Where(i => i.musteriNo == User.Identity.Name && i.aktiflik != false).ToList();
            ViewBag.gonderen = new SelectList(kisihesaplar, "hesapId", "hesapNumarasi");


            return View();
        }
        [HttpPost]
        public ActionResult HavaleGonder(HavaleViewModel hesap)
        {
            //StoreProcedure yazılabilir.

            var gonderenhesap = db.tbl_Hesaplar.FirstOrDefault(i => i.hesapId == hesap.Gonderen);
            var alicihesap = db.tbl_Hesaplar.FirstOrDefault(i => i.hesapNumarasi == hesap.Alici);
            var kisihesaplar = db.tbl_Hesaplar.Where(i => i.musteriNo == User.Identity.Name).ToList();
            ViewBag.gonderen = new SelectList(kisihesaplar, "hesapId", "hesapNumarasi");
            if (alicihesap == null)
            {
                //ModelState.AddModelError("Alici","Hatalı hesap no");
                //return View(hesap);
                ViewBag.alicihata = "Gonderilmek istenen hesap numarası hatalı!";
                return View();
            }
            if (gonderenhesap.bakiye < hesap.Bakiye)
            {
                //ModelState.AddModelError("Bakiye", "Bakiye Hesaptan büyük.");
                //return View(hesap);
                ViewBag.bakiyehata = "Yetersiz bakiye!";
                return View();
            }
            
            if (gonderenhesap.musteriNo == alicihesap.musteriNo)
            {
                ViewBag.bakiyehata = "Kendi hesabınıza havale işlemi yapamazsınız!";
                return View();
            }
            gonderenhesap.bakiye = gonderenhesap.bakiye - hesap.Bakiye;
            alicihesap.bakiye = alicihesap.bakiye + hesap.Bakiye;
            db.SaveChanges();

            ViewBag.mesaj="Transfer işlemi başarılı";
            return View();
        }

        [HttpPost]
        public ActionResult AltHesaplariGetir(int HesapNo)
        {

            var alicihesap = db.tbl_Hesaplar.Where(i => i.musteriNo == User.Identity.Name && i.aktiflik != false).ToList();
            var cikanhesap = db.tbl_Hesaplar.FirstOrDefault(i => i.musteriNo == User.Identity.Name && i.hesapId == HesapNo);
            alicihesap.Remove(cikanhesap);

            List<Hesaplar> hesaplar = new List<Hesaplar>();
            foreach (var item in alicihesap)
            {
                Hesaplar hesap = new Hesaplar { hesapId = item.hesapId, hesapNumarasi = item.hesapNumarasi, musteriNo = item.musteriNo };
                hesaplar.Add(hesap);
            }


            return Json(hesaplar);
        }
    }
}
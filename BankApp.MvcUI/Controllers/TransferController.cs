using BankApp.MvcUI.Entities;
using BankApp.MvcUI.ModelView;
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
            ViewBag.gonderen = new SelectList(kisihesaplar, "hesapId", "hesapNumarasi");
           
          
            return View();
        }
        [HttpPost]
        public ActionResult Virman(VirmanViewModel hesap)
        {
            //StoreProcedure yazılabilir.

            var gonderenhesap = db.tbl_Hesaplar.FirstOrDefault(i => i.hesapId==hesap.Gonderen );
            var alicihesap = db.tbl_Hesaplar.FirstOrDefault(i => i.hesapId == hesap.Alici);
            var kisihesaplar = db.tbl_Hesaplar.Where(i => i.musteriNo == User.Identity.Name).ToList();
            ViewBag.gonderen = new SelectList(kisihesaplar, "hesapId", "hesapNumarasi");
            if (gonderenhesap.bakiye < hesap.Bakiye)
            {
                ModelState.AddModelError("", "Bakiye Hesaptan büyük.");
                return HttpNotFound("Hata oluştu");
            }
            gonderenhesap.bakiye = gonderenhesap.bakiye - hesap.Bakiye;
            alicihesap.bakiye = alicihesap.bakiye + hesap.Bakiye;
            db.SaveChanges();
            
            
         
            return View();
        }
        [HttpPost]
        public ActionResult AltHesaplariGetir(int HesapNo)
        {

            var alicihesap = db.tbl_Hesaplar.Where(i => i.musteriNo == User.Identity.Name).ToList();
            var cikanhesap = db.tbl_Hesaplar.FirstOrDefault(i => i.musteriNo == User.Identity.Name && i.hesapId==HesapNo);
            alicihesap.Remove(cikanhesap);

            List<Hesaplar> hesaplar = new List<Hesaplar>();
            foreach (var item in alicihesap)
            {
                Hesaplar hesap = new Hesaplar { hesapId=item.hesapId, hesapNumarasi=item.hesapNumarasi, musteriNo=item.musteriNo};
                hesaplar.Add(hesap);
            }
           
            
            return Json(hesaplar);
        }
    }
}
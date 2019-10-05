namespace BankApp.MvcUI.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class tbl_Hesaplar
    {
        [Key]
        public int hesapId { get; set; }

        [StringLength(26)]
        public string IBAN { get; set; }

        public int? musteriId { get; set; }

        [StringLength(20)]
        public string hesapNumarasi { get; set; }

        public bool? aktiflik { get; set; }

        public bool? hesapTipi { get; set; }

        [Column(TypeName = "money")]
        public decimal? bakiye { get; set; }

        [StringLength(20)]
        public string paraTipi { get; set; }

        public int? krediLimiti { get; set; }

        public DateTime? hesapAcilisTarihi { get; set; }

        public DateTime? hesapKapanisTarihi { get; set; }

        public int? hesapPuani { get; set; }

        public virtual tbl_Musteriler tbl_Musteriler { get; set; }
    }
}

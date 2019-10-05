namespace BankApp.MvcUI.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class tbl_Kredi
    {
        [Key]
        public int krediId { get; set; }

        public int? musteriId { get; set; }

        [Column(TypeName = "money")]
        public decimal? krediLimiti { get; set; }

        public byte? faizOrani { get; set; }

        public byte? krediTipi { get; set; }

        [Column(TypeName = "money")]
        public decimal? borc { get; set; }

        [Column(TypeName = "money")]
        public decimal? asgariBorc { get; set; }

        public DateTime? baslangicTarihi { get; set; }

        public DateTime? bitisTarihi { get; set; }

        public DateTime? odenenTarih { get; set; }

        public int? paraPuan { get; set; }

        public virtual tbl_Musteriler tbl_Musteriler { get; set; }
    }
}

namespace BankApp.MvcUI.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class tbl_Islemler
    {
        [Key]
        public int islemId { get; set; }

        public int? gondericiId { get; set; }

        public int? aliciId { get; set; }

        public byte? islemTipi { get; set; }

        [Column(TypeName = "money")]
        public decimal? miktar { get; set; }

        [Column(TypeName = "money")]
        public decimal? islemUcreti { get; set; }

        public DateTime? islemTarihi { get; set; }

        public virtual tbl_Musteriler tbl_Musteriler { get; set; }

        public virtual tbl_Musteriler tbl_Musteriler1 { get; set; }
    }
}

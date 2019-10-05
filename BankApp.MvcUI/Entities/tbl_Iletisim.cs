namespace BankApp.MvcUI.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class tbl_Iletisim
    {
        [Key]
        public int iletisimId { get; set; }

        public int? musteriId { get; set; }

        [StringLength(50)]
        public string mail { get; set; }

        [StringLength(50)]
        public string cepTelefonu { get; set; }

        [StringLength(50)]
        public string evTelefonu { get; set; }

        [StringLength(500)]
        public string musteriAdresi { get; set; }

        public virtual tbl_Musteriler tbl_Musteriler { get; set; }
    }
}

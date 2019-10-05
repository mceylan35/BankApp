namespace BankApp.MvcUI.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class tbl_Musteriler
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public tbl_Musteriler()
        {
            tbl_Hesaplar = new HashSet<tbl_Hesaplar>();
            tbl_Iletisim = new HashSet<tbl_Iletisim>();
            tbl_Islemler = new HashSet<tbl_Islemler>();
            tbl_Islemler1 = new HashSet<tbl_Islemler>();
            tbl_Kredi = new HashSet<tbl_Kredi>();
        }

        [Key]
        public int musteriId { get; set; }

        [StringLength(11)]
        public string TCKN { get; set; }

        [StringLength(50)]
        public string sifre { get; set; }

        [StringLength(50)]
        public string isim { get; set; }

        [StringLength(50)]
        public string soyisim { get; set; }

        public bool? cinsiyet { get; set; }

        public DateTime? dogumTarihi { get; set; }

        [StringLength(50)]
        public string kizlikSoyadi { get; set; }

        public bool? musteriTipi { get; set; }

        public int? musteriPuani { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tbl_Hesaplar> tbl_Hesaplar { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tbl_Iletisim> tbl_Iletisim { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tbl_Islemler> tbl_Islemler { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tbl_Islemler> tbl_Islemler1 { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tbl_Kredi> tbl_Kredi { get; set; }
    }
}

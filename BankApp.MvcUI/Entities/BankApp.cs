namespace BankApp.MvcUI.Entities
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class BankApp : DbContext
    {
        public BankApp()
            : base("name=BankApp")
        {
        }

        public virtual DbSet<sysdiagrams> sysdiagrams { get; set; }
        public virtual DbSet<tbl_Hesaplar> tbl_Hesaplar { get; set; }
        public virtual DbSet<tbl_Iletisim> tbl_Iletisim { get; set; }
        public virtual DbSet<tbl_Islemler> tbl_Islemler { get; set; }
        public virtual DbSet<tbl_Kredi> tbl_Kredi { get; set; }
        public virtual DbSet<tbl_Musteriler> tbl_Musteriler { get; set; }
        public virtual DbSet<database_firewall_rules> database_firewall_rules { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<tbl_Hesaplar>()
                .Property(e => e.bakiye)
                .HasPrecision(19, 4);

            modelBuilder.Entity<tbl_Islemler>()
                .Property(e => e.miktar)
                .HasPrecision(19, 4);

            modelBuilder.Entity<tbl_Islemler>()
                .Property(e => e.islemUcreti)
                .HasPrecision(19, 4);

            modelBuilder.Entity<tbl_Kredi>()
                .Property(e => e.krediLimiti)
                .HasPrecision(19, 4);

            modelBuilder.Entity<tbl_Kredi>()
                .Property(e => e.borc)
                .HasPrecision(19, 4);

            modelBuilder.Entity<tbl_Kredi>()
                .Property(e => e.asgariBorc)
                .HasPrecision(19, 4);

            modelBuilder.Entity<tbl_Musteriler>()
                .HasMany(e => e.tbl_Islemler)
                .WithOptional(e => e.tbl_Musteriler)
                .HasForeignKey(e => e.gondericiId);

            modelBuilder.Entity<tbl_Musteriler>()
                .HasMany(e => e.tbl_Islemler1)
                .WithOptional(e => e.tbl_Musteriler1)
                .HasForeignKey(e => e.aliciId);

            modelBuilder.Entity<database_firewall_rules>()
                .Property(e => e.start_ip_address)
                .IsUnicode(false);

            modelBuilder.Entity<database_firewall_rules>()
                .Property(e => e.end_ip_address)
                .IsUnicode(false);
        }
    }
}

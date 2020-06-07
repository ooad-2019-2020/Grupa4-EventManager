using Microsoft.EntityFrameworkCore;
using implementacija.Models;


namespace implementacija.Models
{
    public class EMContext:DbContext
    {
        public EMContext(DbContextOptions<EMContext> options) : base(options) { 
        }
        
        public DbSet<Korisnik> Korisnik { get; set; }
        public DbSet<Admin> Admin { get; set; }
        public DbSet<Dogadjaj> Dogadjaj { get; set; }
        public DbSet<ArhivaDogadjaja> ArhivaDogadjaja { get; set; }
        public DbSet<ArhivaKorisnikaFL> ArhivaKorisnikaFL { get; set; }
        public DbSet<ArhivaKorisnikaUstanova> ArhivaKorisnikaUstanova { get; set; }
        public DbSet<FizickoLice> FizickoLice { get; set; }
        public DbSet<Obavijest> Obavijest { get; set; }
        public DbSet<Komentar> Recenzija { get; set; }
        public DbSet<Rezervacija> Rezervacija { get; set; }
        public DbSet<Sistem> Sistem { get; set; }
        public DbSet<TipFizickogLica> TipFizickogLica { get; set; }
        public DbSet<Transakcija> Transakcija { get; set; }
        public DbSet<Ustanova> Ustanova { get; set; }
        public DbSet<VrstaKarte> VrstaKarte { get; set; }
        public DbSet<Zahtjev> Zahtjev { get; set; }
        public DbSet<NacinPlacanja> NacinPlacanja { get; set; }
        public DbSet<VrstaObavijesti> VrstaObavijesti { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Korisnik>().ToTable("Korisnik");
            modelBuilder.Entity<Admin>().ToTable("Admin");
            modelBuilder.Entity<Dogadjaj>().ToTable("Dogadjaj");
            modelBuilder.Entity<ArhivaDogadjaja>().ToTable("ArhivaDogadjaj");
            modelBuilder.Entity<ArhivaKorisnikaFL>().ToTable("ArhivaKorisnikFL");
            modelBuilder.Entity<ArhivaKorisnikaUstanova>().ToTable("ArhivaUstanova");
            modelBuilder.Entity<FizickoLice>().ToTable("FizickoLice");
            modelBuilder.Entity<Obavijest>().ToTable("Obavijest");
            modelBuilder.Entity<Komentar>().ToTable("Komentar");
            modelBuilder.Entity<Rezervacija>().ToTable("Rezervacija");
            modelBuilder.Entity<Sistem>().ToTable("Sistem");
            modelBuilder.Entity<TipFizickogLica>().ToTable("TipFizickogLica");
            modelBuilder.Entity<Transakcija>().ToTable("Transakcija");
            modelBuilder.Entity<Ustanova>().ToTable("Ustanova");
            modelBuilder.Entity<VrstaKarte>().ToTable("VrstaKarte");
            modelBuilder.Entity<Zahtjev>().ToTable("Zahtjev");
            modelBuilder.Entity<NacinPlacanja>().ToTable("NacinPlacanja");
            modelBuilder.Entity<VrstaObavijesti>().ToTable("VrstaObavijesti");


        }


        public DbSet<implementacija.Models.VIP> VIP { get; set; }


        public DbSet<implementacija.Models.Registracija> Registracija { get; set; }


    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace implementacija.Models
{
    public class Korisnik
    {
        public int KorisnikId { get; set; }
        public string username { get; set; }
        public string password { get; set; }
        public string ime { get; set; }
        public DateTime datumPrijave { get; set; }
        public string adresa { get; set; }
        public string email { get; set; }

        //dio u kojem se definisu veze sa ostalim  klasama
        public virtual ICollection<ArhivaKorisnikaUstanova> ArhivaKorisnikaUstanova { get; set; }
        public virtual ICollection<Zahtjev> Zahtjev { get; set; }
        public virtual ICollection<ArhivaKorisnikaFL> ArhivaKorisnikaFL { get; set; }
        public virtual ICollection<Admin> Admin { get; set; }
        public virtual ICollection<Transakcija> Transakcija { get; set; }
        public virtual ICollection<ArhivaDogadjaja> ArhivaDogadjaja { get; set; }
        public virtual ICollection<Rezervacija> Rezervacija { get; set; }
        public virtual ICollection<Obavijest> Obavijest { get; set; }
        public virtual ICollection<Komentar> Komentar { get; set; }
        public virtual ICollection<FizickoLice> FizickoLice { get; set; }
        public virtual Sistem Sistem { get; set; }
        public virtual Ustanova Ustanova { get; set; }

       
    }
}

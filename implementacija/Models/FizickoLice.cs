using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace implementacija.Models
{
    public class FizickoLice
    {
        public string ime { get; set; }
        public string prezime { get; set; }
        public string brojKartice { get; set; }
        public Boolean osobaOdgovornaUImeUstanove { get; set; }
        public DateTime datumRodjenja { get; set; }
        public virtual Korisnik idKorisnika { get; }
        public double stanjeRacuna { get; set; }
        public Boolean odgovornoLice { get; set; }

        public virtual ICollection<Dogadjaj> Dogadjaj { get; set; }
        public virtual ICollection<Rezervacija> Rezervacija { get; set; }
        internal IKorisnikFactory KorisnikFactory { get; set; }
        internal IKonverzijaBAMEur KonverzijaBAMEur { get; set; }
        internal IObracun Obracun { get; set; }
        internal IFizickoLice TipFizickogLica { get; set; }
        public virtual Ustanova Ustanova { get; set; }


    }
}

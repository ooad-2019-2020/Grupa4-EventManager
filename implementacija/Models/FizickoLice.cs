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
        public virtual TipFizickogLica tipFizickogLica { get; set; }
        public virtual Korisnik idKorisnika { get; }
        public double stanjeRacuna { get; set; }
        public Boolean odgovornoLice { get; set; }
    }
}

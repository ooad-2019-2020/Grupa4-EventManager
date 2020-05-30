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
        internal IFizckoLice TipFizickogLica { get; set; }
        public ICollection<Transakcija> listaTransakcija { get; set; }
        public ICollection<Dogadjaj> wishListaDogadjaja { get; set; }
        public ICollection<Rezervacija> listaZavrsenihRezervacija { get; set; }
        public double stanjeRacuna { get; set; }
        public int popust { get; set; }
        public ICollection<Rezervacija> listaRezervacija { get; set; }
    }
}

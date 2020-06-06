using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace implementacija.Models
{
    public class FizickoLice:Korisnik
    {
        public int KorisnikId { get; set; }
        public string ime { get; set; }
        public string prezime { get; set; }
        public string brojKartice { get; set; }
        public DateTime datumRodjenja { get; set; }
        public int tipFizickogLica { get; set; }
        public Boolean VIP { get; set; }
        public double stanjeRacuna { get; set; }
        public Boolean odgovornoLice { get; set; }

        //dio u kojem se definisu veze sa ostalim klasama
        public virtual Korisnik Korisnik { get; set; }
        public virtual TipFizickogLica TipFizickogLica { get; set; }

    }
}

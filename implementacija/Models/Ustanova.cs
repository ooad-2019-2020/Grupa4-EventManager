using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace implementacija.Models
{
    public class Ustanova:Korisnik
    {
        public int KorisnikId { get; set; }
        public string brojRacunaUBanci { get; set; }
        public string brojTelefona { get; set; }
        public double stanjeUplata { get; set; }
        public int odgovornoLiceId { get; set; }

        //dio u kojem se definisu veze sa ostalim klasama
        public virtual ICollection<Dogadjaj> Dogadjaj { get; set; }
        public virtual ICollection<Rezervacija> Rezervacija { get; set; }
        public virtual ICollection<Korisnik> Korisnik { get; set; }
        public virtual ICollection<ArhivaDogadjaja> ArhivaDogadjaja { get; set; }

    }
}

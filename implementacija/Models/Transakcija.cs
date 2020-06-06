using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace implementacija.Models
{
    public class Transakcija
    {
        public int TransakcijaId { get; set; }
        public int KorisnikId { get; set; }
        public double ukupnoZaUplatu { get; set; }
        public int NacinPlacanjaId { get; set; }

        //dio u kojem se definisu veze sa ostalim klasama
        public virtual Korisnik Korisnik { get; set; }
        public virtual NacinPlacanja NacinPlacanja { get; set; }
    }
}

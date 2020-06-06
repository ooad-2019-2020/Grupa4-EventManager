using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace implementacija.Models
{
    public class Zahtjev
    {
        public int ZahtjevId { get; set; }
        public int KorisnikId { get; set; }
        public string tekst { get; set; }

        //dio u kojem se definisu veze sa ostalim klasama
        public virtual Korisnik Korisnik { get; set; }


    }
}

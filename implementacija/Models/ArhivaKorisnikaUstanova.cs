using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace implementacija.Models
{
    public class ArhivaKorisnikaUstanova
    {
        public int ArhivaKorisnikaUstanovaId { get; set; }
        public int KorisnikId { get; set; }
        public double imaoUplata { get; set; }
        public DateTime kreiraoRacun { get; set; }
        public DateTime napustioSistem { get; set; }

        //dio u kojem se definisu veze sa ostalim klasama
        public virtual Korisnik Korisnik { get; set; }

    }
}

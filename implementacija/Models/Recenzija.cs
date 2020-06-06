using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace implementacija.Models
{
    public class Komentar
    {
        public int KomentarId { get; set; }
        public string recenzija { get; set; }
        public int brojZvjezdica { get; set; }
        public int KorisnikId { get; set; }
        public DateTime datumOstavljanja { get; set; }
        public int DogadjajId { get; set; }
        public bool neprimjerenKomentar { get; set; }

        //dio u kojem se definisu veze sa ostalim klasama
        public virtual Korisnik Korisnik { get; set; }
        public virtual Dogadjaj Dogadjaj { get; set; }

    }
}

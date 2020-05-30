using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace implementacija.Models
{
    public class Komentar
    {
        public string komentar { get; set; }
        public Korisnik komentarOstavio { get; set; }
        public DateTime datumOstavljanja { get; set; }
        public Dogadjaj komentarNaDogadjaj { get; set; }
        public int brojZvjezdica { get; set; }
        public Boolean neprimjerenKomentar { get; set; }

    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace implementacija.Models
{
    public class Transakcija
    {
        public double iznos { get; set; }
        public Korisnik korisnik { get; set; }
        public NacinPlacanja nacinPlacanja { get; set; }
        public static int IDTransakcije { get; }

    }
}

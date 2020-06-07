using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace implementacija.Models
{
    public class Sistem
    {
        public int SistemId { get; set; }// ovo je zapravo brojac posjeta
        public int KorisnikId { get; set; }

        //dio u kojem se definisu veze sa ostalim klasama
        public virtual ICollection<Korisnik> Korisnik { get; set; }


    }
}

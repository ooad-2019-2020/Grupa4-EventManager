using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace implementacija.Models
{
    public class ArhivaDogadjaja
    {
        public int ArhivaDogadjajaId { get; set; }
        public int KorisnikId { get; set; }
        public int UstanovaId { get; set; }
        public double cijenaRezervacije { get; set; }
        public bool popust { get; set; }
        public int iznosPopusta { get; set; }
        public int DogadjajId { get; set; }

        //dio u kojem se definisu veze sa ostalim klasama
        public virtual Korisnik Korisnik { get; set; }
        public virtual Ustanova Ustanova { get; set; }
        public virtual ICollection<Dogadjaj> Dogadjaj { get; set; }

    }
}

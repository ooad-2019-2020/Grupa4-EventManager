using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace implementacija.Models
{
    public class Dogadjaj
    {
        public int DogadjajId { get; set; }
        public int UstanovaId { get; set; }
        public int KorisnikId { get; set; }
        public int kapacitet { get; set; }
        public double cijena { get; set; }
        public DateTime datumDogadjaja { get; set; }
        public int trenutniKapacitet { get; set; }

        //dio u kojem se definisu veze sa ostalim klasama
        public virtual ICollection<Rezervacija> Rezervacija { get; set; }
        public virtual Ustanova Ustanova { get; set; }
        public virtual Korisnik Korisnik { get; set; }
        

    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace implementacija.Models
{
    public class Rezervacija
    {
        public int RezervacijaId { get; set; }
        public int osobaRezervacija { get; set; }
        public int UstanovaId { get; set; }
        public int DogadjajId { get; set; }
        public int VrstaKarteId { get; set; }
        public double cijena { get; set; }
        public int brojRezervisanihMjesta { get; set; }
        public DateTime datumRezervacije { get; set; }
        public double ukupnoZaUplatu { get; set; }
        public DateTime datumDogadjaja { get; set; }

        //dio u kojem se definisu veze sa ostalim klasama
        public virtual VrstaKarte VrstaKarte { get; set; }
        public virtual Ustanova Ustanova { get; set; }
        public virtual Korisnik Korisnik { get; set; }
        public virtual Dogadjaj Dogadjaj { get; set; }


    }
}

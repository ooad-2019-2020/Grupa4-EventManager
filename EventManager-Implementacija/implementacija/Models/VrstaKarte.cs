using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace implementacija.Models
{
    public class VrstaKarte
    {
        public int VrstaKarteId { get; set; }
        public double preporucenaCijena { get; set; }
        public int preporuceniPopust { get; set; }

        //dio u kojem se definisu veze sa ostalim klasama
        public virtual ICollection<Rezervacija> Rezervacija { get; set; }
    }
}

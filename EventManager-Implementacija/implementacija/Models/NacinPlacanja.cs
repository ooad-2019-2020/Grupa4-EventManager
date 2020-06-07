using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace implementacija.Models
{
    public class NacinPlacanja
    {
        public int NacinPlacanjaId { get; set; }

        //dio u kojem se definisu veze sa ostalim klasama
        public virtual ICollection<Transakcija> Transakcija { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace implementacija.Models
{
    public class TipFizickogLica
    {
        public int TipFizickogLicaId { get; set; }
        public bool popust { get; set; }

        //dio u kojem se definisu veze sa ostalim klasama
        public virtual ICollection<FizickoLice> FizickoLice { get; set; }
        public virtual ICollection<ArhivaKorisnikaFL> ArhivaKorisnikaFL { get; set; }
    }
}

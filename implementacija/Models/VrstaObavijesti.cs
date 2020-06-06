using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace implementacija.Models
{
    public class VrstaObavijesti
    {
        public int VrstaObavijestiId { get; set; }
        public string tekst { get; set; }

        //dio u kojem se definisu veze sa ostalim klasama
        public virtual ICollection<Obavijest> Obavijest { get; set; }
    }
}

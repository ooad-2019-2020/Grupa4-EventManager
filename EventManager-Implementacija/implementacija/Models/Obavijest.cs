using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace implementacija.Models
{
    public class Obavijest
    {
        public int ObavijestId { get; set; }
        public int KorisnikId { get; set; }
        public string tekstObavijesti { get; set; }
        public DateTime datumSlanja { get; set; }
        public int VrstaObavijestiId { get; set; }

        //dio u kojem se definisu veze sa ostalim klasama
        public virtual VrstaObavijesti VrstaObavijesti { get; set; }
        public virtual Korisnik Korisnik { get; set; }
        
    }
}

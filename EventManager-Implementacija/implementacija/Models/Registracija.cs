using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace implementacija.Models
{
    public class Registracija
    {
        public int RegistracijaId { get; set; }
        public int KorisnikId { get; set; }
        public int FizickoLiceId { get; set; }
        public int VIPId { get; set; }
        public int UstanovaId { get; set; }

        public virtual Korisnik Korisnik { get; set; }
        public virtual FizickoLice FizickoLice { get; set; }
        public virtual VIP VIP { get; set; }
        public virtual Ustanova Ustanova { get; set; }



    }
}

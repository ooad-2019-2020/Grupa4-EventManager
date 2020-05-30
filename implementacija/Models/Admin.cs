using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace implementacija.Models
{
    public class Admin
    {
        public string ime { get; set; }
        public virtual Korisnik idAdmina { get; }

        public virtual ICollection<Komentar> Komentar { get; set; }
        public virtual ICollection<Rezervacija> Rezervacija { get; set; }
        public virtual ICollection<Dogadjaj> Dogadjaj { get; set; }
        public virtual ICollection<AdminObrada> AdminObrada { get; set; }

       // private virtual ICollection<IKorisnikFactory> korisnikFactory;

    }
}

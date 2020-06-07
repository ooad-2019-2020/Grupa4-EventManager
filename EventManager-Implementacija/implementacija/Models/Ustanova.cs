using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace implementacija.Models
{
    public class Ustanova
    {
        public int UstanovaId { get; set; }
        public int KorisnikId { get; set; }
        [DisplayName("Broj računa u banci")]
        public string brojRacunaUBanci { get; set; }
        [DisplayName("Broj telefona")]
        public string brojTelefona { get; set; }
        public double stanjeUplata { get; set; }
        [DisplayName("ID korisnika koji će biti odgovorno lice ustanove")]
        public int odgovornoLiceId { get; set; }
        [DisplayName("Username")]
        public string username { get; set; }
        [DisplayName("Password")]
        public string password { get; set; }
        [DisplayName("Adresa")]
        public string adresa { get; set; }
        [DisplayName("Email")]
        public string email { get; set; }

        //dio u kojem se definisu veze sa ostalim klasama
        public virtual ICollection<Dogadjaj> Dogadjaj { get; set; }
        public virtual ICollection<Rezervacija> Rezervacija { get; set; }
        public virtual ICollection<Korisnik> Korisnik { get; set; }
        public virtual ICollection<ArhivaDogadjaja> ArhivaDogadjaja { get; set; }

    }
}

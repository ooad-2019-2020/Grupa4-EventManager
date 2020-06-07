using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace implementacija.Models
{
    public class VIP
    {
        public int VIPId { get; set; }
        public int KorisnikId { get; set; }
        [DisplayName("Ime")]
        public string ime { get; set; }
        [DisplayName("Prezime")]
        public string prezime { get; set; }
        [DisplayName("Broj kartice")]
        public string brojKartice { get; set; }
        [DisplayName("Datum rođenja")]
        public DateTime datumRodjenja { get; set; }
        [DisplayName("Tip fizičkog lica")]
        public int tipFizickogLica { get; set; }
        public double stanjeRacuna { get; set; }
        public Boolean odgovornoLice { get; set; }
        public Boolean uplatioClanarinu { get; set; }
        public double iznosClanarine { get; set; }
        public int trajanjeClanarine { get; set; }
        [DisplayName("Username")]
        public string username { get; set; }
        [DisplayName("Password")]
        public string password { get; set; }
        [DisplayName("Adresa")]
        public string adresa { get; set; }
        [DisplayName("Email")]
        public string email { get; set; }



        //dio u kojem se definisu veze sa ostalim klasama
        public virtual Korisnik Korisnik { get; set; }
        public virtual TipFizickogLica TipFizickogLica { get; set; }
    }
}

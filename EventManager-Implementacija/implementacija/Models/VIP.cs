using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace implementacija.Models
{
    public class VIP
    {
        public int VIPId { get; set; }
        public int FizickoLiceId { get; set; }
        public int KorisnikId { get; set; }
        public string ime { get; set; }
        public string prezime { get; set; }
        public string brojKartice { get; set; }
        public DateTime datumRodjenja { get; set; }
        public int tipFizickogLica { get; set; }
        public double stanjeRacuna { get; set; }
        public Boolean odgovornoLice { get; set; }
        public Boolean uplatioClanarinu { get; set; }
        public double iznosClanarine { get; set; }
        public int trajanjeClanarine { get; set; }
        


        //dio u kojem se definisu veze sa ostalim klasama
        public virtual Korisnik Korisnik { get; set; }
        public virtual TipFizickogLica TipFizickogLica { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace implementacija.Models
{
    public class ArhivaKorisnikaFL
    {
        public int ArhivaKorisnikaFLId { get; set; }
        public int KorisnikId { get; set; }
        public int izvrsioTransakciju { get; set; }
        public double ukupnoUplatio { get; set; }
        public Boolean bioOdgovornoLice { get; set; }
        public int TipFizickogLicaId { get; set; }
        public DateTime kreiraoRacun { get; set; }
        public DateTime napustioApp { get; set; }

        //dio u kojem se definisu veze sa ostalim klasama
        public virtual Korisnik Korisnik { get; set; }
        public virtual TipFizickogLica TipFizickogLica { get; set; }

    }
}

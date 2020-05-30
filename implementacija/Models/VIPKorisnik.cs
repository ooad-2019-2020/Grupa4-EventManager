using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace implementacija.Models
{
    public class VIPKorisnik 
    {
        public Boolean uplatioVIPClanstvo { get; set; }
        public double uplataZaClanstvo { get; set; }
        public int brojDostupnihPopusta { get; set; }
        public Boolean daLiSuIskoristeniPopusti { get; set; }
        public DateTime vipIstice { get; set; }
        public FizickoLice korisnik { get; set; }

    }
}

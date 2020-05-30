using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace implementacija.Models
{
    public class Korisnik
    {
public static int ID { get; }
        public string username { get; set; }
        public string password { get; set; }
        public string email { get; set; }
        public string ime { get; set; }
        public DateTime datumPrijave { get; set; }
        public String adresa { get; set; }
       


    }
}

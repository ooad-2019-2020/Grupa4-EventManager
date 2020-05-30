using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace implementacija.Models
{
    public class Ustanova
    {
        public string naziv { get; set; }
        public string brojTelefona { get; set; }
        public string brojRacunaUBanci { get; set; }
        public ICollection<FizickoLice> odgovorniKorisnici { get; set; }
        public ICollection<Dogadjaj> listaKreiranihDogadjaja { get; set; }
        public ICollection<Dogadjaj> arhivaDogadjaja { get; set; }
        public double stanjeUplata { get; set; }
        public ICollection<FizickoLice> listaFanova { get; set; }


        private ICollection<IPretplatnik> listaPretplatnika;

     
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PastaPizzaNet
{
    public enum DrankSoorten
    {
        Water,
        Limonade,
        Cocacola,
        Koffie,
        Thee
    }
    public abstract class Drank : IBedrag
    {
        private string naam;
        public string Naam { get => naam; set => naam = value; }

        private decimal prijs;
        public decimal Prijs
        {
            get => prijs;
            set
            {
                if (prijs < 0)
                    throw new Exception("Prijs kan niet lager zijn dan nul");
                prijs = value;
            }
        }
        public Drank(string naam, decimal prijs) { }
    }
}

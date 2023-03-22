using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PastaPizzaNet
{
    public enum DrankNaam
    {
        Water,
        Limonade,
        Cocacola,
        Koffie,
        Thee
    }
    public abstract class Drank : IBedrag
    {

        public DrankNaam? DrankNaam;

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
        public Drank(DrankNaam drankNaam)
        {
            DrankNaam = drankNaam;
        }
        public virtual decimal BerekenBedrag()
        {
            return Prijs;
        }

        public override string ToString()
        {
            //return $"Drank: " + $"{(DrankNaam != null ? $"{DrankNaam} " : "")}" + $"({BerekenBedrag()} euro)";
            return $"Drank: " + $"{DrankNaam}" + $"({BerekenBedrag()} euro)";
        }

    }
}

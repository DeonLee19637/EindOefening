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

        public static List<Drank> GeldigeDranken = new List<Drank>
        {
            new Warmedrank(PastaPizzaNet.DrankNaam.Koffie, 2.5m),
            new Warmedrank(PastaPizzaNet.DrankNaam.Thee, 2.5m),
            new Frisdrank(PastaPizzaNet.DrankNaam.Water, 2.0m),
            new Frisdrank(PastaPizzaNet.DrankNaam.Limonade, 2.0m),
            new Frisdrank(PastaPizzaNet.DrankNaam.Cocacola, 2.0m)
        };

        private decimal prijs;
        public decimal Prijs
        {
            get => prijs;
            set
            {
                if (prijs < 0)
                    throw new Exception($"Prijs van {DrankNaam} kan niet lager zijn dan nul");
                prijs = value;
            }
        }
        public Drank(DrankNaam drankNaam, decimal prijs)
        {
            DrankNaam = drankNaam;
            Prijs = prijs;
        }
        public virtual decimal BerekenBedrag()
        {
            return Prijs;
        }

        public override bool Equals(object? obj)
        {
            if (obj is Drank drank)
            {
                return drank.DrankNaam == DrankNaam && drank.Prijs == Prijs;
            }
            else
            {
                return false;
            }
        }

        public override int GetHashCode()
        {
            return DrankNaam.GetHashCode();
        }

        public override string ToString()
        {
            //return $"Drank: " + $"{(DrankNaam != null ? $"{DrankNaam} " : "")}" + $"({BerekenBedrag()} euro)";
            return $"Drank: " + $"{DrankNaam}" + $"({BerekenBedrag()} euro)";
        }

    }
}

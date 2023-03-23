using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PastaPizzaNet
{
    public class Warmedrank : Drank
    {

        private DrankNaam drankNaam;
        public DrankNaam DrankNaam 
        { 
            get => drankNaam;
            set => drankNaam = value;
        }
        public Warmedrank(DrankNaam drankNaam, decimal prijs):base(drankNaam, prijs)
        {
            DrankNaam = drankNaam;
            Prijs = prijs;
        }

        public override bool Equals(object? obj)
        {
            if (obj is Warmedrank drank)
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

        //De method BerekenBedrag moeten we hier niet overnemen aangezien we bij de aanmaak van dit object de Prijs een constante is. 
    }
}

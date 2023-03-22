using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PastaPizzaNet
{
    public class Warmedrank : Drank
    {

        private DrankNaam drankSoort;
        public DrankNaam DrankNaam 
        { 
            get => drankSoort; 
            set
            {
                //Als de ingegeven DrankNaam geen warme drank is, geef het een Exception. 
                switch(value)
                {
                    case DrankNaam.Koffie:
                    case DrankNaam.Thee:
                        drankSoort = value; break;
                    default:
                        throw new Exception("Dit is geen warme drank");
                }
            }
        }
        public Warmedrank(DrankNaam drankNaam):base(drankNaam)
        {
            DrankNaam = drankNaam;
            Prijs = 2.5m;
        }

        //De method BerekenBedrag moeten we hier niet overnemen aangezien we bij de aanmaak van dit object de Prijs een constante is. 
    }
}

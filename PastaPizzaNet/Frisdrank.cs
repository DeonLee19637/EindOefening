using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PastaPizzaNet
{
    public class Frisdrank : Drank
    {
        private DrankNaam drankNaam;
        public DrankNaam DrankNaam 
        { 
            get => drankNaam;
            set
            {
                //Als de ingegeven DrankNaam geen frisdrank is, geef het een Exception. 
                switch (value)
                {
                    case DrankNaam.Water:
                    case DrankNaam.Limonade:
                    case DrankNaam.Cocacola:
                        drankNaam = value; break;
                    default:
                        throw new Exception("Dit is geen frisdrank");
                }
            }
        }
        public Frisdrank(DrankNaam dranknaam): base(dranknaam)
        {
            DrankNaam = dranknaam;
            Prijs = 2.0m;
        }

        //De method BerekenBedrag moeten we hier niet overnemen aangezien we bij de aanmaak van dit object de Prijs een constante is. 
    }
}

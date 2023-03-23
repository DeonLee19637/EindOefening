using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PastaPizzaNet
{
    public enum DessertNaam
    {
        Tiramisu,
        Ijs,
        Cake
    }
    public class Dessert : IBedrag
    {
        private DessertNaam dessertNaam;
        public DessertNaam DessertNaam 
        {
            get => dessertNaam;
            set
            {
                //Als de ingegeven DessertNaam geen dessert is, geeft het een Exception;
                switch (value)
                {
                    case DessertNaam.Tiramisu:
                    case DessertNaam.Ijs:
                    case DessertNaam.Cake:
                        dessertNaam = value;
                        break;
                    default:
                        throw new Exception($"De naam {value} is geen geldige naam voor een Dessert");
                }
            } 
        }

        private decimal prijs;
        public decimal Prijs
        {
            get => prijs;
            set
            {
                if (prijs < 0)
                    throw new Exception($"Prijs van {DessertNaam} kan niet lager zijn dan nul");
                prijs = value;
            }
        }

        public Dessert(DessertNaam dessertNaam, decimal prijs) 
        {
            DessertNaam = dessertNaam;
            Prijs = prijs;
        }

        public decimal BerekenBedrag()
        {
            return Prijs;
        }

        public override string ToString()
        {
            return $"Dessert: {DessertNaam} ({BerekenBedrag()} euro)";
        }
    }
}

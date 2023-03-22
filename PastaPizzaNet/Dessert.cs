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
                        throw new Exception("Ongeldig dessert");
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
                    throw new Exception("Prijs kan niet lager zijn dan nul");
                prijs = value;
            }
        }

        public Dessert(DessertNaam dessertNaam) 
        {
            DessertNaam = dessertNaam;
        }

        public decimal BerekenBedrag()
        {
            //Naam van het dessert bepaalt de prijs/bedrag
            switch (dessertNaam)
            {
                case DessertNaam.Tiramisu:
                case DessertNaam.Ijs:
                    Prijs = 3.0m; break;
                case DessertNaam.Cake:
                    Prijs = 2.0m; break;
                default:
                    throw new Exception("Ongeldig dessert");
            }
            return Prijs;
        }

        public override string ToString()
        {
            return $"Dessert: {DessertNaam} ({BerekenBedrag()} euro)";
        }
    }
}

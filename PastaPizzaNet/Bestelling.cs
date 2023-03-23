using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PastaPizzaNet
{
    public class Bestelling :IBedrag
    {
        public Klant Klant;

        public List<IBedrag> Bedragen = new List<IBedrag>();
        public BesteldGerecht Gerecht { get; set; } = null!;

        private Drank drank;
        public Drank Drank 
        {
            get => drank;
            set
            {
                if (value != null)
                {
                    if (!Drank.GeldigeDranken.Contains(value))
                    {
                        throw new Exception($"Invoer van onbestaande drank met type {value.GetType()}");
                    }
                    drank = value;
                }

            } 
        }
        public Dessert Dessert { get; set; } = null!;

        private int aantal;
        public int Aantal 
        {
            get => aantal;
            set
            {
                if (value < 1)
                    aantal = 1;
                aantal = value;
            }
        }

        //Constructor voor als men standaard voor 1 aantal kiest, de rest zijn optionele parameters
        public Bestelling(Klant klant, BesteldGerecht? gerecht = null, Drank? drank = null, Dessert? dessert = null, int aantal = 1) 
        {
            Klant = klant;
            Gerecht = gerecht;
            Drank = drank;
            Dessert = dessert;
            Aantal = aantal;

            //Lijst van alle objecten die interface IBedrag implementeren
            Bedragen.Add(Gerecht);
            Bedragen.Add(Drank);
            Bedragen.Add(Dessert);
        }

        public decimal BerekenBedrag()
        {
            decimal totaalBedrag = 0;

            foreach (IBedrag bedrag in Bedragen)
            {
                if (bedrag != null)
                {
                    totaalBedrag += bedrag.BerekenBedrag();
                }
            }
            totaalBedrag *= Aantal;

            if (Gerecht != null && Drank != null && Dessert != null) 
            {
                totaalBedrag *= 0.9m;
            }

            return totaalBedrag;
        }

        public override string ToString()
        {
            StringBuilder bestelling = new StringBuilder();
            //Hier kon ik misschien beter een event gebruiken aangezien dit dezelfde check uitvoert als in BerekenBedrag
            foreach(IBedrag bedrag in Bedragen)
            {
                if (bedrag != null)
                {
                    bestelling.AppendLine(bedrag.ToString());
                }
            }
            bestelling.AppendLine($"Aantal: {Aantal}");
            bestelling.AppendLine($"Bedrag van de bestelling: {BerekenBedrag().ToString("F2")} euro");
            return bestelling.ToString();
        }
    }
}

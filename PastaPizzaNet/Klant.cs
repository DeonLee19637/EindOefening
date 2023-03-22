using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PastaPizzaNet
{
    public class Klant
    {
        private static int autoIdIncrement = 1;
        public readonly int KlantId;

        private string naam;
        public string Naam 
        { 
            get => naam;
            set
            {
                naam = value ?? "Onbekend persoon";
            }
        }

        public Klant(string naam)
        {
            Naam = naam;
            KlantId = autoIdIncrement++;
        }

        public override string ToString()
        {
            return $"Klant: {Naam}";
        }

    }
}

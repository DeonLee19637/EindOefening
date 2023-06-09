﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PastaPizzaNet
{
    public abstract class Gerecht : IBedrag
    {
        private string naam;
        public string Naam 
        { 
            get => naam;
            set
            {
                naam = value ?? "Onbekend gerecht";
            }
        }

        private decimal prijs;
        public decimal Prijs
        {
            get => prijs;
            set
            {
                if (prijs < 0)
                    throw new Exception($"Prijs van {Naam} kan niet lager zijn dan nul");
                prijs = value;
            }
        }

        public Gerecht(string naam, decimal prijs)
        {
            Naam = naam;
            Prijs = prijs;
        }
        public virtual decimal BerekenBedrag()
        {
            return Prijs;
        }
        
        public override string ToString()
        {
            return $"Gerecht: {Naam} ({BerekenBedrag()} euro) ";
        }

    }
}

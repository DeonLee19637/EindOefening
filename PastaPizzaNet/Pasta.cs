using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PastaPizzaNet
{
    public class Pasta : Gerecht
    {
        public string Omschrijving { get; set; } = null!;

        public Pasta(string naam, decimal prijs):base(naam, prijs)
        {
            
        }

    }
}

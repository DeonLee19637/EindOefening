using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PastaPizzaNet
{
    public class Pizza : Gerecht
    {
        public List<string> Onderdelen { get; set; }
        public Pizza(string naam, decimal prijs) : base(naam, prijs)
        {

        }
    }
}

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
        public Pizza(string naam, decimal prijs, List<string> onderdelen) : base(naam, prijs)
        {
            Onderdelen = onderdelen;
        }

        public override string ToString()
        {
            StringBuilder pizza = new StringBuilder();
            pizza.Append(base.ToString());
            pizza.Append(string.Join(" - ", Onderdelen));
            //foreach (string onderdeel in Onderdelen)
            //{
            //    pizza.Append(onderdeel.Equals(Onderdelen.LastOrDefault()) ? $"{onderdeel} " : $"{onderdeel} - ");
            //}
            return pizza.ToString();
        }
    }
}

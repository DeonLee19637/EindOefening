using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PastaPizzaNet
{
    public enum Grootte
    {
        Klein,
        Groot
    }

    public enum Extras
    {
        Brood,
        Kaas,
        Look
    }

    public class BesteldGerecht : IBedrag
    {
        public Gerecht Gerecht { get; set; }
        public Grootte Grootte { get; set; }
        public Extras[] Extras { get; set; }

        public BesteldGerecht(Gerecht gerecht, Grootte grootte, Extras[] extras ) 
        {
            Gerecht = gerecht;
            Grootte = grootte;
            Extras = extras;
        }

        public decimal BerekenBedrag()
        {
            decimal totaalBedrag = 0;
            totaalBedrag += Gerecht.BerekenBedrag();
            totaalBedrag += Grootte == Grootte.Groot ? 3 : 0;
            totaalBedrag += Extras.Length;
            return totaalBedrag;
        }

        public override string ToString()
        {
            StringBuilder totaalGerecht = new StringBuilder();
            totaalGerecht.Append(Gerecht.ToString());
            totaalGerecht.Append($" ({Grootte})");
            if (Extras.Length > 0)
            {
                totaalGerecht.Append(" extra: ");
                totaalGerecht.Append(string.Join(" ", Extras));
                //foreach(Extras extra in Extras)
                //{
                //    totaalGerecht.Append($"{extra.ToString()} ");
                //}
            }
            totaalGerecht.Append($" (bedrag: {BerekenBedrag()} euro)");
            return totaalGerecht.ToString();
        }
    }
}

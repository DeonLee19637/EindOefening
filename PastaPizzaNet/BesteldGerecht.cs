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
        public Extras Extras { get; set; }

        public BesteldGerecht() { }

    }
}

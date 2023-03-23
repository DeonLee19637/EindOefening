using PastaPizzaNet;
using System.Linq;
// Het Menu:

//Desserts
Dessert tiramisu = new Dessert(DessertNaam.Tiramisu, 3m);
Dessert ijs = new Dessert(DessertNaam.Ijs, 3m);
Dessert cake = new Dessert(DessertNaam.Cake, 2m);

//Dranken zit nu in Dranken.GeldigeDranken
//Drank koffie = new Warmedrank(DrankNaam.Koffie, 2.5m);
//Drank thee = new Warmedrank(DrankNaam.Thee, 2.5m);
//Drank water = new Frisdrank(DrankNaam.Water, 2.0m);
//Drank limonade = new Frisdrank(DrankNaam.Limonade, 2.0m);
//Drank cola = new Frisdrank(DrankNaam.Cocacola, 2.0m);

//Gerechten
Gerecht pizzaMargherita = new Pizza("Margherita", 8.00m, new List<string> { "Tomatensaus", "Mozzarella"});
Gerecht pizzaNapoli = new Pizza("Napoli", 10.00m, new List<string> { "Tomatensaus", "Mozzarella", "Ansjovis", "Kapper", "Olijven" });
Gerecht pastaBolognese = new Pasta("Spaghetti Bolognese", 12.00m, "met gehaktsaus");
Gerecht pastaCarbonara = new Pasta("Spaghetti Carbonara", 13.00m, "spek, roomsaus en parmezaanse kaas");
Gerecht lasagne = new Pasta("Lasagne", 15.00m, "");

//Klanten
Klant klant1 = new Klant("Jan Janssen");
Klant klant2 = new Klant("Piet Pieters");
Klant klant3 = new Klant(null);


//Bestellingen
try
{
    Bestelling bestelling1 = new Bestelling
    (
        klant1,
        new BesteldGerecht(pizzaMargherita, Grootte.Groot, new Extras[] { Extras.Kaas, Extras.Look }),
        new Frisdrank(DrankNaam.Water, 2.0m),
        ijs,
        2
    );

    Bestelling bestelling2 = new Bestelling
    (
        klant2,
        new BesteldGerecht(pizzaMargherita, Grootte.Klein, Array.Empty<Extras>()),
        new Frisdrank(DrankNaam.Koffie, 2.5m),
        tiramisu
    );

    Bestelling bestelling3 = new Bestelling
    (
        klant3,
        new BesteldGerecht(lasagne, Grootte.Klein, new Extras[] { Extras.Look })
    );

    Bestelling bestelling4 = new Bestelling
    (
        klant2,
        new BesteldGerecht(pizzaNapoli, Grootte.Klein, new Extras[] { Extras.Brood }),
        new Frisdrank(DrankNaam.Cocacola, 2.0m),
        ijs
    );
    Bestelling bestelling5 = new Bestelling
    (
        klant3,
        new BesteldGerecht(pastaCarbonara, Grootte.Klein, new Extras[] { Extras.Look }),
        new Frisdrank(DrankNaam.Limonade, 2.0m),
        null,
        3
    );

    List<Bestelling> bestellingen = new List<Bestelling>() { bestelling1, bestelling2, bestelling3, bestelling4, bestelling5 };

    //Enkel bestellingen van Jan Janssen
    var enkelJan = from bestelling in bestellingen
                   where bestelling.Klant.Naam == "Jan Janssen"
                   select bestelling;

    foreach (var bestelling in enkelJan)
    {
        Console.WriteLine($"Bestelling: {enkelJan.ToList().IndexOf(bestelling) + 1}");
        Console.WriteLine(bestelling.Klant);
        Console.WriteLine(bestelling.ToString());
        Console.WriteLine("\n********************************************************\n");
    }

    //Alle bestellingen gegroepeerd per klant
    var alleBestellingen = from bestelling in bestellingen
                           group bestelling by bestelling.Klant.Naam;

    foreach (var klant in alleBestellingen)
    {
        decimal totaalBedrag = 0;
        if (klant.Key != "Onbekend persoon")
        {
            Console.WriteLine($"Bestellingen van {klant.Key}");
            foreach (var bestelling in klant)
            {
                Console.WriteLine(bestelling.ToString());
                totaalBedrag += bestelling.BerekenBedrag();
            }
            Console.WriteLine($"Het totale bedrag van alle bestellingen van {klant.Key}: {totaalBedrag.ToString("F2")} euro");
            Console.WriteLine("\n********************************************************\n");
        }
        else
        {
            Console.WriteLine("Onbekende klanten:");
            foreach (var bestelling in klant)
            {
                Console.WriteLine(bestelling.ToString());
            }
        }
    }
}
catch (Exception ex)
{
    Console.WriteLine($"Foutmelding: {ex.Message}");
}



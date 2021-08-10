using System;

namespace Galgenraten_3000
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Willkommen zum Galgenraten...");
            var spiel = new Business.DasSpiel();
            while (true)
            {
                Console.WriteLine(spiel.Anzeige);
                Console.Write($"{spiel.AnzahlFehler} Fehler> ");

                spiel.Eingabe(Console.ReadLine());
                if (spiel.IstGewonnen || spiel.IstTot)
                {
                    break;
                }
            } //ende von while
            if (spiel.IstGewonnen)
            {
                Console.WriteLine("Herzlichen Glückwunsch, Alter...");
            }
            else
            {
                Console.WriteLine($"Pech gehabt, Alter... ({spiel.GeheimesWort})");
            }

        }
    }
}

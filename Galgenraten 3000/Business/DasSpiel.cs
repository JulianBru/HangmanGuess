using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Galgenraten_3000.Business
{
    public class DasSpiel
    {
        public string GeheimesWort { get; set; }
        public string Anzeige { get; set; }
        public int AnzahlFehler { get; set; }

        public bool IstGewonnen
        {
            get
            {
                return GeheimesWort.Equals(Anzeige);
            }
        }
        public bool IstTot
        {
            get
            {
                return AnzahlFehler > 10;
            }
        }

        public DasSpiel()  //Default-Konstruktor
        {
            var alle = File.ReadAllLines(@"c:\temp\maco\deutsch.txt");
            var r = new Random();
            GeheimesWort = alle[r.Next(0,alle.Length)];
            Anzeige = new string('-', GeheimesWort.Length);
            AnzahlFehler = 0;
        }

        public void Eingabe(string zeichen)
        {
            var tmp = "";
            var gefunden = false;
            for (int i = 0; i < GeheimesWort.Length; i++)
            {
                if (GeheimesWort.ToUpper()[i]==zeichen.ToUpper()[0])
                {
                    tmp += GeheimesWort[i];
                    gefunden = true;
                }
                else
                {
                    tmp += Anzeige[i];
                }
            }
            Anzeige = tmp;
            if (!gefunden)
            {
                AnzahlFehler++;
            }

        }

    }
}

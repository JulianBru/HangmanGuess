using Microsoft.VisualStudio.TestTools.UnitTesting;
using Galgenraten_3000.Business;
using System;
using System.Collections.Generic;
using System.Text;

namespace Galgenraten_3000.Business.Tests
{
    [TestClass()]
    public class DasSpielTests
    {
        [TestMethod()]
        public void DasSpielTest()
        {
            var spiel = new DasSpiel();
            Assert.IsTrue(spiel.GeheimesWort.Length > 0);
            Assert.AreEqual(spiel.GeheimesWort.Length, spiel.Anzeige.Length);
        }

        [TestMethod()]
        public void EingabeTest()
        {
            var spiel = new DasSpiel();
            spiel.GeheimesWort = "Klaus"; spiel.Anzeige = "-----";
            spiel.Eingabe("x");
            Assert.AreEqual(1, spiel.AnzahlFehler);
            spiel.Eingabe("a"); spiel.Eingabe("s"); spiel.Eingabe("u"); spiel.Eingabe("l"); spiel.Eingabe("k");
            Assert.IsTrue(spiel.IstGewonnen);

        }

      
    }
}
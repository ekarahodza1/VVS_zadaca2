using Microsoft.VisualStudio.TestTools.UnitTesting;
using Hypo_Banka;
using System;
using System.Collections.Generic;
using System.Text;

namespace Unit_Testovi
{
    [TestClass()]
    public class RacunTests
    {
        //Esma
        [TestMethod()]
        public void RacunTest()
        {
            Racun racun = new Racun(100);
            Assert.IsFalse(racun.Blokiran);
        }

        //Dženana
        [TestMethod(), ExpectedException(typeof(AccessViolationException))]
        public void PromijeniStanjeRačunaTestPogrešnaVerifikacija()
        {
            Racun racun = new Racun(100);
            racun.PromijeniStanjeRačuna("verifikacija", 50);
        }

        //Dženana
        [TestMethod()]
        public void PromijeniStanjeRačunaTest()
        {
            Racun racun = new Racun(100);
            racun.PromijeniStanjeRačuna("BANKAR12345", 50);

            Assert.AreEqual(150, racun.StanjeRacuna);
        }
    }
}
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
        [TestMethod()]
        public void RacunTest()
        {
            Assert.Fail();
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
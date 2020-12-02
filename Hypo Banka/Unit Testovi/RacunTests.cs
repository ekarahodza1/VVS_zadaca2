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

        //Dženeta
        static IEnumerable<object[]> RacuniPocetnoStanjeVeceOdNula
        {
            get
            {
                return new[]
                {
                    new object[] {150},
                    new object[] {0.2},
                    new object[] {10000}
                };
            }
        }


        static IEnumerable<object[]> RacuniPocetnoStanjeManjeOdGranice
        {
            get
            {
                return new[]
                {
                    new object[] {0},
                    new object[] {-20},
                    new object[] {0.05}
                };
            }
        }

        //Dženeta
        [TestMethod()]
        [ExpectedException(typeof(ArgumentException))]
        [DynamicData("RacuniPocetnoStanjeVeceOdNula")]
        public void RacunBlokiranjeNijeDozvoljeno1(double pocetnoStanje)
        {
            Racun racun = new Racun(pocetnoStanje);
            racun.Blokiran = true;
        }

        //Dženeta
        [TestMethod()]
        [ExpectedException(typeof(ArgumentException))]
        [DynamicData("RacuniPocetnoStanjeManjeOdGranice")]
        public void RacunBlokiranjeNijeDozvoljeno2(double pocetnoStanje)
        {
            Racun racun = new Racun(pocetnoStanje);
            racun.Blokiran = false;
        }

        //Dženeta
        [TestMethod()]
        [ExpectedException(typeof(ArgumentException))]
        [DynamicData("RacuniPocetnoStanjeVeceOdNula")]
        public void RacunBlokiranjeDozvoljeno(double pocetnoStanje)
        {
            Racun racun = new Racun(pocetnoStanje);
            racun.Blokiran = true;
        }

    }
}
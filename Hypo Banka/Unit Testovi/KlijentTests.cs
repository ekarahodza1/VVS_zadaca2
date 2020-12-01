using Microsoft.VisualStudio.TestTools.UnitTesting;
using Hypo_Banka;
using System;
using System.Collections.Generic;
using System.Text;

namespace Unit_Testovi
{
    [TestClass()]
    public class KlijentTests
    {
        //Dženana
        [TestMethod(), ExpectedException(typeof(InvalidOperationException))]
        public void DajUkupanIznosNovcaNaSvimRačunimaTestNemaNijedanRacun()
        {
            Klijent klijent = new Klijent();
            klijent.DajUkupanIznosNovcaNaSvimRačunima();
        }

        //Dženana
        [TestMethod()]
        public void DajUkupanIznosNovcaNaSvimRačunimaTest()
        {
            Klijent klijent = new Klijent("Dženana", "Huseinspahić", "dzhuseinspahic", "lozinka12345678912312#", DateTime.Parse("1.1.2000."), "123A456");
            Racun racun1 = new Racun(5000);
            Racun racun2 = new Racun(1000);
            Racun racun3 = new Racun(2000);
            Racun racun4 = new Racun(3000);

            klijent.Racuni.Add(racun1);
            klijent.Racuni.Add(racun2);
            klijent.Racuni.Add(racun3);
            klijent.Racuni.Add(racun4);
            
            Assert.AreEqual(11000, klijent.DajUkupanIznosNovcaNaSvimRačunima());
        }

        //Dženana
        [TestMethod(), ExpectedException(typeof(InvalidOperationException))]
        public void DajUkupanIznosNovcaNaSvimRačunimaTestBlokirani()
        {
            Klijent klijent = new Klijent();
            Racun racun1 = new Racun(100);
            Racun racun2 = new Racun(100);

            racun1.PromijeniStanjeRačuna("BANKAR12345", -200);
            racun2.PromijeniStanjeRačuna("BANKAR12345", -100);

            racun1.Blokiran = true;
            racun2.Blokiran = true;

            klijent.Racuni.Add(racun1);
            klijent.Racuni.Add(racun2);

            klijent.DajUkupanIznosNovcaNaSvimRačunima();
        }

        //Esma
        [TestMethod()]
        public void TestSkidanjaIznosaSRačunaPrazan()
        {
            Banka b = new Banka();
            Klijent k = new Klijent();

            Assert.IsFalse(k.SkiniIznosSaNekogOdRačuna(1000));
        }

    }

}
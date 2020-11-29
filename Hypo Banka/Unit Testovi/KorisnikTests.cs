using Microsoft.VisualStudio.TestTools.UnitTesting;
using Hypo_Banka;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace Unit_Testovi
{
    [TestClass()]
    public class KorisnikTests
    {

        //Esma
        [TestMethod()]
        [ExpectedException(typeof(ArgumentException))]
        public void AutomatskoGenerisanjePodatakaTest1()
        {
            Korisnik korisnik = new Klijent(null, null, null, null, new DateTime(), null);
            korisnik.AutomatskoGenerisanjePodataka();
        }

        //Dzeneta
        [TestMethod()]
        [ExpectedException(typeof(ArgumentException))]
        public void AutomatskoGenerisanjePodatakaTest2()
        {
            Korisnik korisnik = new Klijent("Dzeneta", "Kudumovic", "dkudumovic1", "123456789123456789P?", new DateTime(1998, 08, 19), "123D456");
            korisnik.Ime = null;
            korisnik.AutomatskoGenerisanjePodataka();
        }
        //Dzeneta
        [TestMethod()]
        public void AutomatskoGenerisanjePodatakaTest3()
        {
            Korisnik korisnik = new Klijent("Dzeneta", "Kudumovic", "dzeneta", "123456789123456789P?", new DateTime(1998, 08, 19), "123D456");
            Assert.IsNotNull(korisnik.AutomatskoGenerisanjePodataka().Item1);
            Assert.IsNotNull(korisnik.AutomatskoGenerisanjePodataka().Item2);
            Assert.AreEqual("dkudumovic1", korisnik.AutomatskoGenerisanjePodataka().Item1);
            Assert.IsTrue(korisnik.AutomatskoGenerisanjePodataka().Item2.Length >= 20);
        }

        //Esma
        [TestMethod()]
        public void AutomatskoGenerisanjePodatakaTest4()
        {
            Korisnik korisnik = new Klijent("Esma", "Karahodza", "esma", "123456789123456789A!", new DateTime(1999, 05, 05), "000A000");
            String str = korisnik.AutomatskoGenerisanjePodataka().Item2;
            Regex r = new Regex("^[a-zA-Z0-9]+$");
            Assert.IsFalse(r.IsMatch(str));
        }



    }
}
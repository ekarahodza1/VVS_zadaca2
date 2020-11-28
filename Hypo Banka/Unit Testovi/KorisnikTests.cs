using Microsoft.VisualStudio.TestTools.UnitTesting;
using Hypo_Banka;
using System;
using System.Collections.Generic;
using System.Text;

namespace Unit_Testovi
{
    [TestClass()]
    public class KorisnikTests
    {
        //Dzeneta
        [TestMethod()]
        [ExpectedException(typeof(Exception))]
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
            Korisnik korisnik = new Klijent("Dzeneta", "Kudumovic", null, null, new DateTime(1998, 08, 19), "123D456");
            Assert.IsNotNull(korisnik.AutomatskoGenerisanjePodataka().Item1);
            Assert.IsNotNull(korisnik.AutomatskoGenerisanjePodataka().Item2);
            Assert.Equals("dkudumovic1", korisnik.AutomatskoGenerisanjePodataka().Item1);
            Assert.IsTrue(korisnik.AutomatskoGenerisanjePodataka().Item2.Length >= 20);
        }



    }
}
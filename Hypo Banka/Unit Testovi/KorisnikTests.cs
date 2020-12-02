using Microsoft.VisualStudio.TestTools.UnitTesting;
using Hypo_Banka;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using System.Globalization;

namespace Unit_Testovi
{
    [TestClass()]
    public class KorisnikTests
    {

        static IEnumerable<object[]> KorisnikIspravno
        {
            get
            {
                return new[]
                {
                    new object[] { "Esma", "Karahodza", "ekarahodza1", "lozinka123456aadfaa!", new DateTime(1999, 01, 10), "123D456" },
                    new object[] { "Ime", "Prezime", "neko1", "lozinka123456aaaaaa!", new DateTime(1999, 01, 10), "123D456" }
                  
                };
            }
        }

        //Esma
        [TestMethod()]
        [DynamicData("KorisnikIspravno")]
        public void ValidacijaKorisnikIspravno(string ime, string prezime, string korisnickoIme, string lozinka, DateTime datum, string licna)
        {
            Korisnik korisnik = new Klijent(ime, prezime, korisnickoIme, lozinka, new DateTime(), licna);
            byte[] data = System.Text.Encoding.ASCII.GetBytes(lozinka);
            data = new System.Security.Cryptography.SHA256Managed().ComputeHash(data);
            string lozinkaHash = System.Text.Encoding.ASCII.GetString(data);
            Assert.AreEqual(lozinkaHash, korisnik.Lozinka);
        }

        static IEnumerable<object[]> KorisnikNeispravno
        {
            get
            {
                return new[]
                {
                    new object[] { null, "Karahodza", "ekarahodza1", "lozinka123456aadfaa!", new DateTime(1999, 05, 05), "123D456" },
                    new object[] { "Esma", null, "ekarahodza1", "lozinka123456aadfaa!", new DateTime(1999, 05, 05), "123D456" },
                    new object[] { "Esma", "Karahodza", null, "lozinka123456aadfaa!", new DateTime(1999, 05, 05), "123D456" },
                    new object[] { "Esma", "Karahodza", "ekarahodza1", null, new DateTime(1999, 05, 05), "123D456" },
                    new object[] { "Esma", "Karahodza", "ekarahodza1", "lozinka123456aadfaa!", new DateTime(1999, 05, 05), null },
                    new object[] { "a", "Karahodza", "ekarahodza1", "lozinka123456aadfaa!#", new DateTime(1999, 05, 05), "123D456" },
                    new object[] { "Esma", "karahodza", "ekarahodza1", "lozinka123456aadfaa!#", new DateTime(1999, 05, 05), "123D456" },
                    new object[] { "Esma", "Karahodza", "ekarahodza1", "lozinka", new DateTime(1999, 05, 05), "123D456" },
                    new object[] { "Esma", "Karahodza", "ekarahodza1", "lozinka123456aadfaa!#", new DateTime(1999, 05, 05), "1230456" }

                };
            }
        }

        //Esma
        [TestMethod()]
        [ExpectedException(typeof(ArgumentException))]
        [DynamicData("KorisnikNeispravno")]
        public void ValidacijaKorisnikNeispravno(string ime, string prezime, string korisnickoIme, string lozinka, DateTime datum, string licna)
        {
            Korisnik korisnik = new Klijent(ime, prezime, korisnickoIme, lozinka, new DateTime(), licna);
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
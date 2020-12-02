using Hypo_Banka;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace Unit_Testovi
{
    [TestClass()]
    public class KreditTest
    {
        //Dženana
        [TestMethod()]
        public void ProvjeriStanjeOtplateTest()
        {
            Klijent klijent = new Klijent();
            Kredit kredit = new Kredit(klijent, 10000, 150, 0.05, DateTime.Parse("12.12.2020."));
            Assert.AreEqual("Kredit koji se treba vratiti najkasnije na dan 12.12.2020. godine " +
                "ima preostali iznos od 10000KM. Iznos rate je 150KM, po stopi od 5%.", kredit.ProvjeriStanjeOtplate());
        }

        //Dženeta
        static IEnumerable<object[]> KamatnaStopaIRokOtplateNeispravno
        {
            get
            {
                return new[]
                {
                    new object[] {new Klijent("Dzeneta", "Kudumovic", "dkudumovic1", "123456789123456789P?", new DateTime(1998, 08, 19), "123D456"),
                        10000,500,0.01,new DateTime(2032,01,01)},
                    new object[] {new Klijent("Dzeneta", "Kudumovic", "dkudumovic1", "123456789123456789P?", new DateTime(1998, 08, 19), "123D456"),
                        21333,764,0.12,new DateTime(2019,01,01)},
                    new object[] {new Klijent("Dzeneta", "Kudumovic", "dkudumovic1", "123456789123456789P?", new DateTime(1998, 08, 19), "123D456"),
                        10000,500,-1,new DateTime(2021,01,01)}
                    
                };
            }
        }

        [TestMethod()]
        [DynamicData("KamatnaStopaIRokOtplateNeispravno")]
        [ExpectedException(typeof(ArgumentException))]
        public void ValidacijaKamatneStopeiRokaOtplate(Klijent client, double amount, double monthlyAmount, double interestRate, DateTime dueDate)
        {
            Kredit kredit = new Kredit(client, amount, monthlyAmount, interestRate, dueDate);
        }

        //Dženeta
        static IEnumerable<object[]> IznosIRataNeispravno
        {
            get
            {
                return new[]
                {
                    new object[] {new Klijent("Dzeneta", "Kudumovic", "dkudumovic1", "123456789123456789P?", new DateTime(1998, 08, 19), "123D456"),
                        100001,5000,0.03,new DateTime(2025,01,01)},
                    new object[] {new Klijent("Dzeneta", "Kudumovic", "dkudumovic1", "123456789123456789P?", new DateTime(1998, 08, 19), "123D456"),
                        151233,-300,0.09,new DateTime(2026,02,07)},
                    new object[] {new Klijent("Dzeneta", "Kudumovic", "dkudumovic1", "123456789123456789P?", new DateTime(1998, 08, 19), "123D456"),
                        -120000,4001,0.05,new DateTime(2021,01,08)}

                };
            }
        }
        [TestMethod()]
        [DynamicData("IznosIRataNeispravno")]
        [ExpectedException(typeof(InvalidOperationException))]
        public void ValidacijaIznosaIRate(Klijent client, double amount, double monthlyAmount, double interestRate, DateTime dueDate)
        {
            Kredit kredit = new Kredit(client, amount, monthlyAmount, interestRate, dueDate);
        }

        //Dženeta
        static IEnumerable<object[]> KreditiIspravno
        {
            get
            {
                return new[]
                {
                    new object[] {new Klijent("Dzeneta", "Kudumovic", "dkudumovic1", "123456789123456789P?", new DateTime(1998, 08, 19), "123D456"),
                        90000,500,0.03,new DateTime(2025,01,01)},
                    new object[] {new Klijent("Dzeneta", "Kudumovic", "dkudumovic1", "123456789123456789P?", new DateTime(1998, 08, 19), "123D456"),
                        2000,200,0.09,new DateTime(2026,03,01)},
                    new object[] {new Klijent("Dzeneta", "Kudumovic", "dkudumovic1", "123456789123456789P?", new DateTime(1998, 08, 19), "123D456"),
                        34000,850,0.05,new DateTime(2021,01,08)}

                };
            }
        }

        [TestMethod()]
        [DynamicData("KreditiIspravno")]
        public void ValidacijaKredita(Klijent client, double amount, double monthlyAmount, double interestRate, DateTime dueDate)
        {
            Kredit kredit = new Kredit(client, amount, monthlyAmount, interestRate, dueDate);
        }

        //Dženeta
        [TestMethod()]
        public void TestGeteri()
        {
            Kredit kredit = new Kredit(new Klijent("Dzeneta", "Kudumovic", "dkudumovic1", "123456789123456789P?", new DateTime(1998, 08, 19), "123D456"),
                        90000, 500, 0.03, new DateTime(2025, 01, 01));
            double iznos = kredit.Iznos;
            double kamatnaStopa = kredit.KamatnaStopa;
            double rata = kredit.Rata;
            DateTime rokOtplate = kredit.RokOtplate;
            Klijent klijent = kredit.Klijent;
            Assert.IsNotNull(klijent);
            Assert.AreEqual(90000, iznos);
            Assert.AreEqual(500, rata);
            Assert.AreEqual(0.03, kamatnaStopa);
            Assert.AreEqual(new DateTime(2025, 01, 01),rokOtplate);

        }
    }
}
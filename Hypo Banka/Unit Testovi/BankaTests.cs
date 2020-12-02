using Microsoft.VisualStudio.TestTools.UnitTesting;
using Hypo_Banka;
using System;
using System.Collections.Generic;
using System.Text;

namespace Unit_Testovi
{
    [TestClass()]
    public class BankaTests
    {

        //Dženana
        [TestMethod()]
        public void RadSaKlijentomTestDodavanjeKlijenata()
        {
            Klijent klijent1 = new Klijent();
            Klijent klijent2 = new Klijent();
            Banka banka = new Banka();

            banka.RadSaKlijentom(klijent1, 0, new List<string>());
            banka.RadSaKlijentom(klijent2, 0, new List<string>());

            Assert.AreEqual(2, banka.Klijenti.Count);
        }

        //Dženana
        [TestMethod()]
        public void RadSaKlijentomTestBrisanjeKlijenata()
        {
            Klijent klijent1 = new Klijent();
            Klijent klijent2 = new Klijent();
            Banka banka = new Banka();

            banka.RadSaKlijentom(klijent1, 0, new List<string>());
            banka.RadSaKlijentom(klijent2, 0, new List<string>());

            banka.RadSaKlijentom(klijent1, 2, new List<string>());

            Assert.AreEqual(1, banka.Klijenti.Count);
        }

        //Dženana
        [TestMethod()]
        public void RadSaKlijentomTestAutomatskoGenerisanje()
        {
            Klijent klijent = new Klijent("Dženana", "Huseinspahić", "nekoime", "lozinka12345678912312#", DateTime.Parse("1.1.2000."), "123A456");
            Banka banka = new Banka();

            banka.RadSaKlijentom(klijent, 0, new List<string>());
            banka.RadSaKlijentom(klijent, 1, new List<string>());

            StringAssert.Matches(banka.Klijenti[0].KorisnickoIme, new System.Text.RegularExpressions.Regex(@"(?:^|\W)dhuseinspahić1(?:$|\W)"));
        }

        //Dženana
        [TestMethod(), ExpectedException(typeof(ArgumentNullException))]
        public void OtvaranjeNovogRačunaTestKlijentNijeRegistrovan()
        {
            Klijent klijent = new Klijent("Dženana", "Huseinspahić", "nekoime", "lozinka12345678912312#", DateTime.Parse("1.1.2000."), "123A456");
            Banka banka = new Banka();
            banka.OtvaranjeNovogRačuna(klijent, new Racun(100));
        }

        //Dženana
        [TestMethod(), ExpectedException(typeof(InvalidOperationException))]
        public void OtvaranjeNovogRačunaTestVišeOd3Računa()
        {
            Klijent klijent = new Klijent("Dženana", "Huseinspahić", "nekoime", "lozinka12345678912312#", DateTime.Parse("1.1.2000."), "123A456");
            Banka banka = new Banka();

            banka.RadSaKlijentom(klijent, 0, new List<string>());
            klijent.Racuni.Add(new Racun(100));
            klijent.Racuni.Add(new Racun(200));
            klijent.Racuni.Add(new Racun(300));
            
            banka.OtvaranjeNovogRačuna(klijent, new Racun(100));
        }

        //Dženana
        [TestMethod()]
        public void OtvaranjeNovogRačunaTest()
        {
            Klijent klijent = new Klijent("Dženana", "Huseinspahić", "nekoime", "lozinka12345678912312#", DateTime.Parse("1.1.2000."), "123A456");
            Banka banka = new Banka();

            banka.RadSaKlijentom(klijent, 0, new List<string>());
            banka.OtvaranjeNovogRačuna(klijent, new Racun(100));
            banka.OtvaranjeNovogRačuna(klijent, new Racun(100));

            Assert.AreEqual(2, banka.Klijenti[0].Racuni.Count);
        }

        //Dzeneta
        [TestMethod()]
        public void KlijentiSBlokiranimRačunimaTest()
        {
            //banka sa jednim klijentom ciji je racun blokiran
            Banka banka = new Banka();
            Klijent klijent1 = new Klijent("Dzeneta", "Kudumovic", "dkudumovic1", "123456789123456789P?", new DateTime(1998, 08, 19), "123D456");
            Racun racun1 = new Racun(100);
            Racun racun2 = new Racun(1);
            racun2.PromijeniStanjeRačuna("BANKAR12345", - 100);
            klijent1.Racuni.Add(racun1);
            klijent1.Racuni.Add(racun2);

            Klijent klijent2 = new Klijent("Neko", "Nekic", "nnekic1", "123456789123456789L!", new DateTime(1995, 01, 01), "789L123");
            Racun racun3 = new Racun(100);
            Racun racun4 = new Racun(2000);
            
            klijent2.Racuni.Add(racun3);
            klijent2.Racuni.Add(racun4);

            banka.Klijenti.Add(klijent1);
            banka.Klijenti.Add(klijent2);
            List<Klijent> ocekivanaLista = new List<Klijent>();
            ocekivanaLista.Add(klijent1);
            CollectionAssert.AreEqual(ocekivanaLista, banka.KlijentiSBlokiranimRačunima());
        }

        //Dzeneta
        [TestMethod()]
        [ExpectedException(typeof(Exception))]
        public void PraznaListaKlijentiSBlokiranimRačunimaTest()
        {
            //banka bez klijenata sa blokiranim racunima
            Banka banka = new Banka();
            Klijent klijent1 = new Klijent("Dzeneta", "Kudumovic", "dkudumovic1", "123456789123456789P?", new DateTime(1998, 08, 19), "123D456");
            Racun racun1 = new Racun(100);
            Racun racun2 = new Racun(20);
            klijent1.Racuni.Add(racun1);
            klijent1.Racuni.Add(racun2);

            Klijent klijent2 = new Klijent("Neko", "Nekic", "nnekic1", "123456789123456789L!", new DateTime(1995, 01, 01), "789L123");
            Racun racun3 = new Racun(100);
            Racun racun4 = new Racun(2000);

            klijent2.Racuni.Add(racun3);
            klijent2.Racuni.Add(racun4);

            banka.Klijenti.Add(klijent1);
            banka.Klijenti.Add(klijent2);
            banka.KlijentiSBlokiranimRačunima();
        }

        //Dzeneta
        [TestMethod()]
        [ExpectedException(typeof(Exception))]
        public void PraznaListaKlijentiSBlokiranimRačunimaTest2()
        {
            //banka bez klijenata
            Banka banka = new Banka();
            banka.KlijentiSBlokiranimRačunima();
        }

        //Dzeneta
        [TestMethod()]
        [ExpectedException(typeof(Exception))]
        public void PraznaListaKlijentiSBlokiranimRačunimaTest3()
        {
            //klijenti bez racuna
            Banka banka = new Banka();
            Klijent klijent1 = new Klijent("Dzeneta", "Kudumovic", "dkudumovic1", "123456789123456789P?", new DateTime(1998, 08, 19), "123D456");
            Klijent klijent2 = new Klijent("Neko", "Nekic", "nnekic1", "123456789123456789L!", new DateTime(1995, 01, 01), "789L123");
            banka.Klijenti.Add(klijent1);
            banka.Klijenti.Add(klijent2);
            banka.KlijentiSBlokiranimRačunima();
        }

        //Dženana
        [TestMethod()]
        public void DajKreditTest()
        {
            Banka banka = new Banka();
            Klijent klijent = new Klijent("Dženana", "Huseinspahić", "nekoime", "lozinka12345678912312#", new DateTime(1998, 12, 26), "123A456");
            banka.RadSaKlijentom(klijent, 0, new List<string>());
            Kredit kredit = new Kredit(klijent, 10000, 100, 0.05, new DateTime(2021, 12, 30));
            
            banka.DajKredit(kredit);

            Assert.IsNotNull(banka.Krediti);
        }

        //Dženana
        [TestMethod(), ExpectedException(typeof(InvalidOperationException))]
        public void DajKreditTestKlijentNijeUBanci()
        {
            Banka banka = new Banka();
            Klijent klijent = new Klijent();
            Kredit kredit = new Kredit(klijent, 10000, 100, 0.05, new DateTime(2021, 12, 30));

            banka.DajKredit(kredit);
        }

        //Dženana
        [TestMethod(), ExpectedException(typeof(InvalidOperationException))]
        public void DajKreditTestPremašenBrojKredita()
        {
            Banka banka = new Banka();
            Klijent klijent = new Klijent();
            Kredit kredit = new Kredit(klijent, 10000, 100, 0.05, new DateTime(2021, 12, 30));
            for (int i = 0; i <= 100; i++)
            {
                banka.RadSaKlijentom(klijent, 0, new List<string>());
                banka.DajKredit(kredit);
            }
        }

        [TestMethod()]
        public void OdobriKreditTest()
        {
            Banka banka = new Banka();
            IZahtjev zahtjev= new StubZahtjev();
            Kredit kredit = new Kredit(new Klijent("Dzeneta", "Kudumovic", "dkudumovic1", "123456789123456789P?", new DateTime(1998, 08, 19), "123D456"),
                        90000, 500, 0.03, new DateTime(2025, 01, 01));
            Assert.IsFalse(banka.OdobriKredit(zahtjev, kredit));
        }
    }
}
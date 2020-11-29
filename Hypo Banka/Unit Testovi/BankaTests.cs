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
        [TestMethod()]
        public void BankaTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void RadSaKlijentomTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void OtvaranjeNovogRačunaTest()
        {
            Assert.Fail();
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

        [TestMethod()]
        public void DajKreditTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void OdobriKreditTest()
        {
            Assert.Fail();
        }
    }
}
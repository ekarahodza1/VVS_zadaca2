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
            Klijent k1 = new Klijent("Dzeneta", "Kudumovic", "dkudumovic1", "123456789123456789P?", new DateTime(1998, 08, 19), "123D456");
            Racun r1 = new Racun(100);
            //Ovdje greska - kako blokirati racun
            Racun r2 = new Racun(0.0);
            r2.Blokiran = true;
            k1.Racuni.Add(r1);
            k1.Racuni.Add(r2);

            Klijent k2 = new Klijent("Neko", "Nekic", "nnekic1", "123456789123456789L!", new DateTime(1995, 01, 01), "789L123");
            Racun r3 = new Racun(100);
            Racun r4 = new Racun(2000);
            
            k2.Racuni.Add(r3);
            k2.Racuni.Add(r4);

            banka.Klijenti.Add(k1);
            banka.Klijenti.Add(k2);
            List<Klijent> ocekivanaLista = new List<Klijent>();
            ocekivanaLista.Add(k1);
            CollectionAssert.AreEqual(ocekivanaLista, banka.KlijentiSBlokiranimRačunima());
        }

        //Dzeneta
        [TestMethod()]
        [ExpectedException(typeof(Exception))]
        public void PraznaListaKlijentiSBlokiranimRačunimaTest()
        {
            //banka bez klijenata sa blokiranim racunima
            Banka banka = new Banka();
            Klijent k1 = new Klijent("Dzeneta", "Kudumovic", "dkudumovic1", "123456789123456789P?", new DateTime(1998, 08, 19), "123D456");
            Racun r1 = new Racun(100);
            Racun r2 = new Racun(20);
            k1.Racuni.Add(r1);
            k1.Racuni.Add(r2);

            Klijent k2 = new Klijent("Neko", "Nekic", "nnekic1", "123456789123456789L!", new DateTime(1995, 01, 01), "789L123");
            Racun r3 = new Racun(100);
            Racun r4 = new Racun(2000);

            k2.Racuni.Add(r3);
            k2.Racuni.Add(r4);

            banka.Klijenti.Add(k1);
            banka.Klijenti.Add(k2);
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
            Klijent k1 = new Klijent("Dzeneta", "Kudumovic", "dkudumovic1", "123456789123456789P?", new DateTime(1998, 08, 19), "123D456");
            Klijent k2 = new Klijent("Neko", "Nekic", "nnekic1", "123456789123456789L!", new DateTime(1995, 01, 01), "789L123");
            banka.Klijenti.Add(k1);
            banka.Klijenti.Add(k2);
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
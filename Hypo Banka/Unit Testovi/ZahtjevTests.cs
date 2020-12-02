using Microsoft.VisualStudio.TestTools.UnitTesting;
using Hypo_Banka;
using System;
using System.Collections.Generic;
using System.Text;

namespace Unit_Testovi
{
    [TestClass()]
    public class ZahtjevTests
    {
        [TestMethod()]
        [ExpectedException(typeof(NotImplementedException))]
        public void DaLiJePovoljanNijeImplementiranTest()
        {
            IZahtjev zahtjev = new Zahtjev();
            zahtjev.DaLiJePovoljan();
        }
    }
}
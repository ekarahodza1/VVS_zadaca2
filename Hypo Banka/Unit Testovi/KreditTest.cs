using Hypo_Banka;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace Unit_Testovi
{
    [TestClass]
    public class KreditTest
    {
        [TestMethod] 
        public void Test()
        {
            Klijent klijent = new Klijent();
            Kredit kredit = new Kredit(klijent, 10000, 150, 0.05, DateTime.Parse("12.12.2020."));
            Assert.AreEqual("Kredit koji se treba vratiti najkasnije na dan 12.12.2020. godine " +
                "ima preostali iznos od 10000KM. Iznos rate je 150KM, po stopi od 5%.", kredit.ProvjeriStanjeOtplate());
        }
}

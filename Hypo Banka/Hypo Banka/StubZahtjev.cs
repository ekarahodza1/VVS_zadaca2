using System;
using System.Collections.Generic;
using System.Text;

//Dzeneta
namespace Hypo_Banka
{
    public class StubZahtjev : IZahtjev
    {
        public bool DaLiJePovoljan()
        {
            return false;
        }
    }
}

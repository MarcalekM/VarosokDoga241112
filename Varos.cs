using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Varosok
{
    internal class Varos
    {
        public string VarosNev {  get; set; }
        public string OrszagNev { get; set; }
        public float Nepesseg { get; set; }

        public override string ToString() => $"{VarosNev} {OrszagNev} {Nepesseg:0.00}";

        public Varos(string sor)
        {
            var temp = sor.Split(';');
            VarosNev = temp[0];
            OrszagNev = temp[1];
            Nepesseg = float.Parse(temp[2]);
        }
    }
}

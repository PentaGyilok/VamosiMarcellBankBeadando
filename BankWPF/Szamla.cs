using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankWPF
{
    /// <summary>
    /// A számla osztály ami a tulajdonost és a tulajdonoshoz tartozó egyenleget fűzi össze
    /// </summary>
    public class Szamla
    {
        /// <summary>
        /// számlatulaj neve
        /// </summary>
        public string Tulajnev { get; set; }
        /// <summary>
        /// számlatulaj pénzmennyisége
        /// </summary>
        public int Egyenleg { get; set; }
        /// <summary>
        /// Szamla konstruktor
        /// </summary>
        /// <param name="ni"></param>
        /// <param name="na"></param>
        public Szamla(string ni="null", int na=0)
        {
            Tulajnev = ni;
            Egyenleg = na;
        }
    }
}

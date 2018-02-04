using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


/* Naloga:
Kot argument sprejme tabelo tabel elementov poljubnega tipa in
vrne njihovo povprečno dolžino.
*/

namespace Naloga1
{
    class Program
    {
        static void Main(string[] args)
        {
            string[][] tabeleNizov = new string[][]
            {
                new string[]{"Piškot", "Ni", "Dober" },
                new string[]{"Če ni", "sladek" }
            };
            Console.WriteLine(PovprečnaVelikost(tabeleNizov));
        }

        /// <summary>
        /// Izračuna povprečno velikost tabel.
        /// </summary>
        public static double PovprečnaVelikost<T>(T[][] tabele)
        {
            double skupno = 0;
            foreach (T[] tabela in tabele)
            {
                skupno += tabela.Length;
            }
            return skupno / tabele.Length;
        }
    }
}

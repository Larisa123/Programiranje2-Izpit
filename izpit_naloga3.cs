using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/* Naloga:
 Prebere vhodno datoteko, vse vrstice, ki predstavljajo datum zapiše v izhodno datoteko. (dd.mm.yyyy format)
 */


namespace Naloga3
{
    class Program
    {
        static void Main(string[] args)
        {
            Prepisi("..\\..\\vhodna.txt", "..\\..\\izhodna.txt");
        }

        /// <summary>
        /// Iz vhodne datoteke prepiše vrstice z datumi v pravilnem formatu
        /// v izhodno datoteko.
        /// </summary>
        static void Prepisi(string vhodna, string izhodna) {
            string vrstica;
            using (StreamReader vhod = new StreamReader(vhodna)) {
                using (StreamWriter izhod = new StreamWriter(izhodna)) {
                    while ((vrstica = vhod.ReadLine()) != null) {
                        if (JeDatum(vrstica)) izhod.WriteLine(vrstica);
                    }
                }
            }
        }

        /// <summary>
        /// Preveri, ali je v nizu datum v pravilnem formatu.
        /// </summary>
        static bool JeDatum(string vrstica)
        {
            DateTime t = new DateTime();
            return DateTime.TryParseExact(vrstica, "dd. MM. yyyy", null, System.Globalization.DateTimeStyles.None , out t);
        }
   }
}

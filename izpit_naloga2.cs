using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


/* Naloga:
 Sprejme celi števili a in b in poišče cela št. iz [b, b**2], ki v zapisu vsebujejo a.
 */


namespace Naloga2
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(VsebujoceStevilo(101, 10));
        }

        /// <summary>
        /// Poišče števila z intervala [b, b*b], ki v zapisu vsebujejo število a.
        /// </summary>
        static string VsebujoceStevilo(int a, int b) {
            List<string> najdena = new List<string>();
            for (int i=b; i<=b*b; i++) {
                if (Vsebuje(i, a))
                    najdena.Add(i.ToString());
            }

            if (najdena.Count == 0) {
                return string.Format("V intervalu [{0}, {1}] ni celih števil, ki bi v zapisu vsebovala število {2}.", b, b * b, a);
            }
            else return string.Format("Cela števila iz intervala [{0}, {1}], ki v zapisu vsebujejo število {2}, so: {3}.", b, b * b, a,
                string.Join(", ", najdena));
        }

        /// <summary>
        /// Preveri, ali število i v zapisu vsebuje število a.
        /// </summary>
        static bool Vsebuje(int i, int a)
        {
            return (i.ToString().Contains(a.ToString()));
        }
    }
}

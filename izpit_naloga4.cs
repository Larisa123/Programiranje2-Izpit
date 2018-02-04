using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Naloga4
{
    class Program
    {
        static void Main(string[] args)
        {
            Vozilo a = new Vozilo(30, 5);
            Vozilo b = new Vozilo(40, 7);
            Vozilo c = new Vozilo(10, 5);

            Vozilo[] tabela = new Vozilo[] { a, b, c };
            Vozilo.UrediPoDosegu(tabela);
            foreach (Vozilo v in tabela)
            {
                Console.WriteLine(v.PreostaliKilometri);
            }
        }
    }

    class Vozilo : IComparable<Vozilo>
    {
        private double gorivo;
        private double kapaciteta;
        private double poraba;

        /// <summary>
        /// Koliko kilometrov vozilo še lahko prevozi 
        /// s trenutno zalogo goriva.
        /// </summary>
        public double PreostaliKilometri
        {
            get { return 100 * gorivo / poraba; }
        }

        /// <summary>
        /// Naredi novo vozilo s podano kapaciteto in porabo.
        /// Trenutna količina goriva je enaka kapaciteti.
        /// </summary>
        /// <param name="k">kapaciteta goriva v vozilu</param>
        /// <param name="p">poraba goriva vozila</param>
        public Vozilo(double k, double p)
        {
            gorivo = k;
            kapaciteta = k;
            poraba = p;
        }

        /// <summary>
        /// Vozilo napolni z gorivom.
        /// </summary>
        public void Crpalka()
        {
            gorivo = kapaciteta;
        }

        /// <summary>
        /// Vozilo prevozi dano število kilometrov. Če pot uspešno zaključi,
        /// metoda vrne true in ustrezno zmanjša količino goriva. Če pa vmes
        /// zmanjka goriva, vrne false, količino goriva pa nastavi na 0.
        /// </summary>
        public bool Prevozi(double km)
        {
            double potreba = poraba * km / 100;
            if (potreba > gorivo)
            {
                gorivo = 0;
                return false;
            }
            else
            {
                gorivo -= potreba;
                return true;
            }

        }

        /// <summary>
        /// Vozili primerja glede na dolžini, ki ju lahko prevozita.
        /// </summary>
        public int CompareTo(Vozilo other)
        {
            double d = PreostaliKilometri - other.PreostaliKilometri;
            if (d < 0) return -1;
            else if (d > 0) return 1;
            else return 0;
        }

        /// <summary>
        /// Tabelo vozil uredi naraščajoče po dolžinah, ki jih lahko prevozijo.
        /// </summary>
        public static void UrediPoDosegu(Vozilo[] vozila)
        {
            Array.Sort(vozila);
        }
    }
}

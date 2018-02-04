using System;
using System.IO;

namespace naloga2 {
	class MainClass {
		public static void Main (string[] args) {

			// Preberimo vnos uporabnika in ga zapisujmo v datoteko, dokler ne vpiše "Konec"
			using (StreamWriter sw = File.CreateText ("test.txt")) { // shrani v Debug
				string novVnos; 
				do {
					novVnos = Console.ReadLine ();
					sw.WriteLine (novVnos);
				} while (novVnos != "Konec");
			}
		}
	}
}

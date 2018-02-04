using System;
using System.IO;

/// <summary>
/// Program, ki v izbrani mapi in njenih podmapah pobriše vse prazne datoteke in prazne mape.
/// </summary>

namespace naloga4 {
	class MainClass {
		public static void Main (string[] args) {

			// pot datoteke na mojem računalniku:
			string glavniImenik = "/Users/Larisa/Desktop/Sola/Prakticna 3. letnik/Programiranje 3/vaje5/brisanje";

			pobrisiPrazne (glavniImenik);
		}

		static void pobrisiPrazne(string imenik) { 
			// zaustavitveni pogoj ni takoj na zacetku, ker bi v tem primeru
			// s takim načinom pobrisali tudi samo mapo (v primeru, ko je prazna)

			foreach (string podimenik in Directory.GetDirectories (imenik)) { // za vsako podmapo pogledamo:
				if (File.Exists (podimenik)) {                               // ce je datoteka
					if (new FileInfo (podimenik).Length == 0) {              // dolzine 0
						File.Delete (podimenik);                             // jo zbrisemo
						return;                                              // in koncamo z rekurzijo,
					}
				} else if (Directory.Exists (podimenik)) {                    // ce je mapa brez map
					if (Directory.GetDirectories (podimenik).Length == 0      // in brez datotek
					    && Directory.GetFiles (podimenik).Length == 0) {     
						try { Directory.Delete (podimenik, false);            // jo poskusimo zbrisati
						} catch {}
						return;                                               // in koncamo z rekurzijo
					} else {                                                  // je imenik, ampak ni prazen
						pobrisiPrazne (podimenik);                            // torej lahko gremo v podimenike imenika
					}
				} else { return; } // ni datoteka ali imenik, na njej na smemo klicati rekurzije
			}
		}
	}
}

// OPOMBA: uporabila sem način, ki sem ga zasledila na tej povezavi: 
// https://stackoverflow.com/questions/2811509/c-sharp-remove-all-empty-subdirectories,
// ker je bila ideja nekoliko krajša in lažje berljiva od moje prvotne ideje
using System;
using System.IO;


namespace naloga3 {
	class MainClass {
		public static void Main (string[] args) {

			try {
				string imeDatoteke = args [0];
			} catch (IndexOutOfRangeException) {
				Console.WriteLine ("Ime datoteke ni bilo vnešeno v ukazno vrstico.");
			}

			string potBranje = "/Users/Larisa/Desktop/Sola/Prakticna 3. letnik/Programiranje 3/vaje5/";
			string potPisanje = "/Users/Larisa/Desktop/Sola/Prakticna 3. letnik/Programiranje 3/vaje5/porocilo.txt";
			int stVrstice = 0;
			string napake = "";

			float dohodki = 0;
			float odhodki = 0;

			// preberimo:
			try {
				using (StreamReader sr = File.OpenText (potBranje)) {
					string vrstica = "";
					string[] razdeljenaVrstica;

					while ((vrstica = sr.ReadLine ()) != null) {
						try {
							razdeljenaVrstica = vrstica.Split (',');
							if (razdeljenaVrstica [0] == "Prodaja")
								dohodki += float.Parse(razdeljenaVrstica [1]);
							else if (razdeljenaVrstica [0] == "Nakup")
								odhodki += float.Parse(razdeljenaVrstica [1]);
							else {
								napake += stVrstice.ToString() + ".: neznan tip transakcije\n";
							}
						} catch (FormatException e) {
							napake += stVrstice.ToString() + ".: vrednost ni število\n";
						} catch {
							napake += stVrstice.ToString() + ".: neznana napaka\n";
						}
						stVrstice++;
					}
				}
			} catch {
				Console.WriteLine("Te datoteke ne gre odpreti.");
			}

			// zapisimo:
			using (StreamWriter sw = File.CreateText (potPisanje)) {
				float dobicek = dohodki - odhodki;
				sw.WriteLine (string.Format ("Skupni dohodki: {0}, skupni odhodki: {1}, dobiček: {2}", dohodki, odhodki, dobicek));
				sw.WriteLine (napake);
			}
		}
	}
}

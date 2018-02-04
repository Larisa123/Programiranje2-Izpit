using System;
using System.IO;

/// <summary>
/// Presteje koliko datotek je v mapi in njenih podmapah
/// </summary>

namespace naloga5 {
	class MainClass {
		public static void Main (string[] args) {

			string imenik = "/Users/Larisa/Desktop/Sola/Prakticna 3. letnik/Programiranje 3/"; 
			// odgovor je 5
			int koliko = prestejSteviloDatotek (imenik);
			Console.WriteLine (koliko);
		}
			

		public static int prestejSteviloDatotek(string imenik) {

			int stevec = 0;

			foreach (string podimenik in Directory.GetDirectories(imenik))
				if (!seZacneSStevko (podimenik)) {
					stevec += Directory.GetFiles (podimenik).Length;

				stevec += prestejSteviloDatotek (podimenik);
			}
			return stevec;
		}

		public static bool seZacneSStevko(string celaPot) {
			string[] imeSeznam = celaPot.Split ('/'); // da iz C:hsakhd/ime.dsj dobimo samo ime.dsj:
			string ime = imeSeznam[imeSeznam.Length - 1];
			Console.WriteLine("ime: "+ ime + "  znak:"+ ime[0]);

			int rezultat;
			return int.TryParse (ime [0].ToString(), out rezultat);
		}
	}
}

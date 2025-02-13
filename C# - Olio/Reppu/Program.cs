using System;

namespace AdventureBackpack
{
    class Program
    {
        static void Main(string[] args)
        {
            Reppu reppu = new Reppu(5, 10, 10);

            Nuoli nuoli = new Nuoli();
            Jousi jousi = new Jousi();
            Köysi köysi = new Köysi();
            Vesi vesi = new Vesi();
            Ruoka ruoka = new Ruoka();
            Miekka miekka = new Miekka();

            bool running = true;
            while (running)
            {
                Console.WriteLine(reppu.ToString());
                Console.WriteLine($"Repussa on tällä hetkellä {reppu.CurrentAmount}/{reppu.MaxItemAmount} tavaraa, {reppu.CurrentWeight}/{reppu.MaxWeight} painoa ja {reppu.CurrentSpace}/{reppu.MaxSpace} tilavuus");
                Console.WriteLine("Mitä haluat lisätä?");
                Console.WriteLine("Repun valikko:\n" +
                      "1 - Nuoli\n" +
                      "2 - Jousi\n" +
                      "3 - Köysi\n" +
                      "4 - Vesi\n" +
                      "5 - Ruoka\n" +
                      "6 - Miekka\n" +
                      "7 - Näytä repun tila\n" +
                      "8 - Lopeta\n" +
                      "Valitse toiminto (1-8): ");

                string input = Console.ReadLine();

                switch (input)
                {
                    case "1":
                        Console.WriteLine("Yritetään lisätä nuoli " + reppu.Lisää(nuoli));
                        break;
                    case "2":
                        Console.WriteLine("yritetään lisätä jousi " + reppu.Lisää(jousi));
                        break;
                    case "3":
                        Console.WriteLine("Yritetään lisätä köysi " + reppu.Lisää(köysi));
                        break;
                    case "4":
                        Console.WriteLine("Yritetään lisätä vesi " + reppu.Lisää(vesi));
                        break;
                    case "5":
                        Console.WriteLine("Yritetään lisätää ruoka " + reppu.Lisää(ruoka));
                        break;
                    case "6":
                        Console.WriteLine("Yritetään lisätä miekka " + reppu.Lisää(miekka));
                        break;
                    case "7":
                        Console.WriteLine($"Repussa on tällä hetkellä {reppu.CurrentAmount}/{reppu.MaxItemAmount} tavaraa, {reppu.CurrentWeight}/{reppu.MaxWeight} painoa ja {reppu.CurrentSpace}/{reppu.MaxSpace} tilavuus");
                        break;
                    case "8":
                        running = false;
                        Console.WriteLine("Lopetetaan ohjelma...");
                        break;
                    default:
                        Console.WriteLine("Virheellinen valinta. Yritä uudelleen.");
                        break;
                }

                Console.WriteLine("Paina mitä tahansa näppäintä jatkaaksesi.");
                Console.ReadKey();
            }
        }
    }
}
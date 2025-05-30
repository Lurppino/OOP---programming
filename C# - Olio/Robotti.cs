﻿namespace Robotti
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Robotti robotti = new Robotti();
            Console.WriteLine("HUOM! Muista käynnistää robotti ensin!");

            for ( int i = 0; i < 3; i++ )
            {
                Console.WriteLine("Mitä komentoja syötetään robotille? Vaihtoehdot: Käynnistä, Sammuta, Ylös, Alas, Oikealle, Vasemmalle");
                
                string answer = Console.ReadLine();

                switch (answer)
                {
                    case "käynnistä":
                        robotti.Käskyt[i] = new Robotti.Käynnistä();
                        break;
                    case "sammuta":
                        robotti.Käskyt[i] = new Robotti.Sammuta();
                        break;
                    case "ylös":
                        robotti.Käskyt[i] = new Robotti.YlösKäsky();
                        break;
                    case "alas":
                        robotti.Käskyt[i] = new Robotti.AlasKäsky();
                        break;
                    case "oikealle":
                        robotti.Käskyt[i] = new Robotti.OikeaKäsky();
                        break;
                    case "vasemmalle":
                        robotti.Käskyt[i] = new Robotti.VasenKäsky();
                        break;
                    default:
                        Console.WriteLine("Virheellinen komento, yritä uudelleen");
                        i--;
                        break;
                }
                
            }
            robotti.Suorita();
        }

        public class Robotti
        {
            public int X { get; set; }
            public int Y { get; set; }
            public bool OnKäynnissä { get; set; }
            public IRobottiKäsky?[] Käskyt { get; } = new IRobottiKäsky?[3];

            public interface IRobottiKäsky
            {
                void Suorita(Robotti robotti);
            }
            public void Suorita()
            {
                foreach (IRobottiKäsky? käsky in Käskyt)
                {
                    käsky?.Suorita(this);
                    Console.WriteLine($"[{X} {Y} {OnKäynnissä}]");
                }
            }

            public class Käynnistä : IRobottiKäsky
            {
                public void Suorita(Robotti robotti)
                {
                    robotti.OnKäynnissä = true;
                }
            }
            public class Sammuta : IRobottiKäsky
            {
                public void Suorita(Robotti robotti)
                {
                    robotti.OnKäynnissä = false;
                }
            }
            public class YlösKäsky : IRobottiKäsky
            {
                public void Suorita(Robotti robotti)
                {
                    if (robotti.OnKäynnissä == true)
                    {
                        robotti.Y += 1;
                    }
                }
            }
            public class AlasKäsky : IRobottiKäsky
            {
                public void Suorita(Robotti robotti)
                {
                    if (robotti.OnKäynnissä == true)
                    {
                        robotti.Y -= 1;
                    }
                }
            }
            public class OikeaKäsky : IRobottiKäsky
            {
                public void Suorita(Robotti robotti)
                {
                    if (robotti.OnKäynnissä == true)
                    {
                        robotti.X += 1;
                    }
                }
            }
            public class VasenKäsky : IRobottiKäsky
            {
                public void Suorita(Robotti robotti)
                {
                    if (robotti.OnKäynnissä == true)
                    {
                        robotti.X -= 1;
                    }
                }
            }
        }

    }
}

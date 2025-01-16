namespace Ruoka_Gen
{
    internal class Program
    {
        enum _Main
        {
            nautaa,
            kanaa,
            kasviksia
        }
        enum Lisuke
        {
            perunaa,
            riisiä,
            pastaa
        }
        enum Kastike
        {
            curry,
            hapanimelä,
            pippuri,
            chili
        }
        static void Main(string[] args)
        {

            string mainDish = GetMainDish();
            string sideDish = GetSideDish();
            string sauce = GetSauce();

            string wholeDish = $"{mainDish} ja {sideDish} {sauce}-kastikkeella";
            Console.WriteLine(wholeDish);
        }

        // Sain idean tehdä GetMainDish helper methodit AI:lta ja se suositteli sitä koska se pitää main methodin puhtaana ja parantaa koodin luettavuutta.
        // Ovi tehtävässä AI suositteli käyttämään switch case formattia koska se pitää koodin helpommin luettavana jos vertaa isoon määrään if else linejä. 

        static string GetMainDish()
        {
            while (true)
            {
                Console.WriteLine("Pääraaka-aine (nautaa, kanaa, kasviksia):");
                string input = Console.ReadLine().Trim().ToLower();

                    switch (input)
                {
                    case "nautaa":
                        return "nautaa";
                    case "kanaa":
                        return "kanaa";
                    case "kasviksia":
                        return "kasviksia";
                    default:
                        Console.WriteLine("Virheellinen syöte. Yritä uudelleen.");
                        break;
                }

            }
        }
        static string GetSideDish()
        {
            while (true)
            {
                Console.WriteLine("Lisuke (perunaa, riisiä, pastaa");
                string input = Console.ReadLine().Trim().ToLower();

                switch (input)
                {
                    case "perunaa":
                        return "perunaa";
                    case "riisiä":
                        return "riisiä";
                    case "pastaa":
                        return "pastaa";
                    default:
                        Console.WriteLine("Virheellinen syöte. Yritä uudelleen.");
                        break;
                }
            }
        }
        static string GetSauce()
        {
            while (true)
            {
                Console.WriteLine("Kastike (curry, chili, pippuri, hapanimelä");
                string input = Console.ReadLine().Trim().ToLower();

                switch (input)
                {
                    case "curry":
                        return "curry";
                    case "chili":
                        return "chili";
                    case "pippuri":
                        return "pippuri";
                    case "hapanimelä":
                        return "hapanimelä";
                    default:
                        Console.WriteLine("Virheellinen syöte. Yritä uudelleen.");
                        break;
                }
            }
        }
    }
}
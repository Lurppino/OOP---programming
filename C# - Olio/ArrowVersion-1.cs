namespace Arrow
{
    internal class Program
    {
        enum Tip
        {
            Wood = 1,
            Steel = 2,
            Diamond = 3
        }
        enum Fletching
        {
            Leaf = 1,
            ChickenFeather = 2,
            EagleFeather = 3
        }

        class Nuoli
        {
            public Tip Arrowhead { get; private set; }
            public Fletching FletchingType { get; private set; }
            public int ShaftLength { get; private set; }

            public Nuoli(Tip arrowhead, Fletching fletching, int shaftLenght)
            {
                Arrowhead = arrowhead;
                FletchingType = fletching;
                ShaftLength = shaftLenght;
            }

            public static Nuoli CreateEliteArrow()
            {
                return new Nuoli(Tip.Diamond, Fletching.EagleFeather, 100);
            }

            public static Nuoli CreateBeginnerArrow()
            {
                return new Nuoli(Tip.Wood, Fletching.Leaf, 70);
            }

            public static Nuoli CreateBasicArrow()
            {
                return new Nuoli(Tip.Steel, Fletching.ChickenFeather, 100);
            }
            public double PalautaHinta()
            {
                double Price = 0;

                switch (Arrowhead)
                {
                    case Tip.Wood:
                        Price += 3;
                        break;
                    case Tip.Steel:
                        Price += 5;
                        break;
                    case Tip.Diamond:
                        Price += 50;
                        break;
                }

                switch (FletchingType)
                {
                    case Fletching.Leaf:
                        Price += 0;
                        break;
                    case Fletching.ChickenFeather:
                        Price += 1;
                        break;
                    case Fletching.EagleFeather:
                        Price += 5;
                        break;
                }

                Price += ShaftLength * 0.05;

                return Price;
            }
        }
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to Albert's Arrow's! How may I help you today?");
            Console.WriteLine("Do you want to: (1) Buy a predefined arrow or (2) Order a custom arrow?");
            int choice = int.Parse(Console.ReadLine());

            Nuoli arrow = null;

            if (choice == 1)
            {
                Console.WriteLine("Choose a predefined arrow type:");
                Console.WriteLine("1. Elite Arrow (Diamond arrowhead, Eagle feather fletching, 100cm shaft length.");
                Console.WriteLine("2. Basic Arrow (Steel arrowhead, Chicken feather fletching, 80cm shaft length.");
                Console.WriteLine("3. Beginner Arrow (Wood arrowhead, Leaf fletching, 75cm shaft length");

                int arrowChoice = int.Parse(Console.ReadLine());

                if (arrowChoice == 1)
                {
                    arrow = Nuoli.CreateEliteArrow();
                }
                else if (arrowChoice == 2)
                {
                    arrow = Nuoli.CreateBasicArrow();
                }
                else if (arrowChoice == 3)
                {
                    arrow = Nuoli.CreateBeginnerArrow();
                }
                else
                {
                    Console.WriteLine("Invalid input");
                    return;
                }
            }

            else if (choice == 2)
            {
                Console.WriteLine("Choose an arrowhead type: (1) Wood, (2) Steel, (3) Diamond");
                int selectedTip = int.Parse(Console.ReadLine());
                if (selectedTip < 1 || selectedTip > 3)
                {
                    Console.WriteLine("Invalid arrowhead type. Please select 1, 2 or 3.");
                    return;
                }
                Tip arrowhead = (Tip)selectedTip;

                Console.WriteLine("Choose the fletching type: (1) Leaf, (2) Chicken feather, (3) Eagle feather");
                int selectedFletching = int.Parse(Console.ReadLine());
                if (selectedFletching < 1 || selectedFletching > 3)
                {
                    Console.WriteLine("Invalid fletching type. Please select 1, 2 or 3.");
                    return;
                }
                Fletching fletching = (Fletching)selectedFletching;

                Console.WriteLine("Choose the shaft length: 60-100cm");
                int selectedLength = int.Parse(Console.ReadLine());
                if (selectedLength < 60 || selectedLength > 100)
                {
                    Console.WriteLine("Invalid shaft length. Please select a value between 60-100cm");
                    return;
                }
                arrow = new Nuoli(arrowhead, fletching, selectedLength);
            }
            else
            {
                Console.WriteLine("Invalid choice");
                return;
            }

            Console.WriteLine($"Arrowhead: {arrow.Arrowhead}");
            Console.WriteLine($"Fletching: {arrow.FletchingType}");
            Console.WriteLine($"Shaft Length: {arrow.ShaftLength} cm");

            double price = arrow.PalautaHinta();
            Console.WriteLine($"The price of the arrow is: {price} gold.");
        }
    }
}

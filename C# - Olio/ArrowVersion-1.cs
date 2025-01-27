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
            public Tip Arrowhead { get; set; }
            public Fletching FletchingType { get; set; }
            public int ShaftLength { get; set; }

            public Nuoli(Tip arrowhead, Fletching fletching, int shaftLenght)
            {
                Arrowhead = arrowhead;
                FletchingType = fletching;
                ShaftLength = shaftLenght;
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

            Console.WriteLine("Choose an arrowhead type: (1) Wood, (2) Steel, (3) Diamond");
            int selectedTip = int.Parse(Console.ReadLine());
            Tip arrowhead = (Tip)selectedTip;

            Console.WriteLine("Choose the fletching type: (1) Leaf, (2) Chicken feather, (3) Eagle feather");
            int selectedFletching = int.Parse(Console.ReadLine());
            Fletching fletching = (Fletching)selectedFletching;

            Console.WriteLine("Choose the shaft lenght: 60-100cm");
            int selectedLength = int.Parse(Console.ReadLine());


            Nuoli arrow = new Nuoli(arrowhead, fletching, selectedLength);

            double price = arrow.PalautaHinta();
            Console.WriteLine($"The price of the arrow is: {price} gold.");
        }
    }
}

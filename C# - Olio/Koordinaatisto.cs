namespace Ruudukko_Kordinaatisto
{
    public struct Kordinaatti
    {
        public int X { get; private set; }
        public int Y { get; private set; }
        public Kordinaatti(int x, int y)
        {
            X = x;
            Y = y;
        }
        public bool IsAdjacentTo(Kordinaatti other)
        {
            // kysin tekoälyltä apua tässä joten sen takia tässä on Math.abs 
            return (Math.Abs(X - other.X) == 1 && Y == other.Y) || (Math.Abs(Y - other.Y) == 1 && X == other.X);
            // AI koodi loppuu
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            Kordinaatti coord1 = new Kordinaatti(0, 0);
            Kordinaatti coord2 = new Kordinaatti(-1, -1);
            Kordinaatti coord3 = new Kordinaatti(1, 0);
            Kordinaatti coord4 = new Kordinaatti(0, 1);
            Kordinaatti coord5 = new Kordinaatti(2, 2);
            Kordinaatti coord6 = new Kordinaatti(-1, 0);
            Kordinaatti coord7 = new Kordinaatti(0, -1);

            CheckAndPrintAdjacency(coord1, coord2);
            CheckAndPrintAdjacency(coord1, coord3);
            CheckAndPrintAdjacency(coord1, coord4);
            CheckAndPrintAdjacency(coord1, coord5);
            CheckAndPrintAdjacency(coord1, coord6);
            CheckAndPrintAdjacency(coord1, coord7);


            CheckAndPrintAdjacency(coord2, coord3);

            CheckAndPrintAdjacency(coord5, coord7);
        }


        public static void CheckAndPrintAdjacency(Kordinaatti coord1, Kordinaatti coord2)
        {
            if (coord1.IsAdjacentTo(coord2))
            {
                Console.WriteLine($"Annettu koordinaatti {coord2.X}, {coord2.Y} on koordinaatin {coord1.X}, {coord1.Y} vieressä.");
            }
            else
            {
                Console.WriteLine($"Annettu koordinaatti {coord2.X}, {coord2.Y} ei ole koordinaatin {coord1.X}, {coord1.Y} vieressä.");
            }
        }
    }
}

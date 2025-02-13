using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventureBackpack
{
    public class Reppu
    {
        public int MaxItemAmount { get;}
        public double MaxWeight { get;}
        public double MaxSpace { get;}

        public int CurrentAmount => Tavarat.Count();
        public double CurrentWeight => CountWeight();
        public double CurrentSpace => CountSpace();

        private List<Tavara> Tavarat;
        public Reppu(int maxItemAmount, double maxWeight, double maxSpace)
        {
            MaxItemAmount = maxItemAmount;
            MaxWeight = maxWeight;
            MaxSpace = maxSpace;
            Tavarat = new List<Tavara>();
        }

        private double CountWeight()
        {
            double Weight = 0;
            foreach (var tavara in Tavarat)
            {
                Weight += tavara.Paino;
            }
            return Weight;
        }
        private double CountSpace()
        {
            double Space = 0;
            foreach(var tavara in Tavarat)
            {
                Space += tavara.Tilavuus;
            }
            return Space;
        }

        public bool Lisää(Tavara tavara)
        {
            if (CurrentAmount + 1 > MaxItemAmount) return false;
            if (CurrentWeight + tavara.Paino > MaxWeight) return false;
            if (CurrentSpace + tavara.Tilavuus > MaxSpace) return false;

            Tavarat.Add(tavara);
            return true;
        }
        public override string ToString()
        {
            if (Tavarat.Count == 0)
            {
                return "Reppu on tyhjä.";
            }

            return "Repussa on seuraavat tavarat: " + string.Join(", ", Tavarat);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventureBackpack
{
    public class Nuoli : Tavara
    {
        public Nuoli() : base(0.1, 0.05)
        {

        }
        public override string ToString()
        {
            return this.GetType().Name;
        }

    }
}

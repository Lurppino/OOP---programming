using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventureBackpack
{
    public class Köysi : Tavara
    {
        public Köysi() : base(1, 1.5)
        {

        }
        public override string ToString()
        {
            return this.GetType().Name;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventureBackpack
{
    public class Vesi : Tavara
    {
        public Vesi() : base(2, 2)
        {

        }
        public override string ToString()
        {
            return this.GetType().Name;
        }

    }
}

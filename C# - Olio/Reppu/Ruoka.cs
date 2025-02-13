using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventureBackpack
{
    public class Ruoka : Tavara
    {
        public Ruoka() : base(1, 0.5)
        {

        }
        public override string ToString()
        {
            return this.GetType().Name;
        }

    }
}

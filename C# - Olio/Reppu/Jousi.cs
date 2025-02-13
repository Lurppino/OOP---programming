using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventureBackpack
{
    public class Jousi : Tavara
    {
        public Jousi() : base(1,4)
        { 

        }
        public override string ToString()
        {
            return this.GetType().Name;
        }

    }
}

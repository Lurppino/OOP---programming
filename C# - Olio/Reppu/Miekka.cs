using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventureBackpack
{
    public class Miekka : Tavara
    {
        public Miekka() : base(5, 3)
        {

        }
        public override string ToString()
        {
            return this.GetType().Name;
        }
    }
}

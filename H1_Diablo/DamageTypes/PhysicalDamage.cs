using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace H1_Diablo
{
    class PhysicalDamage : Damage
    {
        public PhysicalDamage(int minDamage, int maxDamage) : base(minDamage, maxDamage)
        {
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace H1_Diablo
{
    public abstract class Damage
    {
        private int minDamage;

        public int MinDamage
        {
            get { return minDamage; }
            set { minDamage = value; }
        }
        private int maxDamage;

        public int MaxDamage
        {
            get { return maxDamage; }
            set { maxDamage = value; }
        }

        protected Damage(int minDamage, int maxDamage)
        {
            MinDamage = minDamage;
            MaxDamage = maxDamage;
        }
    }
}

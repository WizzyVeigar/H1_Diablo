using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace H1_Diablo
{
    class Scythe_2H : Weapon
    {
        public Scythe_2H(WeaponType weaponType) : base(weaponType)
        {
        }

        public Scythe_2H(WeaponType weaponType, int reqLevel) : base(weaponType, reqLevel)
        {
        }
    }
}

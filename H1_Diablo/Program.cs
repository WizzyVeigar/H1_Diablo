using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace H1_Diablo
{
    class Program
    {
        static void Main(string[] args)
        {
            Weapon weapon = new Weapon(WeaponType.SCYTHE2H);
            Console.WriteLine(weapon.WeaponType);
            Console.ReadLine();
        }
    }
}

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
            Weapon weapon;
            while (true)
            {
                    weapon = WeaponFactory.Instance.CreateWeapon();
                    Console.WriteLine(weapon.ToString());
                    Console.ForegroundColor = ConsoleColor.Gray;
                    Console.WriteLine(weapon.CalculateDPS());
                    Console.ReadLine();
            }
        }
    }
}

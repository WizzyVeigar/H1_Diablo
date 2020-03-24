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
            Weapon weapon = WeaponFactory.Instance.CreateWeapon();
            weapon.MagicProperties = new MagicProperty[4];
            weapon.MagicProperties[0] = new MagicProperty(weapon);
            weapon.MagicProperties[1] = new MagicProperty(weapon);
            //Weapon weapo = WeaponFactory.Instance.CreateWeapon(5, WeaponType.SWORD2H);
            Console.WriteLine(weapon.WeaponType +"\n"+ weapon.Rarity.ToString() +"\n"+ weapon.ReqLevel);
            //Console.WriteLine(weapo.WeaponType +"\n"+ weapo.Rarity.ToString() +"\n"+ weapo.ReqLevel);
            Console.ReadLine();
        }
    }
}

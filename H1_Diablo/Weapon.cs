using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace H1_Diablo
{
    public class Weapon
    {
        private WeaponType weaponType;
        public WeaponType WeaponType
        {
            get { return weaponType; }
            set { weaponType = value; }
        }

        public Weapon(WeaponType weaponType)
        {
            WeaponType = weaponType;
        }

        public Weapon(WeaponType weaponType, int reqLevel) : this(weaponType)
        {
            ReqLevel = reqLevel;
        }
        private List<Damage> damages = new List<Damage>();

        public List<Damage> Damages
        {
            get { return damages; }
            set { damages = value; }
        }

        private string name;

        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        private Rarity rarity;

        public Rarity Rarity
        {
            get { return rarity; }
            set { rarity = value; }
        }

        private int reqLevel;

        public int ReqLevel
        {
            get { return reqLevel; }
            set { reqLevel = value; }
        }
        private int weaponRange;

        public int WeaponRange
        {
            get { return weaponRange; }
            set { weaponRange = value; }
        }


        private float atkSpeed;

        public float AtkSpeed
        {
            get { return atkSpeed; }
            set { atkSpeed = value; }
        }

        private MagicProperty[] magicProperties;

        public MagicProperty[] MagicProperties
        {
            get { return magicProperties; }
            set { magicProperties = value; }
        }


        public string CalculateDPS()
        {
            int totalDmg = 0;
            string str = string.Empty;
            foreach (Damage dmgtype in Damages)
            {
                totalDmg += dmgtype.MinDamage + dmgtype.MaxDamage;
                str.Insert(0, dmgtype.GetType().Name + ":     " + dmgtype.MinDamage +"--"+ dmgtype.MaxDamage);
            }

            if (AtkSpeed == 1)
            {
                return str + (totalDmg / Damages.Count) + " Damage per second";
            }
            return str + totalDmg / AtkSpeed + " Damage per second";
        }
    }
}

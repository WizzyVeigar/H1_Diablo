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
            float totalDmg = 0;
            string str = string.Empty;

            if (Damages.Count != 0)
            {
                foreach (Damage dmgtype in Damages)
                {
                    totalDmg += dmgtype.MinDamage + dmgtype.MaxDamage;
                    str = str.Insert(0, dmgtype.GetType().Name + ":     " + dmgtype.MinDamage + "-" + dmgtype.MaxDamage + "\n");
                }
            }
            if (AtkSpeed == 1)
            {
                return str + (totalDmg / Damages.Count) + " Damage per second";
            }
            return str + (float)Math.Round(totalDmg / AtkSpeed * 100f) / 100f + " Damage per second";
        }

        public override string ToString()
        {
            StringBuilder builder = new StringBuilder();
            switch (Rarity)
            {
                case Rarity.COMMON:
                    Console.ForegroundColor = ConsoleColor.Gray;
                    builder.Append("Common" + " " + Name);
                    break;
                case Rarity.MAGIC:
                    Console.ForegroundColor = ConsoleColor.Blue;
                    builder.Append("Magic" + " " + Name);
                    break;
                case Rarity.RARE:
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    builder.Append("Rare" + " " + Name);
                    break;
                case Rarity.LEGENDARY:
                    Console.ForegroundColor = ConsoleColor.DarkRed;
                    builder.Append("LEGENDARY" + " " + Name);
                    break;
                default:
                    break;
            }
            builder.Append(" Level: " + ReqLevel);
            return builder.ToString();
        }
    }
}

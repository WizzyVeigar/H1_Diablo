using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace H1_Diablo
{
    public enum WeaponType
    {
        AXE,
        DAGGER,
        MACE,
        SWORD1H,
        SWORD2H,
        CEREMONIALKNIFE,
        WAND,
        HANDCROSSBOW,
        CROSSBOW,
        BOW,
        POLEARM,
        SCYTHE1H,
        SCYTHE2H,
        STAFF,
        MAGESTAFF
    }
    public enum Rarity
    {
        COMMON,
        MAGIC,
        RARE,
        LEGENDARY
    }

    class WeaponFactory
    {
        private WeaponFactory()
        {
        }
        private static WeaponFactory instance = null;
        public static WeaponFactory Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new WeaponFactory();
                }
                return instance;
            }
        }

        /// <summary>
        /// Creates a totally random weapon
        /// </summary>
        /// <returns></returns>
        public Weapon CreateWeapon()
        {
            Weapon baseWeapon = GetRndWeapon();
            return baseWeapon;
        }
        /// <summary>
        /// Creates a random weapon with a <paramref name="reqLevel"/>
        /// </summary>
        /// <param name="reqLevel"></param>
        /// <returns></returns>
        public Weapon CreateWeapon(int reqLevel)
        {
            Weapon baseWeapon = GetRndWeapon();
            baseWeapon.ReqLevel = reqLevel;
            return baseWeapon;
        }
        /// <summary>
        /// creates a Weapon of the type <paramref name="weaponType"/> with a random level
        /// </summary>
        /// <param name="weaponType"></param>
        /// <returns></returns>
        public Weapon CreateWeapon(WeaponType weaponType)
        {
            Weapon weapon;
            switch (weaponType)
            {
                case WeaponType.BOW:
                    weapon = new Bow(WeaponType.BOW);
                    break;
                case WeaponType.CROSSBOW:
                    weapon = new Crossbow(WeaponType.CROSSBOW);
                    break;
                case WeaponType.MAGESTAFF:
                    weapon = new Magestaff(WeaponType.MAGESTAFF);
                    break;
                case WeaponType.HANDCROSSBOW:
                    weapon = new HandCrossbow(WeaponType.HANDCROSSBOW);
                    break;
                case WeaponType.WAND:
                    weapon = new Wand(WeaponType.WAND);
                    break;
                case WeaponType.CEREMONIALKNIFE:
                    weapon = new CeremonialKnife(WeaponType.CEREMONIALKNIFE);
                    break;
                case WeaponType.DAGGER:
                    weapon = new Dagger(WeaponType.DAGGER);
                    break;
                case WeaponType.MACE:
                    weapon = new Mace(WeaponType.MACE);
                    break;
                case WeaponType.SCYTHE1H:
                    weapon = new Scythe_1H(WeaponType.SCYTHE1H);
                    break;
                case WeaponType.SWORD1H:
                    weapon = new Sword1H(WeaponType.SWORD1H);
                    break;
                case WeaponType.AXE:
                    weapon = new Axe(WeaponType.AXE);
                    break;
                case WeaponType.SCYTHE2H:
                    weapon = new Scythe_2H(WeaponType.SCYTHE2H);
                    break;
                case WeaponType.POLEARM:
                    weapon = new Polearm(WeaponType.POLEARM);
                    break;
                case WeaponType.SWORD2H:
                    weapon = new Sword2H(WeaponType.SWORD2H);
                    break;
                case WeaponType.STAFF:
                    weapon = new Staff(WeaponType.STAFF);
                    break;
                default:
                    return null;
            }
            weapon.ReqLevel = new Random().Next(1, 60);
            return CreateWeaponStats(weapon);
        }
        /// <summary>
        /// Create a specific weapon of type <paramref name="weaponType"/> and a specific <paramref name="reqLevel"/>
        /// </summary>
        /// <param name="reqLevel"></param>
        /// <param name="weaponType"></param>
        /// <returns></returns>
        public Weapon CreateWeapon(int reqLevel, WeaponType weaponType)
        {
            Weapon baseWeapon = CreateWeapon(weaponType);
            baseWeapon.ReqLevel = reqLevel;
            return baseWeapon;
        }

        private Weapon CreateWeaponStats(Weapon weapon)
        {
            weapon.Rarity = GetRarity();
            //Used for calculations on weapons. Increases on rarity and weapon type
            int statWeight = 1;
            //Gives a bonus to statWeight depending on rarity
            switch (weapon.Rarity)
            {
                case Rarity.COMMON:
                    statWeight += 1;
                    break;
                case Rarity.MAGIC:
                    statWeight += 2;

                    break;
                case Rarity.RARE:
                    statWeight += 3;
                    break;
                case Rarity.LEGENDARY:
                    statWeight += 5;
                    break;
                default:
                    break;
            }
            switch (weapon.WeaponType)
            {
                case WeaponType.BOW:
                    statWeight += 2;
                    weapon.Damages.Add(new RangedDamage(statWeight * weapon.ReqLevel / 2, statWeight * weapon.ReqLevel));
                    weapon.AtkSpeed = 1.4f;
                    weapon.WeaponRange = 300;
                    weapon.Name = "Bow";
                    break;
                case WeaponType.CROSSBOW:
                    statWeight += 2;
                    weapon.Damages.Add(new RangedDamage(statWeight * weapon.ReqLevel, (statWeight + 3) * weapon.ReqLevel));
                    weapon.AtkSpeed = 1.7f;
                    weapon.WeaponRange = 300;
                    weapon.Name = "Crossbow";
                    break;
                case WeaponType.MAGESTAFF:
                    statWeight += 1;
                    weapon.Damages.Add(new FireDamage(statWeight * weapon.ReqLevel, (statWeight + 1) * weapon.ReqLevel));
                    weapon.AtkSpeed = 1.3f;
                    weapon.WeaponRange = 200;
                    weapon.Name = "Mage Staff";
                    break;
                case WeaponType.HANDCROSSBOW:
                    weapon.Damages.Add(new RangedDamage(statWeight * weapon.ReqLevel, (statWeight + 1) * weapon.ReqLevel));
                    weapon.AtkSpeed = 0.9f;
                    weapon.WeaponRange = 250;
                    weapon.Name = "HandCrossBow";
                    break;
                case WeaponType.WAND:
                    statWeight += 2;
                    weapon.Damages.Add(new IceDamage(statWeight * weapon.ReqLevel, (statWeight + 1) * weapon.ReqLevel));
                    weapon.AtkSpeed = 1.2f;
                    weapon.WeaponRange = 150;
                    weapon.Name = "Wand of Wizardry";
                    break;
                case WeaponType.CEREMONIALKNIFE:
                    statWeight += 1;
                    weapon.Damages.Add(new PhysicalDamage(statWeight * weapon.ReqLevel, (statWeight + 1) * weapon.ReqLevel));
                    weapon.AtkSpeed = 1.4f;
                    weapon.WeaponRange = 30;
                    weapon.Name = "Ceremonial Knife";
                    break;
                case WeaponType.DAGGER:
                    statWeight += 1;
                    weapon.Damages.Add(new PhysicalDamage(statWeight * weapon.ReqLevel, (statWeight + 1) * weapon.ReqLevel));
                    weapon.AtkSpeed = 1.4f;
                    weapon.WeaponRange = 30;
                    weapon.Name = "Dagger";
                    break;
                case WeaponType.MACE:
                    statWeight += 2;
                    weapon.Damages.Add(new PhysicalDamage(statWeight * weapon.ReqLevel, (statWeight + 2) * weapon.ReqLevel));
                    weapon.AtkSpeed = 1.2f;
                    weapon.WeaponRange = 50;
                    weapon.Name = "Mace";
                    break;
                case WeaponType.SCYTHE1H:
                    statWeight += 5;
                    weapon.Damages.Add(new PhysicalDamage((statWeight + statWeight / 2) * weapon.ReqLevel, (statWeight + statWeight / 2 + 3) * weapon.ReqLevel));
                    weapon.AtkSpeed = 1.1f;
                    weapon.WeaponRange = 85;
                    weapon.Name = "One Handed Scythe";
                    break;
                case WeaponType.SCYTHE2H:
                    statWeight += 10;
                    weapon.Damages.Add(new PhysicalDamage((statWeight + statWeight / 2) * weapon.ReqLevel, (statWeight + statWeight / 2 + 3) * weapon.ReqLevel));
                    weapon.AtkSpeed = 1.2f;
                    weapon.WeaponRange = 100;
                    weapon.Name = "Two Handed Scythe";
                    break;
                case WeaponType.AXE:
                    statWeight += 7;
                    weapon.Damages.Add(new PhysicalDamage((statWeight + statWeight / 2) * weapon.ReqLevel, (statWeight + statWeight / 2 + 3) * weapon.ReqLevel));
                    weapon.AtkSpeed = 1f;
                    weapon.WeaponRange = 60;
                    weapon.Name = "Two Handed Axe";
                    break;
                case WeaponType.POLEARM:
                    statWeight += 2;
                    weapon.Damages.Add(new PhysicalDamage((statWeight * weapon.ReqLevel), (statWeight + 1) * weapon.ReqLevel));
                    weapon.AtkSpeed = 1.2f;
                    weapon.WeaponRange = 110;
                    weapon.Name = "Polearm";
                    break;
                case WeaponType.SWORD1H:
                    statWeight += 1;
                    weapon.Damages.Add(new PhysicalDamage((statWeight * weapon.ReqLevel), (statWeight + 2) * weapon.ReqLevel));
                    weapon.AtkSpeed = 1.4f;
                    weapon.WeaponRange = 50;
                    weapon.Name = "One Handed Sword";
                    break;
                case WeaponType.SWORD2H:
                    statWeight += 5;
                    weapon.Damages.Add(new PhysicalDamage((statWeight + statWeight / 2) * weapon.ReqLevel, (statWeight + statWeight / 2 + 3) * weapon.ReqLevel));
                    weapon.AtkSpeed = 1.1f;
                    weapon.WeaponRange = 75;
                    weapon.Name = "Two Handed Sword";
                    break;
                case WeaponType.STAFF:
                    statWeight += 2;
                    weapon.Damages.Add(new PhysicalDamage(statWeight * weapon.ReqLevel, (statWeight + 2) * weapon.ReqLevel));
                    weapon.AtkSpeed = 1.2f;
                    weapon.WeaponRange = 110;
                    weapon.Name = "Staff";
                    break;
                default:
                    break;
            }

            weapon.MagicProperties = GetMagicProperties(weapon);
            return weapon;
        }
        /// <summary>
        /// Sets the size of <see cref="Weapon.MagicProperties"/> depending on <see cref="Weapon.Rarity"/>
        /// </summary>
        /// <param name="weapon"></param>
        /// <returns></returns>
        private MagicProperty[] GetMagicProperties(Weapon weapon)
        {
            switch (weapon.Rarity)
            {
                case Rarity.COMMON:
                    break;
                case Rarity.MAGIC:
                    weapon.MagicProperties = new MagicProperty[new Random().Next(2, 4)];
                    break;
                case Rarity.RARE:
                    weapon.MagicProperties = new MagicProperty[new Random().Next(3, 5)];
                    break;
                case Rarity.LEGENDARY:
                    weapon.MagicProperties = new MagicProperty[6];
                    break;
                default:
                    break;
            }
            if (weapon.MagicProperties != null)
            {
                weapon.MagicProperties = RollEnchantments(weapon);
                return weapon.MagicProperties;
            }
            return null;
        }
        /// <summary>
        /// Creates <see cref="MagicProperty"/> for each open slot
        /// </summary>
        /// <param name="weapon"></param>
        /// <returns></returns>
        private MagicProperty[] RollEnchantments(Weapon weapon)
        {
            for (int i = 0; i < weapon.MagicProperties.Length; i++)
            {
                weapon.MagicProperties[i] = new MagicProperty(weapon);
            }
            return weapon.MagicProperties;
        }

        /// <summary>
        /// Creates a random weapon
        /// </summary>
        /// <returns></returns>
        private Weapon GetRndWeapon()
        {
            return CreateWeapon((WeaponType)new Random(Guid.NewGuid().GetHashCode()).Next(0, Enum.GetNames(typeof(WeaponType)).Length));
        }

        private Rarity GetRarity()
        {
            return ((Rarity)new Random(Guid.NewGuid().GetHashCode()).Next(0, Enum.GetNames(typeof(Rarity)).Length));
        }
    }
}

﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace H1_Diablo
{
    public enum WeaponType
    {
        BOW,
        CROSSBOW,
        MAGESTAFF,
        HANDCROSSBOW,
        WAND,
        CEREMONIALKNIFE,
        DAGGER,
        MACE,
        SCYTHE1H,
        SWORD1H,
        AXE,
        SCYTHE2H,
        POLEARM,
        SWORD2H,
        STAFF
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
            baseWeapon.ReqLevel = new Random().Next(0, 30);
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
            return weapon;
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
                    weapon.AtkSpeed = new Random().Next(statWeight, statWeight + 10);
                    weapon.MinDamage = (int)CalculateStat(statWeight, weapon.ReqLevel);
                    weapon.MaxDamage = (int)CalculateStat(statWeight + weapon.ReqLevel / 2, weapon.ReqLevel);
                    break;
                case WeaponType.CROSSBOW:
                    break;
                case WeaponType.MAGESTAFF:
                    break;
                case WeaponType.HANDCROSSBOW:
                    break;
                case WeaponType.WAND:
                    break;
                case WeaponType.CEREMONIALKNIFE:
                    break;
                case WeaponType.DAGGER:
                    break;
                case WeaponType.MACE:
                    break;
                case WeaponType.SCYTHE1H:
                    break;
                case WeaponType.SWORD1H:
                    statWeight += 1;
                    weapon.MinDamage = (statWeight * weapon.ReqLevel);
                    weapon.MaxDamage = (statWeight + 2) * weapon.ReqLevel;
                    weapon.AtkSpeed = 1.4f;
                    weapon.WeaponRange = 50;
                    break;
                case WeaponType.AXE:
                    statWeight += 7;
                    weapon.MinDamage = (statWeight + statWeight / 2) * weapon.ReqLevel;
                    weapon.MaxDamage = (statWeight + statWeight / 2 + 3) * weapon.ReqLevel;
                    weapon.AtkSpeed = 1f;
                    weapon.WeaponRange = 60;
                    break;
                case WeaponType.SCYTHE2H:
                    break;
                case WeaponType.POLEARM:
                    break;
                case WeaponType.SWORD2H:
                    statWeight += 5;
                    weapon.MinDamage = (statWeight + statWeight / 2) * weapon.ReqLevel;
                    weapon.MaxDamage = (statWeight + statWeight / 2 + 3) * weapon.ReqLevel;
                    weapon.AtkSpeed = 1.1f;
                    weapon.WeaponRange = 75;
                    break;
                case WeaponType.STAFF:
                    break;
                default:
                    break;
            }

            return weapon;
        }

        /// <summary>
        /// Creates a random weapon
        /// </summary>
        /// <returns></returns>
        public Weapon GetRndWeapon()
        {
            return CreateWeapon((WeaponType)new Random(Guid.NewGuid().GetHashCode()).Next(0, Enum.GetNames(typeof(WeaponType)).Length));
        }

        public float CalculateStat(int statWeight, int reqLevel)
        {

        }
    }
}

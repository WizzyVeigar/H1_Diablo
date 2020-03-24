using System;
using System.Collections.Generic;

namespace H1_Diablo
{
    public class MagicProperty
    {
        private bool enchantExists;

        public bool EnchantExists
        {
            get { return enchantExists; }
            set { enchantExists = value; }
        }

        private string enchantName;

        public string EnchantName
        {
            get { return enchantName; }
            set { enchantName = value; }
        }

        public MagicProperty(Weapon weaponToEnchant)
        {
            AddRndEnchant(weaponToEnchant);
        }
        /// <summary>
        /// Adds a random enchantment
        /// </summary>
        /// <param name="wep"></param>
        /// <returns></returns>
        private Weapon AddRndEnchant(Weapon wep)
        {
            byte chance = (byte)new Random(Guid.NewGuid().GetHashCode()).Next(0, 100);

            if (chance < 10)
            {
                wep = AddDamage(wep);
            }
            else if (chance < 20)
            {
                AddAtkSpeed(wep);
            }
            else if (chance < 30)
            {
                wep = AddLightningDmg(wep);
            }
            else if (chance < 50)
            {
                wep = AddFireDmg(wep);
            }
            else
            {
                wep = AddIceDmg(wep);
            }
            return wep;
        }
        /// <summary>
        /// Adds a firedamage enchant to <paramref name="wep"/>
        /// </summary>
        /// <param name="wep"></param>
        /// <returns></returns>
        private Weapon AddFireDmg(Weapon wep)
        {
            for (int i = 0; i < wep.Damages.Count; i++)
            {
                if (wep.Damages[i].GetType().Name == "FireDamage")
                {
                    wep.Damages[i].MinDamage += 30;
                    wep.Damages[i].MaxDamage += 60;
                    EnchantExists = true;
                    break;
                }
            }
            if (!EnchantExists)
            {
                wep.Damages.Add(new FireDamage(30, 60));
            }

            EnchantName = "FireDamage";
            return wep;
        }
        /// <summary>
        /// Adds a icedamage enchant to <paramref name="wep"/>
        /// </summary>
        /// <param name="wep"></param>
        /// <returns></returns>
        private Weapon AddIceDmg(Weapon wep)
        {
            for (int i = 0; i < wep.Damages.Count; i++)
            {
                if (wep.Damages[i] is IceDamage)
                {
                    wep.Damages[i].MinDamage += 20;
                    wep.Damages[i].MaxDamage += 40;
                    EnchantExists = true;
                    break;
                }
            }
            if (!EnchantExists)
            {
                wep.Damages.Add(new IceDamage(20, 40));
            }
            EnchantName = "IceDamage";
            return wep;
        }
        /// <summary>
        /// Adds a lightningdamage enchant to <paramref name="wep"/>
        /// </summary>
        /// <param name="wep"></param>
        /// <returns></returns>
        private Weapon AddLightningDmg(Weapon wep)
        {
            for (int i = 0; i < wep.Damages.Count; i++)
            {
                if (wep.Damages[i].GetType().Name == "LightningDamage")
                {
                    wep.Damages[i].MinDamage += 10;
                    wep.Damages[i].MaxDamage += 100;
                    EnchantExists = true;
                    break;
                }
            }
            if (!EnchantExists)
            {
                wep.Damages.Add(new LightningDamage(10, 100));
            }
            EnchantName = "LightningDamage";
            return wep;
        }
        /// <summary>
        /// Adds a physicaldamage enchant to <paramref name="wep"/>
        /// </summary>
        /// <param name="wep"></param>
        /// <returns></returns>
        private Weapon AddPhysicalDmg(Weapon wep)
        {
            for (int i = 0; i < wep.Damages.Count; i++)
            {
                if (wep.Damages[i].GetType().Name == "PhysicalDamage")
                {
                    wep.Damages[i].MinDamage += 25;
                    wep.Damages[i].MaxDamage += 50;
                    EnchantExists = true;
                    break;
                }
            }
            if (!EnchantExists)
            {
                wep.Damages.Add(new PhysicalDamage(25, 50));
            }
            EnchantName = "PhysicalDamage";
            return wep;
        }
        /// <summary>
        /// Gives the <paramref name="wep"/> more attack speed (Less time between attacks)
        /// </summary>
        /// <param name="wep"></param>
        /// <returns></returns>
        private Weapon AddAtkSpeed(Weapon wep)
        {
            wep.AtkSpeed -= 0.2f;
            EnchantName = "AttackSpeed";
            return wep;
        }
        /// <summary>
        /// Adds rangeddamage enchant to the <paramref name="wep"/>
        /// </summary>
        /// <param name="wep"></param>
        /// <returns></returns>
        private Weapon AddRangedDmg(Weapon wep)
        {
            for (int i = 0; i < wep.Damages.Count; i++)
            {
                if (wep.Damages[i].GetType().Name == "RangedDamage")
                {
                    wep.Damages[i].MinDamage += 10;
                    wep.Damages[i].MaxDamage += 60;
                    EnchantExists = true;
                    break;
                }
            }
            if (!EnchantExists)
            {
                wep.Damages.Add(new RangedDamage(10, 60));

            }
            EnchantName = "RangedAtk";
            return wep;
        }
        /// <summary>
        /// Checks for <see cref="WeaponType"/> and adds the appropriate damage enchant
        /// </summary>
        /// <param name="wep"></param>
        /// <returns></returns>
        private Weapon AddDamage(Weapon wep)
        {
            if (wep.WeaponType == WeaponType.BOW || wep.WeaponType == WeaponType.CROSSBOW || wep.WeaponType == WeaponType.HANDCROSSBOW || wep.WeaponType == WeaponType.WAND || wep.WeaponType == WeaponType.MAGESTAFF)
                return AddRangedDmg(wep);
            else
                return AddPhysicalDmg(wep);
        }
    }
}
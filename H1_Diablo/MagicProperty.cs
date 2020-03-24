using System;
using System.Collections.Generic;

namespace H1_Diablo
{
    public class MagicProperty
    {
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

        public Weapon AddRndEnchant(Weapon wep)
        {
            byte chance = (byte)new Random().Next(0, 100);

            if (chance < 55)
            {
                wep = AddIceDmg(wep);
                if (chance < 50)
                {
                    wep = AddFireDmg(wep);
                    if (chance < 30)
                    {
                        wep = AddLightningDmg(wep);
                        if (chance < 20)
                        {
                            AddAtkSpeed(wep);
                            if (chance < 10)
                            {
                                wep = AddDamage(wep);
                            }
                        }
                    }
                }
            }
            return wep;
        }

        public Weapon AddFireDmg(Weapon wep)
        {
            for (int i = 0; i < wep.Damages.Count; i++)
            {
                if (wep.Damages[i].GetType().Name == "FireDamage")
                {
                    wep.Damages[i].MinDamage += 30;
                    wep.Damages[i].MaxDamage += 60;
                    break;
                }
            }
            wep.Damages.Add(new FireDamage(10, 60));
            EnchantName = "FireDamage";
            return wep;
        }

        private Weapon AddIceDmg(Weapon wep)
        {
            for (int i = 0; i < wep.Damages.Count; i++)
            {
                if (wep.Damages[i].GetType().Name == "IceDamage")
                {
                    wep.Damages[i].MinDamage += 20;
                    wep.Damages[i].MaxDamage += 40;
                }
            }
            wep.Damages.Add(new IceDamage(20, 40));
            EnchantName = "IceDamage";
            return wep;
        }

        private Weapon AddLightningDmg(Weapon wep)
        {
            for (int i = 0; i < wep.Damages.Count; i++)
            {
                if (wep.Damages[i].GetType().Name == "LightningDamage")
                {
                    wep.Damages[i].MinDamage += 10;
                    wep.Damages[i].MaxDamage += 100;
                }
            }
            wep.Damages.Add(new LightningDamage(10, 100));
            EnchantName = "LightningDamage";
            return wep;
        }

        private Weapon AddPhysicalDmg(Weapon wep)
        {
            for (int i = 0; i < wep.Damages.Count; i++)
            {
                if (wep.Damages[i].GetType().Name == "PhysicalDamage")
                {
                    wep.Damages[i].MinDamage += 25;
                    wep.Damages[i].MaxDamage += 50;
                }
            }
            wep.Damages.Add(new PhysicalDamage(25, 50));
            EnchantName = "PhysicalDamage";
            return wep;
        }

        private Weapon AddAtkSpeed(Weapon wep)
        {
            wep.AtkSpeed -= 0.2f;
            EnchantName = "AttackSpeed";
            return wep;
        }


        private Weapon AddRangedDmg(Weapon wep)
        {
            for (int i = 0; i < wep.Damages.Count; i++)
            {
                if (wep.Damages[i].GetType().Name == "RangedDamage")
                {
                    wep.Damages[i].MinDamage += 10;
                    wep.Damages[i].MaxDamage += 60;
                }
            }
            wep.Damages.Add(new RangedDamage(10, 60));
            EnchantName = "RangedAtk";
            return wep;
        }

        private Weapon AddDamage(Weapon wep)
        {
            if (wep.WeaponType == WeaponType.BOW || wep.WeaponType == WeaponType.CROSSBOW || wep.WeaponType == WeaponType.HANDCROSSBOW || wep.WeaponType == WeaponType.WAND || wep.WeaponType == WeaponType.MAGESTAFF)
                return AddRangedDmg(wep);
            else
                return AddPhysicalDmg(wep);
        }
    }
}
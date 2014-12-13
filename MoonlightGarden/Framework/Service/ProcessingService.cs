using MoonlightGarden.Framework.Domain.Master;
using MoonlightGarden.Framework.Domain.Mg;
using MoonlightGarden.Framework.Enumeration;
using MoonlightGarden.Framework.Utils;

namespace MoonlightGarden.Framework.Service
{
    public class ProcessingService
    {
        public CombatRate CalculateCombatRate(string rank, CardBase orgCard, Equip weapon, Equip armor)
        {
            EquipBase orgWeapon = weapon.OriginalEquip;
            EquipBase orgArmor = armor.OriginalEquip;
            int orgRating = MgConfiguration.Rating(rank);
            return new CombatRate()
            {
                MaxHP = MgConfiguration.PotionUnit(rank) * orgCard.CON,
                Atk = MgConfiguration.BasicAttack(orgCard) + (orgCard.AGI / 2) + orgWeapon.Extend[EquipExtend.Atk.ToString()],
                AR = orgRating + orgWeapon.Extend[EquipExtend.AR.ToString()],
                Def = orgArmor.Extend[EquipExtend.Def.ToString()],
                DR = orgRating + orgArmor.Extend[EquipExtend.DR.ToString()],
                Class = orgCard.Class,
                Target = 1,
                Hits = 1
            };
        }
        public int Attack(int atk, int ar, int def, int dr)
        {
            return (int)(((atk * ar) - (def * dr)) * MgConfiguration.DamageBoost(ar, dr));
        }
        public int Attack(CombatRate attacker, CombatRate target)
        {
            return Attack(attacker.Atk, attacker.AR, target.Def, target.DR);
        }
    }
}
using MoonlightGarden.Framework.Domain.Master;
using MoonlightGarden.Platform.Domain;

namespace MoonlightGarden.Framework.Domain.Mg
{
    public class Card : OutputData
    {
        public string Rank { get; set; }
        public string CardId { get; set; }                        
        public string ArmorId { get; set; }
        public string WeaponId { get; set; }
        public string FamilyId { get; set; }

        public CardBase OriginalCard;
        public Equip Armor;
        public Equip Weapon;
        public CombatRate Rate;
    }
}
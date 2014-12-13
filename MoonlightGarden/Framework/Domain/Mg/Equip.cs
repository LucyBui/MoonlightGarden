using MoonlightGarden.Framework.Domain.Master;
using MoonlightGarden.Platform.Domain;

namespace MoonlightGarden.Framework.Domain.Mg
{
    public class Equip : OutputData
    {
        public string EquipType { get; set; }
        public string EquipId { get; set; }
        public string FamilyId { get; set; }
        public string CardId { get; set; }

        public EquipBase OriginalEquip;
        
    }
}
using MoonlightGarden.Framework.Domain.Master;
using MoonlightGarden.Framework.Domain.Mg;
using MoonlightGarden.Framework.Domain.Misc;
using MoonlightGarden.Framework.Entity.Master;
using MoonlightGarden.Framework.Entity.Mg;
using MoonlightGarden.Framework.Enumeration;
using MoonlightGarden.Framework.Repository;
using MoonlightGarden.Framework.Utils;
using MoonlightGarden.Platform.Factory;
using System.Collections.Generic;
using System.Linq;

namespace MoonlightGarden.Framework.Service
{
    public class FamilyService
    {
        private FamilyRepository repository = AppContext.getBean<FamilyRepository>();
        private MasterDataService masterDataService = AppContext.getBean<MasterDataService>();
        private ProcessingService processingService = AppContext.getBean<ProcessingService>();
        public Family GetFamily(string familyId)
        {
            Dictionary<FamilyType, List<FamilyData>> rawData = repository.RawData(familyId);
            Family family = new Family();
            family.Profile = rawData[FamilyType.Profile][0].Clone<Profile>();
            family.Cards = rawData[FamilyType.Card].ToDictionary(item => item.Id, item => item.Clone<Card>());
            family.Equips = rawData[FamilyType.Equip].ToDictionary(item => item.Id, item => item.Clone<Equip>());
            ConsolidateFamily(family);
            return family;
        }
        private void ConsolidateFamily(Family family)
        {
            // get original data by id
            List<string> originalIds = new List<string>();
            family.Cards.Values.ForEach(card => originalIds.Add(card.CardId));
            family.Equips.Values.ForEach(equip => originalIds.Add(equip.EquipId));
            Dictionary<string, MasterData> originalDatas = masterDataService.FetchByIds(originalIds);
            // consolidate family
            family.Cards.Values.ForEach(card => card.OriginalCard = originalDatas[card.CardId].Clone<CardBase>());
            family.Equips.Values.ForEach(equip => equip.OriginalEquip = originalDatas[equip.EquipId].Clone<EquipBase>());
            family.CombatTeam = new List<Card>();
            family.Profile.Team.ForEach(cardId => family.CombatTeam.Add(family.Cards[cardId]));            
            family.CombatTeam.ForEach(card =>
            {
                card.Armor = family.Equips[card.ArmorId];
                card.Weapon = family.Equips[card.WeaponId];
                card.Rate = processingService.CalculateCombatRate(card.Rank, card.OriginalCard, card.Weapon, card.Armor);
            });
        }
        public void SaveTeam(string familyId, string[] Team)
        {
            Profile profile = repository.GetProfile(familyId);
            profile.Team = Team;
            repository.Save(profile.Convert<FamilyData>(familyId, FamilyType.Profile));
        }
        public void SaveLastLocation(string familyId, string location)
        {
            Profile profile = repository.GetProfile(familyId);
            profile.LastLocation = location;
            repository.Save(profile.Convert<FamilyData>(familyId, FamilyType.Profile));
        }


        #region CRUD
        public void AddNewFamily(List<FamilyData> datas)
        {
            repository.Add(datas);
        }
        #endregion
    }
}
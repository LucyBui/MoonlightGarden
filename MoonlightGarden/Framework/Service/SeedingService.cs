using MoonlightGarden.Framework.Domain.Master;
using MoonlightGarden.Framework.Domain.Mg;
using MoonlightGarden.Framework.Entity.Master;
using MoonlightGarden.Framework.Entity.Mg;
using MoonlightGarden.Framework.Enumeration;
using MoonlightGarden.Framework.Utils;
using MoonlightGarden.Platform.Domain;
using MoonlightGarden.Platform.Factory;
using System;
using System.Collections.Generic;

namespace MoonlightGarden.Framework.Service
{
    public class SeedingService
    {
        private MasterDataService masterDataService = AppContext.getBean<MasterDataService>();
        private FamilyService familyService = AppContext.getBean<FamilyService>();

        #region Family
        public void SeedNewFamily(string familyId, string familyName)
        {
            List<FamilyData> familyDatas = new List<FamilyData>();
            // create new family
            Profile family = GenerateFamily(familyId, familyName);
            familyDatas.Add(family.Convert<FamilyData>(familyId, FamilyType.Profile));

            IEnumerable<CardBase> cardBases = masterDataService.BasicCards();
            int counter = 0;
            foreach (CardBase cardBase in cardBases)
            {
                // create new card
                Card card = GenerateCard(familyId, cardBase.Id);
                card.Id = GenerateId(card.Id, familyId, ++counter);
                // create new armor
                Equip armor = GenerateEquip(EquipType.Armor, familyId, card.Id, cardBase.ArmorUsable);
                armor.Id = GenerateId(armor.Id, familyId, ++counter);
                familyDatas.Add(armor.Convert<FamilyData>(armor.FamilyId, FamilyType.Equip));
                card.ArmorId = armor.Id;
                // create new weapon
                Equip weapon = GenerateEquip(EquipType.Weapon, familyId, card.Id, cardBase.WeaponUsable);
                weapon.Id = GenerateId(weapon.Id, familyId, ++counter);
                familyDatas.Add(weapon.Convert<FamilyData>(weapon.FamilyId, FamilyType.Equip));
                card.WeaponId = weapon.Id;

                familyDatas.Add(card.Convert<FamilyData>(card.FamilyId, FamilyType.Card));
            }
            familyService.AddNewFamily(familyDatas);
        }
        private string GenerateId(string id, string familyId, int counter)
        {
            return String.Format("{0}_{1}_{2}", id, familyId, counter);
        }
        private Profile GenerateFamily(string familyId, string familyName)
        {
            return new Profile
            {
                Id = familyId,
                Name = familyName,
                Level = 1,
                Title = FamilyTitle.None.ToString(),
                Reputation = 0,
                SavedLocation = "training",
                LastLocation = "training",
                Team = new string[] { }
            };
        }
        private Card GenerateCard(string familyId, string cardId)
        {
            return new Card
            {
                Id = cardId,
                Rank = CardRank.Settle.ToString(),
                CardId = cardId,
                FamilyId = familyId
            };
        }
        private Equip GenerateEquip(EquipType equipType, string familyId, string cardId, string firstUsable)
        {
            string equipId = "";
            switch (equipType)
            {
                case EquipType.Armor: equipId = ArmorInit(firstUsable); break;
                case EquipType.Weapon: equipId = WeaponInit(firstUsable); break;
            }
            return new Equip
            {
                Id = equipId,
                EquipType = equipType.ToString(),
                EquipId = equipId,
                FamilyId = familyId,
                CardId = cardId
            };
        }
        private string ArmorInit(string firstUsable)
        {
            string equipId = "";
            ArmorType armorType = firstUsable.ParseEnum<ArmorType>();
            switch (armorType)
            {
                case ArmorType.Metal: equipId = "it_m_fieldplate"; break;
                case ArmorType.Leather: equipId = "it_m_studdedleatherarmor"; break;
                case ArmorType.Coat: equipId = "it_m_joustocoprs"; break;
                case ArmorType.Robe: equipId = "it_m_elementalist"; break;
            }
            return equipId;
        }
        private string WeaponInit(string firstUsable)
        {
            string equipId = "";
            WeaponType weaponType = firstUsable.ParseEnum<WeaponType>();
            switch (weaponType)
            {
                case WeaponType.Javelin: equipId = "it_w_pizarro"; break;
                case WeaponType.Dagger: equipId = "it_w_persqabz"; break;
                case WeaponType.Rifle: equipId = "it_w_thefinisher"; break;
                case WeaponType.Staff: equipId = "it_w_staffofgnosis"; break;
                case WeaponType.Rod: equipId = "it_w_moonstonerod"; break;
                case WeaponType.Bracelet: equipId = "it_w_lordofelemental"; break;
                case WeaponType.Polearm: equipId = "it_w_muertebalada"; break;
                case WeaponType.Pistol: equipId = "it_w_claudeniquet"; break;
                case WeaponType.GreatSword: equipId = "it_w_yeganehsword"; break;
            }
            return equipId;
        }
        #endregion

        #region Master Data
        public void ImportMasterData(string type)
        {
            MasterDataType masterDataType = type.ParseEnum<MasterDataType>();
            switch (masterDataType)
            {
                case MasterDataType.Zone:
                    masterDataService.Import<ZoneBase>(zones, type, 
                        item => item.Convert<MasterData>(type, item.Type));
                    break;
                case MasterDataType.Skill:
                    masterDataService.Import<Skill>(skills, type, 
                        item => item.Convert<MasterData>(type, item.Type));
                    break;
                case MasterDataType.Monster:
                    masterDataService.Import<Monster>(monsters, type, 
                        item => item.Convert<MasterData>(type, item.ZoneId));
                    break;
                case MasterDataType.Card:
                    masterDataService.Import<CardBase>(cards, type, 
                        item => item.Convert<MasterData>(type, item.Type));
                    break;
                case MasterDataType.Equip:
                    masterDataService.Import<EquipBase>(equips, type,
                        item => item.Convert<MasterData>(type, item.EquipType));
                    break;
            }
        }
        private List<ZoneBase> zones = new List<ZoneBase>
        {
            new ZoneBase{Id="training", Name="Training Center of Soldier of Reboldoeux", Type=ZoneType.SafeZone.ToString(), Points=new string[]{"reboldoeux"}},
            new ZoneBase{Id="reboldoeux", Name="Cite de Reboldoeux", Type=ZoneType.SafeZone.ToString(), Points=new string[]{"fld_tor"}},            
            new ZoneBase{Id="fld_tor", Name="Mansion of Dr. Torsche, Savage Garden", Type=ZoneType.Field.ToString(), Points=new string[]{"reboldoeux","dun_tor01"}},
            new ZoneBase{Id="dun_tor01", Name="Mansion of Dr. Torsche, Reception Hall", Type=ZoneType.Dungeon.ToString(), Points=new string[]{"fld_tor","dun_tor02"}},
            new ZoneBase{Id="dun_tor02", Name="Mansion of Dr. Torsche, Grand Library", Type=ZoneType.Dungeon.ToString(), Points=new string[]{"dun_tor01","dun_tor04"}},
            new ZoneBase{Id="dun_tor04", Name="Mansion of Dr. Torsche, Annex", Type=ZoneType.Dungeon.ToString(), Points=new string[]{"dun_tor02"}},
            new ZoneBase{Id="dun_tor00", Name="Mission: Dr. Torsche's Mansion - Basement ", Type=ZoneType.Instance.ToString(), Points=new string[]{}},
            new ZoneBase{Id="waypoint", Name="Way Point", Points=new string[]{"reboldoeux", "fld_tor"}},
        };
        private List<EquipBase> equips = new List<EquipBase>
        {
            // Armor
            new EquipBase{Id="it_m_fieldplate", Name="Mysterious Metal Armor of Pioneer", EquipType=EquipType.Armor.ToString(), Type=ArmorType.Metal.ToString(), Extend=new Dictionary<string,int>{{EquipExtend.DR.ToString(),26}, {EquipExtend.Def.ToString(),197}}},
            new EquipBase{Id="it_m_studdedleatherarmor", Name="Mysterious Leather Armor of Pioneer", EquipType=EquipType.Armor.ToString(), Type=ArmorType.Leather.ToString(), Extend=new Dictionary<string,int>{{EquipExtend.DR.ToString(),26}, {EquipExtend.Def.ToString(),172}}},
            new EquipBase{Id="it_m_joustocoprs", Name="Mysterious Coat of Pioneer", EquipType=EquipType.Armor.ToString(), Type=ArmorType.Coat.ToString(), Extend=new Dictionary<string,int>{{EquipExtend.DR.ToString(),26}, {EquipExtend.Def.ToString(),147}}},
            new EquipBase{Id="it_m_elementalist", Name="Mysterious Robe of Pioneer", EquipType=EquipType.Armor.ToString(), Type=ArmorType.Robe.ToString(), Extend=new Dictionary<string,int>{{EquipExtend.DR.ToString(),26}, {EquipExtend.Def.ToString(),147}}},
            // Weapon
            new EquipBase{Id="it_w_pizarro", Name="Mysterious Javelin of Pioneer", EquipType=EquipType.Weapon.ToString(), Type=WeaponType.Javelin.ToString(), Extend=new Dictionary<string,int>{{EquipExtend.AR.ToString(),29}, {EquipExtend.Atk.ToString(),237}}},
            new EquipBase{Id="it_w_persqabz", Name="Mysterious Dagger of Pioneer", EquipType=EquipType.Weapon.ToString(), Type=WeaponType.Dagger.ToString(), Extend=new Dictionary<string,int>{{EquipExtend.AR.ToString(),29}, {EquipExtend.Atk.ToString(),158}}},
            new EquipBase{Id="it_w_thefinisher", Name="Mysterious Rifle of Pioneer", EquipType=EquipType.Weapon.ToString(), Type=WeaponType.Rifle.ToString(), Extend=new Dictionary<string,int>{{EquipExtend.AR.ToString(),29}, {EquipExtend.Atk.ToString(),336}}},
            new EquipBase{Id="it_w_staffofgnosis", Name="Mysterious Staff of Pioneer", EquipType=EquipType.Weapon.ToString(), Type=WeaponType.Staff.ToString(), Extend=new Dictionary<string,int>{{EquipExtend.AR.ToString(),29}, {EquipExtend.Atk.ToString(),264}}},
            new EquipBase{Id="it_w_moonstonerod", Name="Mysterious Rod of Pioneer", EquipType=EquipType.Weapon.ToString(), Type=WeaponType.Rod.ToString(), Extend=new Dictionary<string,int>{{EquipExtend.AR.ToString(),29}, {EquipExtend.Atk.ToString(),264}}},
            new EquipBase{Id="it_w_lordofelemental", Name="Mysterious Special Bracelet of Pioneer", EquipType=EquipType.Weapon.ToString(), Type=WeaponType.Bracelet.ToString(), Extend=new Dictionary<string,int>{{EquipExtend.AR.ToString(),29}, {EquipExtend.Atk.ToString(),220}}},
            new EquipBase{Id="it_w_muertebalada", Name="Mysterious Polearm of Pioneer", EquipType=EquipType.Weapon.ToString(), Type=WeaponType.Polearm.ToString(), Extend=new Dictionary<string,int>{{EquipExtend.AR.ToString(),29}, {EquipExtend.Atk.ToString(),297}}},
            new EquipBase{Id="it_w_claudeniquet", Name="Mysterious Pistol of Pioneer", EquipType=EquipType.Weapon.ToString(), Type=WeaponType.Pistol.ToString(), Extend=new Dictionary<string,int>{{EquipExtend.AR.ToString(),29}, {EquipExtend.Atk.ToString(),237}}},
            new EquipBase{Id="it_w_yeganehsword", Name="Mysterious Great Sword of Pioneer", EquipType=EquipType.Weapon.ToString(), Type=WeaponType.GreatSword.ToString(), Extend=new Dictionary<string,int>{{EquipExtend.AR.ToString(),392}, {EquipExtend.Atk.ToString(),237}}},
        };
        private List<Skill> skills = new List<Skill>
        {
            new Skill{Id="poweratk", Name="Power ATK", Type=SkillType.Buff.ToString()},
            new Skill{Id="fear", Name="Fear", Type=SkillType.Cast.ToString()},
            new Skill{Id="knockback", Name="Knockback", Type=SkillType.Combat.ToString()},
        };
        private List<Monster> monsters = new List<Monster> 
        { 
            new Monster{Id="gehcos", Name="Elite Geckos", Type=MonsterType.Wildlife.ToString(), Size=Size.Medium.ToString(), ArmorType=ArmorType.Soft.ToString(), Class=Class.Melee.ToString(), IsBoss=false, ZoneId="fld_tor", MaxHP=7541, DR=37, Def=70, AR=37, Atk=480, Target=1, Hits=1, SkillId="poweratk"},
            new Monster{Id="wild_dog", Name="Wild-Dog", Type=MonsterType.Wildlife.ToString(), Size=Size.Small.ToString(), ArmorType=ArmorType.Soft.ToString(), Class=Class.Melee.ToString(), IsBoss=false, ZoneId="fld_tor", MaxHP=5533, DR=37, Def=61, AR=37, Atk=434, Target=1, Hits=1},
            new Monster{Id="haunted_candle", Name="Elite Haunted Candle", Type=MonsterType.Lifeless.ToString(), Size=Size.Small.ToString(), ArmorType=ArmorType.Soft.ToString(), Class=Class.Magical.ToString(), IsBoss=false, ZoneId="fld_tor", MaxHP=6943, DR=37, Def=114, AR=37, Atk=332, Target=1, Hits=1},
            new Monster{Id="recluse", Name="Hermit", Type=MonsterType.Human.ToString(), Size=Size.Medium.ToString(), ArmorType=ArmorType.Soft.ToString(), Class=Class.Melee.ToString(), IsBoss=false, ZoneId="fld_tor", MaxHP=4904, DR=38, Def=76, AR=38, Atk=416, Target=3, Hits=1, SkillId="fear"},
            new Monster{Id="Monster_Gehvarsboss", Name="Gehvars", Type=MonsterType.Wildlife.ToString(), Size=Size.Medium.ToString(), ArmorType=ArmorType.Soft.ToString(), Class=Class.Melee.ToString(), IsBoss=true, ZoneId="fld_tor", MaxHP=88100, DR=41, Def=73, AR=41, Atk=1499, Target=1, Hits=1, SkillId="knockback"},
        };
        private List<CardBase> cards = new List<CardBase>
        {
            new CardBase{Id="fighter", Name="Fighter", Type=CardType.Basic.ToString(), Class=Class.Melee.ToString(), STR=60, AGI=60, CON=70, DEX=60, INT=40, SEN=50, ArmorUsable=ArmorType.Metal.ToString(), WeaponUsable=WeaponType.Javelin.ToString(), Buff=CardBuff.Def.ToString(), BuffLevel=2},
            new CardBase{Id="musketeer", Name="Musketeer", Type=CardType.Basic.ToString(), Class=Class.Ranger.ToString(), STR=50, AGI=60, CON=50, DEX=80, INT=30, SEN=50, ArmorUsable=ArmorType.Coat.ToString(), WeaponUsable=WeaponType.Rifle.ToString(), Buff=CardBuff.Atk.ToString(), BuffLevel=2},
            new CardBase{Id="scout", Name="Scout", Type=CardType.Basic.ToString(), Class=Class.Melee.ToString(), STR=30, AGI=70, CON=50, DEX=70, INT=50, SEN=50, ArmorUsable=ArmorType.Leather.ToString(), WeaponUsable=WeaponType.Dagger.ToString(), Buff=CardBuff.MaxHP.ToString(), BuffLevel=1},
            new CardBase{Id="wizard", Name="Wizard", Type=CardType.Basic.ToString(), Class=Class.Magical.ToString(), STR=30, AGI=50, CON=40, DEX=40, INT=70, SEN=70, ArmorUsable=ArmorType.Coat.ToString(), WeaponUsable=WeaponType.Rod.ToString(), Buff=CardBuff.SEN.ToString(), BuffLevel=1},
            new CardBase{Id="warlock", Name="Elementalist", Type=CardType.Basic.ToString(), Class=Class.Magical.ToString(), STR=30, AGI=30, CON=40, DEX=50, INT=80, SEN=70, ArmorUsable=ArmorType.Robe.ToString(), WeaponUsable=WeaponType.Bracelet.ToString(), Buff=CardBuff.INT.ToString(), BuffLevel=1},
            new CardBase{Id="soldier", Name="Soldier of Reboldoeux", Type=CardType.Recruited.ToString(), Class=Class.Melee.ToString(), STR=60, AGI=50, CON=70, DEX=40, INT=30, SEN=50, ArmorUsable=ArmorType.Metal.ToString(), WeaponUsable=WeaponType.Polearm.ToString(), Buff=CardBuff.MaxHP.ToString(), BuffLevel=2},
            new CardBase{Id="brunie", Name="Brunie Etienne", Type=CardType.Recruited.ToString(), Class=Class.Ranger.ToString(), STR=40, AGI=90, CON=40, DEX=70, INT=30, SEN=50, ArmorUsable=ArmorType.Coat.ToString(), WeaponUsable=WeaponType.Pistol.ToString(), Buff=CardBuff.Atk.ToString(), BuffLevel=1},
            new CardBase{Id="idge", Name="Idge Imbrulia", Type=CardType.Recruited.ToString(), Class=Class.Melee.ToString(), STR=60, AGI=70, CON=60, DEX=60, INT=30, SEN=50, ArmorUsable=ArmorType.Metal.ToString(), WeaponUsable=WeaponType.GreatSword.ToString(), Buff=CardBuff.Atk.ToString(), BuffLevel=1},
            new CardBase{Id="idgebattle", Name="Battle Smith Idge", Type=CardType.Limited.ToString(), Class=Class.Melee.ToString(), STR=70, AGI=80, CON=60, DEX=60, INT=30, SEN=50, ArmorUsable=ArmorType.Metal.ToString(), WeaponUsable=WeaponType.GreatSword.ToString(), Buff=CardBuff.Atk.ToString(), BuffLevel=2},
        };
        #endregion
    }
}
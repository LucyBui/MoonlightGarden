using MoonlightGarden.Framework.Domain.Master;
using MoonlightGarden.Framework.Domain.Mg;
using MoonlightGarden.Framework.Entity.Master;
using MoonlightGarden.Framework.Enumeration;
using MoonlightGarden.Framework.Repository;
using MoonlightGarden.Framework.Utils;
using MoonlightGarden.Platform.Domain;
using MoonlightGarden.Platform.Factory;
using System;
using System.Collections.Generic;

namespace MoonlightGarden.Framework.Service
{
    public class MasterDataService
    {
        private MasterDataRepository repository = AppContext.getBean<MasterDataRepository>();
        public IEnumerable<T> Find<T>(string masterDataType) where T : OutputData
        {
            return repository.Fetch<T>(masterDataType).Values;
        }
        public T FindOne<T>(string id) where T : OutputData
        {
            return repository.FindOne<T>(id);
        }
        public Dictionary<string, MasterData> FetchByIds(List<string> ids)
        {
            return repository.FetchByIds(ids);
        }

        #region Card
        public IEnumerable<CardBase> BasicCards()
        {
            return repository.BasicCards();
        }
        #endregion

        #region Zone
        public Zone LoadZone(string zoneId)
        {
            Dictionary<string, ZoneBase> zones = repository.Fetch<ZoneBase>(MasterDataType.Zone);
            ZoneBase zone = zones[zoneId];
            Zone current = new Zone
            {
                Id = zone.Id,
                Name = zone.Name,
                Type = zone.Type
            };
            current.Points = new List<ZoneBase>();
            foreach (string id in zone.Points)
            {
                current.Points.Add(zones[id]);
            }
            if (ZoneType.SafeZone.ToString().Equals(zone.Type))
            {
                current.WayPoint = new List<ZoneBase>();
                zones["waypoint"].Points.ForEach(id => current.WayPoint.Add(zones[id]));
            }
            else
            {
                current.Monsters = GetMonsterInZone(zoneId);
                current.Boss = GetBossFromMonsters(current.Monsters);
            }
            return current;
        }
        public List<Monster> GetMonsterInZone(string zoneId)
        {
            return new List<Monster>(repository.MonsterInZone(zoneId));
        }
        public Monster GetBossFromMonsters(List<Monster> monsters)
        {
            foreach (Monster mob in monsters)
            {
                if (mob.IsBoss)
                {
                    monsters.Remove(mob);
                    return mob;
                }
            }
            return null;
        }
        #endregion

        #region CRUD
        public void Import<T>(List<T> datas, string type, Converter<T, MasterData> converter)
        {
            repository.DropByKey(type);
            repository.Add(datas.ConvertAll(converter));
        }
        #endregion
    }
}
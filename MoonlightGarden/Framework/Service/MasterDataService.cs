using MoonlightGarden.Framework.Domain;
using MoonlightGarden.Framework.Context;
using MoonlightGarden.Framework.Enumeration;
using MoonlightGarden.Framework.Repository;
using MoonlightGarden.Framework.Utils;
using MoonlightGarden.Platform;
using System;
using System.Collections.Generic;

namespace MoonlightGarden.Framework.Service
{
    public class MasterDataService
    {
        private MasterDataRepository repos = AppContext.getBean<MasterDataRepository>();
        public IEnumerable<T> FindByType<T>(string masterDataType) where T : OutputData
        {
            return repos.FindByType<T>(masterDataType);
        }

        /*#region Card
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
        #endregion*/

        #region CRUD
        public void Import<T>(List<T> datas, string type, Converter<T, MasterData> converter)
        {
            repos.Import(datas.ConvertAll(converter), type);
        }
        #endregion
    }
}
using MoonlightGarden.Framework.Context;
using MoonlightGarden.Framework.Entity;
using MoonlightGarden.Framework.Entity.Master;
using MoonlightGarden.Framework.Enumeration;
using MoonlightGarden.Platform.Factory;
using System;
using System.Collections.Generic;
using MoonlightGarden.Platform.Repository;
using MoonlightGarden.Framework.Domain.Master;
using MoonlightGarden.Platform.Domain;
using System.Linq.Expressions;
using System.Linq;

namespace MoonlightGarden.Framework.Repository
{
    public class MasterDataRepository : RepositoryBase<MasterData>
    {
        public MasterDataRepository() : base(AppContext.getBean<MasterContext>()) { }
        public Dictionary<string, MasterData> FetchByIds(List<string> ids)
        {
            return Fetch(item => ids.Contains(item.Id));
        }
        public Dictionary<string, OutputData> FetchNameById(List<string> ids)
        {            
            return Fetch<OutputData>(item => ids.Contains(item.Id));
        }
        public Dictionary<string, T> Fetch<T>(Enum masterDataType) where T : OutputData
        {
            return Fetch<T>(masterDataType.ToString());
        }
        public IEnumerable<CardBase> BasicCards()
        {
            return Fetch<CardBase>(MasterDataType.Card.ToString(), CardType.Basic.ToString()).Values;
        }
        public IEnumerable<Monster> MonsterInZone(string zoneId)
        {
            return Fetch<Monster>(MasterDataType.Monster.ToString(), zoneId).Values;
        }
    }
}
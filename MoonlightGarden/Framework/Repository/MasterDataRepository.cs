using MoonlightGarden.Framework.Context;
using MoonlightGarden.Framework.Enumeration;
using MoonlightGarden.Platform;
using System;
using System.Collections.Generic;
using MoonlightGarden.Framework.Domain;
using System.Linq.Expressions;
using System.Linq;

namespace MoonlightGarden.Framework.Repository
{
    public class MasterDataRepository : RepositoryBase<MasterData>
    {
        public MasterDataRepository() : base(AppContext.getBean<MgContext>()) { }

        public IEnumerable<T> FindByType<T>(string masterDataType) where T : OutputData
        {
            return FilterByRowKey<T>(masterDataType).Values;
        }

        public void Import(List<MasterData> datas, string type)
        {
            DropByKey(type);
            Add(datas);
        }
    }
}
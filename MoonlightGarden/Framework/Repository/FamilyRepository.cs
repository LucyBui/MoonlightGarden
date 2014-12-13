using MoonlightGarden.Framework.Context;
using MoonlightGarden.Framework.Domain.Mg;
using MoonlightGarden.Framework.Entity.Mg;
using MoonlightGarden.Framework.Enumeration;
using MoonlightGarden.Framework.Utils;
using MoonlightGarden.Platform.Factory;
using MoonlightGarden.Platform.Repository;
using System.Collections.Generic;
using System.Linq;

namespace MoonlightGarden.Framework.Repository
{
    public class FamilyRepository : RepositoryBase<FamilyData>
    {
        public FamilyRepository() : base(AppContext.getBean<MgContext>()) { }
        public Dictionary<FamilyType, List<FamilyData>> RawData(string familyId)
        {
            return FilterBy(item => item.RowKey == familyId)
                    .GroupBy(item => item.SuperColumn)
                    .ToDictionary(item => item.Key.ParseEnum<FamilyType>(), item => item.ToList());
        }
        public Profile GetProfile(string familyId)
        {
            return Find<Profile>(item => item.RowKey == familyId && item.SuperColumn == FamilyType.Profile.ToString());
        }
    }
}
using MoonlightGarden.Framework.Entity.Master;
using System.Data.Entity;

namespace MoonlightGarden.Framework.Context
{
    public class MasterContext : DbContext
    {
        public DbSet<MasterData> MasterDatas { get; set; }
    }
}
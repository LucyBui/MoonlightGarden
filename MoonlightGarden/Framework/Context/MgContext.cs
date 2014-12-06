using System.Data.Entity;

namespace MoonlightGarden.Framework.Context
{
    public class MgContext : DbContext
    {
        /*public MgContext()
        {
            Database.SetInitializer<MgContext>(new DropCreateDatabaseIfModelChanges<MgContext>());
        }*/
        public DbSet<MasterData> MasterDatas { get; set; }
        public DbSet<Account> Accounts { get; set; }
        public DbSet<FamilyData> Families { get; set; }     
    }
}
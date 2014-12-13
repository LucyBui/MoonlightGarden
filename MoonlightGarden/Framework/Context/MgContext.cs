using MoonlightGarden.Framework.Entity.IssueTracking;
using MoonlightGarden.Framework.Entity.Master;
using MoonlightGarden.Framework.Entity.Mg;
using System.Data.Entity;

namespace MoonlightGarden.Framework.Context
{
    public class MgContext : DbContext
    {
        /*public MgContext()
        {
            Database.SetInitializer<MgContext>(new DropCreateDatabaseIfModelChanges<MgContext>());
        }*/
        public DbSet<Account> Accounts { get; set; }
        public DbSet<FamilyData> Families { get; set; }     
    }
}
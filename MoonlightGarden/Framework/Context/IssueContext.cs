using MoonlightGarden.Framework.Entity.IssueTracking;
using System.Data.Entity;

namespace MoonlightGarden.Framework.Context
{
    public class IssueContext : DbContext
    {
        public DbSet<IssueData> Issues { get; set; }
    }
}
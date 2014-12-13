using MoonlightGarden.Platform.Factory;
using MoonlightGarden.Platform.Repository;
using MoonlightGarden.Framework.Context;
using MoonlightGarden.Framework.Entity.Mg;

namespace MoonlightGarden.Framework.Repository
{
    public class AccountRepository : RepositoryBase<Account>
    {
        public AccountRepository() : base(AppContext.getBean<MgContext>()) { }
    }
}
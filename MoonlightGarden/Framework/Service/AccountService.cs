using MoonlightGarden.Framework.Entity.Mg;
using MoonlightGarden.Framework.Repository;
using MoonlightGarden.Platform.Factory;

namespace MoonlightGarden.Framework.Service
{
    public class AccountService
    {
        private AccountRepository repository = AppContext.getBean<AccountRepository>();
        private SeedingService seedingService = AppContext.getBean<SeedingService>();
        private SecurityService securityService = AppContext.getBean<SecurityService>();
        public void Add(Account account)
        {
            repository.Save(account);
            seedingService.SeedNewFamily(account.Id, account.Name);
        }
        public Account GetCurrentAccount()
        {
            return GetById(securityService.GetCurrentUser());
        }
        public Account GetById(string id)
        {
            return repository.FindOne(id);
        }
                
    }
}
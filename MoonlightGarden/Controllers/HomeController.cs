using MoonlightGarden.Framework.Entity.Mg;
using MoonlightGarden.Framework.Service;
using MoonlightGarden.Platform.Factory;
using System.Web.Mvc;
using System.Web.Security;

namespace MoonlightGarden.Controllers
{
    public class HomeController : Controller
    {
        private AccountService accountService = AppContext.getBean<AccountService>();
        private FamilyService familyService = AppContext.getBean<FamilyService>();
        public ActionResult Index()
        {
            if (!Request.IsAuthenticated)
            {
                return RedirectToAction("Login");
            }
            if (accountService.GetCurrentAccount() == null)
            {
                FormsAuthentication.SignOut();
                return RedirectToAction("Login");
            }
            return View();                    
        }
        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }
        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
        public ActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Register(Account account)
        {
            accountService.Add(account);                        
            FormsAuthentication.SetAuthCookie(account.Id, false);
            return RedirectToAction("Index");
        }
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(Account account)
        {
            account = accountService.GetById(account.Id);
            FormsAuthentication.SetAuthCookie(account.Id, false);
            return RedirectToAction("Index");
        }
        [HttpPost]
        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Index");
        }
    }
}
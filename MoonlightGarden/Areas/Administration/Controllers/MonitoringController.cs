using MoonlightGarden.Platform.Factory;
using System.Web.Mvc;

namespace MoonlightGarden.Areas.Administration.Controllers
{
    public class MonitoringController : Controller
    {
        // GET: Administration/Monitoring
        public ActionResult Index()
        {
            return View(AppContext.getActiveBeans());
        }
    }
}
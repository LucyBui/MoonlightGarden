using MoonlightGarden.Framework.Domain.IssueTracking;
using MoonlightGarden.Framework.Service;
using MoonlightGarden.Platform.Factory;
using System.Web.Mvc;

namespace MoonlightGarden.Areas.IssueTracking.Controllers
{
    public class ProjectController : Controller
    {
        private ProjectService service = AppContext.getBean<ProjectService>();
        // GET: IssueTracking/Project/Create
        public ActionResult Create()
        {
            return View();
        }
        // POST: IssueTracking/Project/Create
        [HttpPost]
        public ActionResult Create(Project project)
        {
            service.Create(project);
            return RedirectToAction("Index", "Dashboard");
        }
    }
}
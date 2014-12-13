using MoonlightGarden.Framework.Domain.IssueTracking;
using MoonlightGarden.Framework.Service;
using MoonlightGarden.Platform.Factory;
using System.Web.Mvc;

namespace MoonlightGarden.Areas.IssueTracking.Controllers
{
    public class IssueController : Controller
    {
        private IssueService service = AppContext.getBean<IssueService>();
        // GET: IssueTracking/Issue/Create/<project_id>?parentId=<parent_id>
        public ActionResult Create(string id, string parentId)
        {
            return View(service.Generate(id, parentId));
        }
        // POST: IssueTracking/Issue/Create
        [HttpPost]
        public ActionResult Create(Issue issue)
        {
            service.Create(issue);
            return RedirectToAction("Details", "Dashboard", new { id = issue.ProjectId });
        }
    }
}
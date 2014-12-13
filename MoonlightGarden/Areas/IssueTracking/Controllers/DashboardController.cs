using MoonlightGarden.Framework.Domain.IssueTracking;
using MoonlightGarden.Framework.Service;
using MoonlightGarden.Platform.Factory;
using System.Web.Mvc;

namespace MoonlightGarden.Areas.IssueTracking.Controllers
{
    public class DashboardController : Controller
    {
        private ProjectService projectService = AppContext.getBean<ProjectService>();
        private IssueService issueService = AppContext.getBean<IssueService>();
        // GET: IssueTracking/Dashboard
        public ActionResult Index()
        {
            return View(projectService.All());
        }
        // GET: IssueTracking/{id}
        public ActionResult Details(string id)
        {
            Project project = projectService.GetById(id);
            if (project != null)
            {
                ViewBag.Project = project;
                return View("ProjectDetails", projectService.GetIssues(id));
            }
            else
            {
                Issue issue = issueService.GetById(id);
                project = projectService.GetById(issue.ProjectId);
                ViewBag.ProjectName = project.Name;
                return View("IssueDetails", issue);
            }            
        }

    }
}
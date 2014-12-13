using System.Web.Mvc;

namespace MoonlightGarden.Areas.IssueTracking
{
    public class IssueTrackingAreaRegistration : AreaRegistration 
    {
        public override string AreaName 
        {
            get 
            {
                return "IssueTracking";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context) 
        {
            context.MapRoute(
                "IssueTracking_browse",
                "IssueTracking/Browse/{id}",
                new { controller = "Dashboard", action = "Details", id = UrlParameter.Optional }
            );
            context.MapRoute(
                "IssueTracking_default",
                "IssueTracking/{controller}/{action}/{id}",
                new { controller = "Dashboard", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
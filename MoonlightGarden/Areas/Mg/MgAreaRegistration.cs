using System.Web.Mvc;

namespace MoonlightGarden.Areas.Mg
{
    public class MgAreaRegistration : AreaRegistration 
    {
        public override string AreaName 
        {
            get 
            {
                return "Mg";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context) 
        {
            context.MapRoute(
                "Mg_default",
                "Mg/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
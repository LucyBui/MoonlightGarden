using System.Web.Mvc;

namespace MoonlightGarden.Areas.Administration
{
    public class AdministrationAreaRegistration : AreaRegistration 
    {
        public override string AreaName 
        {
            get 
            {
                return "Administration";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context) 
        {
            context.MapRoute(
                "MasterDataType",
                "Administration/Manage/{id}",
                new { controller = "Manage", action = "Details", id = UrlParameter.Optional }
            );
            context.MapRoute(
                "ImportData",
                "Administration/Import/{id}",
                new { controller = "Manage", action = "Import", id = UrlParameter.Optional }
            );
            context.MapRoute(
                "Administration_default",
                "Administration/{controller}/{action}/{id}",
                new { controller = "Manage", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
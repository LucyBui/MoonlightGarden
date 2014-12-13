using MoonlightGarden.Framework.Domain.Mg;
using MoonlightGarden.Framework.Enumeration;
using MoonlightGarden.Framework.Service;
using MoonlightGarden.Framework.Utils;
using MoonlightGarden.Platform.Factory;
using System.Collections.Generic;
using System.Web.Http;
using MoonlightGarden.Platform.Utils;

namespace MoonlightGarden.Areas.Mg.Controllers
{
    public class ZoneController : ApiController
    {        
        private SecurityService securityService = AppContext.getBean<SecurityService>();
        private FamilyService familyService = AppContext.getBean<FamilyService>();
        private MasterDataService masterDataService = AppContext.getBean<MasterDataService>();
        private WorkflowService workflowService = AppContext.getBean<WorkflowService>();
        private Dictionary<string, object> LoadZone(string familyId, string zoneId)
        {
            Dictionary<string, object> response = Parser.ToDictionary(familyService.GetFamily(familyId));
            response.Add(MasterDataType.Zone.ToString(), masterDataService.LoadZone(zoneId));
            return response;
        }
        // GET: api/Zone/Load/{id}
        [HttpGet]
        public ApiResponse Load(string id)
        {
            string familyId = securityService.GetCurrentUser();
            familyService.SaveLastLocation(familyId, id);
            return new ApiResponse(LoadZone(familyId, id));
        }
        // GET: api/Zone/Explore/{id}
        [HttpGet]
        public ApiResponse Explore(string id)
        {
            string familyId = securityService.GetCurrentUser();
            Dictionary<string, object> response = LoadZone(familyId, id);
            response.Add("BattleReport", workflowService.Explore(familyId, id));
            return new ApiResponse(response);
        }
    }
}

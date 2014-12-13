using MoonlightGarden.Framework.Service;
using MoonlightGarden.Platform.Factory;
using MoonlightGarden.Framework.Utils;
using System.Web.Http;
using MoonlightGarden.Framework.Enumeration;

namespace MoonlightGarden.Areas.Mg.Controllers
{
    public class BarrackController : ApiController
    {
        private FamilyService familyService = AppContext.getBean<FamilyService>();
        private SecurityService securityService = AppContext.getBean<SecurityService>();
        // GET: api/Barrack
        public ApiResponse Get()
        {
            string familyId = securityService.GetCurrentUser();
            return new ApiResponse(familyService.GetFamily(familyId));
        }
        // PUT: api/Barrack/SaveTeam
        [HttpPut]
        public ApiResponse SaveTeam([FromBody]string[] value)
        {
            string familyId = securityService.GetCurrentUser();
            familyService.SaveTeam(familyId, value);
            return new ApiResponse(new object());
        }
    }
}

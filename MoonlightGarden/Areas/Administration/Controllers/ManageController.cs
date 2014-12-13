using MoonlightGarden.Framework.Domain.Master;
using MoonlightGarden.Framework.Enumeration;
using MoonlightGarden.Framework.Service;
using MoonlightGarden.Framework.Utils;
using MoonlightGarden.Platform.Factory;
using System;
using System.Web.Mvc;

namespace MoonlightGarden.Areas.Administration.Controllers
{
    public class ManageController : Controller
    {
        private MasterDataService masterDataService = AppContext.getBean<MasterDataService>();
        private SeedingService seedingService = AppContext.getBean<SeedingService>();
        // GET: Administration/Manage
        public ActionResult Index()
        {
            return RedirectToAction("Details", new { id = "Card" });
        }
        // GET: Administration/Manage/{id}
        public ActionResult Details(string id)
        {
            ViewBag.MasterDataType = Enum.GetValues(typeof(MasterDataType));
            ViewBag.Type = id;
            MasterDataType dataType = id.ParseEnum<MasterDataType>();
            object datas = null;
            switch (dataType)
            {
                case MasterDataType.Zone: 
                    datas = masterDataService.Find<ZoneBase>(id); break;
                case MasterDataType.Skill:
                    datas = masterDataService.Find<Skill>(id); break;
                case MasterDataType.Monster:
                    datas = masterDataService.Find<Monster>(id); break;
                case MasterDataType.Card:
                    datas = masterDataService.Find<CardBase>(id); break;
                case MasterDataType.Equip:
                    datas = masterDataService.Find<EquipBase>(id); break;
            }
            return View(datas);
        }
        // GET: Administration/Import/{id}
        public ActionResult Import(string id)
        {
            seedingService.ImportMasterData(id);
            return RedirectToAction("Details", new { id = id });
        }
        public ActionResult Create(string id)
        {
            return View();
        }
    }
}
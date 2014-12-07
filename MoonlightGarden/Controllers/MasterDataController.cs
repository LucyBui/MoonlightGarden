using MoonlightGarden.Framework.Domain;
using MoonlightGarden.Framework.Enumeration;
using MoonlightGarden.Framework.Service;
using MoonlightGarden.Framework.Utils;
using MoonlightGarden.Platform;
using System;
using System.Web.Mvc;

namespace MoonlightGarden.Controllers
{
    public class MasterDataController : Controller
    {
        private MasterDataService masterDataService = AppContext.getBean<MasterDataService>();
        private SeedingService seedingService = AppContext.getBean<SeedingService>();
        // GET: MasterData/{id}
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return RedirectToAction("Details", new { id = "Card" });
            }
            ViewBag.MasterDataType = Enum.GetValues(typeof(MasterDataType));
            ViewBag.Type = id;
            MasterDataType dataType = id.ParseEnum<MasterDataType>();
            object datas = null;
            switch (dataType)
            {
                case MasterDataType.Card:
                    datas = masterDataService.FindByType<CardBase>(id); break;
                case MasterDataType.Equip:
                    datas = masterDataService.FindByType<EquipBase>(id); break;
                case MasterDataType.Zone:
                    datas = masterDataService.FindByType<ZoneBase>(id); break;
                case MasterDataType.Monster:
                    datas = masterDataService.FindByType<Monster>(id); break;
                case MasterDataType.Skill:
                    datas = masterDataService.FindByType<Skill>(id); break;
            }
            return View(datas);
        }
        // GET: Administration/Import/{id}
        public ActionResult Import(string id)
        {
            seedingService.ImportMasterData(id);
            return RedirectToAction("Details", new { id = id });
        }
    }
}
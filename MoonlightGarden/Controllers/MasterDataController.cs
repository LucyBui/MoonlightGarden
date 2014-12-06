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
        // GET: MasterData
        public ActionResult Index()
        {
            ViewBag.MasterDataType = Enum.GetValues(typeof(MasterDataType));
            return View();
        }

        public ActionResult Details(string id)
        {
            if (id == null)
            {
                id = MasterDataType.Card.ToString();
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
    }
}
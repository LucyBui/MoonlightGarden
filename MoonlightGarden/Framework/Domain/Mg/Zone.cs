using MoonlightGarden.Framework.Domain.Master;
using MoonlightGarden.Platform.Domain;
using System.Collections.Generic;

namespace MoonlightGarden.Framework.Domain.Mg
{
    public class Zone : OutputData
    {
        public string Type { get; set; }
        public List<ZoneBase> Points { get; set; }
        public List<Monster> Monsters { get; set; }
        public Monster Boss { get; set; }
        public List<ZoneBase> WayPoint { get; set; }
    }
}
using MoonlightGarden.Platform;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MoonlightGarden.Framework.Domain
{
    public class EquipBase : OutputData
    {
        public string EquipType { get; set; }
        public string Type { get; set; }
        public Dictionary<string, int> Extend { get; set; }
    }
}
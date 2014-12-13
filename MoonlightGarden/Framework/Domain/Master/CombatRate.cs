using MoonlightGarden.Framework.Enumeration;
using MoonlightGarden.Platform.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MoonlightGarden.Framework.Domain.Master
{
    public class CombatRate : OutputData
    {
        public int MaxHP { get; set; }
        public int Atk { get; set; }
        public int AR { get; set; }
        public int Def { get; set; }
        public int DR { get; set; }
        public string Class { get; set; }
        public int Target { get; set; }
        public int Hits { get; set; }
    }
}
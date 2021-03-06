﻿using MoonlightGarden.Platform;

namespace MoonlightGarden.Framework.Domain
{
    public class Monster : CombatRate
    {
        public string Type { get; set; }
        public string Size { get; set; }
        public string ArmorType { get; set; }
        public bool IsBoss { get; set; }
        public string ZoneId { get; set; }
        public string SkillId { get; set; }
    }
}
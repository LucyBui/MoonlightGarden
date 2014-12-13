using MoonlightGarden.Framework.Domain.Mg;
using System.Collections.Generic;

namespace MoonlightGarden.Framework.Domain.Misc
{
    public class Family
    {
        public Profile Profile { get; set; }
        public Dictionary<string, Card> Cards { get; set; }
        public Dictionary<string, Equip> Equips { get; set; }
        public List<Card> CombatTeam { get; set; }
    }
}
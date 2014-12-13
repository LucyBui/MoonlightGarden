using MoonlightGarden.Framework.Domain.Mg;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MoonlightGarden.Framework.Utils
{
    public class BattleReport
    {
        private string familyName;
        private List<string> report;
        public const string FAMILY_CHOOSE_TARGET = "{0} family choose {1} as a target";
        public const string CHARACTER_ATTACK_MONSTER = "{0} attacked {1} with {2} damages";
        public const string MONSTER_ATTACK_CHARACTER = "{0} is attacked by {1} with {2} damages";
        public const string DEAD = "{0} is dead";
        public const string YOU_WIN = "{0} family win";
        public const string YOU_LOSE = "{0} family lose";
        public BattleReport(string familyName)
        {
            this.familyName = familyName;
            report = new List<string>();
        }
        public void Write(string log, params object[] args)
        {
            report.Add(String.Format(log, args));
        }
        public List<string> Export()
        {
            return report;
        }
    }
}
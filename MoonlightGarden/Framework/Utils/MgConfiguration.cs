using MoonlightGarden.Framework.Domain.Master;
using MoonlightGarden.Framework.Enumeration;

namespace MoonlightGarden.Framework.Utils
{
    public static class MgConfiguration
    {
        public static int PotionUnit(string rank)
        {
            CardRank rankEnum = rank.ParseEnum<CardRank>();
            switch (rankEnum)
            {
                case CardRank.Settle: return 4;
                case CardRank.Veteran: return 5;
                case CardRank.Expert: return 7;
                case CardRank.Master: return 10;
                case CardRank.HighMaster: return 15;
                case CardRank.GrandMaster: return 20;
                default: return 0;
            }
        }
        public static int Rating(string rank)
        {
            CardRank rankEnum = rank.ParseEnum<CardRank>();
            switch (rankEnum)
            {
                case CardRank.Settle: return 25;
                case CardRank.Veteran: return 26;
                case CardRank.Expert: return 28;
                case CardRank.Master: return 31;
                case CardRank.HighMaster: return 35;
                case CardRank.GrandMaster: return 40;
                default: return 0;
            }
        }
        
        public static int BasicAttack(CardBase card)
        {
            Class clazz = card.Class.ParseEnum<Class>();
            switch (clazz)
            {
                case Class.Melee: return card.STR;
                case Class.Ranger: return card.DEX;
                case Class.Magical: return card.INT;
                default: return 0;
            }
        }
        public static double DamageBoost(int attackerAR, int enemyDR)
        {
            int diff = attackerAR - enemyDR;
            if (diff < -10) { return -1; }
            else if (diff < -5) { return -0.5; }
            else if (diff < 5) { return 0; }
            else if (diff < 7) { return 0.5; }
            else if (diff < 9) { return 1; }
            else if (diff < 11) { return 1.5; }
            else { return 2; }
        }
    }
}
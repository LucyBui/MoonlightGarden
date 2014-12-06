using MoonlightGarden.Platform;

namespace MoonlightGarden.Framework.Domain
{
    public class CardBase : OutputData 
    {
        public string Type { get; set; }
        public string Class { get; set; }
        public int STR { get; set; }
        public int AGI { get; set; }
        public int CON { get; set; }
        public int DEX { get; set; }
        public int INT { get; set; }
        public int SEN { get; set; }
        public string ArmorUsable { get; set; }
        public string WeaponUsable { get; set; }
        public string Buff { get; set; }
        public int BuffLevel { get; set; }
    }
}
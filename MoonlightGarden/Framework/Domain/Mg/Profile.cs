using MoonlightGarden.Platform.Domain;

using System.Collections.Generic;

namespace MoonlightGarden.Framework.Domain.Mg
{
    public class Profile : OutputData
    {
        public int Level { get; set; }
        public string Title { get; set; }
        public int Reputation { get; set; }
        public string[] Team { get; set; }
        public string SavedLocation { get; set; }
        public string LastLocation { get; set; }
        
        
    }
}
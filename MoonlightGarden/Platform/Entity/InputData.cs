using MoonlightGarden.Platform.Domain;
using MoonlightGarden.Platform.Utils;
using System.ComponentModel.DataAnnotations;

namespace MoonlightGarden.Platform.Entity
{
    public class InputData
    {
        public string Id { get; set; }
        public string RowKey { get; set; }
        public string SuperColumn { get; set; }        
        [MaxLength]
        public string Columns { get; set; }        
        public T Clone<T>() where T : OutputData
        {
            return Columns.ParseJson<T>();
        }
    }
}
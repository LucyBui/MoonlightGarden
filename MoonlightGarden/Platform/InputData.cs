using System.ComponentModel.DataAnnotations;

namespace MoonlightGarden.Platform
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
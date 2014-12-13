using MoonlightGarden.Platform.Entity;
using MoonlightGarden.Platform.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace MoonlightGarden.Platform.Domain
{
    public class OutputData
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public T Convert<T>(string key, Enum superColumn) where T : InputData, new()
        {
            return Convert<T>(key, superColumn.ToString());
        }
        public T Convert<T>(string key, string superColumn) where T : InputData, new()
        {
            return new T { 
                Id = Id, 
                RowKey = key, 
                SuperColumn = superColumn, 
                Columns = Parser.ToDictionary(this).ToJsonString() 
            };
        }
    }
}
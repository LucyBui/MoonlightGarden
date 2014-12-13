using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web.Script.Serialization;

namespace MoonlightGarden.Platform.Utils
{
    public static class Parser
    {
        #region Json Extension Methods
        private static JavaScriptSerializer JsonUtils = new JavaScriptSerializer();
        public static string ToJsonString(this object value)
        {
            return JsonUtils.Serialize(value);
        }
        public static T ParseJson<T>(this string value)
        {
            return JsonUtils.Deserialize<T>(value);
        }
        #endregion
        public static Dictionary<string, object> ToDictionary(object src, params string[] skipProps)
        {
            Dictionary<string, object> desc = new Dictionary<string, object>();
            PropertyInfo[] properties = src.GetType().GetProperties();
            object propValue = null;
            foreach (PropertyInfo prop in properties)
            {
                if (!skipProps.Contains(prop.Name))
                {
                    propValue = prop.GetValue(src);
                    if (prop.PropertyType.IsEnum)
                    {
                        propValue = propValue.ToString();
                    }
                    desc.Add(prop.Name, propValue);
                }
            }
            return desc;
        }
    }
}
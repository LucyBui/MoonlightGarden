using System;
using System.Collections.Generic;

namespace MoonlightGarden.Platform
{
    public sealed class AppContext
    {
        private static Dictionary<string, object> Beans;
        public static T getBean<T>()
        {
            return (T)getBean(typeof(T));
        }
        private static object getBean(Type beanType)
        {
            if (Beans == null)
            {
                Beans = new Dictionary<string, object>();
            }
            string name = beanType.Name;
            if (!Beans.ContainsKey(name))
            {
                object bean = Activator.CreateInstance(beanType);
                Beans.Add(name, bean);
            }
            return Beans[name];
        }

        public static List<string> getActiveBeans()
        {
            List<string> activeBeans = new List<string>();
            if (Beans != null)
            {
                foreach (string beanName in Beans.Keys)
                {
                    activeBeans.Add(beanName);
                }
            }
            return activeBeans;
        }
    }
}
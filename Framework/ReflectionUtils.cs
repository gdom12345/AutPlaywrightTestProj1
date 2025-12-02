using Microsoft.Playwright;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace AutPlaywrightTestProj.Framework
{
    public static class ReflectionUtils
    {

        public static Object GetObject(this Dictionary<string, object> dict, Type type)
        {
            var obj = Activator.CreateInstance(type);

            foreach (var kv in dict)
            {
                var prop = type.GetProperty(kv.Key);
                if (prop == null) continue;

                object value = kv.Value;
                if (value is Dictionary<string, object>)
                {
                    value = GetObject(dict, prop.PropertyType); // <= This line
                }
                try
                {
                    prop.SetValue(obj, Convert.ChangeType(kv.Value, prop.PropertyType), null);
                }
                catch (Exception ex)
                {
                    Assert.Fail("Cell was in wrong format for " + kv.Key + "\n" + ex.Message);
                }
            }
            return obj;
        }

        public static T GetObject<T>(this Dictionary<string, object> dict)
        {
            return (T)GetObject(dict, typeof(T));
        }

        public static List<T> GetList<T>(this List<Dictionary<string, object>> dictList)
        {
            List<T> list = new List<T>();
            foreach (Dictionary<string, object> dict in dictList)
            {
                list.Add(GetObject<T>(dict));
            }

            return list;
        }


        private static ILocator GetLocator(IPage page, LocatorType locator, string value)
        {
            switch (locator)
            {
                case LocatorType.Id:
                    return page.Locator("#" + value);
                case LocatorType.XPath:
                    return page.Locator("xpath=" + value);
                case LocatorType.CssSelector:
                    return page.Locator(value);
                case LocatorType.Text:
                    return page.GetByText(value);
                default:
                    throw new Exception("Did NOT find By Locator type of " + locator);
            }
        }

        public static void InitLocators(object source, IPage page)
        {
            FieldInfo[] ps = source.GetType().GetFields(BindingFlags.NonPublic
                | BindingFlags.Public
                | BindingFlags.Instance);
            foreach (var item in ps)
            {

                if (item.FieldType.Name == "ILocator")
                {
                    var attribute = Attribute.GetCustomAttribute(item, typeof(LocatorProperties));

                    if (attribute == null)
                    {
                        continue;
                    }
                    LocatorProperties locatorProperties = (LocatorProperties)attribute;

                    var locator = GetLocator(page, locatorProperties.LocatorType, locatorProperties.Using);
                    //if I want custom element/locator style objects, code here is useful
                    //Type type = Type.GetType(item.FieldType.FullName, true);
                    //object instance = Activator.CreateInstance(type, locator, page, item.Name);
                    //item.SetValue(source, instance);


                    item.SetValue(source, locator);
                }
            }
        }
    }
}

using L4D2Launcher.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Text;

namespace L4D2Launcher.Helper
{
    public static class ReflectionHelper
    {

        public static List<ArgModel> ConsoleArgs<T>(this T obj)
        {
            List<ArgModel> list = new List<ArgModel>();

            var plist = obj.GetType().GetProperties();

            foreach (var p in plist)
            {
                bool hasValue = p.FieldValue<CommandAliasAttribute>();
                if (hasValue)
                {
                    list.Add(new ArgModel(p.FieldName<CommandAliasAttribute>(), p.GetValue(obj, null).CLIValue()));
                }
                else
                {
                    list.Add(new ArgModel(p.FieldName<CommandAliasAttribute>()));
                }
            }

            return list;
        }


        private static string CLIValue(this object value)
        {
            if (value==null)
            {
                return string.Empty;
            }

            if (typeof(Boolean) == value.GetType())
            {
                return ((bool)value) == true ? "1" : "0";
            }
            else return value.ToString();
        }

        private static string FieldName<T>(this PropertyInfo property) where T : CommandAliasAttribute
        {
            object[] os = property.GetCustomAttributes(typeof(T), false);

            if (os != null && os.Length >= 1)
            {
                return (os[0] as T).Alias;
            }
            else
            {
                return string.Empty;
            }
        }

        private static bool FieldValue<T>(this PropertyInfo property) where T : CommandAliasAttribute
        {
            object[] os = property.GetCustomAttributes(typeof(T), false);

            if (os != null && os.Length >= 1)
            {
                return (os[0] as T).HasValue;
            }
            else
            {
                return false;
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace memory.reader.Extensions
{
    public static class ClassExtension
    {
        public static string PropertyListToString(this object obj)
        {
            var properties = obj.GetType().GetProperties();

            var builder = new StringBuilder();

            foreach (var property in properties)
            {
                if (property.GetIndexParameters().Length != 0) continue;

                builder.AppendLine(property.Name + ": " + property.GetValue(obj));
            }

            return builder.ToString();
        }

        public static void SetProperty(this object obj, string propertyName, object value)
        {
            var property = obj.GetType().GetProperty(propertyName);

            if (property == null) return;
            if (property.PropertyType != value.GetType()) return;
            if (property.GetIndexParameters().Length != 0) return;

            property.SetValue(obj, value);

        }

        public static void SetProperty(this object obj, int index, object value)
        {
            var property = obj.GetType().GetProperties().ElementAtOrDefault(index);

            if (property == null) return;
            if (property.PropertyType != value.GetType()) return;
            if (property.GetIndexParameters().Length != 0) return;

            property.SetValue(obj, value);
        }

        public static object GetProperty(this object obj, string propertyName)
        {
            var property = obj.GetType().GetProperty(propertyName);

            if (property == null) return default(object);
            if (property.GetIndexParameters().Length != 0) return default(object);

            return property.GetValue(obj);
        }

        public static object GetProperty(this object obj, int index)
        {
            var property = obj.GetType().GetProperties().ElementAtOrDefault(index);

            if (property == null) return default(object);
            if (property.GetIndexParameters().Length != 0) return default(object);

            return property.GetValue(obj);
        }
    }
}

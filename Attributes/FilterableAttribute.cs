using System;
using System.Linq;
using System.Reflection;

namespace Jaywapp.Infrastructure.Attributes
{
    [AttributeUsage(AttributeTargets.Field, AllowMultiple = true)]
    public class FilterableAttribute : System.Attribute
    {
        public eFilteringType Type { get; }

        public FilterableAttribute(eFilteringType type)
        {
            Type = type;
        }
    }

    public static class FilterableTargetFieldExt
    {
        public static bool TryGetFilterableTargetField(this Enum value, out FilterableAttribute attr)
        {
            var field = value.GetType().GetField(value.ToString());
            attr = field.GetCustomAttribute<FilterableAttribute>();
            return attr != null;
        }

        public static bool IsTargetField(this Enum value, eFilteringType type)
        {
            var field = value.GetType().GetField(value.ToString());
            var attrs = field.GetCustomAttributes<FilterableAttribute>().ToList();

            foreach (var attr in attrs)
            {
                if (attr.Type == type)
                    return true;
            }

            return false;
        }

    }
}

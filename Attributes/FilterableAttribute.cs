using System;
using System.Linq;
using System.Reflection;

namespace Jaywapp.Infrastructure.Attributes
{
    [AttributeUsage(AttributeTargets.Field, AllowMultiple = true)]
/// <summary>
/// 설명
/// </summary>
    public class FilterableAttribute : System.Attribute
    {
/// <summary>
/// 설명
/// </summary>
        public eFilteringType Type { get; }

        public FilterableAttribute(eFilteringType type)
        {
            Type = type;
        }
    }

/// <summary>
/// 설명
/// </summary>
    public static class FilterableTargetFieldExt
    {
/// <summary>
/// 설명
/// </summary>
/// <param name="value">설명</param>
/// <param name="attr">설명</param>
/// <returns>설명</returns>
        public static bool TryGetFilterableTargetField(this Enum value, out FilterableAttribute attr)
        {
            var field = value.GetType().GetField(value.ToString());
            attr = field.GetCustomAttribute<FilterableAttribute>();
            return attr != null;
        }

/// <summary>
/// 설명
/// </summary>
/// <param name="value">설명</param>
/// <param name="type">설명</param>
/// <returns>설명</returns>
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

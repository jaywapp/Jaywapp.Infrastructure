using System;
using System.Linq;
using System.Reflection;

namespace Jaywapp.Infrastructure.Attributes
{
    [AttributeUsage(AttributeTargets.Field, AllowMultiple = true)]
/// <summary>
/// 사용자 지정 특성을 정의합니다.
/// </summary>
    public class FilterableAttribute : System.Attribute
    {
/// <summary>
/// Type를(을) 가져오거나 설정합니다.
/// </summary>
        public eFilteringType Type { get; }

        public FilterableAttribute(eFilteringType type)
        {
            Type = type;
        }
    }

/// <summary>
/// 확장 메서드를 제공합니다.
/// </summary>
    public static class FilterableTargetFieldExt
    {
/// <summary>
/// Get Filterable Target Field를(을) 시도하고, 성공 여부를 반환합니다.
/// </summary>
/// <param name="value">입력 값</param>
/// <param name="attr">특성</param>
/// <returns>조건을 만족하면 true를 반환합니다.</returns>
        public static bool TryGetFilterableTargetField(this Enum value, out FilterableAttribute attr)
        {
            var field = value.GetType().GetField(value.ToString());
            attr = field.GetCustomAttribute<FilterableAttribute>();
            return attr != null;
        }

/// <summary>
/// Target Field인지 여부를 확인합니다.
/// </summary>
/// <param name="value">입력 값</param>
/// <param name="type">형식</param>
/// <returns>조건을 만족하면 true를 반환합니다.</returns>
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

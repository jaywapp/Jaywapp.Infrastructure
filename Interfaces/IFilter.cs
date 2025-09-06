using System.Collections.Generic;
using System.Linq;

namespace Jaywapp.Infrastructure.Interfaces
{
/// <summary>
/// 설명
/// </summary>
    public interface IFilter
    {
        /// <summary>
        /// 다른 필터와의 연관 관계 연산자
        /// </summary>
        eLogicalOperator Logical { get; }

        /// <summary>
        /// <paramref name="target"/>객체가 해당 필터에 걸리는지 확인합니다.
        /// </summary>
        /// <param name="target"></param>
        /// <returns></returns>
        bool IsFiltered(object target);
    }

/// <summary>
/// 설명
/// </summary>
    public static class FilterExt
    {
        /// <summary>
        /// <paramref name="filters"/>에 대해 <paramref name="target"/>이 걸리는지 확인합니다.
        /// </summary>
        /// <param name="filters"></param>
        /// <param name="target"></param>
        /// <returns></returns>
        public static bool IsFilterd(this IEnumerable<IFilter> filters, object target)
        {
            var first = filters.FirstOrDefault();
            if (first == null)
                return false;

            var result = first.IsFiltered(target);

            foreach (var filter in filters.Skip(1).ToList())
            {
                if (filter.Logical == eLogicalOperator.AND)
                    result &= filter.IsFiltered(target);
                else if (first.Logical == eLogicalOperator.OR)
                    result |= filter.IsFiltered(target);
            }

            return result;
        }
    }
}

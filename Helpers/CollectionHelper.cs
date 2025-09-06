using System;
using System.Collections.Generic;
using System.Text;

namespace Jaywapp.Infrastructure.Helpers
{
/// <summary>
/// 유틸리티 메서드를 제공합니다.
/// </summary>
    public static class CollectionHelper
    {
        /// <summary>
        /// 지정한 시퀀스의 항목들을 컬렉션에 순차적으로 추가합니다.
        /// </summary>
        /// <typeparam name="T">항목 형식</typeparam>
        /// <param name="collection">대상 컬렉션</param>
        /// <param name="items">추가할 항목 시퀀스</param>
        public static void AddRange<T>(this ICollection<T> collection, IEnumerable<T> items)
        {
            foreach (var item in items)
                collection.Add(item);
        }
    }
}

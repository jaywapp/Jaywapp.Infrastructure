using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace Jaywapp.Infrastructure.Helpers
{
    public static class EnumerableHelper
    {
        /// <summary>
        /// <paramref name="collection"/>가 null이거나 빈 목록인지 확인합니다.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="collection"></param>
        /// <returns></returns>
        public static bool IsNullOrEmpty<T>(IEnumerable<T> collection)
        {
            return collection == null || !collection.Any();
        }

        /// <summary>
        /// <typeparamref name="T"/> 목록을 <see cref="ObservableCollection{T}"/>형태로 변환하여 반환합니다.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="enumerable"></param>
        /// <returns></returns>
        public static ObservableCollection<T> ToObservableCollection<T>(this IEnumerable<T> enumerable)
        {
            return new ObservableCollection<T>(enumerable);
        }

        /// <summary>
        /// Item 목록을 다음 Item과 페어링합니다.
        /// </summary>
        /// <typeparam name="TItem"></typeparam>
        /// <param name="items"></param>
        /// <returns></returns>
        public static IEnumerable<(TItem, TItem)> ChainPairing<TItem>(this IEnumerable<TItem> items, bool isCircular = false)
        {
            var itemList = items.ToList();

            if (itemList.Count >= 2)
            {
                for (int idx = 0; idx < itemList.Count - 1; idx++)
                {
                    yield return (itemList[idx], itemList[idx + 1]);
                }

                if (isCircular)
                    yield return (items.Last(), items.First());
            }
        }
    }
}

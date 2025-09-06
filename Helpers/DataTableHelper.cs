using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace Jaywapp.Infrastructure.Helpers
{
/// <summary>
/// 유틸리티 메서드를 제공합니다.
/// </summary>
    public static class DataTableHelper
    {
/// <summary>
/// 컬렉션의 항목을 목록(List)으로 변환합니다.
/// </summary>
/// <param name="collection">컬렉션</param>
/// <returns>변환 결과를 반환합니다.</returns>
        public static List<DataColumn> ToList(this DataColumnCollection collection)
        {
            var columns = new List<DataColumn>();
            foreach (DataColumn c in collection)
                columns.Add(c);

            return columns;
        }

/// <summary>
/// 컬렉션의 항목을 목록(List)으로 변환합니다.
/// </summary>
/// <param name="collection">컬렉션</param>
/// <returns>변환 결과를 반환합니다.</returns>
        public static List<DataRow> ToList(this DataRowCollection collection)
        {
            var rows = new List<DataRow>();
            foreach (DataRow c in collection)
                rows.Add(c);

            return rows;
        }
    }
}

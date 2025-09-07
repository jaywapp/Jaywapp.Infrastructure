using System.Data;
using System.Linq;
using Jaywapp.Infrastructure.Helpers;
using NUnit.Framework;

namespace Jaywapp.Infrastructure.Tests
{
    public class TestDataTableHelper
    {
        [TestCase(new string[] { "A", "B" }, 2)]
        public void DataColumnCollection_ToList_ReturnsAllColumns(string[] names, int expected)
        {
            var dt = new DataTable();
            foreach (var n in names) dt.Columns.Add(n);
            var list = dt.Columns.ToList();
            Assert.That(list.Count, Is.EqualTo(expected));
        }

        [TestCase(new int[] { 1, 2 }, 2)]
        public void DataRowCollection_ToList_ReturnsAllRows(int[] values, int expected)
        {
            var dt = new DataTable();
            dt.Columns.Add("A", typeof(int));
            foreach (var v in values) dt.Rows.Add(v);
            var rows = dt.Rows.ToList();
            Assert.That(rows.Count, Is.EqualTo(expected));
        }
    }
}

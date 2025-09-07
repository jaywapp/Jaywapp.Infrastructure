using System.Data;
using System.Linq;
using Jaywapp.Infrastructure.Helpers;
using NUnit.Framework;

namespace Jaywapp.Infrastructure.Tests
{
    public class TestDataTableHelper
    {
        [Test]
        public void DataColumnCollection_ToList_ReturnsAllColumns()
        {
            var dt = new DataTable();
            dt.Columns.Add("A");
            dt.Columns.Add("B");

            var list = dt.Columns.ToList();
            Assert.That(list.Select(c => c.ColumnName).ToArray(), Is.EqualTo(new[] { "A", "B" }));
        }

        [Test]
        public void DataRowCollection_ToList_ReturnsAllRows()
        {
            var dt = new DataTable();
            dt.Columns.Add("A", typeof(int));
            dt.Rows.Add(1);
            dt.Rows.Add(2);

            var rows = dt.Rows.ToList();
            Assert.That(rows.Count, Is.EqualTo(2));
            Assert.That((int)rows[0][0], Is.EqualTo(1));
            Assert.That((int)rows[1][0], Is.EqualTo(2));
        }
    }
}

using System.Collections.Generic;
using Jaywapp.Infrastructure.Interfaces;

namespace Jaywapp.Infrastructure.Models
{
/// <summary>
/// Filter Group를(을) 제공합니다.
/// </summary>
    public class FilterGroup : IFilter
    {
        #region Properties
        /// <inheritdoc/>
        public eLogicalOperator Logical { get; set; }

        /// <summary>
        /// 하위 필터 목록
        /// </summary>
        public List<IFilter> Children { get; set; } = new List<IFilter>();
        #endregion

        #region Functions
        /// <inheritdoc/>
        public bool IsFiltered(object obj) => Children.IsFilterd(obj);
        #endregion
    }
}

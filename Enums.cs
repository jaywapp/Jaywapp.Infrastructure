using System.ComponentModel;
using Jaywapp.Infrastructure.Attributes;

namespace Jaywapp.Infrastructure
{
    public enum eLogicalOperator
    {
        AND,
        OR,
    }

    public enum eFilteringOperator
    {
        [Filterable(eFilteringType.String)]
        [Filterable(eFilteringType.Number)]
        [Filterable(eFilteringType.Enum)]
        [Description("=")]
        Equal,
        [Filterable(eFilteringType.String)]
        [Filterable(eFilteringType.Number)]
        [Filterable(eFilteringType.Enum)]
        [Description("≠")]
        NotEqual,
        [Filterable(eFilteringType.Number)]
        [Description("＜")]
        LessThan,
        [Filterable(eFilteringType.Number)]
        [Description("≤")]
        LessEqual,
        [Filterable(eFilteringType.Number)]
        [Description("＞")]
        GreaterThan,
        [Filterable(eFilteringType.Number)]
        [Description("≥")]
        GreaterEqual,
        [Filterable(eFilteringType.String)]
        [Filterable(eFilteringType.Number)]
        [Filterable(eFilteringType.Enum)]
        [Description("정규식")]
        MatchRegex,
        [Filterable(eFilteringType.String)]
        [Filterable(eFilteringType.Number)]
        [Filterable(eFilteringType.Enum)]
        [Description("포함")]
        Contains,
        [Filterable(eFilteringType.String)]
        [Filterable(eFilteringType.Number)]
        [Filterable(eFilteringType.Enum)]
        [Description("미포함")]
        NotContains,
        [Filterable(eFilteringType.String)]
        [Filterable(eFilteringType.Number)]
        [Filterable(eFilteringType.Enum)]
        [Description("시작 문자열")]
        StartsWith,
        [Filterable(eFilteringType.String)]
        [Filterable(eFilteringType.Number)]
        [Filterable(eFilteringType.Enum)]
        [Description("끝 문자열")]
        EndsWith,
    }

    public enum eFilteringType
    {
        String,
        Enum,
        Number,
    }
}

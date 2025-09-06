using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using Jaywapp.Infrastructure.Helpers;
using System.Windows.Data;

namespace Jaywapp.Infrastructure.Converters
{
/// <summary>
/// 설명
/// </summary>
    public class EnumDescConverter : IValueConverter
    {
        private Type _currentType;

/// <summary>
/// 설명
/// </summary>
/// <param name="value">설명</param>
/// <param name="targetType">설명</param>
/// <param name="parameter">설명</param>
/// <param name="culture">설명</param>
/// <returns>설명</returns>
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (!(value is Enum target))
                return null;

            _currentType = target.GetType();

            return target.GetDescriptionOrToString();
        }

/// <summary>
/// 설명
/// </summary>
/// <param name="value">설명</param>
/// <param name="targetType">설명</param>
/// <param name="parameter">설명</param>
/// <param name="culture">설명</param>
/// <returns>설명</returns>
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (!(value is string target)
                || _currentType == null
                || !EnumHelper.TryParseValueFromDescription(target, _currentType, out object parsed))
                return null;

            return parsed;
        }
    }

/// <summary>
/// 설명
/// </summary>
    public class EnumDescConverter<TEnum> : IValueConverter
        where TEnum : struct, IConvertible
    {
/// <summary>
/// 설명
/// </summary>
/// <param name="value">설명</param>
/// <param name="targetType">설명</param>
/// <param name="parameter">설명</param>
/// <param name="culture">설명</param>
/// <returns>설명</returns>
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (!(value is Enum target))
                return null;

            return target.GetDescriptionOrToString();
        }

/// <summary>
/// 설명
/// </summary>
/// <param name="value">설명</param>
/// <param name="targetType">설명</param>
/// <param name="parameter">설명</param>
/// <param name="culture">설명</param>
/// <returns>설명</returns>
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (!(value is string target) || !EnumHelper.TryParseValueFromDescription(target, out TEnum parsed))
                return null;

            return parsed;
        }
    }
}
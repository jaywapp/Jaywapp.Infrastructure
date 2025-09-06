using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using Jaywapp.Infrastructure.Helpers;
using System.Windows.Data;

namespace Jaywapp.Infrastructure.Converters
{
/// <summary>
/// 값 변환기를 제공합니다.
/// </summary>
    public class EnumDescConverter : IValueConverter
    {
        private Type _currentType;

/// <summary>
/// 값을 변환합니다.
/// </summary>
/// <param name="value">입력 값</param>
/// <param name="targetType">대상 형식</param>
/// <param name="parameter">매개 변수</param>
/// <param name="culture">문화권 정보</param>
/// <returns>변환 결과를 반환합니다.</returns>
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (!(value is Enum target))
                return null;

            _currentType = target.GetType();

            return target.GetDescriptionOrToString();
        }

/// <summary>
/// 대상 값을 원본으로 변환합니다.
/// </summary>
/// <param name="value">입력 값</param>
/// <param name="targetType">대상 형식</param>
/// <param name="parameter">매개 변수</param>
/// <param name="culture">문화권 정보</param>
/// <returns>변환 결과를 반환합니다.</returns>
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
/// 값 변환기를 제공합니다.
/// </summary>
    public class EnumDescConverter<TEnum> : IValueConverter
        where TEnum : struct, IConvertible
    {
/// <summary>
/// 값을 변환합니다.
/// </summary>
/// <param name="value">입력 값</param>
/// <param name="targetType">대상 형식</param>
/// <param name="parameter">매개 변수</param>
/// <param name="culture">문화권 정보</param>
/// <returns>변환 결과를 반환합니다.</returns>
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (!(value is Enum target))
                return null;

            return target.GetDescriptionOrToString();
        }

/// <summary>
/// 대상 값을 원본으로 변환합니다.
/// </summary>
/// <param name="value">입력 값</param>
/// <param name="targetType">대상 형식</param>
/// <param name="parameter">매개 변수</param>
/// <param name="culture">문화권 정보</param>
/// <returns>변환 결과를 반환합니다.</returns>
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (!(value is string target) || !EnumHelper.TryParseValueFromDescription(target, out TEnum parsed))
                return null;

            return parsed;
        }
    }
}
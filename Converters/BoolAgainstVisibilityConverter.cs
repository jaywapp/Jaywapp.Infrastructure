using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using System.Windows.Data;
using System.Windows;

namespace Jaywapp.Infrastructure.Converters
{
/// <summary>
/// 값 변환기를 제공합니다.
/// </summary>
    public class BoolAgainstVisibilityConverter : IValueConverter
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
            if (value is bool boolean)
            {
                if (boolean)
                    return Visibility.Collapsed;
                else
                    return Visibility.Visible;
            }

            return Binding.DoNothing;
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
            return Binding.DoNothing;
        }
    }
}

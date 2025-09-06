using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using System.Windows.Data;
using System.Windows;

namespace Jaywapp.Infrastructure.Converters
{
/// <summary>
/// 설명
/// </summary>
    public class BoolVisibilityConverter : IValueConverter
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
            if (value is bool boolean)
            {
                if (boolean)
                    return Visibility.Visible;
                else
                    return Visibility.Collapsed;
            }

            return Binding.DoNothing;
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
            return Binding.DoNothing;
        }
    }
}

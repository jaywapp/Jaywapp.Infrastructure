using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Media;

namespace Jaywapp.Infrastructure.Helpers
{
/// <summary>
/// 유틸리티 메서드를 제공합니다.
/// </summary>
    public static class ColorHelper
    {
/// <summary>
/// Color Name를(을) 가져옵니다.
/// </summary>
/// <param name="color">색</param>
/// <returns>결과를 반환합니다.</returns>
        public static string GetColorName(this Color color)
        {
            Type colors = typeof(Colors);
            foreach (var prop in colors.GetProperties())
            {
                if (((Color)prop.GetValue(null, null)) == color)
                    return prop.Name;
            }

            return color.ToString();
        }

/// <summary>
/// Color로 변환합니다.
/// </summary>
/// <param name="str">문자열</param>
/// <param name="null">매개 변수</param>
/// <returns>변환 결과를 반환합니다.</returns>
        public static Color ToColor(this string str, Color? defaultColor = null)
        {
            try
            {
                if (!string.IsNullOrEmpty(str))
                    return (Color)ColorConverter.ConvertFromString(str);
            }
            catch { }

            return defaultColor ?? Colors.Black;
        }

/// <summary>
/// Convert Color를(을) 시도하고, 성공 여부를 반환합니다.
/// </summary>
/// <param name="str">문자열</param>
/// <param name="color">색</param>
/// <returns>조건을 만족하면 true를 반환합니다.</returns>
        public static bool TryConvertColor(this string str, out Color color)
        {
            color = default;

            try
            {
                if (!string.IsNullOrEmpty(str))
                {
                    color = (Color)ColorConverter.ConvertFromString(str);
                    return true;
                }
            }
            catch { }

            return false;
        }
    }
}

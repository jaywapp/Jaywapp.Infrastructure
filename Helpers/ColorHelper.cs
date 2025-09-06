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
/// 입력 색상과 일치하는 미리 정의된 색상 이름을 반환합니다. 없으면 색상 문자열을 반환합니다.
/// </summary>
/// <param name="color">색상 값</param>
/// <returns>색상 이름 또는 색상 문자열</returns>
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
/// 문자열 표현을 Color로 변환합니다. 실패 시 기본 색을 반환합니다.
/// </summary>
/// <param name="str">색상 문자열</param>
/// <param name="defaultColor">파싱 실패 시 반환할 기본 색</param>
/// <returns>변환된 색상 값</returns>
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
/// 문자열을 Color로 변환을 시도합니다.
/// </summary>
/// <param name="str">색상 문자열</param>
/// <param name="color">변환 성공 시 결과 색상</param>
/// <returns>성공하면 true, 실패하면 false</returns>
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


using System.Diagnostics;
using System.Globalization;
/**
* 自定义的颜色RGB转换器 将Float类型的RGB转换成整数
*/
namespace MauiBase.Converters;
public class FloatToIntConverter : IValueConverter
{
    public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
    {
        //Debug.WriteLine($"value:{value} type:{targetType} parameter:{parameter} CultureInfo:{culture}");

        if (!float.TryParse((string)parameter, out float multiplier))
            multiplier = 1;

        return (int)Math.Round(multiplier * (float)value);
    }

    public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
    {
        Debug.WriteLine($"ConvertBack:value:{value} type:{targetType} parameter:{parameter} CultureInfo:{culture}");
        if (!float.TryParse(parameter as string, out float divider))
            divider = 1;
        return ((float)(int)value) / divider;
    }
}
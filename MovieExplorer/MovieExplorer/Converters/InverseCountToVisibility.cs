using System;
using System.Globalization;
using Windows.UI.Xaml.Data;

namespace MovieExplorer.Converters
{
    public class InverseCountToVisibility : IValueConverter
    {
        object IValueConverter.Convert(object value, Type targetType, object parameter, string language)
        {
            if (int.Parse(value.ToString()) == 0)
            {
                return "Visible";
            }
            else
            {
                return "Collapsed";
            }
        }

        object IValueConverter.ConvertBack(object value, Type targetType, object parameter, string language)
        {
            throw new NotImplementedException();
        }
    }
}

using System;
using Windows.UI.Xaml.Data;

namespace MovieExplorer.Converters
{
    public class TextToVisibility : IValueConverter
    {
        object IValueConverter.Convert(object value, Type targetType, object parameter, string language)
        {
            if (((string)value).Equals(""))
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

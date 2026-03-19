using System;
using Microsoft.UI.Xaml.Data;

namespace Kil0bitSystemMonitor.Helpers
{
    public class StringFormatConverter : IValueConverter
    {
        public object Convert(object? value, Type targetType, object? parameter, string language)
        {
            if (parameter != null)
            {
                string format = parameter.ToString() ?? "{0}";
                return string.Format(format, value ?? string.Empty);
            }
            return value?.ToString() ?? string.Empty;
        }

        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            throw new NotImplementedException();
        }
    }
}

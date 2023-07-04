using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using System.Windows.Media;

namespace ColorsPicker.Converters
{
    class ColorToSolidColorBrushConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is Color color)
            {
                return new SolidColorBrush(color);
            }
            return new SolidColorBrush();
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return new object();
        }
    }
}

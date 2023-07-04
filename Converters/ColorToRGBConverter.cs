using System;
using System.Collections.Generic;
using System.Windows.Media;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace ColorsPicker.Converters
{
    class ColorToRGBConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is Color color)
            {
                return $"({color.R},{color.G},{color.B})";
            }
            return color;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return new object();
        }
    }
}

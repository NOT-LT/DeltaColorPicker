using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using System.Windows.Media;

namespace DeltaColorPicker.Converters
{
    class ColorToHexConverter : IValueConverter
    {

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is Color color)
            {
                //var sRGB = color.ToString();
                var Hex = "#" + color.R.ToString("X2") + color.G.ToString("X2") + color.B.ToString("X2");
                return Hex;
            }
            return value;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return new object();
        }

    }

}

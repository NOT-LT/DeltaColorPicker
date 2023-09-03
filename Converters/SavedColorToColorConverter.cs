using DeltaColorsPicker.Models;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using System.Windows.Media;
using ColorConverter = System.Windows.Media.ColorConverter;

namespace DeltaColorsPicker.Converters
{
    class SavedColorToColorConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is SavedColor)
            {
                return ((SavedColor)value).Color;
            }
            return 0;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is System.Windows.Media.Color)
            {
                var color = (System.Windows.Media.Color)value;
                return new SavedColor(color, $"{ color.R }, { color.G}, { color.B}", $"#{color.R:X2}{color.G:X2}{color.B:X2}");
            }
            return 0;
        }
    }
}

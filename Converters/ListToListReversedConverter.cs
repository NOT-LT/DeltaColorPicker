using DeltaColorPicker.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace DeltaColorPicker.Converters
{
    class ListToListReversedConverter : IValueConverter
    {

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is ObservableCollection<SavedColor>)
            {
                ObservableCollection<SavedColor> AllColorsList = (ObservableCollection<SavedColor>)value;
                return AllColorsList.Reverse();
            }
            return new object();
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is ObservableCollection<SavedColor>)
            {
                ObservableCollection<SavedColor> AllColorsList = (ObservableCollection<SavedColor>)value;
                return AllColorsList.Reverse();
            }
            return new object();

        }
    }

}

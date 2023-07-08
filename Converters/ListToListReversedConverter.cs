using DeltaColorsPicker.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace DeltaColorsPicker.Converters
{
    class ListToListReversedConverter : IValueConverter
    {

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            ObservableCollection<SavedColor> AllColorsList = (ObservableCollection<SavedColor>)value;
            return AllColorsList.Reverse();
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            ObservableCollection<SavedColor> AllColorsList = (ObservableCollection<SavedColor>)value;
            return AllColorsList.Reverse();
        }
    }

}

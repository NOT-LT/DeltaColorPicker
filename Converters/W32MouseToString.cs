﻿using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using static DeltaColorsPicker.ViewModels.ColorEyedropperViewModel;

namespace DeltaColorsPicker.Converters
{
    class W32MouseToString : IValueConverter
    {


        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is Win32Point win32Point)
            {
                return $"[{win32Point.X.ToString()},{win32Point.Y.ToString()}]";
            }
            else
            {
                return "";
            }

        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return "";
        }
    }

}

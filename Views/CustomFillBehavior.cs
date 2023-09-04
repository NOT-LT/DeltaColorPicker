using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;

namespace DeltaColorsPicker.Views
{
    public class CustomFillBehavior
    {
        public static readonly DependencyProperty FillColorProperty =
            DependencyProperty.RegisterAttached("FillColor", typeof(Brush), typeof(CustomFillBehavior));

        public static void SetFillColor(DependencyObject element, Brush value)
        {
            element.SetValue(FillColorProperty, value);
        }

        public static Brush GetFillColor(DependencyObject element)
        {
            return (Brush)element.GetValue(FillColorProperty);
        }
    }
}

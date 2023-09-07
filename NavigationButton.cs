using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace DeltaColorPicker
{

    public class NavigationButton : ListBoxItem
    {
        static NavigationButton()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(NavigationButton), new FrameworkPropertyMetadata(typeof(NavigationButton)));
        }




        public Uri NavigationLink
        {
            get { return (Uri)GetValue(NavigationLinkProperty); }
            set { SetValue(NavigationLinkProperty, value); }
        }

        // Using a DependencyProperty as the backing store for NavigationLink.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty NavigationLinkProperty =
            DependencyProperty.Register("NavigationLink", typeof(Uri), typeof(NavigationButton), new PropertyMetadata(null));




        public Geometry Icon
        {
            get { return (Geometry)GetValue(IconProperty); }
            set { SetValue(IconProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Icon.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty IconProperty =
            DependencyProperty.Register("Icon", typeof(Geometry), typeof(NavigationButton), new PropertyMetadata(null));




    }

}

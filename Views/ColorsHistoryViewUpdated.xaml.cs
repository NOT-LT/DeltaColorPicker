using DeltaColorsPicker.Converters;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Shapes;
using Brushes = System.Windows.Media.Brushes;
using Color = System.Windows.Media.Color;
using Path = System.Windows.Shapes.Path;

namespace DeltaColorsPicker.Views
{
    /// <summary>
    /// Interaction logic for PointerColorView.xaml
    /// </summary>
    public partial class ColorsHistoryViewUpdated : Page
    {
        public ColorsHistoryViewUpdated()
        {
            InitializeComponent();
            //tooltip.Closed += tooltip_Closed;
        }



        private void ColorBorder_MouseDown(object sender, MouseButtonEventArgs e)
        {
            try
            {
                var border = (Border)(sender);
                Clipboard.SetText("#" + border.Background.ToString().Substring(3, 6)); // RGBA TO RGB in Hexdecimal
            }
            catch (Exception) { }

           

        }





    }
}

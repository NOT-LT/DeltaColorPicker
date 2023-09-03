using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
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
using Rectangle = System.Windows.Shapes.Rectangle;

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
        }

        private void Rectangle_MouseDown(object sender, MouseButtonEventArgs e)
        {
            var rect = (Rectangle)(sender);
            Clipboard.SetText("#" + rect.Fill.ToString().Substring(3, 6)); // RGBA TO RGB in Hexdecimal
        }

        //private async void HEX_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        //{
        //    TextBlock textBlock = (TextBlock)sender;
        //    if (textBlock != null)
        //    {
        //        var hex = textBlock.Text;
        //        Clipboard.SetText(hex);
        //        textBlock.Text = "Copied";
        //        await Task.Delay(1000);
        //        textBlock.Text = hex;
        //    }

        //}

        //private async void RGB_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        //{
        //    TextBlock textBlock = (TextBlock)sender;
        //    if (textBlock != null)
        //    {
        //        var rgb = textBlock.Text;
        //        Clipboard.SetText(rgb);
        //        textBlock.Text = "Copied";
        //        await Task.Delay(1000);
        //        textBlock.Text = rgb;
        //    }

        //}

    }
}

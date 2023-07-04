using System;
using System.Collections.Generic;
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
using System.Threading;

namespace ColorsPicker.Views
{
    /// <summary>
    /// Interaction logic for PointerColorView.xaml
    /// </summary>
    public partial class PointerColorView : Page
    {
        public PointerColorView()
        {
            InitializeComponent();
        }

        private async void HEX_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            TextBlock textBlock = (TextBlock)sender;
            if (textBlock != null)
            {
                var hex = textBlock.Text;
                Clipboard.SetText(hex);
                textBlock.Text = "Copied";
                await Task.Delay(1000);
                textBlock.Text = hex;
            }

        }

        private async void RGB_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            TextBlock textBlock = (TextBlock)sender;
            if (textBlock != null)
            {
                var rgb = textBlock.Text;
                Clipboard.SetText(rgb);
                textBlock.Text = "Copied";
                await Task.Delay(1000);
                textBlock.Text = rgb;
            }

        }

    }
}

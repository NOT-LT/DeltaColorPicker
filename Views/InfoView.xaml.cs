using System;
using System.Collections.Generic;
using System.Diagnostics;
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

namespace DeltaColorsPicker.Views
{
    /// <summary>
    /// Interaction logic for InfoView.xaml
    /// </summary>
    public partial class InfoView : Page
    {
        public InfoView()
        {
            InitializeComponent();
        }

        private void GithubIcon_MouseDown(object sender, MouseButtonEventArgs e)
        {
            Process.Start(new ProcessStartInfo() { UseShellExecute = true, FileName = "https://github.com/NOT-LT" }); ;
        }

        private void IGIcon_MouseDown(object sender, MouseButtonEventArgs e)
        {
            Process.Start(new ProcessStartInfo() { UseShellExecute = true, FileName = "https://instagram.com/zdlk" }); ;
        }

        private void TwitterIcon_MouseDown(object sender, MouseButtonEventArgs e)
        {
            Process.Start(new ProcessStartInfo() { UseShellExecute = true, FileName = "https://twitter.com/zdllk" }); ;
        }

        private void CoffeeIcon_MouseDown(object sender, MouseButtonEventArgs e)
        {
            Process.Start(new ProcessStartInfo() { UseShellExecute = true, FileName = "https://buymeacoffee.com/taljamri" }); ;
        }

        private void GithubProjectPageIcon_MouseDown(object sender, MouseButtonEventArgs e)
        {
            Process.Start(new ProcessStartInfo() { UseShellExecute = true, FileName= "https://github.com/NOT-LT/DeltaColorPicker" });
        }
    }
}

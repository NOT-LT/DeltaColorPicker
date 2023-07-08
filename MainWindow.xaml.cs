using DeltaColorsPicker.ViewModels;
using DeltaColorsPicker.Views;
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
using System.Windows.Threading;

namespace DeltaColorsPicker
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        ColorEyedropperView colorEyedropperView;
        ColorPickerView colorPickerView;
        ColorsHistoryView colorsHistoryView;

        ColorEyedropperViewModel colorEyedropperViewModel;
        ColorPickerViewModel colorPickerViewModel;
        ColorsHistoryViewModel colorsHistoryViewModel;

        public MainWindow()
        {
            
            colorEyedropperViewModel = new ColorEyedropperViewModel(); colorEyedropperView = new ColorEyedropperView();
            colorEyedropperView.DataContext = colorEyedropperViewModel;
            colorPickerViewModel = new ColorPickerViewModel(); colorPickerView = new ColorPickerView();
            colorPickerView.DataContext = colorPickerViewModel;
            colorsHistoryViewModel = new ColorsHistoryViewModel(); colorsHistoryView = new ColorsHistoryView();
            colorsHistoryView.DataContext = colorsHistoryViewModel;
            InitializeComponent();
            ColorEyedropperPageButton.IsSelected = true;

        }

        private void ColorEyedropperPageButton_Selected(object sender, RoutedEventArgs e)
        {
            //var btn = (NavigationButton)sender;
            NavFrame.Navigate(colorEyedropperView);
        }

        private void ColorPickerPageButton_Selected(object sender, RoutedEventArgs e)
        {
            //var btn = (NavigationButton)sender;
            NavFrame.Navigate(colorPickerView);
        }


        private void ColorsHistoryButton_Selected(object sender, RoutedEventArgs e)
        {
            //var btn = (NavigationButton)sender;
            colorsHistoryViewModel = new ColorsHistoryViewModel();
            colorsHistoryView = new ColorsHistoryView();
            colorsHistoryView.DataContext = colorsHistoryViewModel;
            colorsHistoryViewModel.Update();
            NavFrame.Navigate(colorsHistoryView);
        }

        private void InfoPageHButton_Selected(object sender, RoutedEventArgs e)
        {
            var btn = (NavigationButton)sender;
            NavFrame.Navigate(btn?.NavigationLink);
        }

       
    }

}

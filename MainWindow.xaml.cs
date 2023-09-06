using DeltaColorsPicker.DataStore;
using DeltaColorsPicker.ViewModels;
using DeltaColorsPicker.Views;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
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
        ColorsHistoryViewUpdated colorsHistoryViewUpdated;

        ColorEyedropperViewModel colorEyedropperViewModel;
        ColorPickerViewModel colorPickerViewModel;
        ColorsHistoryViewModel colorsHistoryViewModel;


        LowLevelKeyboardHook keyboardHook;

        public MainWindow()
        {
      

            colorEyedropperViewModel = new ColorEyedropperViewModel(); colorEyedropperView = new ColorEyedropperView();
            colorEyedropperView.DataContext = colorEyedropperViewModel;
            colorPickerViewModel = new ColorPickerViewModel(); colorPickerView = new ColorPickerView();
            colorPickerView.DataContext = colorPickerViewModel;
            colorsHistoryViewModel = new ColorsHistoryViewModel(); colorsHistoryView = new ColorsHistoryView();
            colorsHistoryView.DataContext = colorsHistoryViewModel;
            colorsHistoryViewUpdated = new ColorsHistoryViewUpdated();
            colorsHistoryViewUpdated.DataContext = colorsHistoryViewModel;

            InitializeComponent();
            ColorEyedropperPageButton.IsSelected = true;

            Closing += MainWindow_Closing;

            keyboardHook = new LowLevelKeyboardHook();
            keyboardHook.KeyPressed += colorEyedropperViewModel.KeyboardHook_KeyPressed;
            keyboardHook.Install();
            SideFrame.Navigate(colorsHistoryViewUpdated);
        }

        private void MainWindow_Closing(object? sender, System.ComponentModel.CancelEventArgs e)
        {
            keyboardHook?.Uninstall();
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
            //colorsHistoryViewModel = new ColorsHistoryViewModel();
            //colorsHistoryView = new ColorsHistoryView();
            //colorsHistoryView.DataContext = colorsHistoryViewModel;
            //colorsHistoryViewModel.Update();
            NavFrame.Navigate(colorsHistoryView);

           
        }

        private void InfoPageHButton_Selected(object sender, RoutedEventArgs e)
        {
            var btn = (NavigationButton)sender;
            NavFrame.Navigate(btn?.NavigationLink);
        }

    }

}

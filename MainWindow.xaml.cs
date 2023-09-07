using DeltaColorPicker.DataStore;
using DeltaColorPicker.ViewModels;
using DeltaColorPicker.Views;
using System;
using System.Windows;

namespace DeltaColorPicker
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private Lazy<ColorEyedropperView> colorEyedropperView = new Lazy<ColorEyedropperView>(() => new ColorEyedropperView());
        private Lazy<ColorPickerView> colorPickerView = new Lazy<ColorPickerView>(() => new ColorPickerView());
        private Lazy<ColorsHistoryView> colorsHistoryView = new Lazy<ColorsHistoryView>(() => new ColorsHistoryView());
        private Lazy<ColorsHistoryViewUpdated> colorsHistoryViewUpdated = new Lazy<ColorsHistoryViewUpdated>(() => new ColorsHistoryViewUpdated());
        private Lazy<InfoView> infoView = new Lazy<InfoView>(() => new InfoView());

        private Lazy<ColorEyedropperViewModel> colorEyedropperViewModel = new Lazy<ColorEyedropperViewModel>(() => new ColorEyedropperViewModel());
        private Lazy<ColorPickerViewModel> colorPickerViewModel = new Lazy<ColorPickerViewModel>(() => new ColorPickerViewModel());
        private Lazy<ColorsHistoryViewModel> colorsHistoryViewModel = new Lazy<ColorsHistoryViewModel>(() => new ColorsHistoryViewModel());

        private LowLevelKeyboardHook keyboardHook;

        public MainWindow()
        {
            InitializeComponent();
            ColorEyedropperPageButton.IsSelected = true;       

            Closing += MainWindow_Closing;
            colorsHistoryViewUpdated.Value.DataContext = colorsHistoryViewModel.Value;

            keyboardHook = new LowLevelKeyboardHook();
            WeakEventManager<LowLevelKeyboardHook, KeyPressedEventArgs>.AddHandler(keyboardHook, "KeyPressed", colorEyedropperViewModel.Value.KeyboardHook_KeyPressed);
            keyboardHook.Install();
            SideFrame.Navigate(colorsHistoryViewUpdated.Value);
        }

        private void MainWindow_Closing(object? sender, System.ComponentModel.CancelEventArgs e)
        {
            keyboardHook?.Uninstall();
        }

        private void ColorEyedropperPageButton_Selected(object sender, RoutedEventArgs e)
        {
            colorEyedropperView.Value.DataContext = colorEyedropperViewModel.Value;
            NavFrame.Navigate(colorEyedropperView.Value);
        }

        private void ColorPickerPageButton_Selected(object sender, RoutedEventArgs e)
        {
            colorPickerView.Value.DataContext = colorPickerViewModel.Value;
            NavFrame.Navigate(colorPickerView.Value);
        }

        private void ColorsHistoryButton_Selected(object sender, RoutedEventArgs e)
        {
            colorsHistoryView.Value.DataContext = colorsHistoryViewModel.Value;
            NavFrame.Navigate(colorsHistoryView.Value);
        }

        private void InfoPageHButton_Selected(object sender, RoutedEventArgs e)
        {
            colorsHistoryViewUpdated.Value.DataContext = colorsHistoryViewModel.Value;
            NavFrame.Navigate(infoView.Value);
        }
    }
}
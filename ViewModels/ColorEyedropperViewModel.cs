using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media.Imaging;
using System.Windows.Threading;
using CommunityToolkit.Mvvm.ComponentModel;
using DeltaColorPicker.DataStore;
using DeltaColorPicker.Models;

namespace DeltaColorPicker.ViewModels
{
    class ColorEyedropperViewModel : ObservableObject, IDisposable
    {

        public async void KeyboardHook_KeyPressed(object sender, KeyPressedEventArgs e)
        {
            //MessageBox.Show(e.Key.GetHashCode().ToString());
            if (e.Key == Key.Space && Keyboard.Modifiers == ModifierKeys.Control)
            {
                try
                {
                    using (SelectedColor = new SavedColor(SavedColor.Color, SavedColor.RGB, SavedColor.HEX))
                    {
                        ColorsDB.AddColor_Select(SelectedColor);
                        Clipboard.SetText(SelectedColor.HEX);
                        CaptureBorderBackground = System.Windows.Media.Color.FromRgb(58, 166, 56);
                        await Task.Delay(750);
                        CaptureBorderBackground = System.Windows.Media.Color.FromRgb(99, 99, 98);
                    }

                }
                catch { }

            }
        }

        private SavedColor? savedColor;
        public SavedColor? SavedColor
        {
            get { return savedColor; }
            set { SetProperty(ref savedColor, value); }
        }

        private SavedColor? selectedColor;
        public SavedColor? SelectedColor
        {
            get { return selectedColor; }
            set { SetProperty(ref selectedColor, value); }
        }

        private BitmapImage? bitmapImage;
        public BitmapImage? BitmapImage
        {
            get { return bitmapImage; }
            set { SetProperty(ref bitmapImage, value); }
        }

        private System.Windows.Media.Color captureBorderBackground;
        public System.Windows.Media.Color CaptureBorderBackground
        {
            get { return captureBorderBackground; }
            set { SetProperty(ref captureBorderBackground, value); }
        }

        private Win32Point w32Mouse_;
        public Win32Point W32Mouse_
        {
            get { return w32Mouse_; }
            set { w32Mouse_ = value; OnPropertyChanged(nameof(W32Mouse_)); }
        }

        private DispatcherTimer timer;
        private System.Drawing.Color color;
        private Win32Point w32Mouse = new Win32Point();

        [DllImport("user32.dll")]
        [return: MarshalAs(UnmanagedType.Bool)]
        internal static extern bool GetCursorPos(ref Win32Point pt);

        [StructLayout(LayoutKind.Sequential)]
        internal struct Win32Point
        {
            public int X;
            public int Y;
        }

        public ColorEyedropperViewModel()
        {
            SavedColor = new SavedColor(ColorsDB.CurrentColorSelect.Color, ColorsDB.CurrentColorSelect.RGB, ColorsDB.CurrentColorSelect.HEX);
            SelectedColor = new SavedColor(ColorsDB.CurrentColorSelect.Color, ColorsDB.CurrentColorSelect.RGB, ColorsDB.CurrentColorSelect.HEX);

            CaptureBorderBackground = System.Windows.Media.Color.FromRgb(99, 99, 98);

            timer = new DispatcherTimer();
            timer.Interval = TimeSpan.FromSeconds(0.048);
            timer.Tick += Timer_Tick;
            timer.Start();
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            Task.Run(() => GetHoverColor());
        }

        public void GetHoverColor()
        {
            try
            {
                GetCursorPos(ref w32Mouse);
                W32Mouse_ = new Win32Point() { X = w32Mouse.X, Y = w32Mouse.Y };

                using (var bp = new Bitmap(45, 45))
                {
                    using (var graphics = Graphics.FromImage(bp))
                    {
                        graphics.CopyFromScreen(new System.Drawing.Point(w32Mouse.X - 45 / 2, w32Mouse.Y - 45 / 2), new System.Drawing.Point(0, 0), bp.Size, CopyPixelOperation.SourceCopy);
                    }

                    color = bp.GetPixel(45 / 2, 45 / 2);
                    SavedColor = new SavedColor(System.Windows.Media.Color.FromArgb(color.A, color.R, color.G, color.B), $"({color.R},{color.G},{color.B})", $"#{color.R:X2}{color.G:X2}{color.B:X2}");
                    BitmapImage = BitmapToBitmapImage(bp);

                }
                Dispose();
            }
            catch (Exception)
            {
                // Handle exceptions appropriately
            }
        }

        private BitmapImage BitmapToBitmapImage(Bitmap bitmap)
        {
            using (var memoryStream = new MemoryStream())
            {
                bitmap.Save(memoryStream, ImageFormat.Png);
                memoryStream.Position = 0;

                var bitmapImage = new BitmapImage();
                bitmapImage.BeginInit();
                bitmapImage.CacheOption = BitmapCacheOption.OnLoad;
                bitmapImage.StreamSource = memoryStream;
                bitmapImage.EndInit();
                bitmapImage.Freeze();

                return bitmapImage;
            }
        }

        public void Dispose()
        {
            timer.Tick -= (_, _) => GetHoverColor();
            //GC.Collect();
        }
    }
}
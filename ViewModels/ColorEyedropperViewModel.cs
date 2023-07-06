using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;
using System.Windows;
using System.Windows.Media.Imaging;
using System.Drawing;
using CommunityToolkit.Mvvm.ComponentModel;
using ColorsPicker.Models;
using System.Threading;
using System.Windows.Threading;
using System.Timers;
using CommunityToolkit.Mvvm.Input;
using System.Windows.Input;
using System.Text.Json.Serialization.Metadata;
using System.ComponentModel;
using ColorsPicker.DataStore;

namespace ColorsPicker.ViewModels
{
    class ColorEyedropperViewModel : ObservableObject, IDisposable
    {

        DispatcherTimer timer = new DispatcherTimer();

        public ColorEyedropperViewModel()
        {
            SavedColor  = new SavedColor(ColorsDB.CurrentColorSelect.Color, ColorsDB.CurrentColorSelect.RGB, ColorsDB.CurrentColorSelect.HEX, ColorsDB.CurrentColorSelect.SavingDateTime);
            SelectedColor = new SavedColor(ColorsDB.CurrentColorSelect.Color, ColorsDB.CurrentColorSelect.RGB, ColorsDB.CurrentColorSelect.HEX, ColorsDB.CurrentColorSelect.SavingDateTime);
            timer.Interval = TimeSpan.FromSeconds(0.01);
            timer.Tick += (s, e) => GetHoverColor();
            timer.Start();
        }

        public ICommand KeyDownCommand { get { return new RelayCommand<KeyEventArgs>(KeyDownExecute); } }
        private void KeyDownExecute(object? parameter)
        {
            if (Keyboard.IsKeyDown(Key.X) && Keyboard.IsKeyDown(Key.LeftAlt))
            {
                SelectedColor = new SavedColor(SavedColor.Color, SavedColor.RGB, SavedColor.HEX, DateTime.Now);
                ColorsDB.AddColor_Select(SelectedColor);
            }
        }

        private SavedColor savedColor;
        public SavedColor SavedColor
        {
            get { return savedColor; }
            set { savedColor = value; OnPropertyChanged(nameof(SavedColor)); }
        }

        private SavedColor selectedColor;
        public SavedColor SelectedColor
        {
            get { return selectedColor; }
            set { selectedColor = value; OnPropertyChanged(nameof(SelectedColor)); }
        }

        private BitmapSource bitmapSource;
        public BitmapSource BitmapSource
        {
            get { return bitmapSource; }
            set { bitmapSource = value; OnPropertyChanged(nameof(BitmapSource)); }
        }

        private Graphics graphics;
        private int captureSize = 80;
        private Bitmap bitmap;
        private Image ScreenImage;

        private Win32Point w32Mouse_;
        public Win32Point W32Mouse_
        {
            get { return w32Mouse_; }
            set { w32Mouse_ = value; OnPropertyChanged(nameof(W32Mouse_)); }
        }

        [DllImport("user32.dll")]
        [return: MarshalAs(UnmanagedType.Bool)]
        internal static extern bool GetCursorPos(ref Win32Point pt);

        [StructLayout(LayoutKind.Sequential)]
        internal struct Win32Point
        {
            public Int32 X;
            public Int32 Y;
        };
        public void GetHoverColor()
		{
            try
            {
                var w32Mouse = new Win32Point();
                GetCursorPos(ref w32Mouse);
                W32Mouse_ = new Win32Point() { X= w32Mouse.X, Y=w32Mouse.Y};
                bitmap = new Bitmap(captureSize, captureSize);
                graphics = Graphics.FromImage(bitmap);
                graphics.CopyFromScreen(
                    new System.Drawing.Point(w32Mouse.X - captureSize / 2, w32Mouse.Y - captureSize / 2),
                    new System.Drawing.Point(0, 0),
                    new System.Drawing.Size(captureSize, captureSize));
                var color = bitmap.GetPixel(captureSize / 2, captureSize / 2);

                 BitmapSource = System.Windows.Interop.Imaging.CreateBitmapSourceFromHBitmap(
                    bitmap.GetHbitmap(),
                    IntPtr.Zero,
                    System.Windows.Int32Rect.Empty,
                    BitmapSizeOptions.FromEmptyOptions());

                SavedColor = new SavedColor(System.Windows.Media.Color.FromArgb(color.A, color.R, color.G, color.B), $"({color.R},{color.G},{color.B})", $"#{color.R:X2}{color.G:X2}{color.B:X2}", DateTime.Now );
            }
            catch (Exception){}

        }

        public void Dispose()
        {
            if (graphics != null)
            {
                graphics.Dispose();
                graphics = null;
            }

            if (bitmap != null)
            {
                bitmap.Dispose();
                bitmap = null;
            }

            if (ScreenImage != null)
            {
                ScreenImage.Dispose();
                ScreenImage = null;
            }

            if (timer != null)
            {
                timer.Stop();
                timer.Tick -= (s, e) => GetHoverColor();
                timer = null;
            }
        }

    }
}

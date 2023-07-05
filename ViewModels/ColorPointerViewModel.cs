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

namespace ColorsPicker.ViewModels
{
    class ColorPointerViewModel : ObservableObject, IDisposable
    {

        DispatcherTimer timer = new DispatcherTimer();

        public ColorPointerViewModel()
        {
            timer.Interval = TimeSpan.FromSeconds(0.01);
            timer.Tick += (s, e) => GetHoverColor();
            timer.Start();
        }

        //private async void method1()
        //{
        //    while (true)
        //    {
        //        Dispatcher.CurrentDispatcher.InvokeAsync(() => GetHoverColor());
        //    }

        //}

        private SolidColorBrush hoverColor;
		public SolidColorBrush HoverColor
        {
			get { return hoverColor; }
			set { hoverColor = value; OnPropertyChanged(nameof(HoverColor)); }
        }

        private SavedColor savedColor;
        public SavedColor SavedColor
        {
            get { return savedColor; }
            set { savedColor = value; OnPropertyChanged(nameof(SavedColor)); }
        }

        private BitmapSource bitmapSource;
        public BitmapSource BitmapSource
        {
            get { return bitmapSource; }
            set { bitmapSource = value; OnPropertyChanged(nameof(BitmapSource)); }
        }

        private Graphics graphics;
        private int captureSize;
        private Bitmap bitmap;
        private Image ScreenImage;


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
                captureSize = 80;
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

                HoverColor = new SolidColorBrush(System.Windows.Media.Color.FromArgb(color.A, color.R, color.G, color.B));
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

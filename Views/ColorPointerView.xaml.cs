using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Reflection.Emit;
using System.Runtime.InteropServices;
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
using System.Windows.Threading;
using static System.Net.Mime.MediaTypeNames;

namespace ColorsPicker.Views
{
    /// <summary>
    /// Interaction logic for ColorPointerView.xaml
    /// </summary>
    public partial class ColorPointerView : Page
    {
        //private DispatcherTimer _timer;
        //private Graphics graphics;
        //private int captureSize;
        //private Bitmap bitmap;

        public ColorPointerView()
        {
            InitializeComponent();
            //_timer = new DispatcherTimer();
            //_timer.Interval = TimeSpan.FromMilliseconds(100);
            //_timer.Tick += Timer_Tick;
            //_timer.Start();
        }

        //[DllImport("user32.dll")]
        //[return: MarshalAs(UnmanagedType.Bool)]
        //internal static extern bool GetCursorPos(ref Win32Point pt);

        //[StructLayout(LayoutKind.Sequential)]
        //internal struct Win32Point
        //{
        //    public Int32 X;
        //    public Int32 Y;
        //};

        //private void Timer_Tick(object? sender, EventArgs e)
        //{
        //    try
        //    {
        //        var w32Mouse = new Win32Point();
        //        GetCursorPos(ref w32Mouse);
        //        captureSize = 80;
        //        bitmap = new Bitmap(captureSize, captureSize);
        //        graphics = Graphics.FromImage(bitmap);
        //        graphics.CopyFromScreen(
        //            new System.Drawing.Point(w32Mouse.X - captureSize / 2, w32Mouse.Y - captureSize / 2),
        //            new System.Drawing.Point(0, 0),
        //            new System.Drawing.Size(captureSize, captureSize));
        //        var color = bitmap.GetPixel(captureSize / 2, captureSize / 2);

        //        var bitmapSource = System.Windows.Interop.Imaging.CreateBitmapSourceFromHBitmap(
        //            bitmap.GetHbitmap(),
        //            IntPtr.Zero,
        //            System.Windows.Int32Rect.Empty,
        //            BitmapSizeOptions.FromEmptyOptions());

        //        Image.Source = bitmapSource;
        //        SolidColorBrush brush = new SolidColorBrush(System.Windows.Media.Color.FromArgb(color.A, color.R, color.G, color.B));
        //        rect.Fill = brush;
        //    }
        //    catch (Exception)
        //    {
                
        //    }
           
        //}

        

    }
}

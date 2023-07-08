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
using DeltaColorsPicker.Models;
using System.Threading;
using System.Windows.Threading;
using System.Timers;
using CommunityToolkit.Mvvm.Input;
using System.Windows.Input;
using System.Text.Json.Serialization.Metadata;
using System.ComponentModel;
using DeltaColorsPicker.DataStore;
using System.Drawing.Imaging;
using System.Windows.Ink;
using System.Windows.Media.Media3D;
using PixelFormat = System.Drawing.Imaging.PixelFormat;
using System.IO;

namespace DeltaColorsPicker.ViewModels
{
    class ColorEyedropperViewModel : ObservableObject
    {

        public ICommand KeyDownCommand { get { return new RelayCommand<KeyEventArgs>(KeyDownExecute); } }
        private void KeyDownExecute(object? parameter)
        {
            if (Keyboard.IsKeyDown(Key.X) && (Keyboard.IsKeyDown(Key.LeftAlt) || Keyboard.IsKeyDown(Key.RightAlt)))
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
            set { selectedColor = value; OnPropertyChanged(nameof(SelectedColor));
            }
        }

        private BitmapImage bitmapImage;
        public BitmapImage BitmapImage
        {
            get { return bitmapImage; }
            set { bitmapImage = value; OnPropertyChanged(nameof(BitmapImage)); }
        }

        private MemoryStream memoryStream = new MemoryStream();


        private DispatcherTimer timer;
        private Graphics graphics;
     //   private Bitmap bitmap;
        private System.Drawing.Color color;

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

        public ColorEyedropperViewModel()
        {
            SavedColor = new SavedColor(ColorsDB.CurrentColorSelect.Color, ColorsDB.CurrentColorSelect.RGB, ColorsDB.CurrentColorSelect.HEX, ColorsDB.CurrentColorSelect.SavingDateTime);
            SelectedColor = new SavedColor(ColorsDB.CurrentColorSelect.Color, ColorsDB.CurrentColorSelect.RGB, ColorsDB.CurrentColorSelect.HEX, ColorsDB.CurrentColorSelect.SavingDateTime);

            timer = new DispatcherTimer();
            timer.Interval = TimeSpan.FromSeconds(0.01);
            timer.Tick += (s, e) => GetHoverColor();
            timer.Start();
        }

        public void GetHoverColor()
        {
            try
            {
                var w32Mouse = new Win32Point();
                GetCursorPos(ref w32Mouse);
                W32Mouse_ = new Win32Point() { X = w32Mouse.X, Y = w32Mouse.Y };

                using (var bp = new Bitmap(110, 110))
                {
                    using (graphics = Graphics.FromImage(bp))
                    {

                        graphics.CopyFromScreen(
                            new System.Drawing.Point(w32Mouse.X - 110 / 2, w32Mouse.Y - 110 / 2),
                            new System.Drawing.Point(0, 0),
                            new System.Drawing.Size(110, 110));
                        color = bp.GetPixel(110 / 2, 110 / 2);
                        SavedColor = new SavedColor(System.Windows.Media.Color.FromArgb(color.A, color.R, color.G, color.B), $"({color.R},{color.G},{color.B})", $"#{color.R:X2}{color.G:X2}{color.B:X2}", ColorsDB.CurrentColorSelect.SavingDateTime);
                        BitmapImage = BitmapToBitmapImage(bp);


                        Dispose();
                    }
                }
                     
                
                
            }
            catch (Exception) { }

        }

        private BitmapImage BitmapToBitmapImage(Bitmap bitmap)
        {
            // Clear the MemoryStream object before use
            memoryStream.SetLength(0);

            // Save the Bitmap object to the MemoryStream object
            bitmap.Save(memoryStream, ImageFormat.Png);
            memoryStream.Position = 0;

            // Create a new BitmapImage from the MemoryStream
            BitmapImage bitmapImage = new BitmapImage();
            bitmapImage.BeginInit();
            //bitmapImage.CacheOption = BitmapCacheOption.OnLoad;
            bitmapImage.StreamSource = memoryStream;
            bitmapImage.EndInit();
            return bitmapImage;
        }

        public void Dispose()
        {
            timer.Tick -= (s, e) => GetHoverColor();
            memoryStream.Flush();
            GC.Collect();
        }

    }
}

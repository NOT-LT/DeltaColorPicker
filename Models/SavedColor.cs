using System;

namespace DeltaColorsPicker.Models
{
    public class SavedColor : IDisposable
    {
        public System.Windows.Media.Color Color { get; set; }
        public string RGB { get; set; }
        public string HEX { get; set; }

        public SavedColor(System.Windows.Media.Color _Color, string _RGB, string _HEX)
        {
            Color = _Color;
            RGB = _RGB;
            HEX = _HEX;
        }

        public void Dispose()
        {
        }
    }
}

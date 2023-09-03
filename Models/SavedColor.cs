using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeltaColorsPicker.Models
{
    public class SavedColor
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


    }
}

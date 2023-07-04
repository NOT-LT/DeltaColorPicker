using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ColorsPicker.Models
{
    public class SavedColor
    {
        public System.Windows.Media.Color Color { get; set; }
        public string RGB { get; set; }
        public string HEX { get; set; }
        public DateTime SavingDateTime { get; set; }

        public SavedColor(System.Windows.Media.Color _Color, string _RGB, string _HEX, DateTime _SavingDateTime)
        {
            Color = _Color;
            RGB = _RGB;
            HEX = _HEX;
            SavingDateTime = _SavingDateTime;
        }


    }
}

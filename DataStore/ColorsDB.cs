using DeltaColorsPicker.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;

namespace DeltaColorsPicker.DataStore
{
    public static class ColorsDB
    {


        private static List<SavedColor> AllColors = new List<SavedColor>();
        public static SavedColor CurrentColorSet = new SavedColor(Color.FromRgb(0,0,0), "","");
        public static SavedColor CurrentColorSelect = new SavedColor(Color.FromRgb(0, 0, 0), "", "");

        public static void AddColor_Set(in SavedColor savedColor)
        { 
            CurrentColorSet = savedColor;
            AllColors.Add(CurrentColorSet);
            ColorsListChanged?.Invoke();
        }
        public static void AddColor_Select(in SavedColor savedColor)
        {
            CurrentColorSelect = savedColor;
            AllColors.Add(CurrentColorSelect);
            ColorsListChanged?.Invoke();
        }

        public static List<SavedColor> GetAll()
        {
            return AllColors;
        }

        public static void ClearAll()
        {
            AllColors?.Clear();
            ColorsListChanged?.Invoke();
        }

        public static StringBuilder GetAll_Hex_RGB()
        {
            StringBuilder result = new StringBuilder();
            foreach (var color in ColorsDB.GetAll())
            {
                result.AppendLine($"{color.HEX}-{color.RGB}");
            }
            return result;
        }

        public static event Action? ColorsListChanged;


    }
}

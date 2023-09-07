using DeltaColorPicker.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;

namespace DeltaColorPicker.DataStore
{
    public static class ColorsDB
    {
        private static LinkedList<SavedColor> AllColors = new LinkedList<SavedColor>();
        public static SavedColor CurrentColorSet = new SavedColor(Color.FromRgb(0, 0, 0), "", "");
        public static SavedColor CurrentColorSelect = new SavedColor(Color.FromRgb(0, 0, 0), "", "");

        public static void AddColor_Set(in SavedColor savedColor)
        {
            CurrentColorSet = savedColor;
            AllColors.AddLast(savedColor);
            ColorsListChanged?.Invoke();
        }

        public static void AddColor_Select(in SavedColor savedColor)
        {
            CurrentColorSelect = savedColor;
            AllColors.AddLast(new SavedColor(savedColor.Color, savedColor.RGB, savedColor.HEX));
            ColorsListChanged?.Invoke();
        }

        public static List<SavedColor> GetAll()
        {
            return AllColors.ToList();
        }

        public static void ClearAll()
        {
            AllColors.Clear();
            ColorsListChanged?.Invoke();
        }

        public static StringBuilder GetAll_Hex_RGB()
        {
            StringBuilder result = new StringBuilder();
            foreach (var color in AllColors)
            {
                result.AppendLine($"{color.HEX}-{color.RGB}");
            }
            return result;
        }

        public static event Action? ColorsListChanged;
    }
}
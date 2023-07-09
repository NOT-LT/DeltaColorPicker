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
        public static SavedColor CurrentColorSet = new SavedColor(Color.FromRgb(0,0,0), "","",DateTime.Now);
        public static SavedColor CurrentColorSelect = new SavedColor(Color.FromRgb(0, 0, 0), "", "", DateTime.Now);

        public static void AddColor_Set(SavedColor savedColor)
        { 
                CurrentColorSet = new SavedColor(savedColor.Color, savedColor.RGB, savedColor.HEX, savedColor.SavingDateTime);
            AllColors.Add(CurrentColorSet);
                ColorsListChanged?.Invoke();
        }
        public static void AddColor_Select(SavedColor savedColor)
        {
            CurrentColorSelect = new SavedColor(savedColor.Color, savedColor.RGB, savedColor.HEX, savedColor.SavingDateTime);
            AllColors.Add(CurrentColorSelect);
            ColorsListChanged?.Invoke();
        }

        public static void Delete(SavedColor savedColor)
        {
            if (AllColors.Contains(savedColor))
                AllColors.Remove(savedColor);
        }

        public static List<SavedColor> GetAll()
        {
            return AllColors;
        }

        public static StringBuilder GetAll_Hex_RGB()
        {
            StringBuilder result = new StringBuilder();
            foreach (var color in AllColors)
            {
                result.AppendLine ($"{color.HEX}-{color.RGB}");
            }
            return result;
        }

        public static event Action ColorsListChanged;


    }
}

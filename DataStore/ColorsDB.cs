using ColorsPicker.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;

namespace ColorsPicker.DataStore
{
    public static class ColorsDB
    {
        private static List<SavedColor> AllColors = new List<SavedColor>();
        public static SavedColor CurrentColor = new SavedColor(Color.FromRgb(0,0,0), "","",DateTime.Now);

        public static void Add(SavedColor savedColor)
        { 
                CurrentColor = new SavedColor(savedColor.Color, savedColor.RGB, savedColor.HEX, savedColor.SavingDateTime);
                AllColors.Add(CurrentColor);
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

        public static event Action ColorsListChanged;


    }
}

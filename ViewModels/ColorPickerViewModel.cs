using DeltaColorPicker.DataStore;
using DeltaColorPicker.Models;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media;
using System.Diagnostics;

namespace DeltaColorPicker.ViewModels
{
    class ColorPickerViewModel : ObservableObject
    {

        public RelayCommand HexColorCopyCommand { get; set; }

        public RelayCommand RGBColorCopyCommand { get; set; }

        private SavedColor currentColor;

        public SavedColor CurrentColor
        {
            get { return currentColor; }
            set { currentColor = value;
                OnPropertyChanged(nameof(CurrentColor)); }
        }

        public ColorPickerViewModel()
        {

            CurrentColor = new SavedColor( ColorsDB.CurrentColorSet.Color, ColorsDB.CurrentColorSet.RGB, ColorsDB.CurrentColorSet.HEX);

            HexColorCopyCommand = new RelayCommand(() =>
            {
                ColorsDB.AddColor_Set(CurrentColor);
                ColorsDB.CurrentColorSet = new SavedColor(CurrentColor.Color, CurrentColor.RGB, CurrentColor.HEX);
                Clipboard.SetText(CurrentColor.HEX);
            });

            RGBColorCopyCommand = new RelayCommand(() =>
            {
                ColorsDB.AddColor_Set(CurrentColor);
                ColorsDB.CurrentColorSet = new SavedColor(CurrentColor.Color, CurrentColor.RGB, CurrentColor.HEX);
                Clipboard.SetText(CurrentColor.RGB);
            });
        }


    }
}

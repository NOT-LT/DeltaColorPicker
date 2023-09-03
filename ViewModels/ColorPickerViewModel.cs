using DeltaColorsPicker.DataStore;
using DeltaColorsPicker.Models;
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

namespace DeltaColorsPicker.ViewModels
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

        private byte redValue;

		public byte RedValue
        {
			get { return CurrentColor.Color.R; }
			set { redValue = value; OnPropertyChanged(nameof(RedValue));  }
		}

        private byte greenValue;

        public byte GreenValue
        {
            get { return CurrentColor.Color.G; }
            set { greenValue = value; OnPropertyChanged(nameof(GreenValue));  }
        }

        private byte blueValue;

        public byte BlueValue
        {
            get { return CurrentColor.Color.B; }
            set { blueValue = value; OnPropertyChanged(nameof(BlueValue));  }
        }

        private string _RGBValue;
        public string RGBValue
        {
            get {  return $"({RedValue},{BlueValue},{GreenValue})"; }
            set { _RGBValue = value; OnPropertyChanged(nameof(RGBValue)); }
        }

        private string _HexValue;
        public string HEXValue
        {
            get { return string.Format("#{0:X2}{1:X2}{2:X2}", RedValue, GreenValue, BlueValue);}
            set { _HexValue = value; OnPropertyChanged(nameof(HEXValue)); }
        }


        public ColorPickerViewModel()
        {

            CurrentColor = new SavedColor( ColorsDB.CurrentColorSet.Color, ColorsDB.CurrentColorSet.RGB, ColorsDB.CurrentColorSet.HEX, ColorsDB.CurrentColorSet.SavingDateTime);
            //CurrentColorSet = ColorsDB.GetAll()?.LastOrDefault<SavedColor>() ?? new SavedColor(Color.FromRgb(0,0,0), "", "", DateTime.Now);            //RedValue = 0;
            ////GreenValue = 0;
            ////BlueValue = 0;
            HexColorCopyCommand = new RelayCommand(() =>
            {
                ColorsDB.AddColor_Set(CurrentColor);
                ColorsDB.CurrentColorSet = new SavedColor(CurrentColor.Color, CurrentColor.RGB, CurrentColor.HEX, CurrentColor.SavingDateTime);
                Clipboard.SetText(HEXValue);
            });

            RGBColorCopyCommand = new RelayCommand(() =>
            {
                ColorsDB.AddColor_Set(CurrentColor);
                ColorsDB.CurrentColorSet = new SavedColor(CurrentColor.Color, CurrentColor.RGB, CurrentColor.HEX, CurrentColor.SavingDateTime);
                Clipboard.SetText(RGBValue);
            });
        }


    }
}

using DeltaColorPicker.DataStore;
using DeltaColorPicker.Models;
using CommunityToolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.IO;
using System.Windows.Input;
using CommunityToolkit.Mvvm.Input;

namespace DeltaColorPicker.ViewModels
{
    public class ColorsHistoryViewModel : ObservableObject, IDisposable
    {

        public RelayCommand ClearColorsCommand { get; set; }


        private ObservableCollection<SavedColor> allSavedColors;

        public ObservableCollection<SavedColor> AllSavedColors
        {
            get { return allSavedColors; }
            set
            {
                allSavedColors = value;
                OnPropertyChanged(nameof(AllSavedColors));
            }
        }

        public ColorsHistoryViewModel()
        {

            AllSavedColors = new ObservableCollection<SavedColor>();
            Task.Run(() => { ColorsDB.GetAll().ForEach(color => AllSavedColors.Add(color)); });
            ColorsDB.ColorsListChanged += ColorsDB_NewColorAdded;

            ClearColorsCommand = new RelayCommand(() =>
            {
                if (MessageBox.Show("Are you sure you want to clear the color history", "Confirmation", MessageBoxButton.YesNoCancel, MessageBoxImage.Warning) == MessageBoxResult.Yes)
                {
                    ColorsDB.ClearAll();
                    AllSavedColors.Clear();
                    OnPropertyChanged(nameof(AllSavedColors));
                }
            });
        }

        private void ColorsDB_NewColorAdded()
        {

            if (ColorsDB.GetAll()?.Count > 0)
            {
                AllSavedColors.Add(ColorsDB.GetAll()?.Last());
                OnPropertyChanged(nameof(AllSavedColors));
            }


        }

        public void Dispose()
        {
            ColorsDB.ColorsListChanged -= ColorsDB_NewColorAdded;
        }

    }


}
using DeltaColorsPicker.DataStore;
using DeltaColorsPicker.Models;
using CommunityToolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.IO;

namespace DeltaColorsPicker.ViewModels
{
    class ColorsHistoryViewModel : ObservableObject
    {
		private ObservableCollection<SavedColor> allSavedColors;

		public ObservableCollection<SavedColor> AllSavedColors
        {
			get { return allSavedColors; }
			set { 
				allSavedColors = value;
				OnPropertyChanged(nameof(AllSavedColors));
				}
		}

		public ColorsHistoryViewModel()
		{
			AllSavedColors = new ObservableCollection<SavedColor>();
			ColorsDB.GetAll().ForEach(color => AllSavedColors.Add(color));
			ColorsDB.ColorsListChanged += ColorsDB_NewColorAdded;
		}

        public void Dispose()
        {
            ColorsDB.ColorsListChanged -= ColorsDB_NewColorAdded;
        }

        public void Update()
		{
            AllSavedColors = new ObservableCollection<SavedColor>();
            ColorsDB.GetAll().ForEach(color => AllSavedColors.Add(color));
        }

        private void ColorsDB_NewColorAdded()
		{
			ColorsDB.GetAll().ForEach(color => AllSavedColors.Add(color));
			//Dispose();
        }

    }


}

using ColorsPicker.DataStore;
using ColorsPicker.Models;
using CommunityToolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace ColorsPicker.ViewModels
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

        private void ColorsDB_NewColorAdded()
		{
            ColorsDB.GetAll().ForEach(color => AllSavedColors.Add(color));
        }

    }


}

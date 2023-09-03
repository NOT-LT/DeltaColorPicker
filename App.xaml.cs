using DeltaColorsPicker.DataStore;
using DeltaColorsPicker.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;

namespace DeltaColorsPicker
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {



        protected override void OnStartup(StartupEventArgs e)
        {

            base.OnStartup(e);

            // Load the application resources
            InitializeComponent();

            base.OnStartup(e);
            try
            {
                if (!File.Exists("AllSavedColors.txt"))
                {
                    File.WriteAllLines("AllSavedColors.txt", new string[] {""});
                }
                var SavedColorstxt = File.ReadAllLines("AllSavedColors.txt");
                foreach (var line in SavedColorstxt)
                {
                    //var HEX = line.Split("-")[0];
                    //var RGB = line.Split("-")[1];
                    Color color = (Color)ColorConverter.ConvertFromString(line.Split("-")[0]);

                    ColorsDB.AddColor_Set(new SavedColor(color, line.Split("-")[1], line.Split("-")[0], DateTime.Now));
                }

            }
            catch (Exception) { }
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();

        }

        protected override void OnExit(ExitEventArgs e)
        {
            try
            {
                System.IO.File.WriteAllText("AllSavedColors.txt", ColorsDB.GetAll_Hex_RGB().ToString());
            }
            catch (Exception) {}

            base.OnExit(e);
        }



    }


}

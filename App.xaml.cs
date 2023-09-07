using DeltaColorPicker.DataStore;
using DeltaColorPicker.Models;
using DeltaColorPicker.ViewModels;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;

namespace DeltaColorPicker
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {

        protected override void OnStartup(StartupEventArgs e)
        {


            base.OnStartup(e);
            InitializeComponent();

            new MainWindow().Show();


            Task.Run(() =>
            {
                try
                {
                    if (!File.Exists("AllSavedColors.txt"))
                    {
                        File.WriteAllLines("AllSavedColors.txt", new string[] { "" });
                    }
                    foreach (var _ in File.ReadAllLines("AllSavedColors.txt"))
                    {
                        //var HEX = line.Split("-")[0];
                        //var RGB = line.Split("-")[1];
                        Color color = (Color)ColorConverter.ConvertFromString(_.Split("-")[0]);
                        ColorsDB.AddColor_Set(new SavedColor(color, _.Split("-")[1], _.Split("-")[0]));
                    }

                }
                catch (Exception) { }

            });

            // Checking for updates
            Task.Run(() =>
            {
                using (HttpClient client = new HttpClient())
                {
                    try
                    {
                        if (client.GetStringAsync("https://raw.githubusercontent.com/NOT-LT/DeltaColorPicker/master/Updates.txt").Result.Contains("Update Available: True") && MessageBox.Show("An update is available. Do you want to visit the repository?", "Update Available", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
                        {
                            Process.Start(new ProcessStartInfo() { UseShellExecute = true, FileName = "https://github.com/NOT-LT/DeltaColorPicker" }); ;
                        }
                    }
                    catch ( Exception) { }

                }
            });


        }

        protected override void OnExit(ExitEventArgs e)
        {
            try
            {
                System.IO.File.WriteAllText("AllSavedColors.txt", ColorsDB.GetAll_Hex_RGB().ToString());
            }
            catch (Exception) { }

            base.OnExit(e);
        }



    }


}

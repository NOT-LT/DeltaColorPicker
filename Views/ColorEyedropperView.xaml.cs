using DeltaColorPicker.ViewModels;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Reflection.Emit;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;
using static System.Net.Mime.MediaTypeNames;

namespace DeltaColorPicker.Views
{

    public partial class ColorEyedropperView : Page
    {
        public ColorEyedropperView()
        {
            InitializeComponent();
            Image.Focus();
            //vm = new ColorEyedropperViewModel();
            //DataContext = vm;
        }


    }
}

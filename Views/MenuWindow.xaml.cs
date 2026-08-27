using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using WpfApp1.ViewModels;

namespace WpfApp1.Views
{
    public partial class MenuWindow : Window
    {
        public MenuWindow()
        {
            InitializeComponent();

            // default constructor kept for designer support
            DataContext = new MenuViewModel(null);
        }

        public MenuWindow(Services.AppDataService service)
        {
            InitializeComponent();

            DataContext = new MenuViewModel(service);
        }
    }
}
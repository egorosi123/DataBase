using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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
using WpfApp2.Pages;

namespace WpfApp2
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void MenuItem_Click_Employees(object sender, RoutedEventArgs e)
        {
            Nav.Navigate(new Employees());
        }

        private void MenuItem_Click_Guests(object sender, RoutedEventArgs e)
        {
            Nav.Navigate(new Guests());
        }

        private void MenuItem_Click_Rooms(object sender, RoutedEventArgs e)
        {
            Nav.Navigate(new Rooms());
        }
    }
}

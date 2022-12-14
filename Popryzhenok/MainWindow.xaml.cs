using Popryzhenok.Pages;
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

namespace Popryzhenok
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            FrameMain.Navigate(new PageAgent());
            Manager.FrameMain = FrameMain;
        }

        private void Back_Click(object sender, RoutedEventArgs e)
        {
            Manager.FrameMain.GoBack();

        }

        private void FrameMain_ContentRendered(object sender, EventArgs e)
        {
            if (FrameMain.CanGoBack)
            {
                Back.Visibility = Visibility.Visible;
            }
            else
            {
                Back.Visibility = Visibility.Hidden;
            }
        }

        private void Add_Click(object sender, RoutedEventArgs e)
        {
            Manager.FrameMain.Navigate(new PageAddAgent(null)); ;
        }
    }
}

using Popryzhenok.AppData;
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

namespace Popryzhenok.Pages
{
    /// <summary>
    /// Логика взаимодействия для PageAgent.xaml
    /// </summary>
    public partial class PageAgent : Page
    {
        public PageAgent()
        {
            InitializeComponent();

            var allType = tren2_SokolovEntities.GetContext().Agent.ToList();
            allType.Insert(0, new Agent
            {
                NameCompany = "Все агенты"
            });
            ComboType.ItemsSource = allType;

            ComboType.SelectedIndex = 0;

            UpdateAgent();

            var currentAgent = tren2_SokolovEntities.GetContext().Agent.ToList();
            LViewAgent.ItemsSource = currentAgent;
        }

        private void UpdateAgent()
        {
            var currentAgent = tren2_SokolovEntities.GetContext().Agent.ToList();

            //if (ComboType.SelectedIndex > 0)
            //    currentAgent = currentAgent.Where(p => p.TypeAgent.Contains(ComboType.SelectedItem as Agent)).ToList();

            currentAgent = currentAgent.Where(p => p.NameCompany.ToLower().Contains(TBoxSearch.Text.ToLower())).ToList();

            LViewAgent.ItemsSource = currentAgent.OrderBy(p => p.NameCompany).ToList();

        }

        private void ComboType_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            UpdateAgent();
        }

        private void TBoxSearch_TextChanged(object sender, TextChangedEventArgs e)
        {
            UpdateAgent();
        }

        private void BtnDelete_Click(object sender, RoutedEventArgs e)
        {
            var agentForRemoving = LViewAgent.SelectedItems.Cast<Agent>().ToList();

            if (MessageBox.Show($"Вы точно хотите удалить следующие {agentForRemoving.Count()} элементов?", "Внимание",
                MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
            {
                try
                {
                    tren2_SokolovEntities.GetContext().Agent.RemoveRange(agentForRemoving);
                    tren2_SokolovEntities.GetContext().SaveChanges();
                    MessageBox.Show("Данные удалены!");
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message.ToString());
                }
            }
        }

        private void BtnRedact_Click(object sender, RoutedEventArgs e)
        {
            Manager.FrameMain.Navigate(new PageAddAgent((sender as Button).DataContext as Agent));
        }
    }
}

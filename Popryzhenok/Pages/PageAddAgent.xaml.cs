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
    /// Логика взаимодействия для PageAddAgent.xaml
    /// </summary>
    public partial class PageAddAgent : Page
    {
        private Agent _currentAgent = new Agent();
        public PageAddAgent(Agent selectedAgent)
        {
            InitializeComponent();

            if (selectedAgent != null)
                _currentAgent = selectedAgent;

            DataContext = _currentAgent;
        }

        private void BtnSave_Click(object sender, RoutedEventArgs e)
        {
            StringBuilder errors = new StringBuilder();

            if (string.IsNullOrWhiteSpace(_currentAgent.NameCompany))
                errors.AppendLine("Укажите название отеля");
            if (string.IsNullOrWhiteSpace(_currentAgent.Phone))
                errors.AppendLine("Укажите номер телефона");

            if (errors.Length > 0)
            {
                MessageBox.Show(errors.ToString());
                return;
            }
            if (_currentAgent.ID == 0)
                tren2_SokolovEntities.GetContext().Agent.Add(_currentAgent);

            try
            {
                tren2_SokolovEntities.GetContext().SaveChanges();
                MessageBox.Show("Информация сохранена!");
                Manager.FrameMain.GoBack();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }
    }
}

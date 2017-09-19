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
using LibraryWPF.Models;
using LibraryWPF.ViewModels;

namespace LibraryWPF.Views
{
    /// <summary>
    /// Логика взаимодействия для SubscriberView.xaml
    /// </summary>
    public partial class SubscriberView : UserControl
    {
        public SubscriberView()
        {
            InitializeComponent();
            this.DataContext = new SubscriberVM();
        }

        private void btnShowProfile_Click(object sender, RoutedEventArgs e)
        {
            if (grid.SelectedItem != null)
            {
                SubscriberProfile sp = new SubscriberProfile(grid.SelectedItem as SubscriberModel);
                sp.ShowDialog();
            }
            else
            {
                MessageBox.Show("Выберите пользователя");
            }
        }
    }
}

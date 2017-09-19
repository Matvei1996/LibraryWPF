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
using System.Windows.Shapes;
using LibraryWPF.ViewModels;
using LibraryWPF.Models;

namespace LibraryWPF.Views
{
    /// <summary>
    /// Логика взаимодействия для SubscriberProfile.xaml
    /// </summary>
    public partial class SubscriberProfile : Window
    {
        public SubscriberProfile()
        {
            InitializeComponent();
        }

        public SubscriberProfile(SubscriberModel sm) : this()
        {
            this.DataContext = new SubscriberProfileVM(sm);
        }

    }
}

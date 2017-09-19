using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using GalaSoft.MvvmLight.Messaging;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using LibraryWPF.Massages;
using LibraryWPF.ViewModels;

namespace LibraryWPF.View
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            Messenger.Default.Register<NavigateMsg>(this, (action) => ShowUserControl(action));
            Messenger.Default.Register<SubscriberMsg>(this, (action) => ReceiveUserMessage(action));
            this.DataContext = new MainWindowVM();
        }

        private void ReceiveUserMessage(SubscriberMsg msg)
        {
            UIMessage.Opacity = 1;
            UIMessage.Text = msg.Message;
            Storyboard sb = (Storyboard)this.FindResource("FadeUIMessage");
            sb.Begin();
        }
        private void ShowUserControl(NavigateMsg nm)
        {
            EditFrame.Content = nm.View;
        }
    }
}

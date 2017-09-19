using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LibraryWPF.Massages;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Messaging;

namespace LibraryWPF.ViewModels
{
    public class CommandVM
    {
        public string CommandDisplay { get; set; }
        public CommandMsg Message { get; set; }
        public RelayCommand Send { get; private set; }
        public CommandVM()
        {
            Send = new RelayCommand(SendExecute);
        }
        private void SendExecute()
        {
            Messenger.Default.Send(Message);
        }
    }
}

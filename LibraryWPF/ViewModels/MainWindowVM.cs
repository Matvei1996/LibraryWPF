using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LibraryWPF.SupportUtils;
using System.Collections.ObjectModel;
using LibraryWPF.Views;
using LibraryWPF.Massages;

namespace LibraryWPF.ViewModels
{
    public class MainWindowVM : NotifyUIBase
    {
        public ObservableCollection<CommandVM> Commands { get; set; }
        public ObservableCollection<ViewVM> Views { get; set; }
        public string Message { get; set; }

        public MainWindowVM()
        {
            ObservableCollection<ViewVM> views = new ObservableCollection<ViewVM>
            {
                new ViewVM{ ViewDisplay="Книги", ViewType = typeof(BookView), ViewModelType = typeof(BookVM)},
                new ViewVM{ ViewDisplay="Читатели", ViewType = typeof(SubscriberView), ViewModelType = typeof(SubscriberVM)},
                new ViewVM{ ViewDisplay="Заказы", ViewType = typeof(OrderView), ViewModelType = typeof(OrdersVM)}
            };
            Views = views;
            RaisePropertyChanged("Views");
            views[0].NavigateExecute();

            ObservableCollection<CommandVM> commands = new ObservableCollection<CommandVM>
            {
                new CommandVM{ CommandDisplay="Добавить", Message=new CommandMsg{ Command = CommandType.Insert}},
                new CommandVM{ CommandDisplay="Удалить", Message=new CommandMsg{ Command = CommandType.Delete}},
                new CommandVM{ CommandDisplay="Сохранить изменения", Message=new CommandMsg{ Command = CommandType.Save}},
                new CommandVM{ CommandDisplay="Обновить данные", Message=new CommandMsg{ Command = CommandType.Update}}

            };
            Commands = commands;
            RaisePropertyChanged("Commands");
        }
    }
}

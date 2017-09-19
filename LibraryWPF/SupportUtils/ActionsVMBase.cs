using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LibraryWPF.Massages;
using GalaSoft.MvvmLight.Messaging;

namespace LibraryWPF.SupportUtils
{
    public class ActionsVMBase : NotifyUIBase
    {
        protected LibraryEntities db = new LibraryEntities();

        protected void HandleCommand(CommandMsg action)
        {
            if (isCurrentView)
            {
                switch (action.Command)
                {
                    case CommandType.Insert:
                        Create();
                        break;
                    case CommandType.Delete:
                        Delete();
                        break;
                    case CommandType.Save:
                        Save();
                        break;
                    case CommandType.Update:
                        Update();
                        break;
                    default:
                        break;
                }
            }
        }

        protected virtual void Save() { }

        protected virtual void Delete() { }

        protected virtual void Update()
        {
            GetData();
        }

        protected virtual void Create() { }

        protected virtual void GetData() { }

        protected ActionsVMBase()
        {
            GetData();
            Messenger.Default.Register<CommandMsg>(this, (action) => HandleCommand(action));
            Messenger.Default.Register<NavigateMsg>(this, (action) => CurrentUserControl(action));
        }

        protected bool isCurrentView = false;

        private void CurrentUserControl(NavigateMsg nm)
        {
            if (GetType() == nm.ViewModelType)
            {
                isCurrentView = true;
            }
            else
            {
                isCurrentView = false;
            }
        }
        private string errorMessage;

        public string ErrorMessage
        {
            get { return errorMessage; }
            set
            {
                errorMessage = value;
                RaisePropertyChanged();
            }
        }
    }
}

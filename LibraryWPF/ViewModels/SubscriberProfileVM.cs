using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LibraryWPF.Models;
using LibraryWPF.SupportUtils;

namespace LibraryWPF.ViewModels
{
    public class SubscriberProfileVM : ActionsVMBase
    {
        private SubscriberModel selectedSubscriber;

        private string name;
        private string surname;
        private string patronimic;
        private int age;
        private string regDate;

        public SubscriberProfileVM(SubscriberModel sm)
        {
            selectedSubscriber = sm;
            GetData();

        }

        public string Name
        {
            get => selectedSubscriber.NewSubscriber.Name;
            set => name = value;
        }

        public string Surname
        {
            get => selectedSubscriber.NewSubscriber.Surname;
            set => surname = value;
        }

        public string Patronimic
        {
            get => selectedSubscriber.NewSubscriber.Patronimic;
            set => patronimic = value;
        }

        public int Age
        {
            get => selectedSubscriber.NewSubscriber.Age;
            set => age = value;
        }
        public string RegDate
        {
            get => selectedSubscriber.NewSubscriber.RegDate;
            set => regDate = value;
        }

        public ObservableCollection<String> SubscriberBooks { get; set; }

        protected new void GetData()
        {
            if (selectedSubscriber != null)
            {
                SubscriberBooks = new ObservableCollection<string>();
                var books = from c in db.Orders
                            where c.SubscriberID == selectedSubscriber.NewSubscriber.Id
                            select c.Book.BookTitle;
                if (books != null)
                {
                    foreach (string book in books)
                    {
                        SubscriberBooks.Add(book);
                    }
                }
            }
        }
    }
}

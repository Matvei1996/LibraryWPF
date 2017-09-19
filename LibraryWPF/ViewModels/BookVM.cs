using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LibraryWPF.SupportUtils;
using LibraryWPF.Models;
using System.Collections.ObjectModel;
using GalaSoft.MvvmLight.Messaging;
using LibraryWPF.Massages;
using System.Data.Entity;

namespace LibraryWPF.ViewModels
{
    public class BookVM : ActionsVMBase
    {
        public BookModel SelectedBook
        {
            get;
            set;
        }

        public ObservableCollection<BookModel> Books { get; set; }

        protected override void GetData()
        {
            ObservableCollection<BookModel> _books = new ObservableCollection<BookModel>();
            var books = from p in db.Books
                               orderby p.BookTitle
                               select p;
            foreach (Book bk in books)
            {
                _books.Add(new BookModel { IsNew = false, NewBook = bk });
            }
            Books = _books;
            RaisePropertyChanged("Books");
        }
        protected override void Save()
        {
            SubscriberMsg msg = new SubscriberMsg();
            var updated = (from c in Books
                           where c.IsNew = false
                           select c).ToList();
            if (db.ChangeTracker.HasChanges())
            {
                try
                {
                    db.SaveChanges();
                }
                catch (Exception e)
                {
                    if (System.Diagnostics.Debugger.IsAttached)
                    {
                        ErrorMessage = e.InnerException.GetBaseException().ToString();
                    }
                }
            }
            else
            {

            }

        }
        protected override void Delete()
        {
            SubscriberMsg msg = new SubscriberMsg();
            if (SelectedBook != null)
            {
                db.Books.Remove(SelectedBook.NewBook);
                Books.Remove(SelectedBook);
                RaisePropertyChanged("Books");
            }
            else
            {

            }
            Messenger.Default.Send(msg);
        }
        protected override void Create()
        {
            SubscriberMsg msg = new SubscriberMsg();
            var inserted = (from c in Books
                            where c.IsNew
                            select c).ToList();
            if (db.ChangeTracker.HasChanges() || inserted.Count > 0)
            {
                foreach (BookModel c in inserted)
                {
                    db.Books.Add(c.NewBook);
                }
                try
                {
                    db.SaveChanges();
                }
                catch (Exception e)
                {
                    if (System.Diagnostics.Debugger.IsAttached)
                    {
                        ErrorMessage = e.InnerException.GetBaseException().ToString();
                    }
                }
            }
            else
            {

            }
            Messenger.Default.Send(msg);
        }

        public BookVM() : base() { }
    }
}

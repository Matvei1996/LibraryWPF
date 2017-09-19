using System;
using System.Linq;
using LibraryWPF.Models;
using LibraryWPF.SupportUtils;
using LibraryWPF.Massages;
using System.Collections.ObjectModel;
using GalaSoft.MvvmLight.Messaging;

namespace LibraryWPF.ViewModels
{
    public class SubscriberVM : ActionsVMBase
    {
        public SubscriberModel SelectedSubscriber { get; set; }

        public ObservableCollection<SubscriberModel> Subscribers { get; set; }

        public ObservableCollection<String> SubscriberBooks { get; set; }

        public SubscriberVM()
            : base()
        {

        }
        protected override void Save()
        {
            SubscriberMsg msg = new SubscriberMsg();
            var inserted = (from c in Subscribers
                            where c.IsNew = false
                            select c).ToList();
            if (db.ChangeTracker.HasChanges() || inserted.Count > 0)
            {
                foreach (SubscriberModel c in inserted)
                {
                    db.Subscribers.Add(c.NewSubscriber);
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

        }
        protected override void Delete()
        {
            SubscriberMsg msg = new SubscriberMsg();
            if (SelectedSubscriber != null)
            {
                db.Subscribers.Remove(SelectedSubscriber.NewSubscriber);
                Subscribers.Remove(SelectedSubscriber);
                RaisePropertyChanged("Subscribers");
            }
            else
            {

            }

        }

        protected override void Create()
        {
            SubscriberMsg msg = new SubscriberMsg();
            var inserted = (from c in Subscribers
                            where c.IsNew
                            select c).ToList();
            if (db.ChangeTracker.HasChanges() || inserted.Count > 0)
            {
                foreach (SubscriberModel c in inserted)
                {
                    db.Subscribers.Add(c.NewSubscriber);
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
        }

        protected override void GetData()
        {
            ObservableCollection<SubscriberModel> _subscribers = new ObservableCollection<SubscriberModel>();
            var subscribers = from c in db.Subscribers
                               select c;
            foreach (Subscriber sb in subscribers)
            {
                _subscribers.Add(new SubscriberModel { IsNew = false, NewSubscriber = sb });
            }
            Subscribers = _subscribers;
            RaisePropertyChanged("Subscribers");
        }

        protected void GetOrdersList()
        {
            if (SelectedSubscriber != null)
            {
                var orders = (from c in db.Orders
                              where c.SubscriberID == SelectedSubscriber.NewSubscriber.Id
                              select c.Book.BookTitle).ToList();
            }

        }
    }
}

using GalaSoft.MvvmLight.Messaging;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LibraryWPF.Models;
using LibraryWPF.SupportUtils;
using LibraryWPF.Massages;

namespace LibraryWPF.ViewModels
{
    public class OrdersVM : ActionsVMBase
    {
        public OrderModel SelectedOrder
        {
            get;
            set;
        }

        public ObservableCollection<OrderModel> Orders { get; set; }

        protected override void GetData()
        {
            ObservableCollection<OrderModel> _orders = new ObservableCollection<OrderModel>();
            var orders = from p in db.Orders
                                orderby p.Id
                                select p;
            foreach (Order or in orders)
            {
                _orders.Add(new OrderModel { IsNew = false, NewOrder = or });
            }
            Orders = _orders;
            RaisePropertyChanged("Orders");
        }
        protected override void Save()
        {
            SubscriberMsg msg = new SubscriberMsg();
            var inserted = (from c in Orders
                            where c.IsNew = false
                            select c).ToList();
            if (db.ChangeTracker.HasChanges() || inserted.Count > 0)
            {
                foreach (OrderModel c in inserted)
                {
                    db.Orders.Add(c.NewOrder);
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
            if (SelectedOrder != null)
            {
                db.Orders.Remove(SelectedOrder.NewOrder);
                Orders.Remove(SelectedOrder);
                RaisePropertyChanged("Orders");
            }
            else
            {

            }
        }

        protected override void Create()
        {
            SubscriberMsg msg = new SubscriberMsg();
            var inserted = (from c in Orders
                            where c.IsNew
                            select c).ToList();
            if (db.ChangeTracker.HasChanges() || inserted.Count > 0)
            {
                foreach (OrderModel c in inserted)
                {
                    db.Orders.Add(c.NewOrder);
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
        public OrdersVM() : base() { }
    }
}

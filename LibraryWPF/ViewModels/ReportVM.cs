using System;
using System.Collections.ObjectModel;
using System.Linq;
using LibraryWPF.SupportUtils;

namespace LibraryWPF.ViewModels
{
    public class ReportVM : ActionsVMBase
    {
        public DateTime firstDate;
        public DateTime lastDate;

        public ReportVM(DateTime start, DateTime finish)
        {
            firstDate = start;
            lastDate = finish;
            GetData();
        }

        public ObservableCollection<PopularBook> PopularBooks { get; set; }

        protected new void GetData()
        {
            PopularBooks = new ObservableCollection<PopularBook>();
            var books = from c in db.Orders
                        where ((c.Date >= firstDate) && (c.Date <= lastDate))
                        select c;
        }
    }
    public class PopularBook
    {
        public PopularBook()
        {

        }
        public int Quantity { get; set; }
        public string BookName { get; set; }
    }
}

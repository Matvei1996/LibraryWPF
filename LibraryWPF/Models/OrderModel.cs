using LibraryWPF.SupportUtils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryWPF.Models
{
    public class OrderModel: VMBase
    {
        public Order NewOrder { get; set; }

        public OrderModel()
        {
            NewOrder = new Order();
        }
    }
}

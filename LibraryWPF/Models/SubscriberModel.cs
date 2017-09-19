using LibraryWPF.SupportUtils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryWPF.Models
{
    public class SubscriberModel : VMBase
    {
        public Subscriber NewSubscriber { get; set; }

        public SubscriberModel()
        {
            NewSubscriber = new Subscriber();
        }
    }
}

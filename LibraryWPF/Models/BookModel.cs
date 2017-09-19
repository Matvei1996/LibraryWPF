using LibraryWPF.SupportUtils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryWPF.Models
{
    public class BookModel: VMBase
    {
        public Book NewBook { get; set; }

        public BookModel()
        {
            NewBook = new Book();
        }
    }
}

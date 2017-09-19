using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryWPF.Massages
{
    public class CommandMsg
    {
        public CommandType Command { get; set; }
    }
    public enum CommandType
    {
        Insert,
        Delete,
        Save,
        Update
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETOS.Common
{
    public class LogFilter
    {
        public DateTime CreationDate { get; set; }

        public string CreatorLastName { get; set; }

        public string CreatorFirstName { get; set; }


        public LogFilter GetDefault()
        {
            return new LogFilter()
            {
                CreationDate = DateTime.MinValue,
                CreatorLastName = null,
                CreatorFirstName = null
            };
        }
    }
}

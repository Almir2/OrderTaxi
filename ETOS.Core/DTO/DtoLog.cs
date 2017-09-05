using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETOS.Core.DTO
{
    public class DtoLog
    {
        public int Id { get; set; }

        public string CreatorFirstName { get; set; }

        public string CreatorLastName { get; set; }

        public string BrowserName { get; set; }

        public string IpAddress { get; set; }

        public decimal? RequestPrice { get; set; }

        public double? RequestMile { get; set; }

        public DateTime CreationDataTime { get; set; }
    }
}

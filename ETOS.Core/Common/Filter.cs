using ETOS.Core.Services.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETOS.Core.Common
{
   public class RequestFilter : IFilter
    {
        public int AuthorId { get; set; }

        public string Comment { get; set; }

        public DateTime CreatingDateTime { get; set; }

        public string DepartureAddress { get; set; }

        public DateTime DepartureDateTime { get; set; }

        public int? DeparturePointId { get; set; }

        public string DestinationAddress { get; set; }

        public int? DestinationPointId { get; set; }

        public bool IsBaggage { get; set; }

        public double Mileage { get; set; }

        public double Price { get; set; }

        public int RequestId { get; set; }

        public int StatusId { get; set; }
    }
}

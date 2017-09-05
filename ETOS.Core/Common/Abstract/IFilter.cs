using System;

namespace ETOS.Core.Services.Abstract
{
    public interface IFilter
    {
        int RequestId { get; set; }
        int AuthorId { get; set; }
        Nullable<int> DeparturePointId { get; set; }
        Nullable<int> DestinationPointId { get; set; }
        string DepartureAddress { get; set; }
        string DestinationAddress { get; set; }
        DateTime DepartureDateTime { get; set; }
        DateTime CreatingDateTime { get; set; }
        bool IsBaggage { get; set; }
        string Comment { get; set; }
        double Mileage { get; set; }
        double Price { get; set; }
        int StatusId { get; set; }
    }
}

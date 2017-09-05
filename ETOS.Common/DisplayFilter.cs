using System;

namespace ETOS.Common
{
    /// <summary>
    /// Класс,содержащий поля для фильтрации
    /// </summary>
    public class DisplayFilter
    {
        public int RequestId { get; set; }
        public string AuthorFirstName { get; set; }
        public string AuthorLastName { get; set; }
        public string Comment { get; set; }
        public DateTime CreationDateTime { get; set; }
        public string DepartureAddress { get; set; }
        public DateTime DepartureDateTime { get; set; }
        public string DeparturePoint { get; set; }
        public string DestinationAddress { get; set; }
        public string DestinationPoint { get; set; }
        public bool HasBaggage { get; set; }
        public float Mileage { get; set; }
        public decimal Price { get; set; }
        public string StatusName { get; set; }


        public DisplayFilter GetDefault()
        {
            return new DisplayFilter()
            {
                RequestId = default(int),
                AuthorFirstName = default(string),
                AuthorLastName = default(string),
                Comment = default(string),
                CreationDateTime = default(DateTime),
                DepartureAddress = default(string),
                DepartureDateTime = default(DateTime),
                DeparturePoint = default(string),
                DestinationAddress = default(string),
                DestinationPoint = default(string),
                HasBaggage = default(bool),
                Mileage = default(float),
                Price = default(decimal),
                StatusName = default(string),
            };
        }
    }

}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETOS.Core.DTO
{
    class DtoEditRequest
    {

        /// <summary>
        /// Код заявкт
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Табельный номер отправителя заявки.
        /// </summary>
        public int AuthorId { get; set; }

        public string AuthorName { get; set; }

        /// <summary>
        /// Код точки отправки.
        /// Не указывается в том случае, если точка отправки не является точкой интереса (POI).
        /// </summary>
        public int? DeparturePointId { get; set; }
        public string DeparturePointName { get; set; }

        /// <summary>
        /// Код точки прибытия.
        /// Не указывается в том случае, если точка прибытия не является точкой интереса (POI).
        /// </summary>
        public int? DestinationPointId { get; set; }
        public string DestinationPointName { get; set; }

        /// <summary>
        /// Адрес места отправки.
        /// Указывается в том случае, если место отправки не является точкой интереса (POI).
        /// </summary>
        public string DepartureAddress { get; set; }

        /// <summary>
        /// Адрес места прибытия.
        /// Указывается в том случае, если место прибытия не является точкой интереса (POI).
        /// </summary>
        public string DestinationAddress { get; set; }

        /// <summary>
        /// Предполагаемые дата и время отправки.
        /// </summary>
        public DateTime DepartureDateTime { get; set; }

        /// <summary>
        /// Дата и время создания заявки.
        /// </summary>
        public DateTime CreationDateTime { get; set; }

        /// <summary>
        /// Флаг, определяющий наличие багажа.
        /// </summary>
        public bool HasBaggage { get; set; }

        /// <summary>
        /// Комментарий к заявке.
        /// </summary>
        public string Comment { get; set; }

        /// <summary>
        /// Общий километраж заявки.
        /// </summary>
        public float Mileage { get; set; }

        /// <summary>
        /// Общая стоимость заявки.
        /// </summary>
        public decimal Price { get; set; }

        /// <summary>
        /// Код статуса выполнения заявки.
        /// </summary>
        public int StatusId { get; set; }
    }
}

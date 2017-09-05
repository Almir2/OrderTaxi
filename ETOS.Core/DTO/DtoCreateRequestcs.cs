using System;

namespace ETOS.Core.DTO
{
    /// <summary>
    /// Объект передачи данных между моделью уровня представления и уровнем доступа к данным.
    /// Представляет собой новую заявку пользователя.
    /// </summary>
    public class DtoCreateRequest
    {
        /// <summary>
        /// Логин автора
        /// </summary>
        public string AuthorLogin { get; set; }

        /// <summary>
        /// Код точки отправки.
        /// Не указывается в том случае, если точка отправки не является точкой интереса (POI).
        /// </summary>
        public int DeparturePointId { get; set; }

        /// <summary>
        /// Код точки прибытия.
        /// Не указывается в том случае, если точка прибытия не является точкой интереса (POI).
        /// </summary>
        public int DestinationPointId { get; set; }

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
        /// Желаемые дата и время отправки.
        /// </summary>
        public DateTime DepartureDateTime { get; set; }
        
        /// <summary>
        /// Флаг, определяющий наличие багажа.
        /// </summary>
        public bool HasBaggage { get; set; }

        /// <summary>
        /// Комментарий к заявке.
        /// </summary>
        public string Comment { get; set; }

        /// <summary>
        /// Расстояние между пунктами (км)
        /// </summary>
        public int Mileage { get; set; }
    }
}

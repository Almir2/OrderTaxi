using System;

namespace ETOS.Core.DTO
{
    /// <summary>
    /// Объект передачи данных между моделью уровня представления и уровнем доступа к данным.
    /// Представляет собой аккаунт пользователя.
    /// </summary>
    public class DtoRequest
    {
        /// <summary>
        /// Код заявкт
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Табельный номер сотрудника - отправителя заявки.
        /// </summary>
        public int ? EmployeeId { get; set; }

		/// <summary>
		/// Код клиента - отправителя заявки.
		/// </summary>
		public int ? CustomerId { get; set; }

        /// <summary>
        /// Имя автора заявки
        /// </summary>
        public string AuthorFirstName { get; set; }

        /// <summary>
        /// Фамилия автора заявки
        /// </summary>
        public string AuthorLastName { get; set; }

        /// <summary>
        /// Адрес точки отправки согласно коду
        /// </summary>
        public string DeparturePointName { get; set; }

        /// <summary>
        /// Адрес точки прибытия согласно коду
        /// </summary>
        public string DestinationPointName { get; set; }

        /// <summary>
        /// Код точки отправки.
        /// Не указывается в том случае, если точка отправки не является точкой интереса (POI).
        /// </summary>
        public int? DeparturePointId { get; set; }

        /// <summary>
        /// Код точки прибытия.
        /// Не указывается в том случае, если точка прибытия не является точкой интереса (POI).
        /// </summary>
        public int? DestinationPointId { get; set; }

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
		/// Код автомобиля, назначенного данной заявке.
		/// </summary>
		public int VehicleId { get; set; }

        /// <summary>
        /// Общий километраж заявки.
        /// </summary>
        public float Mileage { get; set; }

        /// <summary>
        /// Общая стоимость заявки.
        /// </summary>
        public decimal Price { get; set; }

        /// <summary>
        /// Статус
        /// </summary>
        public string StatusName { get; set; }
        /// <summary>
        /// Код статуса выполнения заявки.
        /// </summary>
        public int StatusId { get; set; }
    }
}

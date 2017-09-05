using System;
using System.Collections.Generic;

namespace ETOS.Core.DTO
{
	/// <summary>
	/// Объект передачи данных между моделью уровня представления и уровнем доступа к данным.
	/// Представляет собой подрядчика.
	/// </summary>
	public class DtoContractor
	{
		/// <summary>
		/// Код подрядчика.
		/// </summary>
		public int Id { get; set; }

		/// <summary>
		/// Название подрядчика.
		/// </summary>
		public string Name { get; set; }

		/// <summary>
		/// Номер телефона подрядчика.
		/// </summary>
		public string Phone { get; set; }

		/// <summary>
		/// Стоимость, устанавливаемая подрядчиком за километр поездки.
		/// </summary>
		public decimal Tariff { get; set; }

		/// <summary>
		/// Список локаций, обслуживаемых данным подрядчиком.
		/// </summary>
		public IEnumerable<DtoLocation> MaintainedLocations { get; set; }
	}
}

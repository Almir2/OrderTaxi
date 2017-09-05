using System;

using ETOS.DAL.Interfaces;

namespace ETOS.DAL.Entities
{
	/// <summary>
	/// Описывает сущность "Бюджет".
	/// Данная сущность предоставляет информацию о квотах общего количества и суммы поездок сотрудника,
	/// выделяемых каждому сотруднику на определенный период, а также их остатках.
	/// </summary>
	public class Budget : IEntity
	{
		#region Fields

		/// <summary>
		/// Код бюджета.
		/// </summary>
		public int Id { get; set; }

		/// <summary>
		/// Табельный номер сотрудника, для котрого устанавливается бюджет.
		/// </summary>
		public int EmployeeId { get; set; }

		/// <summary>
		/// Квота количества заявок.
		/// </summary>
		public int RequestsNumberQuota { get; set; }

		/// <summary>
		/// Квота общей стоимости заявок.
		/// </summary>
		public decimal TotalPriceQuota { get; set; }

		/// <summary>
		/// Остаток количества заявок.
		/// </summary>
		public int RequestsNumberBalance { get; set; }

		/// <summary>
		/// Остаток общей стоимости заявок.
		/// </summary>
		public decimal TotalPriceBalance { get; set; }

		#endregion

	}
}

using System;

using ETOS.DAL.Interfaces;

namespace ETOS.DAL.Entities
{
	/// <summary>
	/// Описывает сущность "Этап выполнения заявки".
	/// Данная сущность представляет событие, изменяющее статус выполнения заявки в процессе ее выполнения.
	/// </summary>
	public class RequestLifecycleEvent : IEntity
	{
		#region Fields

		/// <summary>
		/// Код события.
		/// </summary>
		public int Id { get; set; }

		/// <summary>
		/// Код заявки.
		/// </summary>
		public int RequestId { get; set; }

		/// <summary>
		/// Табельный номер инициатора события.
		/// </summary>
		public int EmployeeId { get; set; }

		/// <summary>
		/// Дата и время события.
		/// </summary>
		public DateTime EventDateTime { get; set; }

		#endregion
	}
}

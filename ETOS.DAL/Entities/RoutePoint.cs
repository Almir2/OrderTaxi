using System;

using ETOS.DAL.Interfaces;

namespace ETOS.DAL.Entities
{
	/// <summary>
	/// Описывает сущность "Точка маршрута".
	/// Данная сущность представляет промежуточную точку в заявке.
	/// </summary>
	public class RoutePoint : IEntity
	{
		#region Fields

		/// <summary>
		/// Код точки маршрута.
		/// </summary>
		public int Id { get; set; }

		/// <summary>
		/// Код заявки, которой назначен данный маршрут.
		/// </summary>
		public int RequestId { get; set; }

		/// <summary>
		/// Код точки прибытия.
		/// Не указывается в том случае, если точка прибытия не является точкой интереса (POI).
		/// </summary>
		public int ? DestinationPointId { get; set; }

		/// <summary>
		/// Адрес места прибытия.
		/// Указывается в том случае, если место прибытия не является точкой интереса (POI).
		/// </summary>
		public string DestinationPointAddress { get; set; }

		/// <summary>
		/// Код следующей точки маршрута.
		/// </summary>
		public int ? NextPointId { get; set; }

		#endregion
	}
}

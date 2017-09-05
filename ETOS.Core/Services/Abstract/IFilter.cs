using System;

namespace ETOS.Core.Services.Abstract
{
	/// <summary>
	/// Интерфейс для работы с фильтром заявок
	/// </summary>
	public interface IFilter
	{
		int RequestId { get; set; }
		int AuthorId { get; set; }
		int? DeparturePointId { get; set; }
		int? DestinationPointId { get; set; }
		string DepartureAddress { get; set; }
		string DestinationAddress { get; set; }
		DateTime DepartureDateTime { get; set; }
		DateTime CreatingDateTime { get; set; }
		bool HasBaggage { get; set; }
		string Comment { get; set; }
		double Mileage { get; set; }
		decimal Price { get; set; }
		int StatusId { get; set; }
	}
}

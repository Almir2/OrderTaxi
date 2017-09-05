using System;

namespace ETOS.Core.DTO
{
	/// <summary>
	/// Объект передачи данных между моделью уровня представления и уровнем доступа к данным.
	/// Представляет собой марку автомобиля.
	/// </summary>
	public class DtoBrand
	{
		/// <summary>
		/// Код марки автомобиля.
		/// </summary>
		public int Id { get; set; }

		/// <summary>
		/// Название марки автомобиля.
		/// </summary>
		public string Name { get; set; }
	}
}

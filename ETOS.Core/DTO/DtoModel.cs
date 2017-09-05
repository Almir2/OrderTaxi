using System;

namespace ETOS.Core.DTO
{
	/// <summary>
	/// Объект передачи данных между моделью уровня представления и уровнем доступа к данным.
	/// Представляет собой модель автомобиля.
	/// </summary>
	public class DtoModel
	{
		/// <summary>
		/// Код модели автомобиля.
		/// </summary>
		public int Id { get; set; }

		/// <summary>
		/// Название модели автомобиля.
		/// </summary>
		public string Name { get; set; }

		/// <summary>
		/// Код марки автомобиля.
		/// </summary>
		public int BrandId { get; set; }
	}
}

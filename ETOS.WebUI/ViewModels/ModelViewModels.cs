using System;

namespace ETOS.WebUI.ViewModels
{
	public class ModelInfoViewModel
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
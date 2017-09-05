using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace ETOS.WebUI.ViewModels
{
	public class BrandListViewModel
	{
		public IEnumerable<BrandInfoViewModel> Brands { get; set; }
	}

	public class BrandInfoViewModel
	{
		/// <summary>
		/// Код марки автомобиля.
		/// </summary>
		[HiddenInput(DisplayValue = false)]
		public int Id { get; set; }

		/// <summary>
		/// Название марки автомобиля.
		/// </summary>
		[Required(ErrorMessage = "Пожалуйста, укажите название марки автомобиля.")]
		[MaxLength(50, ErrorMessage = "Длина названия марки автомобиля не должна превышать 50 символов.")]
		[Display(Name = "Название марки")]
		public string Name { get; set; }

	}

	public class BrandDetailsViewModel
	{
		public BrandInfoViewModel Brand { get; set; }

		public IEnumerable<ModelInfoViewModel> BrandedModels { get; set; }
	}
}
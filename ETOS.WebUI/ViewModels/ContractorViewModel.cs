using System;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;

using ETOS.Core.DTO;
using System.Web.Mvc;

namespace ETOS.WebUI.ViewModels
{
    /// <summary>
    /// ViewModel для поиска подрядчика
    /// </summary>
    public class ContractorViewModel
    {
        /// <summary>
        /// id заявки
        /// </summary>
		[ScaffoldColumn(false)]
        public int RequestId { get; set; }

        /// <summary>
        /// Адрес точки назначения
        /// </summary>
        public string DestinationAddress;

        /// <summary>
        /// Адрес точки отправки
        /// </summary>
        public string DepartureAddress;

        /// <summary>
        /// Список подрядчиков с информацией
        /// </summary>
        public List<DtoContractorInfo> contractors;

        /// <summary>
        /// Расстояние между пунктами
        /// </summary>
        public float Mileage { get; set; }


		public decimal Price { get; set; }

       /// <summary>
       /// Выбраный подрядчик
       /// </summary>
        public int SelectedContractorId { get; set; }

        /// <summary>
        /// Информация об автомобиле
        /// </summary>
        public string Comment { get; set; }

        /// <summary>
        ///  ошибки
        /// </summary>
        public List<string> errors { get; set; }
    }

	/// <summary>
	/// Модель представления для подрядчика.
	/// </summary>
	public class ContractorInfoViewModel
	{
		/// <summary>
		/// Код подрядчика.
		/// </summary>
		[ScaffoldColumn(false)]
		public int Id { get; set; }

		/// <summary>
		/// Название фирмы-подрядчика.
		/// </summary>
		[Required(ErrorMessage = "Пожалуйста, укажите название фирмы.")]
		[MaxLength(100, ErrorMessage = "Длина названия фирмы не должна превышать 100 символов!")]
		[Display(Name = "Название фирмы")]
		public string Name { get; set; }

		/// <summary>
		/// Номер телефона подрядчика.
		/// </summary>
		[Required(ErrorMessage = "Пожалуйста, укажите номер телефона фирмы.")]
		[MaxLength(16, ErrorMessage = "Длина номера телефона не должна превышать 16 символов!")]
		[Display(Name = "Номер телефона")]
		public string Phone { get; set; }

		/// <summary>
		/// Тариф подрядчика за 1 км.
		/// </summary>
		[Required(ErrorMessage = "Пожалуйста, укажите тариф подрядчика за 1 км.")]
		[Display(Name = "Тариф за 1 км.")]
		public decimal Tariff { get; set; }
	}

	/// <summary>
	/// Модель представления для списка подрядчиков.
	/// </summary>
	public class ContractorListViewModel
	{
		public IEnumerable<ContractorInfoViewModel> Contractors { get; set; }
	}
}

using System;
using System.ComponentModel.DataAnnotations;

namespace ETOS.WebUI.ViewModels
{
	/// <summary>
	/// Описывает модель представления входа в систему.
	/// </summary>
	public class LoginViewModel
	{
		/// <summary>
		/// Имя пользователя.
		/// </summary>
		[Required(ErrorMessage = "Пожалуйста, введите Ваш e-mail.")]
		[RegularExpression(@".+\@.+\..+", ErrorMessage = "Пожалуйста, укажите корректный e-mail.")]
		[Display(Name = "E-mail")]
		public string Username { get; set; }

		/// <summary>
		/// Пароль пользователя.
		/// </summary>
		[Required(ErrorMessage = "Пожалуйста, введите Ваш пароль.")]
		[DataType(DataType.Password)]
		[Display(Name = "Пароль")]
		public string Password { get; set; }

		/// <summary>
		/// Флаг запоминания пользователя в системе.
		/// </summary>
		[Display(Name = "Запомнить?")]
		public bool Persistent { get; set; }
	}
}
using System;

namespace ETOS.Core.DTO
{
	/// <summary>
	/// Представляет собой объект передачи учётных данных пользователя между уровнем представления и уровнем доступа к данным.
	/// </summary>
	public class DtoApplicationUser
	{
		/// <summary>
		/// Код учётной записи.
		/// </summary>
		public string Id { get; set; }

		/// <summary>
		/// E-mail пользователя.
		/// </summary>
		public string Email { get; set; }

		/// <summary>
		/// Пароль пользователя.
		/// </summary>
		public string Password { get; set; }
	}
}

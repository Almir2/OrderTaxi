using System;

using System.ComponentModel.DataAnnotations;

namespace ETOS.WebUI.ViewModels
{
	public class ApplicationUserViewModel
	{
		public string Id { get; set; }

		[Display(Name = "E-mail")]
		public string Email { get; set; }

		[Display(Name = "Пароль")]
		public string Password { get; set; }
	}

	public class ApplicationRoleViewModel
	{
		public string Name { get; set; }
	}
}
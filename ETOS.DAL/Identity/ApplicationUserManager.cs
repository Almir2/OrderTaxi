using System;

using Microsoft.AspNet.Identity;

using ETOS.DAL.Entities;

namespace ETOS.DAL.Identity
{
	/// <summary>
	/// Реализует управление учетными записями пользователей на уровне доступа к данным.
	/// </summary>
	public class ApplicationUserManager : UserManager<ApplicationUser>
	{
		public ApplicationUserManager(IUserStore<ApplicationUser> store) : base(store) { }
	}
}

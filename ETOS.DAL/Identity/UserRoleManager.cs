using System;

using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

using ETOS.DAL.Entities;

namespace ETOS.DAL.Identity
{
	/// <summary>
	/// Реализует управление роляеми пользователей системы на уровне доступа к данным.
	/// </summary>
	public class UserRoleManager : RoleManager<UserRole>
	{
		public UserRoleManager(RoleStore<UserRole> store) : base(store) { }
	}
}

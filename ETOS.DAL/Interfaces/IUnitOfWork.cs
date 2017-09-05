using System;
using System.Threading.Tasks;

using ETOS.DAL.Identity;

namespace ETOS.DAL.Interfaces
{
	/// <summary>
	/// Описывает единицу работы, необходимую для функционирования ASP.NET Identity.
	/// </summary>
	public interface IUnitOfWork : IDisposable
	{
		/// <summary>
		/// Экземпляр менеджера учётных записей пользователей.
		/// </summary>
		ApplicationUserManager UserManager { get; }

		/// <summary>
		/// Экземпляр менеджера ролей пользователей.
		/// </summary>
		UserRoleManager RoleManager { get; }

		// Асинхронная операция сохранения изменений в хранилище данных.
		Task SaveChangesAsync();
	}
}

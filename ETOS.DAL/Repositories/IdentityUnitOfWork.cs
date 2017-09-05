using System;
using System.Threading.Tasks;

using Microsoft.AspNet.Identity.EntityFramework;

using ETOS.DAL.EF;
using ETOS.DAL.Entities;
using ETOS.DAL.Interfaces;
using ETOS.DAL.Identity;

namespace ETOS.DAL.Repositories
{
	/// <summary>
	/// Реализует единицу работы, необходимую для функционирования ASP.NET Identity.
	/// </summary>
	public class IdentityUnitOfWork : IUnitOfWork
	{
		#region Fields

		/// <summary>
		/// Экземпляр хранилища данных.
		/// </summary>
		private IDataWarehouseContext _dataWarehouseContext;

		/// <summary>
		/// Экземпляр менеджера учётных записей пользователей.
		/// </summary>
		private ApplicationUserManager _userManager;

		/// <summary>
		/// Экземпляр менеджера ролей пользователей.
		/// </summary>
		private UserRoleManager _roleManager;

		#endregion

		#region Constructor

		public IdentityUnitOfWork(IDataWarehouseContext dataWarehouseContext)
		{
			_dataWarehouseContext = dataWarehouseContext;
			_userManager = new ApplicationUserManager(new UserStore<ApplicationUser>(_dataWarehouseContext as EFDataWarehouseContext));
			_roleManager = new UserRoleManager(new RoleStore<UserRole>(_dataWarehouseContext as EFDataWarehouseContext));
		}

		#endregion

		#region Accessors

		/// <summary>
		/// Экземпляр менеджера учётных записей пользователей (только для чтения).
		/// </summary>
		public ApplicationUserManager UserManager
		{
			get
			{
				return _userManager;
			}
		}

		/// <summary>
		/// Экземпляр менеджера ролей пользователей (только для чтения).
		/// </summary>
		public UserRoleManager RoleManager
		{
			get
			{
				return _roleManager;
			}
		}

		#endregion

		#region Methods

		/// <summary>
		/// Реализует асинхронное сохранение изменений в хранилище.
		/// </summary>
		public async Task SaveChangesAsync()
		{
			await _dataWarehouseContext.SaveChangesAsync();
		}

		#endregion

		#region Dispose support

		public void Dispose()
		{
			Dispose(true);
			GC.SuppressFinalize(this);
		}

		private bool _disposed = true;

		public virtual void Dispose(bool disposing)
		{
			if (!_disposed)
			{
				if (disposing)
				{
					_userManager.Dispose();
					_roleManager.Dispose();
				}
				_disposed = true;
			}
		}

		#endregion
	}
}

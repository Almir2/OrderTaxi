using System;
using System.Data.Entity;
using System.Threading.Tasks;
using System.Data.Entity.Infrastructure;

using ETOS.DAL.Entities;

namespace ETOS.DAL.Interfaces
{
	/// <summary>
	/// Описывает функционал, необходимый каждому хранилищу данных.
	/// </summary>
	public interface IDataWarehouseContext : IDisposable
	{
		IDbSet<TEntity> Set<TEntity>() where TEntity : class, IEntity;
		
		DbEntityEntry<TEntity> Entry<TEntity>(TEntity entity) where TEntity : class;

		int SaveChanges();

		Task SaveChangesAsync();
	}
}

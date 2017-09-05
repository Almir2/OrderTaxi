using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace ETOS.DAL.Interfaces
{
	/// <summary>
	/// Описывает функционал, необходимый для работы с экземплярами сущностей любого типа.
	/// </summary>
	/// <typeparam name="TEntity">Необходимая сущность-тип.</typeparam>
	public interface IRepository<TEntity> : IDisposable where TEntity : IEntity
	{
		void Add(TEntity item);
		void Update(TEntity item);
		void Delete(int id);

		IEnumerable<TEntity> All();
		TEntity GetById(int id);
		IEnumerable<TEntity> Find(Expression<Func<TEntity, bool>> predicate);

		void Commit();
	}
}

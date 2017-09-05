using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;

using ETOS.DAL.Entities;
using ETOS.DAL.Interfaces;

namespace ETOS.DAL.Repositories
{
	/// <summary>
	/// Реализует функционал, необходимый для работы с экземплярами сущности "Подрядчик".
	/// </summary>
	public class ContractorRepository : IContractorRepository
    {
		#region Fields
		
		/// <summary>
		/// Контекст хранилища данных, с которым работает данный репозиторий.
		/// </summary>
		private readonly IDataWarehouseContext _dataWarehouseContext;

		private bool _disposed = false;

		#endregion

		#region Constructor

		public ContractorRepository(IDataWarehouseContext dataWarehouseContext)
		{
			_dataWarehouseContext = dataWarehouseContext;
		}

		#endregion

		#region Methods

		/// <summary>
		/// Реализует добавление нового аккаунта.
		/// </summary>
		public void Add(Contractor item)
		{
			_dataWarehouseContext.Set<Contractor>().Add(item);

			Commit();
		}

		/// <summary>
		/// Реализует обновление заданного аккаунта. 
		/// </summary>
		public void Update(Contractor item)
		{
			_dataWarehouseContext.Entry(item).State = EntityState.Modified;

			Commit();
		}

		/// <summary>
		/// Реализует удаление аккаунта, соответствующего заданному идентификатору.
		/// </summary>
		public void Delete(int id)
		{
            Contractor acc = _dataWarehouseContext.Set<Contractor>().Find(id);
			
			if (acc != null)
				_dataWarehouseContext.Set<Contractor>().Remove(acc);

			Commit();
		}

		/// <summary>
		/// Реализует получение полного списка всех имеющихся аккаунтов.
		/// </summary>
		public IEnumerable<Contractor> All()
		{
			return _dataWarehouseContext.Set<Contractor>().AsEnumerable();
		}

		/// <summary>
		/// Реализует получение аккаунта, соответствующего заданному идентификатору.
		/// </summary>
		public Contractor GetById(int id)
		{
			return _dataWarehouseContext.Set<Contractor>().Find(id);
		}

		/// <summary>
		/// Реализует получение списка аккаунтов, удовлетворяющих заданному условию.
		/// </summary>
		/// <param name="predicate">Условие отбора.</param>
		public IEnumerable<Contractor> Find(Expression<Func<Contractor, bool>> predicate)
		{
			return _dataWarehouseContext.Set<Contractor>().Where(predicate).AsEnumerable();
		}

		/// <summary>
		/// Реализует сохранение изменений в хранилище данных.
		/// </summary>
		public void Commit()
		{
			_dataWarehouseContext.SaveChanges();
		}

		public virtual void Dispose(bool disposing)
		{
			if (!_disposed)
			{
				if (disposing)
				{
					_dataWarehouseContext.Dispose();
				}
			}
			_disposed = true;
		}

		public void Dispose()
		{
			Dispose(true);
			GC.SuppressFinalize(this);
		}

		#endregion
	}
}

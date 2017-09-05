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
    /// Реализует функционал, необходимый для работы с экземплярами сущности "Сотрудник".
    /// </summary>
    public class EmployeeRepository : IEmployeeRepository
	{
		#region Fields
		
		/// <summary>
		/// Контекст хранилища данных, с которым работает данный репозиторий.
		/// </summary>
		private readonly IDataWarehouseContext _dataWarehouseContext;

		private bool _disposed = false;

		#endregion

		#region Constructor

		public EmployeeRepository(IDataWarehouseContext dataWarehouseContext)
		{
			_dataWarehouseContext = dataWarehouseContext;
		}

		#endregion

		#region Methods

		/// <summary>
		/// Реализует добавление нового сотрудника.
		/// </summary>
		public void Add(Employee item)
		{
			_dataWarehouseContext.Set<Employee>().Add(item);
			
			Commit();
		}

		/// <summary>
		/// Реализует обновление данных сотрудника.
		/// </summary>
		public void Update(Employee item)
		{
			_dataWarehouseContext.Entry(item).State = EntityState.Modified;

			Commit();
		}

		/// <summary>
		/// Реализует удаление сотрудника с заданным табельным номером.
		/// </summary>
		public void Delete(int id)
		{
			Employee employee = _dataWarehouseContext.Set<Employee>().Find(id);
			
			if (employee != null)
				_dataWarehouseContext.Set<Employee>().Remove(employee);

			Commit();
		}

		/// <summary>
		/// Реализует получение списка всех сотрудников.
		/// </summary>
		public IEnumerable<Employee> All()
		{
			return _dataWarehouseContext.Set<Employee>().AsEnumerable();
		}

		/// <summary>
		/// Реализует получение сотруника с заданным табельным номером.
		/// </summary>
		public Employee GetById(int id)
		{
			return _dataWarehouseContext.Set<Employee>().Find(id);
		}

		/// <summary>
		/// Реализует получение списка сотрудников, удовлетворяющих заданному условию.
		/// </summary>
		/// <param name="predicate">Условие отбора.</param>
		public IEnumerable<Employee> Find(Expression<Func<Employee, bool>> predicate)
		{
			return _dataWarehouseContext.Set<Employee>().Where(predicate).AsEnumerable();
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

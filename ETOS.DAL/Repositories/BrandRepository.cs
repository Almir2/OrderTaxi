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
	/// Реализует функционал, необходимый для работы с экземплярами сущности "Марка автомобиля".
	/// </summary>
	public class BrandRepository : IBrandRepository
	{
		#region Fields

		/// <summary>
		/// Экземпляр хранилища данных.
		/// </summary>
		private readonly IDataWarehouseContext _dataWarehouseContext;

		private bool _disposed = false;

		#endregion

		#region Constructor

		public BrandRepository(IDataWarehouseContext dataWarehouseContext)
		{
			_dataWarehouseContext = dataWarehouseContext;
		}

		#endregion

		#region Methods

		/// <summary>
		/// Реализует добавление новой марки автомобиля.
		/// </summary>
		public void Add(Brand item)
		{
			_dataWarehouseContext.Set<Brand>().Add(item);

			Commit();
		}

		/// <summary>
		/// Реализует обновление данных марки автомобиля.
		/// </summary>
		public void Update(Brand item)
		{
			_dataWarehouseContext.Entry(item).State = EntityState.Modified;

			Commit();
		}

		/// <summary>
		/// Реализует удаление марки автомобиля с заданным идентификатором.
		/// </summary>
		public void Delete(int id)
		{
			Brand brand = _dataWarehouseContext.Set<Brand>().Find(id);

			if (brand != null)
				_dataWarehouseContext.Set<Brand>().Remove(brand);

			Commit();
		}

		/// <summary>
		/// Реализует получение списка всех марок автомобилей.
		/// </summary>
		public IEnumerable<Brand> All()
		{
			return _dataWarehouseContext.Set<Brand>().AsEnumerable();
		}

		/// <summary>
		/// Реализует получение марки автомобиля с заданным идентификатором.
		/// </summary>
		public Brand GetById(int id)
		{
			return _dataWarehouseContext.Set<Brand>().Find(id);
		}

		/// <summary>
		/// Реализует получение списка марок автомобилей, удовлетворяющих заданному условию.
		/// </summary>
		/// <param name="predicate">Условие отбора.</param>
		public IEnumerable<Brand> Find(Expression<Func<Brand, bool>> predicate)
		{
			return _dataWarehouseContext.Set<Brand>().Where(predicate).AsEnumerable();
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

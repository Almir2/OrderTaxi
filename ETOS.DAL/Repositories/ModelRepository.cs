using System;
using System.Data.Entity;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

using ETOS.DAL.Entities;
using ETOS.DAL.Interfaces;

namespace ETOS.DAL.Repositories
{
	/// <summary>
	/// Реализует функционал, необходимый для работы с экземплярами сущности типа "Модель автомобиля".
	/// </summary>
	public class ModelRepository : IModelRepository
	{
		#region Fields

		/// <summary>
		/// Экземпляр хранилища данных.
		/// </summary>
		private readonly IDataWarehouseContext _dataWarehouseContext;

		private bool _disposed = false;

		#endregion

		#region Construnctor

		public ModelRepository(IDataWarehouseContext dataWarehouseContext)
		{
			_dataWarehouseContext = dataWarehouseContext;
		}

		#endregion

		#region Methods

		/// <summary>
		/// Реализует добавление новой модели автомобиля.
		/// </summary>
		public void Add(Model item)
		{
			_dataWarehouseContext.Set<Model>().Add(item);

			Commit();
		}

		/// <summary>
		/// Реализует обновление данных модели автомобиля.
		/// </summary>
		public void Update(Model item)
		{
			_dataWarehouseContext.Entry(item).State = EntityState.Modified;

			Commit();
		}

		/// <summary>
		/// Реализует удаление модели автомобиля с заданным идентификатором.
		/// </summary>
		public void Delete(int id)
		{
			Model model = _dataWarehouseContext.Set<Model>().Find(id);

			if (model != null)
			{
				_dataWarehouseContext.Set<Model>().Remove(model);
			}	

			Commit();
		}

		/// <summary>
		/// Реализует получение списка всех моделей автомобилей.
		/// </summary>
		public IEnumerable<Model> All()
		{
			return _dataWarehouseContext.Set<Model>().AsEnumerable();
		}

		/// <summary>
		/// Реализует получение модели автомобиля с заданным идентификатором.
		/// </summary>
		public Model GetById(int id)
		{
			return _dataWarehouseContext.Set<Model>().Find(id);
		}

		/// <summary>
		/// Реализует получение списка моделей автомобилей, удовлетворяющих заданному условию.
		/// </summary>
		/// <param name="predicate">Условие отбора.</param>
		public IEnumerable<Model> Find(Expression<Func<Model, bool>> predicate)
		{
			return _dataWarehouseContext.Set<Model>().Where(predicate).AsEnumerable();
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

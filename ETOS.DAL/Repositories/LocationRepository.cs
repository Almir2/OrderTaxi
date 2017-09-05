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
	/// Реализует функционал, необходимый для работы с экземплярами сущности "Локации".
	/// </summary>
	public class LocationRepository : ILocationRepository
	{
		#region Fields

		/// <summary>
		/// Контекст хранилища данных, с которым работает данный репозиторий.
		/// </summary>
		private readonly IDataWarehouseContext _dataWarehouseContext;

		private bool _disposed = false;
		
		#endregion

		#region Constructor

		public LocationRepository(IDataWarehouseContext dataWarehouseContext)
		{
			_dataWarehouseContext = dataWarehouseContext;
		}

		#endregion

		#region Methods

		/// <summary>
		/// Реализует добавление новой локации.
		/// </summary>
		public void Add(Location item)
		{
			_dataWarehouseContext.Set<Location>().Add(item);

			Commit();
		}

        /// <summary>
        /// Реализует обновление данных локации.
        /// </summary>
        public void Update(Location item)
		{
			_dataWarehouseContext.Entry(item).State = EntityState.Modified;

			Commit();
		}

        /// <summary>
        /// Реализует удаление локации с заданным идентификатором.
        /// </summary>
        public void Delete(int id)
		{
			var req = _dataWarehouseContext.Set<Location>().Find(id);
			if (req != null)
				_dataWarehouseContext.Set<Location>().Remove(req);

			Commit();
		}

        /// <summary>
        /// Реализует получение списка всех локаций.
        /// </summary>
        public IEnumerable<Location> All()
		{
			return _dataWarehouseContext.Set<Location>().AsEnumerable();
		}

        /// <summary>
        /// Реализует получение списка всех локаций являющихся точкой интереса.
        /// </summary>
        public IEnumerable<Location> AllPOI()
        {
            return _dataWarehouseContext.Set<Location>().Where(c=>c.IsPOI).AsEnumerable();
        }

        /// <summary>
        /// Реализует получение локации с заданным идентификатором.
        /// </summary>
        public Location GetById(int id)
		{
			return _dataWarehouseContext.Set<Location>().Find(id);
		}

		/// <summary>
		/// Реализует получение списка локаций, удовлетворяющих заданному условию.
		/// </summary>
		/// <param name="predicate">Условие отбора.</param>
		public IEnumerable<Location> Find(Expression<Func<Location, bool>> predicate)
		{
			return _dataWarehouseContext.Set<Location>().Where(predicate).AsEnumerable();
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
			if (_disposed)
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

using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;

using ETOS.Common;
using ETOS.DAL.Entities;
using ETOS.DAL.Interfaces;
using ETOS.DAL.Enums;

namespace ETOS.DAL.Repositories
{
	/// <summary>
	/// Реализует функционал, необходимый для работы с экземплярами сущности "Заявка".
	/// </summary>
	public class RequestRepository : IRequestRepository
	{
		#region Fields

		/// <summary>
		/// Контекст хранилища данных, с которым работает данный репозиторий.
		/// </summary>
		private readonly IDataWarehouseContext _dataWarehouseContext;

		private bool _disposed = false;
		#endregion

		#region Constructor

		public RequestRepository(IDataWarehouseContext dataWarehouseContext)
		{
			_dataWarehouseContext = dataWarehouseContext;
		}

		#endregion

		#region Methods

		/// <summary>
		/// Реализует добавление новой заявки.
		/// </summary>
		public void Add(Request item)
		{
			_dataWarehouseContext.Set<Request>().Add(item);

			Commit();
		}

		/// <summary>
		/// Реализует обновление данных заявки.
		/// </summary>
		public void Update(Request item)
		{
			_dataWarehouseContext.Entry(item).State = EntityState.Modified;

			Commit();
		}

		/// <summary>
		/// Реализует удаление заявки с заданным идентификатором.
		/// </summary>
		public void Delete(int id)
		{
			var req = _dataWarehouseContext.Set<Request>().Find(id);
			if (req != null)
				_dataWarehouseContext.Set<Request>().Remove(req);

			Commit();
		}

		/// <summary>
		/// Реализует получение списка всех заявок.
		/// </summary>
		public IEnumerable<Request> All()
		{
			return _dataWarehouseContext.Set<Request>().AsEnumerable();
		}

		/// <summary>
		/// Реализует получение сотруника с заданным идентификатором.
		/// </summary>
		public Request GetById(int id)
		{
			return _dataWarehouseContext.Set<Request>().Find(id);
		}

		/// <summary>
		/// Реализует получение списка заявок, удовлетворяющих заданному условию.
		/// </summary>
		/// <param name="predicate">Условие отбора.</param>
		public IEnumerable<Request> Find(Expression<Func<Request, bool>> predicate)
		{
			return _dataWarehouseContext.Set<Request>().Where(predicate).AsEnumerable();
		}

		/// <summary>
		/// Реализует сохранение изменений в хранилище данных.
		/// </summary>
		public void Commit()
		{
			_dataWarehouseContext.SaveChanges();
		}

		/// <summary>
		/// Возвращает список заявок с примением фильтра
		/// </summary>		
		public IEnumerable<Request> GetRequestsApplyFilter(DisplayFilter filter)
		{
			var filteredSet = Find(x => (filter.RequestId == 0) || (x.Id == filter.RequestId))
                                .Where(x => (filter.AuthorFirstName == null) || (x.Employee.Firstname == filter.AuthorFirstName) || (x.Employee.Firstname).Contains(filter.AuthorFirstName))
								.Where(x => (filter.AuthorLastName == null) || (x.Employee.Lastname == filter.AuthorLastName) || (x.Employee.Lastname).Contains(filter.AuthorLastName))
								.Where(x => (filter.DeparturePoint == null) || (x.DeparturePoint.Name == filter.DeparturePoint) || (x.DeparturePoint.Name).Contains(filter.DeparturePoint))
								.Where(x => (filter.DestinationPoint == null) || (x.DestinationPoint.Name == filter.DestinationPoint) || (x.DestinationPoint.Name).Contains(filter.DestinationPoint))
								.Where(x => (filter.DepartureAddress == null) || (x.DepartureAddress == filter.DepartureAddress))
								.Where(x => (filter.DestinationAddress == null) || (x.DestinationAddress == filter.DestinationAddress))
								.Where(x => (filter.DepartureDateTime == DateTime.MinValue) || (x.DepartureDateTime == filter.DepartureDateTime))
								.Where(x => (filter.CreationDateTime == DateTime.MinValue) || (x.CreationDateTime == filter.CreationDateTime))
								.Where(x => (filter.HasBaggage == false) || (x.HasBaggage == filter.HasBaggage))
								.Where(x => (filter.Comment == null) || (x.Comment == filter.Comment))
								.Where(x => (filter.Mileage == 0) || (x.Mileage == filter.Mileage))
								.Where(x => (filter.Price == 0) || (x.Price == filter.Price))
								.Where(x => (filter.StatusName== null) || (((Statuses)(x.StatusId)).ToString() == filter.StatusName));
			return filteredSet;
		}

		/// <summary>
		/// Реализует получение заданной страницы указанного размера.
		/// </summary>
		public IEnumerable<Request> GetPage(DisplayFilter filter, int pageSize = 50, int pageNumber = 1)
		{
			var filteredPage = GetRequestsApplyFilter(filter)
					.Skip((pageNumber - 1) * pageSize)
					.Take(pageSize);

			return filteredPage;
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

using ETOS.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using ETOS.DAL.Entities;
using System.Linq.Expressions;
using System.Data.Entity;
using ETOS.Common;

namespace ETOS.DAL.Repositories
{
    public class LogRepository : ILogRepository
    {

        #region Fields

        /// <summary>
        /// Контекст хранилища данных, с которым работает данный репозиторий.
        /// </summary>
        private readonly IDataWarehouseContext _dataWarehouseContext;

        private bool _disposed = false;

        #endregion

        #region Constructor

        public LogRepository(IDataWarehouseContext dataWarehouseContext)
        {
            _dataWarehouseContext = dataWarehouseContext;
        }

        #endregion

        public void Add(Log item)
        {
            _dataWarehouseContext.Set<Log>().Add(item);

            Commit();
        }

        public IEnumerable<Log> All()
        {
            return _dataWarehouseContext.Set<Log>().AsEnumerable();
        }

        public void Commit()
        {
            _dataWarehouseContext.SaveChanges();
        }

        public void Delete(int id)
        {
            Log log = _dataWarehouseContext.Set<Log>().Find(id);

            if (log != null)
                _dataWarehouseContext.Set<Log>().Remove(log);

            Commit();
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

        public IEnumerable<Log> Find(Expression<Func<Log, bool>> predicate)
        {
            return _dataWarehouseContext.Set<Log>().Where(predicate).AsEnumerable();
        }

        public Log GetById(int id)
        {
            return _dataWarehouseContext.Set<Log>().Find(id);
        }

        public void Update(Log item)
        {
            _dataWarehouseContext.Entry(item).State = EntityState.Modified;

            Commit();
        }

        public IEnumerable<Log> GetLogsByFilter(LogFilter filter)
        {
            var filteredSet = Find(x => x.Id != null)
                            .Where(x => (filter.CreatorLastName == x.CreatorLastName || filter.CreatorLastName == null))
                            .Where(x => (filter.CreatorFirstName == x.CreatorFirstName || filter.CreatorFirstName == null))
                            .Where(x => (filter.CreationDate.ToString("yyyy-MM-dd") == x.CreationDateTime.ToString("yyyy-MM-dd") || filter.CreationDate == DateTime.MinValue));
            return filteredSet;
        }
    }
}

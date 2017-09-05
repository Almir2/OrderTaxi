using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using ETOS.Common;
using ETOS.DAL.Entities;

namespace ETOS.DAL.Interfaces
{
    /// <summary>
	/// Описывает функционал, необходимый для работы с экземплярами сущностей заявки
	/// </summary>
	/// <typeparam name="TEntity">Необходимая сущность-тип.</typeparam>
	public interface IRequestRepository : IRepository<Request>
	{
		IEnumerable<Request> GetPage(DisplayFilter filter, int pageSize = 50, int pageNumber = 1);

        IEnumerable<Request> GetRequestsApplyFilter(DisplayFilter filter);

    }
}

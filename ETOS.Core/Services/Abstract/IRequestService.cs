using System.Collections.Generic;
using ETOS.Common;
using ETOS.Core.DTO;

namespace ETOS.Core.Services.Abstract
{
	/// <summary>
	/// Интерфейс сервиса по работе с заявками пользователей.
	/// </summary>
	public interface IRequestService
	{
		IEnumerable<DtoRequest> GetRequest(DisplayFilter filter);

		bool GetRequestById(int id, out DtoRequest outrequest, out string error);

		bool AddRequest(DtoCreateRequest item, out string errorMsg);

		void DeleteRequest(DtoRequest item);

		void UpdateRequestStatus(int id, int statusId, string comment);

	}
}

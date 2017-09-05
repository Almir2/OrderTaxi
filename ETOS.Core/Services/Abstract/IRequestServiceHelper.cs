using ETOS.Core.DTO;
using ETOS.DAL.Entities;
using System.Collections.Generic;

namespace ETOS.Core.Services.Abstract
{
    /// <summary>
	/// Интерфейс вспомогательного сервиса для работы с заявками пользователей.
	/// </summary>
    public interface IRequestServiceHelper
    {
        bool MapDtoCreateRequestToRequest(DtoCreateRequest item, out Request newRequest, out string errorMsg);

        bool MapRequestToDtoRequest(Request request, out DtoRequest dtoRequest);

        bool MapIEnumRequestToIEnumDtoRequest(IEnumerable<Request> request, out List<DtoRequest> dtoRequest);
    }
}
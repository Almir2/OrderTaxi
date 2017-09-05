using System;
using System.Collections.Generic;

using ETOS.Core.DTO;

namespace ETOS.Core.Services.Abstract
{
	/// <summary>
	/// Интерфейс сервиса по работе с подрядчиками.
	/// </summary>
	public interface IContractorService
	{
		//List<DtoContractorInfo> GetContractorsForLocation(int id);

		List<DtoContractorInfo> GetAllContractors();

		//List<DtoContractorInfo> GetContractorsForLocations(int id1,int id2);

		bool SetContractorForRequest(out string error, int contractorId, int requestId, string comment);

		IEnumerable<DtoContractor> GetContractorsList();

		void SaveContractor(DtoContractor contractorDto);

		DtoContractor GetContractor(int id);

		void RemoveContractor(int id);
	}
}

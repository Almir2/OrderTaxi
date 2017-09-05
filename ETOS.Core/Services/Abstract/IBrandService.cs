using System;
using System.Collections.Generic;

using ETOS.Core.DTO;

namespace ETOS.Core.Services.Abstract
{
	/// <summary>
	/// Описывает функционал, необходимый сервису для работы с марками автомобилей.
	/// </summary>
	public interface IBrandService
	{
		IEnumerable<DtoBrand> GetBrandsList();

		DtoBrand GetBrand(int id);

		void SaveBrand(DtoBrand brandDto);

		void RemoveBrand(int id);
	}
}

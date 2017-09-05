using System;
using System.Collections.Generic;

using ETOS.Core.DTO;

namespace ETOS.Core.Services.Abstract
{
	/// <summary>
	/// Описывает функционал, необходимый сервису для работы с моделями автомобилей.
	/// </summary>
	public interface IModelService
	{
		IEnumerable<DtoModel> GetBrandModelsList(int brandId);

		DtoModel GetModel(int brandedModelId);

		void SaveModel(DtoModel modelDto);

		void RemoveModel(int id); 
	}
}

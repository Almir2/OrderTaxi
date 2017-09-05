using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using ETOS.DAL.Entities;
using ETOS.DAL.Interfaces;
using ETOS.Core.DTO;
using ETOS.Core.Services.Abstract;

namespace ETOS.Core.Services
{
	/// <summary>
	/// Сервис для работы с моделями автомобилей.
	/// </summary>
	public class ModelService : IModelService
	{
		#region Fields

		/// <summary>
		/// Экземпляр репозитория моделей автомобилей.
		/// </summary>
		private readonly IModelRepository _modelRepository;

		#endregion

		#region Constructor

		public ModelService(IModelRepository modelRepository)
		{
			_modelRepository = modelRepository;
		}

		#endregion

		#region Methods

		public IEnumerable<DtoModel> GetBrandModelsList(int brandId)
		{
			var models = _modelRepository.Find(m => m.BrandId == brandId)
				.Select(m => new DtoModel
				{
					Id = m.Id,
					Name = m.Name,
					BrandId = m.BrandId
				});

			return models;
		}

		public DtoModel GetModel(int brandedModelId)
		{
			var model = _modelRepository.GetById(brandedModelId);

			return new DtoModel { Id = model.Id, Name = model.Name, BrandId = model.BrandId } ?? null;
		}

		public void SaveModel(DtoModel modelDto)
		{
			var model = new Model
			{
				Id = modelDto.Id,
				Name = modelDto.Name,
				BrandId = modelDto.BrandId
			};

			if (model.Id == 0)
			{
				_modelRepository.Add(model);
			}
			else
			{
				_modelRepository.Update(model);
			}
		}

		public void RemoveModel(int id)
		{
			_modelRepository.Delete(id);
		}

		#endregion
	}
}

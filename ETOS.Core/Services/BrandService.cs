using System;
using System.Linq;
using System.Collections.Generic;

using ETOS.DAL.Entities;
using ETOS.DAL.Interfaces;
using ETOS.Core.DTO;
using ETOS.Core.Services.Abstract;

namespace ETOS.Core.Services
{
	public class BrandService : IBrandService
	{
		#region Fields

		private readonly IBrandRepository _brandRepository;

		#endregion

		#region Constructor
		
		public BrandService(IBrandRepository brandRepository)
		{
			_brandRepository = brandRepository;
		}

		#endregion

		public DtoBrand GetBrand(int id)
		{
			var brand = _brandRepository.GetById(id);

			return new DtoBrand { Id = brand.Id, Name = brand.Name } ?? null;
		}

		public IEnumerable<DtoBrand> GetBrandsList()
		{
			var brands = _brandRepository.All()
				.Select(br => new DtoBrand
				{
					Id = br.Id,
					Name = br.Name
				});

			return brands;
		}
		
		public void RemoveBrand(int id)
		{
			_brandRepository.Delete(id);
		}

		public void SaveBrand(DtoBrand brandDto)
		{
			var brand = new Brand
			{
				Id = brandDto.Id,
				Name = brandDto.Name
			};

			if (brand.Id == 0)
			{
				_brandRepository.Add(brand);
			}
			else
			{
				_brandRepository.Update(brand);
			}
		}
	}
}

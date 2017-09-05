using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using ETOS.Core.DTO;
using ETOS.Core.Services;
using ETOS.Core.Services.Abstract;
using ETOS.WebUI.ViewModels;


namespace ETOS.WebUI.Controllers
{
	public class BrandController : Controller
	{
		#region Fields

		private readonly IBrandService _brandService;

		private readonly IModelService _modelService;

		#endregion

		#region Constructor

		public BrandController(IBrandService brandService, IModelService modelService)
		{
			_brandService = brandService;
			_modelService = modelService;
		}

		#endregion

		public ActionResult Index()
		{
			BrandListViewModel model = new BrandListViewModel
			{
				Brands = _brandService.GetBrandsList()
					.Select(br => new BrandInfoViewModel
					{
						Id = br.Id,
						Name = br.Name
					})
			};

			return View(model);
		}

		public ActionResult Create()
		{
			ViewBag.Title = "Добавление новой марки автомобиля";

			return View("Edit", new BrandInfoViewModel());
		}

		public ActionResult Edit(int brandId)
		{
			var brand = _brandService.GetBrand(brandId);
			var model = new BrandInfoViewModel { Id = brand.Id, Name = brand.Name };

			ViewBag.Title = "Редактирование марки автомобиля";

			return View(model);
		}

		public ActionResult Save(BrandInfoViewModel model)
		{
			var brandDto = new DtoBrand { Id = model.Id, Name = model.Name };

			_brandService.SaveBrand(brandDto);

			return RedirectToAction("Index");
		}

		public ActionResult Remove(int brandId)
		{
			if (brandId > 0)
			{
				_brandService.RemoveBrand(brandId);
			}
			else
			{
				return View("Error");
			}

			return RedirectToAction("Index");
		}

		public ActionResult Details (int brandId)
		{
			var brandDto = _brandService.GetBrand(brandId);
			var modelsDto = _modelService.GetBrandModelsList(brandId);

			var model = new BrandDetailsViewModel
			{
				Brand = new BrandInfoViewModel { Id = brandDto.Id, Name = brandDto.Name },
				BrandedModels = modelsDto
					.Select(m => new ModelInfoViewModel { Id = m.Id, Name = m.Name, BrandId = m.BrandId })
			};

			return View(model);
		}
	}
}
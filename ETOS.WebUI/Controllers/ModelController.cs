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
	public class ModelController : Controller
	{
		#region Fields

		private readonly IModelService _modelService;

		#endregion

		#region Constructor

		public ModelController(IModelService modelService)
		{
			_modelService = modelService;
		}

		#endregion

		#region Methods

		public ActionResult Create(int brandId)
		{
			ViewBag.Title = "Добавление новой модели автомобиля";

			return View("Edit", new ModelInfoViewModel { BrandId = brandId });
		}

		public ActionResult Edit(int brandedModelId)
		{
			var brandedModel = _modelService.GetModel(brandedModelId);
			var model = new ModelInfoViewModel
			{
				Id = brandedModel.Id,
				Name = brandedModel.Name,
				BrandId = brandedModel.BrandId
			};

			ViewBag.Title = "Редактирование модели автомобиля";

			return View(model);
		}

		[HttpPost]
		public ActionResult Save(ModelInfoViewModel model)
		{
			var modelDto = new DtoModel { Id = model.Id, Name = model.Name, BrandId = model.BrandId };

			_modelService.SaveModel(modelDto);

			return RedirectToAction("Details", "Brand", new { @brandId = model.BrandId });
		}

		public ActionResult Remove(int brandId, int brandedModelId)
		{
			if (brandedModelId > 0)
			{
				_modelService.RemoveModel(brandedModelId);
			}
			else
			{
				return View("Error");
			}

			return RedirectToAction("Details", "Brand", new { @brandId = brandId });
		}

		#endregion
	}
}
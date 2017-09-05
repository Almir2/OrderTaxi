using System.Linq;
using System.Collections.Generic;
using System.Web.Mvc;

using ETOS.Core.DTO;
using ETOS.Core.Services.Abstract;
using ETOS.WebUI.ViewModels;
using ETOS.WebUI.RequestPriceCalculator;

namespace ETOS.WebUI.Controllers
{
	/// <summary>
	/// Контроллер, обеспечивающий работу с подрядчиками на уровне представления.
	/// </summary>
	[Authorize]
    public class ContractorController : Controller
    {
        #region Fields

        IRequestService _requestService;
        ILocationService _locationService;
        IContractorService _contractorService;

        #endregion 

        #region Constructor

        public ContractorController(IRequestService reqService, ILocationService locService, IContractorService contractorService)
        {
            _requestService = reqService;
            _locationService = locService;
            _contractorService = contractorService;
        }

        #endregion 

        #region Methods

        /// <summary>
        /// Get-версия метода, возвращающая представление с подрядчиками подходящими данной заявке
        /// </summary>        
        [HttpGet]
        public ViewResult Select(int id)
        {
            var model = new ContractorViewModel();
            model.errors = new List<string>();
            var error = "";
            var request = new DtoRequest();
            if (!_requestService.GetRequestById(id, out request, out error))
            {
                model.errors.Add(error);
            }

            model.RequestId = request.Id;
            model.Mileage = request.Mileage;

            int? DeparturePointId = null;
         
            if (request.DeparturePointId != null)
            {
                DeparturePointId = request.DeparturePointId;
                model.DepartureAddress = _locationService.GetPOIById((int)DeparturePointId).Name;
            }
            else
            {
                model.DepartureAddress = request.DepartureAddress;
            }


			int? DestinationPointId = null;

			if (request.DestinationPointId != null)
			{
				DestinationPointId = request.DestinationPointId;
				model.DestinationAddress = _locationService.GetPOIById((int)DestinationPointId).Name;
			}
			else
			{
				model.DestinationAddress = request.DestinationAddress;
			}


			model.contractors = _contractorService.GetAllContractors();

            if (model.contractors == null || model.contractors.Count == 0)
            {
                model.errors.Add("Не найдено подходящих вариантов для данной поездки");
            }

			var requestPriceCalculator = new RequestPriceCalculatingServiceClient();
            
			// заполняем цену поездки для каждого подрядчика 
            foreach (var contractor in model.contractors)
            {
				contractor.TotalPrice = /*(decimal)model.Mileage * contractor.Tariff;*/ requestPriceCalculator.CalculateRequestPrice(model.Mileage, contractor.Tariff);
			}

			requestPriceCalculator.Close();

            return View(model);
        }

        /// <summary>
        /// Get-версия метода, возвращающая представление для создания новой заявки.
        /// </summary>
        [HttpPost]
        public ActionResult Select(ContractorViewModel model)
        {
            var error = "";
            if (model.errors == null) model.errors = new List<string>();

            if (!_contractorService.SetContractorForRequest(out error, model.SelectedContractorId, model.RequestId, model.Comment))
            {
                model.errors.Add(error);
                return View(model);
            }
            return RedirectToAction("Index", "Request");
        }

		public ViewResult Index()
		{
			var model = new ContractorListViewModel
			{
				Contractors = _contractorService.GetContractorsList()
					.Select(c => new ContractorInfoViewModel
					{
						Id = c.Id,
						Name = c.Name,
						Phone = c.Phone,
						Tariff = c.Tariff
					})
			};

			return View(model);
		}

		public ViewResult Create()
		{
			ViewBag.Title = "Добавление нового подрядчика";

			return View("Edit", new ContractorInfoViewModel { Id = 0 });
		}

		public ViewResult Edit(int contractorId)
		{
			var contractorDto = _contractorService.GetContractor(contractorId);

			if (contractorDto != null)
			{
				var model = new ContractorInfoViewModel
				{
					Id = contractorDto.Id,
					Name = contractorDto.Name,
					Phone = contractorDto.Phone,
					Tariff = contractorDto.Tariff
				};

				ViewBag.Title = "Редактирование данных подрядчика";

				return View(model);
			}

			return View("_Error");
		}

		public ActionResult Save(ContractorInfoViewModel model)
		{
			if (ModelState.IsValid)
			{
				var contractor = new DtoContractor
				{
					Id = model.Id,
					Name = model.Name,
					Phone = model.Phone,
					Tariff = model.Tariff
				};

				_contractorService.SaveContractor(contractor);

				return RedirectToAction("Index");
			}
			else
			{
				if (model.Id > 0)
				{
					return RedirectToAction("Edit", new { contractorId = model.Id });
				}
				else
				{
					return RedirectToAction("Create");
				}
			}
		}
		
		public ActionResult Remove(int contractorId)
		{
			if (contractorId > 0)
			{
				_contractorService.RemoveContractor(contractorId);

				return RedirectToAction("Index");
			}
			else
			{
				return View("_Error");
			}
		}
		
		#endregion
	}
}

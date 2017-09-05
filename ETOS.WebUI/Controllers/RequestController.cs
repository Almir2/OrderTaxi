using System.Collections.Generic;
using System.Web.Mvc;
using System.Web;

using ETOS.Core.DTO;
using ETOS.Core.Services.Abstract;
using ETOS.Common;
using static ETOS.WebUI.ViewModels.RequestsViewModels;

using PagedList;
using Microsoft.AspNet.Identity.Owin;
using System.Linq;
using ETOS.WebUI.ViewModels;
using ETOS.DAL.Enums;
using System;
using ETOS.WSL;

namespace ETOS.WebUI.Controllers
{
	/// <summary>
	/// Контроллер, обеспечивающий работу с заявками на уровне представления.
	/// </summary>
	[Authorize]
	public class RequestController : Controller
	{
		#region Fields

		IRequestService _requestService;
		ILocationService _locationService;
		private DisplayFilter _displayFilter;
		private LogFilter _logFilter;
		IEmployeeService _employeeService;
		ILogService _logService;

		private IApplicationUserService _userService
		{
			get
			{
				return HttpContext.GetOwinContext().GetUserManager<IApplicationUserService>();
			}
		}
		#endregion

		#region Constructor

		public RequestController(IRequestService reqService, ILocationService locService, IEmployeeService employeeService, ILogService logService)
		{
			_requestService = reqService;
			_locationService = locService;
			_employeeService = employeeService;
			_logService = logService;
		}

		#endregion

		#region Methods

		[HttpGet]
		public ActionResult Index()
		{
			if (HttpContext.User.IsInRole("Секретарь"))
			{
				return RedirectToAction("PartialSecretaryIndex", "Request");
			}
			if (HttpContext.User.IsInRole("Бухгалтер"))
			{
				return RedirectToAction("Index", "Request");
			}
			if (HttpContext.User.IsInRole("Менеджер"))
			{
				return RedirectToAction("PartialManagerIndex", "Request");
			}
			if (HttpContext.User.IsInRole("Администратор"))
			{
				return RedirectToAction("PartialAdminIndex", "Request");
			}
			return RedirectToAction("PartialRequestIndex", "Request");
		}

		/// <summary>
		/// Get-версия метода, возвращающая представление с полным перечнем заявок.
		/// </summary>
		[HttpGet]
		public ActionResult PartialRequestIndex(DisplayFilter displayFilter, string cleanFilter, int? page)
		{

			if (displayFilter.AuthorFirstName != null || displayFilter.AuthorLastName != null || displayFilter.DepartureAddress != null || displayFilter.DestinationAddress != null)
			{
				Session["disFilter"] = displayFilter;
				_displayFilter = displayFilter;
			}
			else
			{
				if (_displayFilter == null && (DisplayFilter)Session["disFilter"] == null)
				{
					_displayFilter = (new DisplayFilter()).GetDefault();
				}
				else
				{
					_displayFilter = (DisplayFilter)Session["disFilter"];
				}
			}
			if (cleanFilter == "true")
			{
				_displayFilter = (new DisplayFilter()).GetDefault();
			}

			if (displayFilter.AuthorFirstName == null && displayFilter.AuthorLastName == null && displayFilter.DepartureAddress == null && displayFilter.DestinationAddress == null)
			{
				_displayFilter = (new DisplayFilter()).GetDefault();
			}

			var userId = _userService.GetUserByMail(HttpContext.User.Identity.Name).Id;
			var userName = _employeeService.GetUserLastName(userId).Lastname;
			_displayFilter.AuthorLastName = userName;

			int pageSize = 5;
			int pageNumber = (page ?? 1);

			var model = new RequestIndexViewModel();

			var requestsList = _requestService.GetRequest(_displayFilter).OrderByDescending(x => x.Id);
			model.Requests = requestsList.ToPagedList(pageNumber, pageSize);

			return PartialView(model);
		}

		[HttpGet]
		public ViewResult MoreDetails(int Id)
		{
			string error = "";

			var request = new DtoRequest();

			_requestService.GetRequestById(Id, out request, out error);

			var model = new EditRequestModel();

			model.Request = request;

			return View(model);
		}

		/// <summary>
		/// Get-версия метода, возвращающая представление с полями заявки
		/// </summary>
		[HttpGet]
		public ActionResult Edit()
		{
			return View();
		}

		/// <summary>
		/// Post - Версия метода обновляет заявку или выводит ошибки
		/// </summary>
		[HttpPost]
		public ActionResult Edit(RequestsViewModels model)
		{
			return View(model);

		}

		/// <summary>
		/// Get-версия метода, возвращающая представление для создания новой заявки.
		/// </summary>
		[HttpGet]
		public ViewResult Create()
		{
			var model = new CreateRequestModel();

			var poiList = _locationService.GetPOIList();

			model.POIList = new SelectList(poiList, "Id", "Name");
			model.POIListAddresses = new SelectList(poiList, "Id", "Address");

			model.Request = new DtoCreateRequest();

			return View(model);
		}

		/// <summary>
		/// Get-версия метода, возвращающая представление для создания новой заявки.
		/// </summary>
		[HttpPost]
		public ActionResult Create(CreateRequestModel model)
		{

			var valid = true;
			var addresses = new List<string>();

			if (model.Errors == null) model.Errors = new List<string>();

			if (model.Request.DepartureAddress == "" && model.Request.DeparturePointId == 0)
			{
				model.Errors.Add("Укажите адрес отправления");
				valid = false;
			}

			if (model.Request.DestinationAddress == "" && model.Request.DestinationPointId == 0)
			{
				model.Errors.Add("Укажите адрес назначения");
				valid = false;
			}

			//TODO сделать валидацию даты времени отправления

			if (!valid)
			{
				var poiList = _locationService.GetPOIList();
				model.POIList = new SelectList(poiList, "Id", "Name");
				model.POIListAddresses = new SelectList(poiList, "Id", "Address");

				return View(model);
			}

			var mileageService = new MileageCalculatingService();
			string calcDestinationAddress;
			string calcDepartureAddress;

			if (model.Request.DestinationPointId == 0)
			{
				calcDestinationAddress = model.Request.DestinationAddress;
			}
			else
			{
				calcDestinationAddress = _locationService.GetPOIById(model.Request.DestinationPointId).Address;
			}

			if (model.Request.DeparturePointId == 0)
			{
				calcDepartureAddress = model.Request.DepartureAddress;
			}
			else
			{
				calcDepartureAddress = _locationService.GetPOIById(model.Request.DeparturePointId).Address;
			}

			model.Request.Mileage = mileageService.GetMileage(calcDepartureAddress, calcDestinationAddress);


			model.Request.AuthorLogin = User.Identity.Name;
			var error = "";
			if (!_requestService.AddRequest(model.Request, out error))
			{
				model.Errors.Add(error);
				var poiList = _locationService.GetPOIList();
				model.POIList = new SelectList(poiList, "Id", "Name");
				model.POIListAddresses = new SelectList(poiList, "Id", "Address");
				return View(model);
			}

			var userId = _userService.GetUserByMail(HttpContext.User.Identity.Name).Id;

			var newLog = new DtoLog()
			{
				CreatorFirstName = _employeeService.GetUserLastName(userId).Firstname,
				CreatorLastName = _employeeService.GetUserLastName(userId).Lastname,
				BrowserName = HttpContext.Request.Browser.Browser,
				IpAddress = HttpContext.Request.UserHostAddress,
				RequestMile = model.Request.Mileage,
				RequestPrice = 10
			};

			_logService.AddLog(newLog, out error);

			return RedirectToAction("Index", "Request");
		}
		[Authorize(Roles = "Секретарь")]
		[HttpGet]
		public ActionResult PartialSecretaryIndex(DisplayFilter displayFilter, string cleanFilter, int? page)
		{

			if (displayFilter.AuthorFirstName != null || displayFilter.AuthorLastName != null || displayFilter.DepartureAddress != null || displayFilter.DestinationAddress != null)
			{
				_displayFilter = displayFilter;
			}
			else
			{
				if (_displayFilter == null)
				{
					_displayFilter = (new DisplayFilter()).GetDefault();
				}
			}
			if (cleanFilter == "true")
			{
				_displayFilter = (new DisplayFilter()).GetDefault();
			}

			if (displayFilter.AuthorFirstName == null && displayFilter.AuthorLastName == null && displayFilter.DepartureAddress == null && displayFilter.DestinationAddress == null)
			{
				_displayFilter = (new DisplayFilter()).GetDefault();
			}


			int pageSize = 5;
			int pageNumber = (page ?? 1);

			var model = new RequestIndexViewModel();
			var requestsList = _requestService.GetRequest(_displayFilter).OrderByDescending(x => x.Id);
			model.Requests = requestsList.ToPagedList(pageNumber, pageSize);

			return PartialView(model);
		}
		[Authorize(Roles = "Секретарь")]
		[HttpGet]
		public ActionResult SecretaryHandleRequest(int? id)
		{
			var error = "";
			if (id == null) return HttpNotFound();

			var model = new RequestHandleViewModel();

			var filter = new DisplayFilter();

			var ar = new DtoRequest();

			if (!_requestService.GetRequestById((int)id, out ar, out error)) return HttpNotFound();

			model.Request = ar;

			return View(model);
		}
		[Authorize(Roles = "Секретарь")]
		[HttpPost]
		public ActionResult SecretaryReject(RequestHandleViewModel model)
		{
			_requestService.UpdateRequestStatus(model.Request.Id, (int)Statuses.WasDeclined, model.Request.Comment);

			return RedirectToAction("Index", "Request");
		}

		[HttpPost]
		public ActionResult SecretaryFinishFailed(RequestHandleViewModel model)
		{
			_requestService.UpdateRequestStatus(model.Request.Id, (int)Statuses.WasCompletedPoorly, model.Request.Comment);

			return RedirectToAction("Index", "Request");
		}
		[Authorize(Roles = "Секретарь")]
		[HttpPost]
		public ActionResult SecretaryFinishSuccess(RequestHandleViewModel model)
		{
			_requestService.UpdateRequestStatus(model.Request.Id, (int)Statuses.WasCompletedSuccessfully, model.Request.Comment);

			return RedirectToAction("Index", "Request");
		}
		[Authorize(Roles = "Менеджер")]
		[HttpGet]
		public ActionResult PartialManagerIndex(DisplayFilter displayFilter, string cleanFilter, int? page)
		{

			if (displayFilter.AuthorFirstName != null || displayFilter.AuthorLastName != null || displayFilter.DepartureAddress != null || displayFilter.DestinationAddress != null)
			{
				Session["disFilter"] = displayFilter;
				_displayFilter = displayFilter;
			}
			else
			{
				if (_displayFilter == null && (DisplayFilter)Session["disFilter"] == null)
				{
					_displayFilter = (new DisplayFilter()).GetDefault();
				}
				else
				{
					_displayFilter = (DisplayFilter)Session["disFilter"];
				}
			}
			if (cleanFilter == "true")
			{
				_displayFilter = (new DisplayFilter()).GetDefault();
			}

			if (displayFilter.AuthorFirstName == null && displayFilter.AuthorLastName == null && displayFilter.DepartureAddress == null && displayFilter.DestinationAddress == null)
			{
				_displayFilter = (new DisplayFilter()).GetDefault();
			}


			var model = new RequestIndexViewModel();

			var requestsList = _requestService.GetRequest(_displayFilter).OrderByDescending(x => x.Id);

			int pageSize = 5;
			int pageNumber = (page ?? 1);

			model.Requests = requestsList.ToPagedList(pageNumber, pageSize);

			return PartialView(model);
		}


		[Authorize(Roles = "Менеджер")]
		[HttpGet]
		public ActionResult ManagerHandleRequest(int? id)
		{
			var error = "";
			if (id == null) return HttpNotFound();

			var model = new RequestHandleViewModel();

			var filter = new DisplayFilter();

			var ar = new DtoRequest();

			if (!_requestService.GetRequestById((int)id, out ar, out error)) return HttpNotFound();

			model.Request = ar;

			return View(model);
		}
		[Authorize(Roles = "Менеджер")]
		[HttpPost]
		public ActionResult ManagerReject(RequestHandleViewModel model)
		{
			_requestService.UpdateRequestStatus(model.Request.Id, (int)Statuses.WasDeclined, model.Request.Comment);

			return RedirectToAction("Index", "Request");
		}
		[Authorize(Roles = "Менеджер")]
		[HttpPost]
		public ActionResult ManagerFinishFailed(RequestHandleViewModel model)
		{
			_requestService.UpdateRequestStatus(model.Request.Id, (int)Statuses.WasCompletedPoorly, model.Request.Comment);

			return RedirectToAction("Index", "Request");
		}
		[Authorize(Roles = "Менеджер")]
		[HttpPost]
		public ActionResult ManagerFinishSuccess(RequestHandleViewModel model)
		{
			_requestService.UpdateRequestStatus(model.Request.Id, (int)Statuses.WasCompletedSuccessfully, model.Request.Comment);

			return RedirectToAction("Index", "Request");
		}
		[Authorize(Roles = "Администратор")]
		[HttpGet]
		public ActionResult PartialAdminIndex(DisplayFilter displayFilter, string cleanFilter, int? page)
		{

			if (displayFilter.AuthorFirstName != null || displayFilter.AuthorLastName != null || displayFilter.DepartureAddress != null || displayFilter.DestinationAddress != null)
			{
				Session["disFilter"] = displayFilter;
				_displayFilter = displayFilter;
			}
			else
			{
				if (_displayFilter == null && (DisplayFilter)Session["disFilter"] == null)
				{
					_displayFilter = (new DisplayFilter()).GetDefault();
				}
				else
				{
					_displayFilter = (DisplayFilter)Session["disFilter"];
				}
			}
			if (cleanFilter == "true")
			{
				_displayFilter = (new DisplayFilter()).GetDefault();
			}

			if (displayFilter.AuthorFirstName == null && displayFilter.AuthorLastName == null && displayFilter.DepartureAddress == null && displayFilter.DestinationAddress == null)
			{
				_displayFilter = (new DisplayFilter()).GetDefault();
			}


			var model = new RequestIndexViewModel();

			var requestsList = _requestService.GetRequest(_displayFilter).OrderByDescending(x => x.Id);

			int pageSize = 5;
			int pageNumber = (page ?? 1);

			model.Requests = requestsList.ToPagedList(pageNumber, pageSize);

			return PartialView(model);
		}

		[Authorize(Roles = "Администратор")]
		[HttpGet]
		public ActionResult LogIndex(LogFilter logFilter, string cleanFilter, int? page)
		{

			if (logFilter.CreatorFirstName != null || logFilter.CreatorLastName != null || logFilter.CreationDate != DateTime.MinValue)
			{
				Session["logFilter"] = logFilter;
				_logFilter = logFilter;
			}
			else
			{
				if (_logFilter == null && (LogFilter)Session["logFilter"] == null)
				{
					_logFilter = (new LogFilter()).GetDefault();
				}
				else
				{
					_logFilter = (LogFilter)Session["LogFilter"];
				}
			}
			if (cleanFilter == "true")
			{
				_logFilter = (new LogFilter()).GetDefault();
			}

			if (logFilter.CreatorFirstName == null && logFilter.CreatorLastName == null && logFilter.CreationDate == DateTime.MinValue)
			{
				_logFilter = (new LogFilter()).GetDefault();
			}



			int pageSize = 2;
			int pageNumber = (page ?? 1);

			var model = _logService.GetAllByFilter(_logFilter).OrderByDescending(x => x.CreationDataTime).ToPagedList(pageNumber, pageSize);
			return View(model);
		}

		#endregion
	}
}

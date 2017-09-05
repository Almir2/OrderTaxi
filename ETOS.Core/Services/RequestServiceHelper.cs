using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNet.Identity;

using ETOS.Core.DTO;
using ETOS.Core.Services.Abstract;
using ETOS.DAL.Entities;
using ETOS.DAL.Enums;
using ETOS.DAL.Interfaces;

namespace ETOS.Core.Services
{
	/// <summary>
	/// Класс обеспечивает вспомогательные функции для сервиса
	/// </summary>
	public class RequestServiceHelper : IRequestServiceHelper
	{
		private readonly IRequestRepository _requestRepository;
		private readonly ILocationRepository _locationRepository;
		private readonly IEmployeeRepository _employeeRepository;
				
		/// <summary>
		/// Необходимый набор компонентов.
		/// </summary>
		private IUnitOfWork _toolset { get; }

		/// <summary>
		/// Конструктор вспомогательного сервиса
		/// </summary>
		public RequestServiceHelper(IRequestRepository requestRep, ILocationRepository locationRep, IEmployeeRepository empRep, IUnitOfWork toolset)
		{
			_requestRepository = requestRep;
			_locationRepository = locationRep;
			_employeeRepository = empRep;			
			_toolset = toolset;
		}

		/// <summary>
		/// Маппинг DtoCreateRequestcs в Request
		/// установка значений по умолчанию статус, стоимость и километраж поездки
		/// TODO правильно ли устанавливать значения статуса стоимости и колометража в маппинге?
		/// </summary>
		/// <param name="item">объект класса DtoCreateRequestcs</param>
		/// <param name="newRequest">результирующий объект класса Request</param>
		/// <param name="errorMsg">текст ошибки</param>
		/// <returns>результат - удалось ли сделать маппинг</returns>
		public bool MapDtoCreateRequestToRequest(DtoCreateRequest item, out Request newRequest, out string errorMsg)
		{
			errorMsg = "";
			newRequest = new Request();

			var account = _toolset.UserManager.FindByEmail(item.AuthorLogin);

			/////Выставляем автора заявки и его Id, ищем его по account  Employee
			//var account = _accountRepository.Find(a => a.Username == item.AuthorLogin).FirstOrDefault();
			if (account == null)
			{
				errorMsg = "Пользователь с логином " + item.AuthorLogin + "не найден";
				return false;
			}

			else
			{
				var author = _employeeRepository
					.Find(e => e.UserId == account.Id)
					.FirstOrDefault();

				newRequest.EmployeeId = author.Id;
			}

			//Багаж
			newRequest.HasBaggage = item.HasBaggage;


			//Выставляем статус в зависимости от адресов что ввел пользователь
			// Если адрес из списка то Заявка на этапе подбора автомобиля - VehicleSelection 
			// иначе - На согласовании - OnApproval

			if (item.DepartureAddress != null || item.DestinationAddress != null)
			{
				newRequest.StatusId = (int)Statuses.OnApproval;
			}
			else
			{
				newRequest.StatusId = (int)Statuses.VehicleSelection;
			}

			//Устанавливает адреса куда откуда
			if (item.DestinationAddress != null)
			{
				newRequest.DestinationAddress = item.DestinationAddress;
			}
			else
			{
				//TODO w нужно проверить есть ли такой Id в БД 
				newRequest.DestinationPointId = item.DestinationPointId;
			}

			if (item.DepartureAddress != null)
			{
				newRequest.DepartureAddress = item.DepartureAddress;
			}
			else
			{
				//TODO возможно нужно проверить есть ли такой Id в БД
				newRequest.DeparturePointId = item.DeparturePointId;
			}

			//Коммент
			newRequest.Comment = item.Comment;

			newRequest.Mileage = item.Mileage;
			newRequest.Price = 0;

			newRequest.DepartureDateTime = item.DepartureDateTime;

			newRequest.CreationDateTime = DateTime.Now;

			return true;
		}

		/// <summary>
		/// Маппит Request в DtoRequest
		/// </summary>
		/// <param name="request">переменная типа Request</param>
		/// <param name="dtoRequest">переменная типа DtoRequest </param>      
		/// <returns>результат маппинга</returns>
		public bool MapRequestToDtoRequest(Request request, out DtoRequest dtoRequest)
		{

			dtoRequest = new DtoRequest()
			{
				Id = request.Id,
				EmployeeId = request.EmployeeId,
				AuthorFirstName = request.Employee.Firstname,
				AuthorLastName = request.Employee.Lastname,
				DeparturePointId = request.DeparturePointId,
				DeparturePointName = (request.DeparturePoint == null) ? request.DepartureAddress : request.DeparturePoint.Name,
				DepartureAddress = request.DepartureAddress,
				DestinationPointId = request.DestinationPointId,
				DestinationPointName = (request.DestinationPoint == null) ? request.DestinationAddress : request.DestinationPoint.Name,
				DestinationAddress = request.DestinationAddress,
				DepartureDateTime = request.DepartureDateTime,
				CreationDateTime = request.CreationDateTime,
				HasBaggage = request.HasBaggage,
				Comment = request.Comment,
				Mileage = request.Mileage,
				Price = request.Price,
				StatusId = request.StatusId,
				StatusName = request.Status.Viewname
			};
			try
			{
				if (dtoRequest == null) return false;
			}

			catch (Exception)
			{
				return false;
			}
			return true;
		}
		public bool MapIEnumRequestToIEnumDtoRequest(IEnumerable<Request> request, out List<DtoRequest> dtoRequest)
		{

			dtoRequest = request.Select(x => new DtoRequest
			{
				Id = x.Id,
				EmployeeId = x.EmployeeId,
				AuthorFirstName = x.Employee.Firstname,
				AuthorLastName = x.Employee.Lastname,
				DeparturePointId = x.DeparturePointId,
				DeparturePointName = (x.DeparturePoint == null) ? x.DepartureAddress : x.DeparturePoint.Name,
				DepartureAddress = x.DepartureAddress,
				DestinationPointId = x.DestinationPointId,
				DestinationPointName = (x.DestinationPoint == null) ? x.DestinationAddress : x.DestinationPoint.Name,
				DestinationAddress = x.DestinationAddress,
				DepartureDateTime = x.DepartureDateTime,
				CreationDateTime = x.CreationDateTime,
				HasBaggage = x.HasBaggage,
				Comment = x.Comment,
				Mileage = x.Mileage,
				Price = x.Price,
				StatusId = x.StatusId,
				StatusName = x.Status.Viewname
			}).ToList();
			try
			{
				if (dtoRequest == null) return false;
			}

			catch (Exception)
			{
				return false;
			}
			return true;
		}
	}
}

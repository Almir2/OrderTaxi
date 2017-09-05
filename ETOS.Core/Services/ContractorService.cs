using System.Collections.Generic;
using System.Linq;

using ETOS.Core.DTO;
using ETOS.Core.Services.Abstract;
using ETOS.DAL.Entities;
using ETOS.DAL.Enums;
using ETOS.DAL.Interfaces;

namespace ETOS.Core.Services
{
	/// <summary>
	/// Сервис, реализующий функционал для работы с учетными данными пользователей системы на уровне бизнес-логики.
	/// </summary>
	public class ContractorService : IContractorService
	{
		#region Fields

		private readonly IContractorRepository _contractorRepository;
		private readonly ILocationRepository _locationRepository;
		private readonly IRequestRepository _requestRepository;

		#endregion

		#region Constructor

		public ContractorService(IContractorRepository contractorRepository, ILocationRepository locationRepository, IRequestRepository requestRepository)
		{
			_contractorRepository = contractorRepository;
			_locationRepository = locationRepository;
			_requestRepository = requestRepository;
		}

		/// <summary>
		/// Возвращает всех подрядчиков
		/// </summary>        
		/// <returns></returns>
		public List<DtoContractorInfo> GetAllContractors()
		{
			var result = new List<DtoContractorInfo>();
			//var contractorIdsList = _locationsMaintenanceRepository.Find(c => c.ContractorId > 0).ToList();

			var contractorIdsList = _contractorRepository.All().ToList();

			if (contractorIdsList == null) return null;

			foreach (var typ in contractorIdsList)
			{
				////находим подрядчика
				//var top = _contractorRepository.Find(c => c.Id == typ.ContractorId).FirstOrDefault();
				//if (top == null) continue;

				////добавляем информацию о нем в список подрядчиков для локации
				result.Add(new DtoContractorInfo
				{
					Id = typ.Id,
					Name = typ.Name,
					Phone = typ.Phone,
					Tariff = typ.Tariff
				});
			}

			return result;
		}

		#endregion

		#region Methods

		public bool SetContractorForRequest(out string error, int contractorId, int requestId, string comment)
		{
			error = "";

			var request = _requestRepository.GetById(requestId);
			var contractor = _contractorRepository.GetById(contractorId);

			if (request == null)
			{
				error = "Ошибка: Заявка не найдена";
				return false;
			}

			if (contractor == null)
			{
				error = "Ошибка: Подрядчик не найден";
				return false;
			}


			request.StatusId = (int)Statuses.WasAccepted;
			request.Price = contractor.Tariff * (decimal) request.Mileage;
			request.Comment = comment;

			_requestRepository.Update(request);

			return true;
		}

		/// <summary>
		/// Реализует получение списка всех имеющихся подрядчиков.
		/// </summary>
		public IEnumerable<DtoContractor> GetContractorsList()
		{
			var contractorsList = _contractorRepository.All()
				.Select(x => new DtoContractor
				{
					Id = x.Id,
					Name = x.Name,
					Phone = x.Phone,
					Tariff = x.Tariff
				});

			return contractorsList;
		}

		/// <summary>
		/// Реализует сохранение подрядчика.
		/// Добавляет подрядчика, если он отсутствует, или обновляет данные, если подрядчик уже существует.
		/// </summary>
		public void SaveContractor(DtoContractor contractorDto)
		{
			var contractor = new Contractor
			{
				Id = contractorDto.Id,
				Name = contractorDto.Name,
				Phone = contractorDto.Phone,
				Tariff = contractorDto.Tariff
			};

			if (contractor.Id == 0)
			{
				_contractorRepository.Add(contractor);
			}
			else
			{
				_contractorRepository.Update(contractor);
			}
		}

		/// <summary>
		/// Реализует получение данных подрядчика с заданным значением идентификатора.
		/// </summary>
		public DtoContractor GetContractor(int id)
		{
			var contractor = _contractorRepository.GetById(id);

			if (contractor != null)
			{
				var contractorDto = new DtoContractor
				{
					Id = contractor.Id,
					Name = contractor.Name,
					Phone = contractor.Phone,
					Tariff = contractor.Tariff
				};

				return contractorDto;
			}
			else
			{
				return null;
			}
		}

		/// <summary>
		/// Реализует удаление подрядчика с заданным значением идентификатора.
		/// </summary>
		public void RemoveContractor(int id)
		{
			_contractorRepository.Delete(id);
		}

		#endregion
	}
}

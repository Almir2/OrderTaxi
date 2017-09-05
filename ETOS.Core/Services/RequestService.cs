using System;
using System.Collections.Generic;

using ETOS.Common;
using ETOS.Core.DTO;
using ETOS.Core.Services.Abstract;
using ETOS.DAL.Entities;
using ETOS.DAL.Interfaces;

namespace ETOS.Core.Services
{
	/// <summary>
	/// Сервис, реализующий функционал для работы с заявками пользователей системы на уровне бизнес-логики.
	/// </summary>
	public class RequestService : IRequestService
    {
        #region Fields 

        private readonly IRequestRepository _requestRepository;
        private readonly IEmployeeRepository _employeeRepository;
        private readonly IRequestServiceHelper _requestServiceHelper;

        #endregion

        #region Constructor

        /// <summary>
        /// Конструктор сервиса по работе с заявками
        /// </summary>
        public RequestService(IRequestRepository requestRep, IEmployeeRepository empRep, IRequestServiceHelper reqServiceHelper)
        {
            _requestRepository = requestRep;
            _employeeRepository = empRep;
            _requestServiceHelper = reqServiceHelper;
        }

        #endregion

        #region Methods

        /// <summary>
        /// Метод,реализующий получение списка заявок с учётом фильтрации.
        /// </summary>
        /// <param name="filter">Условие фильтрования.</param>
        public IEnumerable<DtoRequest> GetRequest(DisplayFilter filter)
        {
            var filterList = _requestRepository.GetRequestsApplyFilter(filter);

            var outList = new List<DtoRequest>();

            if (!_requestServiceHelper.MapIEnumRequestToIEnumDtoRequest(filterList, out outList)) return null;

            return outList;
        }

        /// <summary>
        /// Метод отрабатывает вызов реализации добавления заявки через репозиторий
        /// </summary>
        /// <param name="item"></param>
        public bool AddRequest(DtoCreateRequest item, out string errorMsg)
        {
            errorMsg = "";
            var newRequest = new Request();

            //Маппим и устанавливаем статус
            if (!_requestServiceHelper.MapDtoCreateRequestToRequest(item, out newRequest, out errorMsg)) return false;

            //добавляем заявку
            try
            {
                _requestRepository.Add(newRequest);

                return true;
            }
            catch (Exception)
            {
                errorMsg = "Ошибка добавления заявки";
                return false;
            }
        }

        /// <summary>
        /// Метод отрабатывает вызов реализации удаления заявки через репозиторий
        /// </summary>
        /// <param name="item"></param>
        public void DeleteRequest(DtoRequest item)
        {
            _requestRepository.Delete(item.Id);
        }

        /// <summary>
        /// Изменяет статус и комментарий заданной заявки 
        /// </summary>
        /// <param name="item"></param>
        public void UpdateRequestStatus(int id, int statusId, string comment)
        {
            var req = _requestRepository.GetById(id);

            if (req == null) return;

            req.StatusId = statusId;
            req.Comment = comment;

            _requestRepository.Update(req);
        }

        /// <summary>
        /// Возвращает заявку с заданным id
        /// </summary>
        /// <param name="id">id заявки</param>
        /// <returns>DTO заявки</returns>
        public bool GetRequestById(int id, out DtoRequest outrequest, out string error)
        {
            outrequest = new DtoRequest();
            error = "";

            //Получаем заявку по ID из БД
            var request = _requestRepository.GetById(id);

            if (request == null)
            {
                error = "Данной заявки не существует";
                return false;
            }

            //маппим в Dto
            if (!_requestServiceHelper.MapRequestToDtoRequest(request, out outrequest))
            {
                error = "Ошибка данных заявки";
                return false;
            }

            return true;
        }

        #endregion
    }
}

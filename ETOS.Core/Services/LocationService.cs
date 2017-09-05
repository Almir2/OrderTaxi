using System.Collections.Generic;
using System.Linq;

using ETOS.Core.DTO;
using ETOS.DAL.Interfaces;

namespace ETOS.Core.Services.Abstract
{
    /// <summary>
    /// Сервис работы с сущностью Локации
    /// </summary>
    public class LocationService : ILocationService
    {
        private readonly ILocationRepository _locationRepository;

        /// <summary>
        /// Конструктор сервиса по работе с локациями
        /// </summary>
        public LocationService(ILocationRepository locationRep)
        {
            _locationRepository = locationRep;
        }

        /// <summary>
        /// Возвращает список точек интереса id name address
        /// </summary>
        public List<DtoPointOfInterest> GetPOIList()
        {		
	    var result = _locationRepository.AllPOI().Select(c => new DtoPointOfInterest  { Id = c.Id, Name = c.Name , Address = c.Address}).ToList();							
            return result;
        }

        /// <summary>
        /// Возвращает PointOfInterest для заданной локации
        /// </summary>
        /// <param name="id">id локации</param>
        /// <returns>PointOfInterest</returns>
        public DtoPointOfInterest GetPOIById(int id)
        {
            var poi = new DtoPointOfInterest();

            var location = _locationRepository.GetById(id);

            if (location == null || !location.IsPOI) return null;

            poi.Id = location.Id;
            poi.Name = location.Name;
			poi.Address = location.Address;

            return poi;
        }

    }
}

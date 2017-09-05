using System.Collections.Generic;
using ETOS.DAL.Entities;

namespace ETOS.DAL.Interfaces
{
    /// <summary>
	/// Описывает функционал, необходимый для работы с экземплярами сущности типа "Локации".
	/// </summary>
    public interface ILocationRepository : IRepository<Location>
	{
        IEnumerable<Location> AllPOI();
    }
}

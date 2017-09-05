using System;

using ETOS.DAL.Entities;

namespace ETOS.DAL.Interfaces
{
	/// <summary>
	/// Описывает функционал, необходимый для работы с экземплярами сущности типа "Подрядчик".
	/// </summary>
	public interface IContractorRepository : IRepository<Contractor> { }
}

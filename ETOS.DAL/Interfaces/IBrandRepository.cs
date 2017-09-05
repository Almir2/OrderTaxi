using System;

using ETOS.DAL.Entities;

namespace ETOS.DAL.Interfaces
{
	/// <summary>
	/// Описывает функционал, необходимый для работы с экземплярами сущности типа "Марка автомобиля".
	/// </summary>
	public interface IBrandRepository : IRepository<Brand> { }
}
